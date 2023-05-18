using MetarSharp.Parser;

namespace MetarSharp.Parser
{
    public class ParseToStringList
    {
        internal static List<string> Parse(List<Metar> metars) => metars.Select(x => ParseToString.Parse(x)).ToList();
    }
}
