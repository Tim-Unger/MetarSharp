using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Extensions
{
    public static class FromMeter
    {
        public static decimal ToKilometer(this double value)
        {
            return Math.Round((decimal)value / 1000, 2);
        }

        public static decimal ToKilometer(this int value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 1000, decimalPlaces);
        }

        public static decimal ToStatuteMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.000621371, 2);
        }

        public static decimal ToStatuteMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.000621371, decimalPlaces);
        }

        public static decimal ToNauticalMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.000539957, 2);
        }

        public static decimal ToNauticalMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.000539957, decimalPlaces);
        }
    }
}
