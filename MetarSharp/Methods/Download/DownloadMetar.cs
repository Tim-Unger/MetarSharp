namespace MetarSharp.Downloader
{
    public class DownloadMetar
    {
        public static string FromVatsimSingle(string icao) => Vatsim.Single(icao).Result;

        public static List<string> FromVatsimMultiple(string icao) => Vatsim.Multiple(icao).Result;

        public static List<string> FromAviationWeather(string icao) => AviationWeather.Get(icao, null).Result;

        public static List<string> FromAviationWeather(string icao, byte hours) => AviationWeather.Get(icao, hours).Result;
    }
}
