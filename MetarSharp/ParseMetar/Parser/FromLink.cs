namespace MetarSharp.Parser
{
    internal class FromLink
    {
        /// <summary>
        /// This downloads the content of a web page and then parses it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar Parse(string input) => FromString.Parse(new HttpClient().GetStringAsync(input).Result);
    }
}
