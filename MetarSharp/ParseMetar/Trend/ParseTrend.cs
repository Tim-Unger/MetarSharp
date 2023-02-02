using System.Text.RegularExpressions;
using MetarSharp.Exceptions;

namespace MetarSharp.Parse
{
    public class ParseTrend
    {
        public static List<Trend> ReturnTrend (string raw, Metar metar)
        {
            //\n and single line doesn't work in c# apparently, so MultiLine and $ is used to get the NOSIG at the very end of the metar
            Regex trendRegex = new(@"(NOSIG|BECMG|TEMPO|NSW)(\s((FM|TL|AT)([0-9]{4})))?(.*?)(?=RMK|$|BECMG)", RegexOptions.Multiline);

            MatchCollection trendMatches = trendRegex.Matches(raw);

            if (trendMatches.Count == 0)
            {
                return Enumerable.Empty<Trend>().ToList();
            }

            List<Trend> trends = new List<Trend>();

            foreach (var match in trendMatches.Cast<Match>())
            {
                GroupCollection groups = match.Groups;
                Trend trend = new Trend();

                trend.TrendRaw = groups[0].Value;

                trend.TrendTypeRaw = groups[1].Value;

                (trend.TrendType, trend.TrendTypeDecoded) = groups[1].Value switch
                {
                    "NOSIG" => (TrendType.NoSignificantChange, "No significant change"),
                    "BECMG" => (TrendType.Becoming, "Becoming"),
                    "TEMPO" => (TrendType.Tempo, "Temporary"),
                    "NSW" => (TrendType.NoSignificantWeather, "No significant weather"),
                    _ => throw new ParseException()
                };

                trend.IsTimeRestricted = groups[3].Success;

                if (groups[3].Success)
                {
                    trend.TimeRestrictionRaw = groups[3].Value;

                    trend.TimeRestriction = TryParseWithThrow(groups[5].Value, raw);

                    trend.TimeRestrictionType = groups[4].Value switch
                    {
                        "FM" => TimeRestrictionType.From,
                        "TL" => TimeRestrictionType.Until,
                        "AT" => TimeRestrictionType.At,
                        _ => throw new ParseException()
                    };

                    var reportingTime = metar.ReportingTime.ReportingTimeZulu;

                    var year = reportingTime.Year;
                    var month = reportingTime.Month;
                    var day = reportingTime.Day;
                    int hour = TryParseWithThrow(groups[5].Value[..2], raw);
                    int minute = TryParseWithThrow(groups[5].Value[2..], raw);

                    DateTime timeRestriction = new DateTime(year, month, day, hour, minute, 00);

                    trend.TimeRestrictionDateTime = timeRestriction;
                }

                //Somehow, the capture is also successful if it shouldn't be/if the string is empty
                //that's why the NullOrWhiteSpace Check is here
                if (groups[6].Success && groups[6].Value != "" && !string.IsNullOrWhiteSpace(groups[6].Value))
                {
                    trend.TrendList = GetTrendObjects(match.Value);
                }

                trends.Add(trend);
            }

            return trends;
        }

        private static List<object> GetTrendObjects(string input)
        {
            var result = new List<object>();

            //First, all trend objects are split by this big regex
            Regex trendRegex = new Regex
                (@"(\s[0-9]{4}(?:\s|$))|(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s|((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\s(([0-9]{3})V([0-9]{3})))?|((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))", RegexOptions.Multiline);

            MatchCollection matches = trendRegex.Matches(input);

            //this uses the individual regex on each trend object and checks which one it is
            foreach (var match in matches.Cast<Match>())
            {
                Regex visRegex = new Regex(@"(\s[0-9]{4}(?:\s|$))", RegexOptions.Multiline);
                if (visRegex.IsMatch(match.Value))
                {
                    result.Add(GetVisibility(match.Value));
                }

                Regex weatherRegex = new Regex(@"(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s", RegexOptions.None);
                if (weatherRegex.IsMatch(match.Value))
                {
                    result.Add(GetWeather(match.Value));
                }

                Regex windRegex = new Regex("((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\\s(([0-9]{3})V([0-9]{3})))?");
                if (windRegex.IsMatch(match.Value))
                {
                    result.Add(GetWind(match.Value));
                }

                Regex cloudRegex = new Regex("((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))", RegexOptions.None);
                if (cloudRegex.IsMatch(match.Value))
                {
                    result.Add(GetCloud(match.Value));
                }
            }

            return result;
        }

        private static Visibility GetVisibility(string input)
        {
            return ParseVisibility.ReturnVisibility(input);
        }

        private static Weather GetWeather(string input)
        {
            return ParseWeather.GetWeatherFromTrend(input);
        }

        private static Wind GetWind(string input)
        {
            return ParseWind.ReturnWind(input);
        }

        private static Cloud GetCloud(string input)
        {
            return ParseClouds.ReturnClouds(input).First();
        }

        private static int TryParseWithThrow(string value, string raw)
        {
            return int.TryParse(value, out int converted)
              ? converted
              : throw new ParseException($"Could not convert value {value} {raw} to number");
        }
    }
}
