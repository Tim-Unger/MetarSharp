using MetarSharp.Exceptions;

namespace MetarSharp.Converter.Time
{
    public static class ConvertFromYears
    {
        public static ulong ToMilliseconds(this double value)
        {
            var val = Math.Round(value * 31540000000000, 0);
            var parseUlong = ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToSeconds(this double value)
        {
            var val = Math.Round(value * 31540000000, 0);
            var parseUlong = ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static ulong ToMinutes(this double value)
        {
            var val = Math.Round(value * 525600, 0);
            var parseUlong = ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
            return parseUlong;
        }

        public static decimal ToHours(this double value)
        {
            return Math.Round((decimal)value * 8760, 2);
        }

        public static decimal ToHours(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 8760, decimalPlaces);
        }

        public static decimal ToDays(this double value)
        {
            return Math.Round((decimal)value * 365, 2);
        }

        public static decimal ToDays(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 365, decimalPlaces);
        }

        public static decimal ToWeeks(this double value)
        {
            return Math.Round((decimal)value * (decimal)52.143, 2);
        }

        public static decimal ToWeeks(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)52.143, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value * 12, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 12, decimalPlaces);
        }
    }
}
