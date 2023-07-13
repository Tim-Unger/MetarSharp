namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static List<Airport> FromName(string name) =>
            GetAllAirports()
                .Where(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
    }
}
