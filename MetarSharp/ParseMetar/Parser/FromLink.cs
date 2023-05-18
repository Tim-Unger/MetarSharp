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
        internal static async Task<Metar> Parse(string input) => FromString.Parse(await new HttpClient().GetStringAsync(input));
    }
}
