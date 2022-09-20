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
                GroupCollection Groups = TemperatureMatches[0].Groups;

                temperature.TemperatureRaw = TemperatureMatches[0].ToString();

                if (Groups[1].Success == true)
                {
                    temperature.IsTemperatureBelowZero = true;
                }
                else
                {
                    temperature.IsTemperatureBelowZero = false;
                }

                if (Groups[3].Success == true)
                {
                    temperature.IsDewpointBelowZero = true;
                }
                else
                {
                    temperature.IsDewpointBelowZero = false;
                }

                if (int.TryParse(Groups[2].Value, out int Temperature))
                {
                    temperature.TemperatureOnly = Temperature;
                }

                if (int.TryParse(Groups[4].Value, out int Dewpoint))
                {
                    temperature.DewpointOnly = Dewpoint;
                }
            }
            return temperature;
        }
    }
}
