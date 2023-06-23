namespace MetarSharp.Parser
{
    internal class FromArray
    {
        /// <summary>
        /// This parses the metar from an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar[] Parse(string[] input) => input.ToList().Select(x => FromString.Parse(x)).ToArray();

        /// <summary>
        /// This parses the metar from an array parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar[] ParseParallel(string[] input)
        {
            var metars = new List<Metar>(input.Length);
            Parallel.ForEach(input, x => metars.Add(ParseMetar.FromString(x)));
            return metars.ToArray();
        }
    }
}