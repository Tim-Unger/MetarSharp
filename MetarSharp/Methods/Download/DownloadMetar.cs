using MetarSharp.Exceptions;
using System.Net;

namespace MetarSharp.Methods.Download
{
    public class DownloadMetar
    {
        public static string FromVatsimSingle(string icao)
        {
            return Vatsim.Single(icao);
        }

        public static List<string> FromVatsimMultiple(string icao)
        {
            return Vatsim.Multiple(icao);
        }

        public static List<string> FromAviationWeather(string icao)
        {
            return AviationWeather.Get(icao, null);
        }

        public static List<string> FromAviationWeather(string icao, byte hours)
        {
            return AviationWeather.Get(icao, hours);
        }
    }
}
