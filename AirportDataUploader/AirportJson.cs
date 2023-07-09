using AviationSharp;

namespace AirportDataUploader
{
    internal class AirportJson
    {
        public int Airac { get ; set; }
        public DateOnly CreationDate { get; private set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string Source { get; private set; } = "https://ourairports.com/data/";
        public int AirportCount { get; set; }
        public List<Airport> Airports { get; set; }
    }
}
