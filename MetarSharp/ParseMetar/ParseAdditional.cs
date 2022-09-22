using System;
using System.Collections.Generic;
using System.Linq;
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
                    }
                    //Windshear
                    else if (Groups[5].Success == true)
                    {
                        WindShear wind = new WindShear();

                        wind.WindShearRaw = Groups[5].Value;

                        if (Groups[7].Value == "ALL RWY")
                        {
                            wind.IsAllRunways = true;

                            wind.Runway = null;
                        }
                        //TODO parallel runways
                        else
                        {
                            wind.IsAllRunways = false;

                            if (int.TryParse(Groups[9].Value, out int Runway))
                            {
                                wind.Runway = Runway;
                            }
                        }

                        windShear.Add(wind);
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

            if(RemarkMatches.Count == 1)
            {
                GroupCollection Groups = RemarkMatches[0].Groups;

                additionalInformation.Remarks = Groups[2].Value;
            }
            else
            {
                additionalInformation.Remarks = null;
            }

            additionalInformation.AdditionalInformationRaw = SB.ToString();

            additionalInformation.RecentWeather = recentWeather;
            additionalInformation.WindShear = windShear;

            return additionalInformation;
        }
    }
}
