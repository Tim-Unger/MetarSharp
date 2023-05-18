﻿using MetarSharp.Exceptions;
using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestPressure
    {
        internal static Metar GetQNH(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureAsQnh)
                    .First();
        }

        internal static Metar GetINHG(List<Metar> metars)
        {
            return metars.OrderByDescending(x => x.Pressure.PressureAsAltimeter)
                .First();
        }

        internal static dynamic GetQNHReturn(List<Metar> metars, ValueReturnType returnType, bool isQNH) => returnType switch
        {
            ValueReturnType.FullMetar => GetQNH(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => isQNH? GetValueQNH(metars) : GetValueINHG(metars),
        };

        internal static dynamic GetINHGReturn(List<Metar> metars, ValueReturnType returnType, bool isQNH) => returnType switch
        {
            ValueReturnType.FullMetar => GetQNH(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => isQNH ? GetValueQNH(metars) : GetValueINHG(metars),
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
                    .Pressure.PressureAsQnh ?? throw new ParseException();
        }

        private static double GetValueINHG(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure.PressureAsAltimeter ?? throw new ParseException();
        }
    }
}
