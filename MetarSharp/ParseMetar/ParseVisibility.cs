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
                        if (Groups[5].Success == true)
                        {
                            visibility.HasVisibilityLowestValue = true;

                            if (int.TryParse(Groups[6].Value, out int LowestVisibility))
                            {
                                visibility.LowestVisibility = LowestVisibility;
                            }

                            string LowestVisibilityDirection = Groups[7].Value;
                            string LowestVisibilityDirectionDecoded = null;

                            visibility.LowestVisibilityDirectionRaw = LowestVisibilityDirection;

                            //TODO custom definitions
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
                        else
                        {
                            visibility.HasVisibilityLowestValue = false;
                        }
                    }
                    //Vis in Miles
                }
                //Vis is not measurable (///)
                else
                {
                    visibility.VisibilityRaw = Groups[0].Value;
                    visibility.IsVisibilityMeasurable = false;
                }
            }
            //Vis in miles
            else
            {
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

                    if (Groups[3].Success == true)
                    {
                        visibility.HasVisibilityLowestValue = true;

                        if (int.TryParse(Groups[4].Value, out int LowestVisibility))
                        {
                            visibility.LowestVisibility = LowestVisibility;
                        }

                        string LowestVisibilityDirection = Groups[5].Value;
                        string LowestVisibilityDirectionDecoded = null;

                        visibility.LowestVisibilityDirectionRaw = LowestVisibilityDirection;

                        //TODO custom definitions
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
                    else
                    {
                        visibility.HasVisibilityLowestValue = false;
                    }
                }
            }
            return visibility;
        }
    }
}
