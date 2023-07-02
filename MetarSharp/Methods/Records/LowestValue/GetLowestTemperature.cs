namespace MetarSharp.Records.LowestValue
{
    internal class LowestTemperature
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
            _ => throw new ArgumentOutOfRangeException(nameof(returnType)),
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
                .OrderBy(x => x.Temperature.TemperatureCelsius)
                .First();
        }
    }
}
