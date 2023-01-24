using static MetarSharp.Parser.Helpers;
namespace MetarSharp.Parser
{
    internal class FromCollection
    {
        internal static IEnumerable<Metar> Parse(IEnumerable<string> input)
        {
            input = input.Where(x => IsStringNullOrEmpty(x) == false);

            List<Metar> returnList = input.Select(MetarSharp.ParseMetar.FromString).ToList();

            return returnList;
        }
    }
}