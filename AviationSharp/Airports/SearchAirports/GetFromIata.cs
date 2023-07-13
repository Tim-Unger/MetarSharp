namespace AviationSharp.Airports
{
    public partial class SearchAirports
    {
        public static Airport FromIata(string iata)
        {
            if (iata.Length != 3)
            {
                throw new InvalidDataException("IATA-Code must be three letters");
            }

            return Reader.Airports.Read().Where(x => x.Iata == iata).First()
                ?? throw new Exception("IATA not found");
        }
    }
}
