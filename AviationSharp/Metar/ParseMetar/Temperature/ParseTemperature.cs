using AviationSharp.Converter.Temperature;
using static AviationSharp.Metar.Extensions.TryParseExtensions;

namespace AviationSharp.Metar.Parse
{
    internal class ParseTemperature
    {
        private static readonly Regex _temperatureRegex = new(@"(M)?([0-9]{1,2})/(M)?([0-9]{1,2})|\s(/{5})\s");

        internal static Temperature ReturnTemperature(string raw)
        {
            var temperature = new Temperature();

            MatchCollection temperatureMatches = _temperatureRegex.Matches(raw);

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

            var tempCelsius = DoubleTryParseWithThrow(groups[2].Value);
            var dewpointCelsius = DoubleTryParseWithThrow(groups[4].Value);

            //Temperature is negative (e.g. M1)
            if (groups[1].Success)
            {
                tempCelsius *= -1;
            }

            temperature.TemperatureCelsius = tempCelsius;
            temperature.TemperatureFahrenheit = (double)ConvertFromCelsius.ToFahrenheit(tempCelsius);

            //Dewpoint is negative (e.g. M3)
            if (groups[3].Success)
            {
                dewpointCelsius *= -1;
            }

            temperature.DewpointCelsius = dewpointCelsius;
            temperature.DewpointFahrenheit = (double)ConvertFromCelsius.ToFahrenheit(dewpointCelsius);

            return temperature;
        }
    }

    public class ParseTemperatureOnly
    {
        public static Temperature FromString(string raw) => ParseTemperature.ReturnTemperature(raw);
    }
}
