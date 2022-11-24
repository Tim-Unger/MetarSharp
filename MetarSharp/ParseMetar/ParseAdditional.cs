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

            Regex AdditionalRegex = new Regex(
                "(((RE(MI|BC|PR|DR|BL|SH|TS|FZ|DZ|RA|SN|SG|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|PO|SQ|FC|SS|DS)){1,})|((WS\\s((R([0-9]{1,2}))|(ALL RWY))){1,})|(BLU+|BLU|WHT|GRN|YLO|AMB|RED|BLACK))",
                RegexOptions.None
            );

            MatchCollection AdditionalMatches = AdditionalRegex.Matches(raw);

            StringBuilder SB = new StringBuilder();

            if (AdditionalMatches.Count > 0)
            {
                foreach (Match Match in AdditionalMatches)
                {
                    SB.Append(Match.ToString());

                    GroupCollection Groups = Match.Groups;

                    //Recent Weather
                    if (Groups[2].Success == true)
                    {
                        RecentWeather recent = new RecentWeather();

                        recent.RecentWeatherRaw = Groups[2].Value;

                        recent.RecentWeatherTypeRaw = Groups[4].Value;

                        recent.RecentWeatherDecoded = null; //TODO

                        recentWeather.Add(recent);
                        continue;
                    }

                    //Windshear
                    if (Groups[5].Success == true)
                    {
                        WindShear wind = new WindShear();

                        wind.WindShearRaw = Groups[5].Value;

                        if (Groups[7].Value == "ALL RWY")
                        {
                            wind.IsAllRunways = true;

                            wind.Runway = null;
                            windShear.Add(wind);

                            continue;
                        }

                        //TODO parallel runways
                        
                        wind.IsAllRunways = false;

                        if (int.TryParse(Groups[9].Value, out int Runway))
                        {
                            wind.Runway = Runway;
                        }

                    }
                    //ColorCode
                    else if (Groups[9].Success == true)
                    {
                        //TODO
                    }
                }
            }


            Regex RemarkRegex = new Regex("(RMK\\s(.*$))", RegexOptions.None);
            //TODO

            MatchCollection RemarkMatches = RemarkRegex.Matches(raw);

            additionalInformation.Remarks = RemarkMatches.Count == 1 ? RemarkMatches[0].Groups[2].Value : null;

            additionalInformation.AdditionalInformationRaw = SB.ToString();

            additionalInformation.RecentWeather = recentWeather;
            additionalInformation.WindShear = windShear;

            return additionalInformation;
        }
    }
}
