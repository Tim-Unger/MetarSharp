﻿namespace MetarSharp.Methods.Convert.Time
{
    public static class ConvertFromSeconds
    {
        public static decimal ToMilliseconds(this double value)
        {
            return Math.Round((decimal)value * 1000, 2);
        }

        public static decimal ToMilliseconds(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 1000, decimalPlaces);
        }
        public static decimal ToMinutes(this double value)
        {
            return Math.Round((decimal)value / 60, 2);
        }

        public static decimal ToMinutes(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 60, decimalPlaces);
        }
        public static decimal ToHours(this double value)
        {
            return Math.Round((decimal)value / 3600, 2);
        }

        public static decimal ToHours(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 3600, decimalPlaces);
        }

        public static decimal ToDays(this double value)
        {
            return Math.Round((decimal)value / 86400, 2);
        }

        public static decimal ToDays(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 86400, decimalPlaces);
        }

        public static decimal ToWeeks(this double value)
        {
            return Math.Round((decimal)value / 604800, 2);
        }

        public static decimal ToWeeks(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 604800, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value / 2628000000, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 2628000000, decimalPlaces);
        }

        public static decimal ToYears(this double value)
        {
            return Math.Round((decimal)value / 31540000000, 2);
        }

        public static decimal ToYears(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 31540000000, decimalPlaces);
        }
    }
}
