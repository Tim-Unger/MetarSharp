using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Parse
{
    internal class ParseTrend
    {
        //\n and single line doesn't work for some reason, so MultiLine and $ is used to get the NOSIG at the very end of the metar
        private static readonly Regex _trendRegex = new(@"(NOSIG|BECMG|TEMPO|NSW)(\s((FM|TL|AT)([0-9]{4})))?(.*?)(?=RMK|$|BECMG)", RegexOptions.Multiline);

        internal static List<Trend> ReturnTrend (string raw, Metar metar)
        {
            MatchCollection trendMatches = _trendRegex.Matches(raw);

            if (trendMatches.Count == 0)
            {
                return Enumerable.Empty<Trend>().ToList();
            }

            var trends = new List<Trend>();

            foreach (var match in trendMatches.Cast<Match>())
            {
                GroupCollection groups = match.Groups;
                var trend = new Trend
                {
                    TrendRaw = groups[0].Value,

                    TrendTypeRaw = groups[1].Value
                };

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

                    trend.TimeRestriction = IntTryParseWithThrow(groups[5].Value);

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
                    var hour = IntTryParseWithThrow(groups[5].Value[..2]);
                    var minute = IntTryParseWithThrow(groups[5].Value[2..]);

                    var timeRestriction = new DateTime(year, month, day, hour, minute, 00);

                    trend.TimeRestrictionDateTime = timeRestriction;
                }

                //Somehow, the capture is also successful if it shouldn't be/if the string is empty
                //that's why the NullOrWhiteSpace Check is here
                if (groups[6].Success && groups[6].Value != "" && !string.IsNullOrWhiteSpace(groups[6].Value))
                {
                    trend.TrendList = TrendObjects.Get(match.Value);
                }

                trends.Add(trend);
            }

            return trends;
        }
    }

    public class ParseTrendOnly
    {
        //TODO
        //public static List<Trend> FromString(string raw) => ParseTrend.ReturnTrend(raw);
    }
}
