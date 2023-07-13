namespace AviationSharp.Converter.Time
{
    public static class ConvertFromYears
    {
        public static ulong ToMilliseconds(this double value)
        {
            var val = Math.Round(value * 31540000000000, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static ulong ToSeconds(this double value)
        {
            var val = Math.Round(value * 31540000000, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static ulong ToMinutes(this double value)
        {
            var val = Math.Round(value * 525600, 0);
            return ulong.TryParse(val.ToString(), out var output) ? output : throw new ParseException();
        }

        public static decimal ToHours(this double value) => Math.Round((decimal)value * 8760, 2);

        public static decimal ToHours(this double value, int decimalPlaces) => Math.Round((decimal)value * 8760, decimalPlaces);

        public static decimal ToDays(this double value) => Math.Round((decimal)value * 365, 2);

        public static decimal ToDays(this double value, int decimalPlaces) => Math.Round((decimal)value * 365, decimalPlaces);

        public static decimal ToWeeks(this double value) => Math.Round((decimal)value * (decimal)52.143, 2);

        public static decimal ToWeeks(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)52.143, decimalPlaces);

        public static decimal ToMonths(this double value) => Math.Round((decimal)value * 12, 2);

        public static decimal ToMonths(this double value, int decimalPlaces) => Math.Round((decimal)value * 12, decimalPlaces);
    }
}
