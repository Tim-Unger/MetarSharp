using MetarSharp.Exceptions;
using System.Net;

namespace MetarSharp.Methods.Download
{
    internal class Vatsim
    {
        internal static string Single(string icao)
        {
            if (icao.Length != 4)
            {
                throw new ParseException("Please use a four letter ICAO, for multiple metars, please use FromVatsimMultiple");
            }

            WebClient webClient = new WebClient();
            string raw = webClient.DownloadString($"https://metar.vatsim.net/{icao}");

            if (string.IsNullOrEmpty(raw))
            {
                throw new ParseException();
            }

            return raw;
        }

        internal static List<string> Multiple(string icao)
        {
            if(string.IsNullOrWhiteSpace(icao))
            {
                throw new ParseException("Input is null or empty");
            }

            if (icao.Length > 4)
            {
                throw new ParseException("Maximum ICAO Length can be 4 characters");
            }

            WebClient webClient = new WebClient();
            string raw = webClient.DownloadString($"https://metar.vatsim.net/{icao}");

            //\n\n is just here in case Vatsim does weird stuff with the metars
            return raw.Split(new string[] { "\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
