using static MetarSharp.Parser.Helpers;
namespace MetarSharp.Parser
{
    internal class FromCollection
    {
        internal static IEnumerable<Metar> Parse<T>(T input)
        {
            var inputConvert = input as List<string>;

            var cleanInput = inputConvert.Where(x => IsStringNullOrEmpty(x) == false);

            List<Metar> returnList = cleanInput.Select(MetarSharp.ParseMetar.FromString).ToList();

            return returnList as IEnumerable<Metar>;
        }
    }
}