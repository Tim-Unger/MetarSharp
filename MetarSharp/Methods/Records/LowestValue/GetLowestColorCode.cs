﻿using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.LowestValue
{
    internal class LowestColorCode
    {
        internal static Metar Get(List<Metar> metars)
        {
            return SortColorCodes(metars);
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetValue(metars),
        };


        private static ColorCode GetClass(List<Metar> metars)
        {
            return SortColorCodes(metars)
                    .AdditionalInformation
                    .ColorCode;
        }

        private static Color GetValue(List<Metar> metars)
        {
            return SortColorCodes(metars)
                    .AdditionalInformation
                    .ColorCode
                    .Color;
        }

        private static Metar SortColorCodes(List<Metar> metars)
        {
            return metars.Where(x => x.AdditionalInformation.ColorCode.Color != Color.NIL)
                 .ToList()
                 .OrderByDescending(x => x.AdditionalInformation.ColorCode.Color)
                 .First();
        }
    }
}