namespace MetarSharp.Converter.Time
{
    public static class ConvertFromMilliseconds
    {
        public static decimal ToSeconds(this double value)
        {
            return Math.Round((decimal)value / 1000, 2);
        }

        public static decimal ToSeconds(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 1000, decimalPlaces);
        }
        public static decimal ToMinutes(this double value)
        {
            return Math.Round((decimal)value / 60000, 2);
        }

        public static decimal ToMinutes(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 60000, decimalPlaces);
        }
        public static decimal ToHours(this double value)
        {
            return Math.Round((decimal)value / 3600000, 2);
        }

        public static decimal ToHours(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 3600000, decimalPlaces);
        }

        public static decimal ToDays(this double value)
        {
            return Math.Round((decimal)value / 8640000000, 2);
        }

        public static decimal ToDays(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 8640000000, decimalPlaces);
        }

        public static decimal ToWeeks(this double value)
        {
            return Math.Round((decimal)value / 604800000000, 2);
        }

        public static decimal ToWeeks(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 604800000000, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value / 2628000000000, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 2628000000000, decimalPlaces);
        }

        public static decimal ToYears(this double value)
        {
            return Math.Round((decimal)value / 31540000000000, 2);
        }

        public static decimal ToYears(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 31540000000000, decimalPlaces);
        }
    }
}
