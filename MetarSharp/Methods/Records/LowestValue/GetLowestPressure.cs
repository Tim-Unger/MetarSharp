using MetarSharp.Extensions;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.LowestValue
{
    internal class LowestPressure
    {
        internal static Metar Get(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.Pressure.PressureOnly)
                    .First();
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType, bool isQNH) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => isQNH ? GetValueQNH(metars) : GetValueINHG(metars)
        };

        private static Pressure GetClass(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure;
        }

        private static int GetValueQNH(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure.PressureAsQnh ?? throw new Exception();
        }

        private static double GetValueINHG(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.Pressure.PressureOnly)
                    .First()
                    .Pressure.PressureAsAltimeter ?? throw new Exception();
        }
    }
}
