using MetarSharp.Exceptions;
using MetarSharp.Extensions;

namespace MetarSharp.Records.LowestValue
{
    internal class LowestVisibility
    {
        internal static Metar Get(List<Metar> metars)
        {
            return SortVisibility(metars);
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetValue(metars),
            _ => throw new ParseException()
        };

        private static Visibility GetClass(List<Metar> metars)
        {
            return SortVisibility(metars)
                    .Visibility;
        }

        private static double GetValue(List<Metar> metars)
        {
            return SortVisibility(metars)
                    .Visibility
                    .LowestVisibility ?? throw new ParseException();
        }

        private static Metar SortVisibility(List<Metar> metars)
        {
            return metars
                .Where(x => x.Visibility.IsVisibilityMeasurable)
                .ToList()
                .OrderBy(x => x.Visibility.ReportedVisibility)
                .First();
        }
    }
}
