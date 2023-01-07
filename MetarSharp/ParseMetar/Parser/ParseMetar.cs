using MetarSharp.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class ParseMetar
    {
        public static Metar ParseFromString(string metar)
        {
            return FromString.Parse(metar);
        }

        public static Metar ParseFromLink(string link)
        {
            return FromLink.Parse(link);
        }

        public static List<Metar> ParseFromList(List<string> input)
        {
            return FromList.Parse(input);
        }
    }
}
