using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestVisibility
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
                    .LowestVisibility ?? throw new Exception();
        }

        private static Metar SortVisibility(List<Metar> metars)
        {
            return metars
                .Where(x => x.Visibility.IsVisibilityMeasurable)
                .ToList()
                .OrderByDescending(x => x.Visibility.ReportedVisibility)
                .First();
        }
    }
}
