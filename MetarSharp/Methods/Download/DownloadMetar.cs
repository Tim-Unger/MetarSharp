namespace MetarSharp.Downloader
{
    public class DownloadMetar
    {
        public static string FromVatsimSingle(string icao) => Vatsim.Single(icao).Result;

        public static List<string> FromVatsimMultiple(string icao) => Vatsim.Multiple(icao);

        public static List<string> FromVatsimMultipleIcaos(params string[] icaos) => Vatsim.MultipleIcaos(icaos);

        public static List<string> FromAviationWeather(string icao) => AviationWeather.Get(icao, null);

        public static List<string> FromAviationWeather(string icao, int hours) => AviationWeather.Get(icao, hours);
    }
}