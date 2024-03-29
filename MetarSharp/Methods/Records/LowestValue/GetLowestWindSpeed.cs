﻿namespace MetarSharp.Records.LowestValue
{
    internal class LowestWindSpeed
    {
        internal static Metar Get(List<Metar> metars)
        {
            return SortWind(metars);
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetValue(metars),
            _ => throw new ArgumentOutOfRangeException(nameof(returnType)),
        };

        private static Wind GetClass(List<Metar> metars)
        {
            return SortWind(metars).Wind;
        }

        private static int GetValue(List<Metar> metars)
        {
            return SortWind(metars).Wind.WindStrength ?? throw new ParseException();
        }

        private static Metar SortWind(List<Metar> metars)
        {
            return metars
                .Where(x => x.Wind.IsWindMeasurable && !x.Wind.IsWindCalm)
                .ToList()
                .OrderBy(x => x.Wind.WindStrength)
                .First();
        }
    }
}
