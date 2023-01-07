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
            string webData = null;
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = null;
            raw = wc.DownloadData(input);
            webData = Encoding.UTF8.GetString(raw);

            parsed = FromString.Parse(webData);

            return parsed;
        }
    }
}
