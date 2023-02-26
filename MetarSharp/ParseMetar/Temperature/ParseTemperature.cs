using MetarSharp.Exceptions;
using System.Text.RegularExpressions;
using static MetarSharp.Extensions.Helpers;

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

            temperature.IsTemperatureMeasurable = true;

            temperature.TemperatureRaw = temperatureMatches[0].ToString();

            temperature.IsTemperatureBelowZero = groups[1].Success;

            temperature.IsDewpointBelowZero = groups[3].Success;

            double tempCelsius = DoubleTryParseWithThrow(groups[2].Value);
            double dewpointCelsius = DoubleTryParseWithThrow(groups[4].Value);

            if (groups[1].Success)
            {
                tempCelsius *= -1;
            }

            temperature.TemperatureCelsius = tempCelsius;
            temperature.TemperatureFahrenheit = Math.Round((tempCelsius * 1.8) + 32, 2);

            if (groups[3].Success)
            {
                dewpointCelsius *= -1;
            }

            temperature.DewpointCelsius = dewpointCelsius;
            temperature.DewpointFahrenheit = Math.Round((dewpointCelsius * 1.8) + 32, 2);

            return temperature;
        }
    }
}
