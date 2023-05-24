using static MetarSharp.Extensions.Helpers;
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
    }
}
