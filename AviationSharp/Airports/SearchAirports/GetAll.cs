namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static List<Airport> GetAllAirports() => Reader.Airports.Read();
    }

    public partial class SearchRunways
    {
        public static List<Runway> GetRunways() => Reader.Airports.Read().SelectMany(x => x.Runways).ToList();
    }
}
