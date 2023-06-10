namespace MetarSharp.Downloader
{
    public class DownloadMetar
    {
        public static string FromVatsimSingle(string icao) => Vatsim.Single(icao).Result;

        public static List<string> FromVatsimMultiple(string icao) => Vatsim.Multiple(icao).Result;

        public static List<string> FromAviationWeather(string icao) => AviationWeather.Get(icao, null).Result;

        public static List<string> FromAviationWeather(string icao, byte hours) => AviationWeather.Get(icao, hours).Result;
    }

    public static class DownloadExtensions
    {
        public static Metar Parse(this string raw) => ParseMetar.FromString(raw);

        public static List<Metar> Parse(this List<string> raw) => ParseMetar.FromList(raw);

        public static Metar TryParseMetar(this string raw)
        {
            try
            {
                return ParseMetar.FromString(raw);
            }
            catch (Exception e)
            {
                throw new ParseException(e.ToString());
            }
        }

        public static List<Metar> TryParseMetar(this List<string> raw)
        {
            try
            {
                var metars = new List<Metar>();
                Parallel.ForEach(raw, x => metars.Add(ParseMetar.FromString(x)));
                return metars;
            }
            catch (Exception e)
            {
                throw new ParseException(e.ToString());
            }
        }
    }
}
