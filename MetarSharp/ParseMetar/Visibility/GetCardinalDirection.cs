namespace MetarSharp.Parse
{
    internal class GetCardinalDirection
    {
        internal static (CardinalDirection, string) Get(string raw) =>
            raw switch
            {
                "N" => (CardinalDirection.North, CardinalDirectionDefinitions.NorthLong),
                "NE" => (CardinalDirection.NorthEast, CardinalDirectionDefinitions.NorthEastLong),
                "E" => (CardinalDirection.East, CardinalDirectionDefinitions.EastLong),
                "SE" => (CardinalDirection.SouthEast, CardinalDirectionDefinitions.SouthEastLong),
                "S" => (CardinalDirection.South, CardinalDirectionDefinitions.SouthLong),
                "SW" => (CardinalDirection.SouthWest, CardinalDirectionDefinitions.SouthWestLong),
                "W" => (CardinalDirection.West, CardinalDirectionDefinitions.WestLong),
                "NW" => (CardinalDirection.NorthWest, CardinalDirectionDefinitions.NorthWestLong),
                _ => throw new ParseException("Could not convert cardinal direction")
            };
    }
}
