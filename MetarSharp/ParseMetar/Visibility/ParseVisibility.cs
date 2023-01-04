using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp;

namespace MetarSharp.Parse
{
    public class ParseVisibility
    {
        //TODO
        public static Visibility ReturnVisibility(string raw)
        {
            Regex visibilityRegex = new Regex(
                @"(\s([0-9]{4})\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(\s((([0-9]{1,2})|(M)?([0-9]/[0-9]))(SM|KM))\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s",
                RegexOptions.None
            );

            MatchCollection matches = visibilityRegex.Matches(raw);

            if (matches.Count == 0)
            {
                if (Regex.IsMatch(raw, "\\sAUTO\\s") || Regex.IsMatch(raw, "\\sCAVOK\\s"))
                {
                    return new Visibility();
                }

                throw new Exception("Could not find Visibility");
            }
            
            GroupCollection groups = matches[0].Groups;
            if (groups[2].Success)
            {
                return ParseFromMeter.ParseVisibiltiy(groups);
            }

            if (groups[12].Value == "SM")
            {
                return ParseFromMiles.ParseVisibility(groups);
            }

            if (groups[12].Value == "KM")
            {
                return ParseFromKilometer.ParseVisibility(groups);
            }

            //TODO
            //This also covers the //// case
            return new Visibility { IsVisibilityMeasurable = false };
        }

        private static Visibility GetVisibility(
            VisibilityUnit visibilityType,
            GroupCollection groups
        )
        {
            Visibility visibility = new Visibility();

            visibility.VisibilityRaw =
                visibilityType == VisibilityUnit.Meters ? groups[1].Value : groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            int visibilityTypeInt = visibilityType switch
            {
                VisibilityUnit.Meters => 2,
                VisibilityUnit.Miles => 8,
                _ => throw new Exception("Could not find Visibility Unit")
            };

            bool hasVisibilitySlash = false;
            double convertedValue = 0;
            if (groups[8].Value.Contains('/'))
            {
                int indexNegative = groups[10].Success ? 1 : 0;
                hasVisibilitySlash = true;

                var valueArray = groups[8].Value.ToCharArray();
                double firstValue = double.Parse(valueArray[indexNegative].ToString());
                double lastValue = double.Parse(valueArray.Last().ToString());

                convertedValue = firstValue / lastValue;
            }

            if (groups[10].Success)
            {
                convertedValue *= -1;
            }

            int reportedVisibility = 0;
            if (!hasVisibilitySlash)
            {
                reportedVisibility = int.TryParse(groups[visibilityTypeInt].Value, out int visParse)
                  ? visParse
                  : throw new Exception(
                        $"Could not convert Visibility {groups[visibilityTypeInt].Value} to Number"
                    );
            }

            visibility.ReportedVisibility = hasVisibilitySlash
                ? convertedValue
                : reportedVisibility;

            (visibility.VisibilityUnitRaw, visibility.VisibilityUnitDecoded) = visibilityType switch
            {
                VisibilityUnit.Meters => ("M", "Meters"),
                VisibilityUnit.Miles => ("SM", "Statute Miles"),
                _ => throw new Exception("Could not Convert Visibility Unit")
            };

            (int lowestValueIndex, int directionIndex) = visibilityType switch
            {
                VisibilityUnit.Meters => (4, 5),
                VisibilityUnit.Miles => (12, 13),
                _ => throw new Exception()
            };

            bool hasLowestValue = groups[lowestValueIndex].Success;
            visibility.HasVisibilityLowestValue = hasLowestValue;

            if (!hasLowestValue)
            {
                return visibility;
            }

            #region VISHASLOWESTDIRECTION
            visibility.HasVisibilityLowestValue = true;

            bool hasLowestVisibilitySlash = false;
            double lowestConvertedValue = 0;
            if (groups[8].Value.Contains('/'))
            {
                int indexNegative = groups[10].Success ? 1 : 0;

                hasLowestVisibilitySlash = true;

                var valueArray = groups[8].Value.ToCharArray();
                double firstValue = double.Parse(valueArray[indexNegative].ToString());
                double lastValue = double.Parse(valueArray.Last().ToString());

                lowestConvertedValue = firstValue / lastValue;
            }

            int lowestVisibilityInt = 0;
            if (!hasLowestVisibilitySlash)
            {
                lowestVisibilityInt = int.TryParse(
                    groups[lowestValueIndex].Value,
                    out int lowestVal
                )
                  ? lowestVal
                  : throw new Exception(
                        $"Could not convert Lowest Visibility Value {groups[lowestValueIndex].Value} to number"
                    );
            }

            visibility.LowestVisibility = hasLowestVisibilitySlash ? lowestConvertedValue : lowestVisibilityInt;

            string lowestDirectionRaw = groups[directionIndex].Value;

            visibility.LowestVisibilityDirectionRaw = lowestDirectionRaw;
            visibility.LowestVisibilityDirectionDecoded = CardinalDirection(lowestDirectionRaw);

            return visibility;
            #endregion
        }

        internal static (CardinalDirection, string) GetCardinalDirection(string raw) =>
            raw switch
            {
                "N" => (CardinalDirection.North, "North"),
                "NE" => (CardinalDirection.NorthEast, "North-East"),
                "E" => (CardinalDirection.East, "East"),
                "SE" => (CardinalDirection.SouthEast, "South-East"),
                "S" => (CardinalDirection.South, "South"),
                "SW" => (CardinalDirection.SouthWest, "South-West"),
                "W" => (CardinalDirection.West, "West"),
                "NW" => (CardinalDirection.NorthWest, "North-West"),
                _ => throw new Exception("Could not convert cardinal direction")
            };
    }
}
