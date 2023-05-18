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
        internal static IEnumerable<Metar> Parse(IEnumerable<string> input)
        {
            input = input.Where(x => IsStringNullOrEmpty(x) == false);

            return input.Select(ParseMetar.FromString).ToList();
        }
    }
}