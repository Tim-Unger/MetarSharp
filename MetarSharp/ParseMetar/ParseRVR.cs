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

            foreach (Match Match in RVRRegex.Matches(raw))
            {
                RunwayVisibility runwayVisibility = new RunwayVisibility();

                runwayVisibility.RunwayVisibilityRaw = Match.ToString();

                GroupCollection Groups = Match.Groups;

                runwayVisibility.Runway = Groups[1].Value;
                if (Groups[3].Success == true)
                {
                    runwayVisibility.ParallelRunwayDesignator = Groups[3].Value;

                    string RunwayDesignatorDecoded = null;
                    switch (Groups[3].Value)
                    {
                        case "L":
                            RunwayDesignatorDecoded = "Left";
                            break;
                        case "C":
                            RunwayDesignatorDecoded = "Center";
                            break;
                        case "R":
                            RunwayDesignatorDecoded = "Right";
                            break;
                    }
                    runwayVisibility.ParallelRunwayDesignatorDecoded = RunwayDesignatorDecoded;

                    if (int.TryParse(Groups[5].Value, out int RVR))
                    {
                        runwayVisibility.RunwayVisualRange = RVR;
                    }

                    if (Groups[4].Success == true)
                    {
                        runwayVisibility.IsRVRValueMoreOrLess = true;

                        string MoreOrLessDecoded = null;
                        switch (Groups[4].Value)
                        {
                            case "M":
                                MoreOrLessDecoded = "Less";
                                break;
                            case "P":
                                MoreOrLessDecoded = "More";
                                break;
                        }
                        runwayVisibility.RVRMoreOrLessDecoded = MoreOrLessDecoded;
                    }

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
                    }
                    runwayVisibility.RVRTendencyRaw = RVRTendencyRaw;
                    runwayVisibility.RVRTendencyDecoded = RVRTendencyDecoded;

                    if (Groups[6].Success == true)
                    {
                        runwayVisibility.IsRVRVarying = true;

                        if (Groups[7].Success == true)
                        {
                            runwayVisibility.IsRVRVariationMoreOrLess = true;
                            string MoreOrLessDecoded = null;

                            switch (Groups[7].Value) 
                            {
                                case "M":
                                    MoreOrLessDecoded = "Less";
                                    break;
                                case "P":
                                    MoreOrLessDecoded = "More";
                                    break;
                            }
                            runwayVisibility.RVRVariationMoreOrLessDecoded = MoreOrLessDecoded;

                            if (int.TryParse(Groups[8].Value, out int RVRVariation))
                            {
                                runwayVisibility.RVRVariationValue = RVRVariation;
                            }

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
                            }
                            runwayVisibility.RVRVariationTendencyRaw = RVRVariationTendencyRaw;
                            runwayVisibility.RVRVariationTendencyDecoded = RVRVariationTendencyDecoded;
                        }
                    }
                }
                runwayVisibilities.Add(runwayVisibility);
            }

            return runwayVisibilities;
        }
    }
}
