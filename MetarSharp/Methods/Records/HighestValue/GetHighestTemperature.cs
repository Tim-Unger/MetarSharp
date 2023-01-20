using MetarSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestTemperature
    {
        internal static Metar Get(List<Metar> metars)
        {
            return SortTemperatures(metars);
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType, bool isCelsius) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => isCelsius ? GetValueCelsius(metars) : GetValueFahrenheit(metars),
        };

        private static Temperature GetClass(List<Metar> metars)
        {
            return SortTemperatures(metars)
                .Temperature;
        }

        private static double GetValueCelsius(List<Metar> metars)
        {
            return SortTemperatures(metars)
               .Temperature
               .TemperatureCelsius;
        }

        private static double GetValueFahrenheit(List<Metar> metars)
        {
            return SortTemperatures(metars)
               .Temperature
               .TemperatureFahrenheit;
        }

        private static Metar SortTemperatures(List<Metar> metars)
        {
            return metars
                .Where(x => x.Temperature.IsTemperatureMeasurable)
                .ToList()
                .OrderByDescending(x => (double)x.Temperature.TemperatureCelsius)
                .First();
        }
    }
}
