namespace AviationSharp.Converter.Time
{
    public static class ConvertFromMinutes
    {
        public static decimal ToMilliseconds(this double value) => Math.Round((decimal)value * 60000, 2);

        public static decimal ToMilliseconds(this double value, int decimalPlaces) => Math.Round((decimal)value * 60000, decimalPlaces);

        public static decimal ToSeconds(this double value) => Math.Round((decimal)value * 60, 2);

        public static decimal ToSeconds(this double value, int decimalPlaces) => Math.Round((decimal)value * 60, decimalPlaces);

        public static decimal ToHours(this double value) => Math.Round((decimal)value / 60, 2);

        public static decimal ToHours(this double value, int decimalPlaces) => Math.Round((decimal)value / 60, decimalPlaces);

        public static decimal ToDays(this double value) => Math.Round((decimal)value / 1440, 2);

        public static decimal ToDays(this double value, int decimalPlaces) => Math.Round((decimal)value / 1440, decimalPlaces);

        public static decimal ToWeeks(this double value) => Math.Round((decimal)value / 10080, 2);

        public static decimal ToWeeks(this double value, int decimalPlaces) => Math.Round((decimal)value / 10080, decimalPlaces);

        public static decimal ToMonths(this double value) => Math.Round((decimal)value / 43800, 2);

        public static decimal ToMonths(this double value, int decimalPlaces) => Math.Round((decimal)value / 43800, decimalPlaces);

        public static decimal ToYears(this double value) => Math.Round((decimal)value / 525600, 2);

        public static decimal ToYears(this double value, int decimalPlaces) => Math.Round((decimal)value / 525600, decimalPlaces);
    }
}
