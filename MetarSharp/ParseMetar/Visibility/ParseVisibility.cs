using MetarSharp.Exceptions;
using System.Text.RegularExpressions;
using static MetarSharp.Definitions.CardinalDirectionDefinitions;

namespace MetarSharp.Parse
{
    internal class ParseVisibility
    {
        internal static Visibility ReturnVisibility(string raw)
        {
            var visibilityRegex = new Regex(
                @"(\s([0-9]{4})(?:\s|$)(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(\s((([0-9]{1,2})|(M)?([0-9]/[0-9](?>[0-9])?))(SM|KM))\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s",
                RegexOptions.None
            );

            MatchCollection matches = visibilityRegex.Matches(raw);

            if (matches.Count == 0)
            {
                if (Regex.IsMatch(raw, @"\sAUTO\s") || Regex.IsMatch(raw, @"\sCAVOK\s"))
                {
                    return new Visibility()
                    {
                        IsVisibilityMeasurable = true,
                        ReportedVisibility = 9999,
                        VisibilityRaw = "9999",
                        VisibilityUnitRaw = "M"
                    };
                }

                throw new ParseException("Could not find Visibility");
            }

            GroupCollection groups = matches[0].Groups;
            if (groups[2].Success)
            {
                return ParseFromMeter.ParseVisibility(groups);
            }

            if (groups[12].Value == "SM")
            {
                return ParseFromMiles.ParseVisibility(groups);
            }

            if (groups[12].Value == "KM")
            {
                return ParseFromKilometer.ParseVisibility(groups);
            }

            //This also covers the //// case
            return new Visibility { IsVisibilityMeasurable = false };
        }

        internal static (CardinalDirection, string) GetCardinalDirection(string raw) =>
            raw switch
            {
                "N" => (CardinalDirection.North, NorthLong),
                "NE" => (CardinalDirection.NorthEast, NorthEastLong),
                "E" => (CardinalDirection.East, EastLong),
                "SE" => (CardinalDirection.SouthEast, SouthEastLong),
                "S" => (CardinalDirection.South, SouthLong),
                "SW" => (CardinalDirection.SouthWest, SouthWestLong),
                "W" => (CardinalDirection.West, WestLong),
                "NW" => (CardinalDirection.NorthWest, NorthWestLong),
                _ => throw new ParseException("Could not convert cardinal direction")
            };
    }
}
