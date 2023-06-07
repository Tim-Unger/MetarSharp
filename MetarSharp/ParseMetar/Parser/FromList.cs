namespace MetarSharp.Parser
{
    internal class FromList
    {
        /// <summary>
        /// This parses the input from a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static List<Metar> Parse(List<string> input) => input.Select(x => ParseDirectlyOrDownload(x)).ToList();

        /// <summary>
        /// This parses the input from a list parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static List<Metar> ParseParallel(List<string> input)
        {
            var metars = new List<Metar>(input.Count());

            Parallel.ForEach(input, x => metars.Add(ParseDirectlyOrDownload(x)));

            return metars;
        }

        private static Metar ParseDirectlyOrDownload(string input) => input.StartsWith("http") ? FromLink.Parse(input) : FromString.Parse(input);
    }
}
