using MetarSharp.Exceptions;
using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestWindStrength
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
        };

        private static Wind GetClass(List<Metar> metars)
        {
            return SortWind(metars)
                    .Wind;
        }

        private static int GetValue(List<Metar> metars)
        {
            return SortWind(metars)
                    .Wind.WindStrength ?? throw new ParseException();
        }

        private static Metar SortWind(List<Metar> metars)
        {
            return metars
                .Where(x => x.Wind.IsWindMeasurable && !x.Wind.IsWindCalm)
                .ToList()
                .OrderByDescending(x => x.Wind.WindStrength)
                .First();
        }
    }
}
