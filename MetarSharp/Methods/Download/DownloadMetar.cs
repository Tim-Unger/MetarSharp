namespace MetarSharp.Methods.Download
{
    public class DownloadMetar
    {
        public static string FromVatsimSingle(string icao)
        {
            return Vatsim.Single(icao).Result;
        }

        public static List<string> FromVatsimMultiple(string icao)
        {
            return Vatsim.Multiple(icao).Result;
        }

        public static List<string> FromAviationWeather(string icao)
        {
            return AviationWeather.Get(icao, null).Result;
        }

        public static List<string> FromAviationWeather(string icao, byte hours)
        {
            return AviationWeather.Get(icao, hours).Result;
        }
    }
}
