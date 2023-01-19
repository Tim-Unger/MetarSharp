using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Parser
{
    internal class FromLink
    {
        internal static Metar Parse(string input)
        {
            Metar parsed = new Metar();

            System.Net.WebClient wc = new();
            string raw = wc.DownloadString(input);

            parsed = FromString.Parse(raw);

            return parsed;
        }
    }
}
