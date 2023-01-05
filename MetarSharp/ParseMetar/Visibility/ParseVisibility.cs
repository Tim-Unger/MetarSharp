using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp;
using static MetarSharp.Definitions.CardinalDirectionDefinitions;

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
                _ => throw new Exception("Could not convert cardinal direction")
            };
    }
}
