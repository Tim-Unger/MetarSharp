namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static Airport FromIcao(string icao)
        {
            if (icao.Length != 4)
            {
                throw new InvalidDataException("ICAO-Code must be four letters");
            }

            return Reader.Airports.Read().Where(x => x.Icao == icao).First()
                ?? throw new Exception("ICAO not found");
        }
    }
}
