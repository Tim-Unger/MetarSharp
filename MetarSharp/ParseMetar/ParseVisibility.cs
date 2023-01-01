using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public enum VisibilityType
    {
        Meter,
        Miles
    }

    public class ParseVisibility
    {
        
        public static Visibility ReturnVisibility(string raw)
        {
            Regex visibilityRegex = new Regex(
                @"(\s([0-9]{4})\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(\s(([0-9]{1,2})SM)\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s",
                RegexOptions.None
            );

            MatchCollection matches = visibilityRegex.Matches(raw);

            if (matches.Count == 1)
            {
                //2 9999
                //4,5
                //7 10SM
                // 8 10
                //10 11
                //12 ///
                GroupCollection groups = matches[0].Groups;
                if (groups[2].Success)
                {
                    return GetVisibility(VisibilityType.Meter, groups);
                }

                if (groups[7].Success)
                {
                    return GetVisibility(VisibilityType.Miles, groups);
                }
            }
            //This also covers the //// case
            return new Visibility { IsVisibilityMeasurable = false };
        }

        private static Visibility GetVisibility(
            VisibilityType visibilityType,
            GroupCollection groups
        )
        {
            Visibility visibility = new Visibility();

            visibility.VisibilityRaw = visibilityType == VisibilityType.Meter ? groups[1].Value : groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            int visibilityTypeInt = visibilityType switch
            {
                VisibilityType.Meter => 2,
                VisibilityType.Miles => 8,
                _ => throw new Exception("Could not find Visibility Unit")
            };

            visibility.ReportedVisibility = int.TryParse(
                groups[visibilityTypeInt].Value,
                out int reportedVisibility
            )
              ? reportedVisibility
              : throw new Exception(
                    $"Could not convert Visibility {groups[visibilityTypeInt].Value} to Number"
                );

            (visibility.VisibilityUnitRaw, visibility.VisibilityUnitDecoded) = visibilityType switch
            {
                VisibilityType.Meter => ("M", "Meters"),
                VisibilityType.Miles => ("SM", "Statute Miles"),
                _ => throw new Exception("Could not Convert Visibility Unit")
            };

            (int lowestValueIndex, int directionIndex) = visibilityType switch
            {
                VisibilityType.Meter => (4, 5),
                VisibilityType.Miles => (10, 11),
                _ => throw new Exception()
            };

            bool hasLowestValue = visibility.HasVisibilityLowestValue = groups[
                lowestValueIndex
            ].Success;

            if (hasLowestValue)
            {
                visibility.LowestVisibility = int.TryParse(
                    groups[lowestValueIndex].Value,
                    out int lowestValue
                )
                  ? lowestValue
                  : throw new Exception(
                        "Could not convert Lowest Visibility Value {groups[lowestValueIndex].Value to number"
                    );

                string lowestDirectionRaw = groups[directionIndex].Value;

                visibility.LowestVisibilityDirectionRaw = lowestDirectionRaw;
                visibility.LowestVisibilityDirectionDecoded = CardinalDirection(lowestDirectionRaw);
            }

            return visibility;
        }

        private static string CardinalDirection(string raw) =>
            raw switch
            {
                "N" => "North",
                "NE" => "North-East",
                "E" => "East",
                "SE" => "South-East",
                "S" => "South",
                "SW" => "South-West",
                "W" => "West",
                "NW" => "North-West",
                _ => throw new Exception("Could not convert cardinal direction")
            };
    }
}
