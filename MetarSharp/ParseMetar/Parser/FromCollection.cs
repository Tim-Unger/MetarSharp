namespace MetarSharp.Parser
{
    internal class FromCollection
    {
        internal static IEnumerable<Metar> Parse<T>(T input)
        {
            var inputConvert = input as IEnumerable;

            var cleanInput = inputConvert.Where(x => x != IsStringNullOrEmpty(x));

            List<Metar> returnList = cleanInput.Select(x => ParseMetar.ParseFromString(x)).ToList();

            IEnumerable<Metar> returnEnumerable = returnList;
            return returnEnumerable;
        }
    }
}