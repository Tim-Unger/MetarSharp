using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    public class ParseAuto
    {
        public static bool ReturnIsAutomated(string raw)
        {
            Regex autoRegex = new Regex("(AUTO)", RegexOptions.None);

            MatchCollection matches = autoRegex.Matches(raw);

            return matches.Count == 1;
        }
    }
}
