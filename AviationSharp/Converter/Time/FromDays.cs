namespace AviationSharp.Converter.Time
{
    public static class ConvertFromDays
    {
        public static ulong ToMilliseconds(this double value)
        {
            var val = Math.Round(value * 8640000000, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static ulong ToSeconds(this double value)
        {
            var val = Math.Round(value * 86400, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static ulong ToMinutes(this double value)
        {
            var val = Math.Round(value * 1440, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static decimal ToHours(this double value) => Math.Round((decimal)value * 24, 2);

        public static decimal ToHours(this double value, int decimalPlaces) => Math.Round((decimal)value * 24, decimalPlaces);

        public static decimal ToWeeks(this double value) => Math.Round((decimal)value / 7, 2);

        public static decimal ToWeeks(this double value, int decimalPlaces) => Math.Round((decimal)value / 7, decimalPlaces);

        public static decimal ToMonths(this double value) => Math.Round((decimal)value / (decimal)30.417, 2);

        public static decimal ToMonths(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)30.417, decimalPlaces);

        public static decimal ToYears(this double value) => Math.Round((decimal)value / 365, 2);

        public static decimal ToYears(this double value, int decimalPlaces) => Math.Round((decimal)value / 365, decimalPlaces);
    }
}
