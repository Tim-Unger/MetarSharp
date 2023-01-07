using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseAdditional
    {
        public static AdditionalInformation ReturnAdditional(string raw)
        {
            AdditionalInformation additionalInformation = new AdditionalInformation();

            List<RecentWeather> recentWeather = new List<RecentWeather>();
            List<WindShear> windShear = new List<WindShear>();

            Regex additionalRegex = new Regex(
                "(((RE(MI|BC|PR|DR|BL|SH|TS|FZ|DZ|RA|SN|SG|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|PO|SQ|FC|SS|DS)){1,})|((WS\\s((R([0-9]{1,2}))|(ALL RWY))){1,})|(BLU+|BLU|WHT|GRN|YLO|AMB|RED|BLACK))",
                RegexOptions.None
            );

            MatchCollection additionalMatches = additionalRegex.Matches(raw);

            StringBuilder stringBuilder = new StringBuilder();

            if(additionalMatches.Count == 0)
            {
                return new AdditionalInformation();
            }
            
            foreach (Match Match in additionalMatches.Cast<Match>())
            {
                stringBuilder.Append(Match.ToString());

                GroupCollection groups = Match.Groups;

                //Recent Weather
                if (groups[2].Success)
                {
                    recentWeather.Add(RecentWeatherParse.Parse(groups));
                    continue;
                }

                //Windshear
                if (groups[5].Success == true)
                {
                    windShear.Add(WindshearParse.Parse(groups));
                    continue;
                }

                //ColorCode
                if (groups[9].Success == true)
                {
                    //TODO
                }
            }
            


            Regex RemarkRegex = new Regex("(RMK\\s(.*$))", RegexOptions.None);
            //TODO

            MatchCollection RemarkMatches = RemarkRegex.Matches(raw);

            additionalInformation.Remarks = RemarkMatches.Count == 1 ? RemarkMatches[0].Groups[2].Value : null;

            additionalInformation.AdditionalInformationRaw = stringBuilder.ToString();

            additionalInformation.RecentWeather = recentWeather;
            additionalInformation.WindShear = windShear;

            return additionalInformation;
        }
    }
}
