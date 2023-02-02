using MetarSharp.Parser;

namespace MetarSharp.Parser
{
    public class ParseToStringList
    {
        internal static List<string> Parse(List<Metar> metars)
        {
            return metars.Select(x => ParseToString.Parse(x)).ToList();
        }
    }
}
