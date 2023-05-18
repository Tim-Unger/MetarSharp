namespace MetarSharp.Converter.Time
{
    public static class ConvertFromHours
    {
        public static decimal ToMilliseconds(this double value)
        {
            return Math.Round((decimal)value * 36000000, 2);
        }

        public static decimal ToMilliseconds(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 36000000, decimalPlaces);
        }
        public static decimal ToSeconds(this double value)
        {
            return Math.Round((decimal)value * 3600, 2);
        }

        public static decimal ToSeconds(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 3600, decimalPlaces);
        }
        public static decimal ToMinutes(this double value)
        {
            return Math.Round((decimal)value * 60, 2);
        }

        public static decimal ToMinutes(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 60, decimalPlaces);
        }

        public static decimal ToDays(this double value)
        {
            return Math.Round((decimal)value / 24, 2);
        }

        public static decimal ToDays(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 24, decimalPlaces);
        }

        public static decimal ToWeeks(this double value)
        {
            return Math.Round((decimal)value / 168, 2);
        }

        public static decimal ToWeeks(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 168, decimalPlaces);
        }

        public static decimal ToMonths(this double value)
        {
            return Math.Round((decimal)value / 730, 2);
        }

        public static decimal ToMonths(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 730, decimalPlaces);
        }

        public static decimal ToYears(this double value)
        {
            return Math.Round((decimal)value / 8760, 2);
        }

        public static decimal ToYears(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / 8760, decimalPlaces);
        }
    }
}
