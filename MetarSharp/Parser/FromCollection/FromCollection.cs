namespace MetarSharp.Parser
{
    internal class FromCollection
    {
        /// <summary>
        /// This parses the metar from any Enumerable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //The Collection is cleaned one level up
        internal static IEnumerable<Metar> Parse(IEnumerable<string> input) => input.Select(ParseMetar.FromString).ToList();

        /// <summary>
        /// This parses the metar from any IEnumerable Parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static IEnumerable<Metar> ParseParallel(IEnumerable<string> input)
        {
            var metars = new List<Metar>(input.Count());
            Parallel.ForEach(input, x => metars.Add(ParseMetar.FromString(x)));
            return metars;
        }
    }
}
