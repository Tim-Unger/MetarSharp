using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Convert.Pressure
{
    public static class ConvertFromInchesMercury
    {
        public static decimal ToHectopascals(this double value)
        {
            return Math.Round((decimal)value * (decimal)33.86388666666671, 2);
        }
        public static decimal ToHectopascals(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)33.86388666666671, decimalPlaces);
        }
    }
}
