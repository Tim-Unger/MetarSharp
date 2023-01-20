using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestPressure
    {
        internal static Metar Get(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureOnly)
                    .First();
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType, bool isQNH) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => isQNH? GetValueQNH(metars) : GetValueINHG(metars),
        };

        private static Pressure GetClass(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure;
        }

        private static int GetValueQNH(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure.PressureAsQnh ?? throw new Exception();
        }

        private static double GetValueINHG(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure.PressureAsAltimeter ?? throw new Exception();
        }
    }
}
