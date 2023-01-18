using MetarSharp.Exceptions;

namespace MetarSharp.Methods.Convert.Time
{
    public static class ConvertFromDays
    {
        public static ulong ToMilliseconds(this double value)
        {
            var val = Math.Round(value * 8640000000, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToSeconds(this double value)
        {
            var val = Math.Round(value * 86400, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToMinutes(this double value)
        {
            var val = Math.Round(value * 1440, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static decimal ToHours(this double value)
        {
            return Math.Round((decimal)value * 24, 2);
        }

        public static decimal ToHours(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 24, decimalPlaces);
        }

        public static decimal ToWeeks(this double value)
        {
            return Math.Round((decimal)value / 7, 2);
        }

        public static decimal ToWeeks(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 7, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value / (decimal)30.417, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)30.417, decimalPlaces);
        }

        public static decimal ToYears(this double value)
        {
            return Math.Round((decimal)value / 365, 2);
        }

        public static decimal ToYears(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 365, decimalPlaces);
        }
    }
}
