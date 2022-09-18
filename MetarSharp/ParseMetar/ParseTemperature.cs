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

                temperature.IsTemperatureBelowZero =
                    TemperatureMatches[1].Success == true
                        ? temperature.IsTemperatureBelowZero = true
                        : temperature.IsTemperatureBelowZero = false;
                temperature.IsDewpointBelowZero =
                    TemperatureMatches[3].Success == true
                        ? temperature.IsDewpointBelowZero = true
                        : temperature.IsDewpointBelowZero = false;

                if (int.TryParse(TemperatureMatches[2].Value, out int Temperature))
                {
                    temperature.TemperatureOnly = Temperature;
                }

                if (int.TryParse(TemperatureMatches[4].Value, out int Dewpoint))
                {
                    temperature.DewpointOnly = Dewpoint;
                }
            }
            return temperature;
        }
    }
}
