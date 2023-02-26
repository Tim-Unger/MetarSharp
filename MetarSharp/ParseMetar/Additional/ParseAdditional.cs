using MetarSharp.Parse.Additional;
using System.Text;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    public class ParseAdditional
    {
        /// <summary>
        /// this returns the additional information part of the metar
        /// this part is optional, so if the regex doesn't match, an empty class will be returned
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static AdditionalInformation ReturnAdditional(string raw)
        {
            AdditionalInformation additionalInformation = new AdditionalInformation();

            List<RecentWeather> recentWeather = new List<RecentWeather>();
            List<WindShear> windShear = new List<WindShear>();

            Regex additionalRegex = new Regex(
                @"(((RE(MI|BC|PR|DR|BL|SH|TS|FZ|DZ|RA|SN|SG|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|PO|SQ|FC|SS|DS)){1,})|(WS\sR([0-9]{1,2}(L|C|R)?))|(WS ALL RWY)|\s(BLU+|BLU|WHT|GRN|YLO|AMB|RED|BLACK))(?>\s|$)",
                RegexOptions.Multiline
            );

            var additionalMatches = additionalRegex.Matches(raw);

            var stringBuilder = new StringBuilder();

            if(additionalMatches.Count == 0)
            {
                return new AdditionalInformation();
            }
            
            foreach (var match in additionalMatches.Cast<Match>())
            {
                stringBuilder.Append(match);

                GroupCollection groups = match.Groups;

                //Recent Weather
                if (groups[2].Success)
                {
                    recentWeather.Add(RecentWeatherParse.Parse(groups));
                    continue;
                }

                //Windshear
                if (groups[5].Success || groups[8].Success)
                {
                    MatchCollection allRunways = Regex.Matches(raw, @"(WS\sR([0-9]{1,2}(L|C|R)?))|(WS ALL RWY)");
                    windShear.Add(WindshearParse.Parse(allRunways));
                    continue;
                }

                //ColorCode
                if (groups[9].Success)
                {
                    //GetColorCode returns the ColorCode enum, the ColorCode in short and in long
                    var colorCodeTuple = Additional.ColorCode.GetColorCode(groups).ToTuple();
                    
                    additionalInformation.ColorCode = new ColorCode
                    {
                        Color = colorCodeTuple.Item1,
                        ColorCodeShort = colorCodeTuple.Item2,
                        ColorCodeLong = colorCodeTuple.Item3
                    };
                }
            }
            


            var remarkRegex = new Regex("(RMK\\s(.*$))", RegexOptions.None);
            //TODO

            MatchCollection remarkMatches = remarkRegex.Matches(raw);

            additionalInformation.Remarks = remarkMatches.Count == 1 ? remarkMatches[0].Groups[2].Value : null;

            additionalInformation.AdditionalInformationRaw = stringBuilder.ToString();

            additionalInformation.RecentWeather = recentWeather;
            additionalInformation.WindShear = windShear;

            return additionalInformation;
        }
    }
}
