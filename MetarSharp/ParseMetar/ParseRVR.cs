using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseRVR
    {
        public static List<RunwayVisibility> ReturnRVR(string raw)
        {
            List<RunwayVisibility> runwayVisibilities = new List<RunwayVisibility>();

            Regex RVRRegex = new Regex(
                "R(([0-9]{2})(L|R|C)?)/(P|M)?([0-9]{4})(?:(V?(P|M)?([0-9]{4})?))(U|D|N)",
                RegexOptions.None
            );

            foreach (Match Match in RVRRegex.Matches(raw).Cast<Match>())
            {
                RunwayVisibility runwayVisibility = new RunwayVisibility();

                runwayVisibility.RunwayVisibilityRaw = Match.ToString();

                GroupCollection Groups = Match.Groups;

                runwayVisibility.Runway = Groups[1].Value;

                runwayVisibility.ParallelRunwayDesignator = Groups[3].Success ? Groups[3].Value : null;

                runwayVisibility.ParallelRunwayDesignatorDecoded = Groups[3].Value switch
                {
                    "L" => "Left",
                    "C" => "Center",
                    "R" => "Right",
                    null => null,
                    _ => null
                };

                runwayVisibility.RunwayVisualRange = int.TryParse(Groups[5].Value, out int _rvr) ? _rvr : 0;

                runwayVisibility.IsRVRValueMoreOrLess = Groups[4].Success ? true : null;

                runwayVisibility.RVRMoreOrLessDecoded = Groups[4].Value switch
                {
                    "M" => "Less",
                    "P" => "More",
                    _ => ""
                };

                string RVRTendencyRaw = null;
                string RVRTendencyDecoded = null;
                switch (Groups[9].Value)
                {
                    case "U":
                        RVRTendencyRaw = "U";
                        RVRTendencyDecoded = "Upward";
                        break;
                    case "N":
                        RVRTendencyRaw = "N";
                        RVRTendencyDecoded = "Stagnant";
                        break;
                    case "D":
                        RVRTendencyRaw = "D";
                        RVRTendencyDecoded = "Downward";
                        break;
                    default:
                        RVRTendencyDecoded = "";
                        RVRTendencyRaw = "";
                        break;
                }
                runwayVisibility.RVRTendencyRaw = RVRTendencyRaw;
                runwayVisibility.RVRTendencyDecoded = RVRTendencyDecoded;

                runwayVisibility.IsRVRVarying = Groups[6].Success ? true : null ;
                runwayVisibility.IsRVRVariationMoreOrLess = Groups[7].Success ? true : null ;

                runwayVisibility.RVRVariationMoreOrLessDecoded = Groups[7].Value switch
                {
                    "M" => "Less",
                    "P" => "More",
                    null => null,
                    _ => ""
                };

                runwayVisibility.RVRVariationValue = int.TryParse(Groups[8].Value, out int _rvrVar) ? _rvrVar : null;

                string RVRVariationTendencyRaw = null;
                string RVRVariationTendencyDecoded = null;
                switch (Groups[9].Value)
                {
                    case "U":
                        RVRTendencyRaw = "U";
                        RVRTendencyDecoded = "Upward";
                        break;
                    case "N":
                        RVRTendencyRaw = "N";
                        RVRTendencyDecoded = "Stagnant";
                        break;
                    case "D":
                        RVRTendencyRaw = "D";
                        RVRTendencyDecoded = "Downward";
                        break;
                    default:
                        RVRTendencyRaw = "";
                        RVRTendencyDecoded = "";
                        break;
                }
                runwayVisibility.RVRVariationTendencyRaw = RVRVariationTendencyRaw;
                runwayVisibility.RVRVariationTendencyDecoded = RVRVariationTendencyDecoded;

                runwayVisibilities.Add(runwayVisibility);
            }

            return runwayVisibilities;
        }
    }
}
