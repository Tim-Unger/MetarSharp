namespace AviationSharp.Airports.Reader
{
    public class Region
    {
        public static IcaoRegion Get(string icao)
        {
            if (icao.Length != 4)
            {
                return IcaoRegion.Unknown;
            }

            var index = AirportRegion.RegionLetters.IndexOf(icao.ToCharArray()[0]);

            if (index > 23 || index < 0)
            {
                return IcaoRegion.Unknown;
            }

            return (IcaoRegion)index;
        }
    }
}
