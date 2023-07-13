namespace MetarSharp.Parser
{
    public class ParseToStringList
    {
        internal static List<string> Parse(IEnumerable<Metar> metars) => metars.Select(x => ParseToString.Parse(x)).ToList();
    }
}
