using System.Net;

namespace MetarSharp.Parser
{
    internal class FromLink
    {
        /// <summary>
        /// This downloads the content of a web page and then parses it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar Parse(string input)
        {
            Metar parsed = new Metar();

            WebClient webClient = new WebClient();
            string raw = webClient.DownloadString(input);

            parsed = FromString.Parse(raw);

            return parsed;
        }
    }
}
