using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace MetarSharp.Parser
{
    internal class FromArray
    {
        internal static Metar[] Parse(string[] input) => ParseMetar(input, null);

        internal static Metar[] Parse(string[] input, MetarParser parser) => ParseMetar(input, parser);

        /// <summary>
        /// This parses the metar from an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static Metar[] ParseMetar(string[] input, MetarParser? parser) => input.ToList().Select(x => FromString.Parse(x, parser)).ToArray();

        internal static Metar[] ParseParallel(string[] input) => ParseMetarParallel(input, null);

        internal static Metar[] ParseParallel(string[] input, MetarParser parser) => ParseMetarParallel(input, parser);

        /// <summary>
        /// This parses the metar from an array parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar[] ParseMetarParallel(string[] input, MetarParser? parser)
        {
            var metars = new List<Metar>(input.Length);

            var inputReadonly = input.ToImmutableList();
            Parallel.ForEach(inputReadonly, x => metars.Add(FromString.Parse(x, parser)));
            return metars.ToArray();
        }
    }
}