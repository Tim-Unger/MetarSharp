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

    }
}