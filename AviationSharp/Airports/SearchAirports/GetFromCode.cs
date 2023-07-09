namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static Airport FromCode(string airportCode)
        {
            if (airportCode.Length < 3 || airportCode.Length > 4)
            {
                throw new Exception("Airport-Code must be three letters (IATA) or four letters (ICAO)");
            }

            return airportCode.Length == 4 ? FromIcao(airportCode) : FromIata(airportCode);
        }
    }
}
