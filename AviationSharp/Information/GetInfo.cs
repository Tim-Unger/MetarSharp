using System.Reflection;

namespace AviationSharp
{
    public class Information
    {
        public readonly string Version = Assembly.LoadFrom("AviationSharp.dll").GetName().Version!.ToString();

        public readonly string UTCNow = DateTime.UtcNow.ToLongTimeString();

        public readonly int Airac = Airacs.Airacs.GetCurrent().Ident;

        public readonly int AirportCount =
#if DEBUG
            Airports.SearchAirports.GetAllAirports().Count;
#else
            75_606;
#endif
        public readonly int AircraftCount =
#if DEBUG
            Aircraft.Aircraft.GetAll().Count;
#else
            10_438;
#endif

        public readonly string AirportSource = "https://ourairports.com/data/";

        public readonly string AircraftSource = "https://www.icao.int/publications/doc8643/pages/search.aspx";

        public readonly string AiracSource = "https://www.nm.eurocontrol.int/RAD/common/airac_dates.html";

        public static Information Get() => new();
    }
}
