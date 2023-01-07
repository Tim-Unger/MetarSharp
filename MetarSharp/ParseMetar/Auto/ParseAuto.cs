using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
