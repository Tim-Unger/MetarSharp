using System.Collections.Immutable;

namespace MetarSharp.Parser
{
    internal class FromCollection
    {
        internal static IEnumerable<Metar> Parse(IEnumerable<string> input) => ParseMetar(input, null);

        internal static IEnumerable<Metar> Parse(IEnumerable<string> input, MetarParser parser) => ParseMetar(input, parser);

        /// <summary>
        /// This parses the metar from any Enumerable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //The Collection is cleaned one level up
        private static IEnumerable<Metar> ParseMetar(IEnumerable<string> input, MetarParser? parser) => input.Select(FromString.Parse).ToList();


        internal static IEnumerable<Metar> ParseParallel(IEnumerable<string> input) => ParseMetarParallel(input, null);

        internal static IEnumerable<Metar> ParseParallel(IEnumerable<string> input, MetarParser parser) => ParseMetarParallel(input, parser);

        /// <summary>
        /// This parses the metar from any IEnumerable Parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static IEnumerable<Metar> ParseMetarParallel(IEnumerable<string> input, MetarParser? parser)
        {
            var metars = new List<Metar>(input.Count());

            var inputReadonly = input.ToImmutableList();
            Parallel.ForEach(input, x => metars.Add(FromString.Parse(x, parser)));
            return metars;
        }
    }
}
