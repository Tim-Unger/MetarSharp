using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseTemperature
    {
        public static Temperature ReturnTemperature(string raw)
        {
            Temperature temperature = new Temperature();

            Regex TemperatureRegex = new Regex(
                @"(M)?([0-9]{1,2})/(M)?([0-9]{1,2})",
                RegexOptions.None
            );

            MatchCollection TemperatureMatches = TemperatureRegex.Matches(raw);

            if (TemperatureMatches.Count == 1)
            {
                GroupCollection groups = TemperatureMatches[0].Groups;

                temperature.TemperatureRaw = TemperatureMatches[0].ToString();

                temperature.IsTemperatureBelowZero = groups[1].Success;
                
                temperature.IsDewpointBelowZero = groups[3].Success;

                temperature.TemperatureOnly = int.Parse(groups[2].Value);

                temperature.DewpointOnly = int.Parse(groups[4].Value);

            }
            return temperature;
        }
    }
}
