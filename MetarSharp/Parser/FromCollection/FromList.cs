namespace MetarSharp.Parser
{
    internal class FromList
    {

        internal static List<Metar> Parse(IEnumerable<string> input) => ParseMetar(input, null);

        internal static List<Metar> Parse(IEnumerable<string> input, MetarParser parser) => ParseMetar(input, parser);

        /// <summary>
        /// This parses the input from a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<Metar> ParseMetar(IEnumerable<string> input, MetarParser? parser) => input.Select(x => ParseDirectlyOrDownload(x, parser)).ToList();


        internal static List<Metar> ParseParallel(IEnumerable<string> input) => ParseMetarParallel(input, null);

        internal static List<Metar> ParseParallel(IEnumerable<string> input, MetarParser parser) => ParseMetarParallel(input, parser);

        /// <summary>
        /// This parses the input from a list parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<Metar> ParseMetarParallel(IEnumerable<string> input, MetarParser? parser)
        {
            var metars = new List<Metar>();

            Parallel.ForEach(input, x => metars.Add(ParseDirectlyOrDownload(x, parser)));

            return metars;
        }

#pragma warning disable CS8604
        private static Metar ParseDirectlyOrDownload(string input, MetarParser? parser) => input.StartsWith("http") ? FromLink.Parse(input, parser) : FromString.Parse(input, parser);
    }
}
