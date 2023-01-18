using MetarSharp.Exceptions;

namespace MetarSharp.Methods.Convert.Time
{
    public static class ConvertFromWeeks
    {
        public static ulong ToMilliseconds(this double value)
        {
            var val = Math.Round(value * 604800000000, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToSeconds(this double value)
        {
            var val = Math.Round(value * 604800, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToMinutes(this double value)
        {
            var val = Math.Round(value * 10080, 0);
            ulong parseUlong = ulong.TryParse(val.ToString(), out ulong output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static decimal ToHours(this double value)
        {
            return Math.Round((decimal)value * 168, 2);
        }

        public static decimal ToHours(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 168, decimalPlaces);
        }

        public static decimal ToDays(this double value)
        {
            return Math.Round((decimal)value * 7, 2);
        }

        public static decimal ToDays(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 7, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value / (decimal)4.345, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)4.345, decimalPlaces);
        }

        public static decimal ToYears(this double value)
        {
            return Math.Round((decimal)value / (decimal)52.143, 2);
        }

        public static decimal ToYears(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)52.143, decimalPlaces);
        }
    }
}
