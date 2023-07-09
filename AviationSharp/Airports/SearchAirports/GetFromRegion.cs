namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static List<Airport> GetFromIcaoRegion(string region)
        {
            if (region.Length != 1)
            {
                throw new Exception("Region-Code length must be one letter");
            }

            var regionChar = char.Parse(region);

            if(!AirportRegion.RegionLetters.Any(x => x == regionChar))
            {
                throw new Exception("Provided Letter is not an ICAO-Region");
            }

            var regionIndex = AirportRegion.RegionLetters.IndexOf(regionChar);

            return Get((IcaoRegion)regionIndex);
        }

        public static List<Airport> GetFromIcaoRegion(char region)
        {
            if (!AirportRegion.RegionLetters.Any(x => x == region))
            {
                throw new Exception("Provided Letter is not an ICAO-Region");
            }

            var regionIndex = AirportRegion.RegionLetters.IndexOf(region);

            return Get((IcaoRegion)regionIndex);
        }

        public static List<Airport> GetFromIcaoRegion(IcaoRegion region) => Get(region);

        private static List<Airport> Get(IcaoRegion region) => Reader.Airports.Read().Where(x => x.IcaoRegion == region).ToList();
    }
}
