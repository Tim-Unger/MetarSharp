using MetarSharp.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestWindSpeed
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
                    .Wind.WindStrength ?? throw new Exception();
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
