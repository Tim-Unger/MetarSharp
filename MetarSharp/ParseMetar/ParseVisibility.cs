using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseVisibility
    {
        public static Visibility ReturnVisibility(string raw)
        {
            Visibility visibility = new Visibility();

            Regex VisibilityRegex = new Regex(
                @"\s([0-9]{4})\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?",
                RegexOptions.None
            );

            MatchCollection VisibilityMatches = VisibilityRegex.Matches(raw);

            //Vis in Meters
            if (VisibilityMatches.Count == 1)
            {
                GroupCollection Groups = VisibilityMatches[0].Groups;
                visibility.VisibilityRaw = Groups[0].Value;

                //Vis is measurable
                if (Groups[4].Success == false)
                {
                    visibility.IsVisibilityMeasurable = true;

                    //Vis in Meters
                    if (Groups[1].Success == true)
                    {
                        visibility.VisibilityUnitRaw = "M";
                        visibility.VisibilityUnitDecoded = "Meters";

                        if (int.TryParse(Groups[1].Value, out int Visibility))
                        {
                            visibility.ReportedVisibility = Visibility;
                        }

                        //Lowest vis-direction is given
                        visibility.HasVisibilityLowestValue = Groups[5].Success;
                        if (Groups[5].Success == true)
                        {
                            visibility.HasVisibilityLowestValue = true;

                            if (int.TryParse(Groups[6].Value, out int LowestVisibility))
                            {
                                visibility.LowestVisibility = LowestVisibility;
                            }

                            string LowestVisibilityDirection = Groups[7].Value;

                            visibility.LowestVisibilityDirectionRaw = LowestVisibilityDirection;

                            visibility.LowestVisibilityDirectionDecoded = CardinalDirection(LowestVisibilityDirection);
                        }
                        else
                        {
                            visibility.HasVisibilityLowestValue = false;
                        }

                        return visibility;
                    }
                    //Vis in Miles
                }
                //Vis is not measurable (///)
                
                visibility.VisibilityRaw = Groups[0].Value;
                visibility.IsVisibilityMeasurable = false;

                return visibility;
            }

            //Vis in miles
            visibility.IsVisibilityMeasurable = true;
            Regex MilesRegex = new Regex(
                @"\s(([0-9]{1,2})SM)\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?",
                RegexOptions.None
            );

            MatchCollection MilesMatches = MilesRegex.Matches(raw);

            //TODO 1/2 miles visibility regex
            if (MilesMatches.Count == 1)
            {
                GroupCollection Groups = MilesMatches[0].Groups;

                visibility.VisibilityRaw = Groups[1].Value;

                visibility.VisibilityUnitRaw = "SM";
                visibility.VisibilityUnitDecoded = "Statute Miles";

                if (int.TryParse(Groups[2].Value, out int Visibility))
                {
                    visibility.ReportedVisibility = Visibility;
                }

                visibility.HasVisibilityLowestValue = Groups[3].Success;
                if (Groups[3].Success == true)
                {

                    if (int.TryParse(Groups[4].Value, out int LowestVisibility))
                    {
                        visibility.LowestVisibility = LowestVisibility;
                    }

                    string LowestVisibilityDirection = Groups[5].Value;
                    string LowestVisibilityDirectionDecoded = null;

                    visibility.LowestVisibilityDirectionRaw = LowestVisibilityDirection;

                    switch (LowestVisibilityDirection)
                    {
                        case "N":
                            LowestVisibilityDirectionDecoded = "North";
                            break;
                        case "NE":
                            LowestVisibilityDirectionDecoded = "North-East";
                            break;
                        case "E":
                            LowestVisibilityDirectionDecoded = "East";
                            break;
                        case "SE":
                            LowestVisibilityDirectionDecoded = "South-East";
                            break;
                        case "S":
                            LowestVisibilityDirectionDecoded = "South";
                            break;
                        case "SW":
                            LowestVisibilityDirectionDecoded = "South-West";
                            break;
                        case "W":
                            LowestVisibilityDirectionDecoded = "West";
                            break;
                        case "NW":
                            LowestVisibilityDirectionDecoded = "North-West";
                            break;
                    }
                    visibility.LowestVisibilityDirectionDecoded =
                        LowestVisibilityDirectionDecoded;
                }
            }
            
            return visibility;
        }

        private static string CardinalDirection(string raw) => raw switch
        {
            "N" => "North",
            "NE" => "North-East",
            "E" => "East",
            "SE" => "South-East",
            "S" => "South",
            "SW" => "South-West",
            "W" => "West",
            "NW" => "North-West",
            _ => ""
        };
    }
}
