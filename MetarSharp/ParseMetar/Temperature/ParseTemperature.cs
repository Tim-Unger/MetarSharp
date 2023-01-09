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

            Regex temperatureRegex = new Regex(
                @"(M)?([0-9]{1,2})/(M)?([0-9]{1,2})|\s(/{5})\s",
                RegexOptions.None
            );

            MatchCollection temperatureMatches = temperatureRegex.Matches(raw);

            if (temperatureMatches.Count == 0)
            {
                temperature.IsTemperatureMeasurable = false;
                return temperature;
            }

            GroupCollection groups = temperatureMatches[0].Groups;

            if (groups[5].Success == true)
            {
                temperature.IsTemperatureMeasurable = false;
                return temperature;
            }
            temperature.TemperatureRaw = temperatureMatches[0].ToString();

            temperature.IsTemperatureBelowZero = groups[1].Success;

            temperature.IsDewpointBelowZero = groups[3].Success;

            temperature.TemperatureOnly = int.TryParse(groups[2].Value, out int temperatureValue)
              ? temperatureValue
              : throw new Exception($"Could not convert temperature {groups[2].Value} to number");

            temperature.DewpointOnly = int.TryParse(groups[4].Value, out int dewpointValue)
              ? dewpointValue
              : throw new Exception($"Could not convert Temperature {groups[2].Value} to number");

            return temperature;
        }
    }
}
