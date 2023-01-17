using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Convert.Distance
{
    public static class FromKilometer
    {
        public static decimal ToMeter(this double value)
        {
            return Math.Round((decimal)value * 1000, 2);
        }

        public static decimal ToMeter(this int value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 1000, decimalPlaces);
        }

        public static decimal ToStatuteMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.621371, 2);
        }

        public static decimal ToStatuteMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.621371, decimalPlaces);
        }

        public static decimal ToNauticalMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.539957, 2);
        }

        public static decimal ToNauticalMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.539957, decimalPlaces);
        }
    }
}
