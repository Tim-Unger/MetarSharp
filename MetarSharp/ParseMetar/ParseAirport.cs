using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp;

namespace MetarSharp.Parse
{
    internal class ParseAirport
    {
        public static string ReturnAirport(string raw)
        {
            Regex AirportRegex = new Regex(@"^([A-Z]{4})\s", RegexOptions.None);

            return "";
        } 
    }
}
