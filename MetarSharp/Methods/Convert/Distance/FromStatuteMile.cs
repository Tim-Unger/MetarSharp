namespace MetarSharp.Converter.Distance
{
    public static class ConvertFromStatuteMile
    {
        /// <summary>
        /// Converts the given value from Statute Miles to Meters
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a decimal</returns>
        public static decimal ToMeter(this double value) => Math.Round((decimal)value * (decimal)1609.34, 2);

        /// <summary>
        /// Converts the given value from Statute Miles to Meters with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a decimal with set decimal places</returns>
        public static decimal ToMeter(this int value, byte decimalPlaces) => Math.Round((decimal)value * (decimal)1609.34, decimalPlaces);

        /// <summary>
        /// Converts the given value from Statute Miles to Kilometers
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers as a decimal</returns>
        public static decimal ToKilometer(this double value) => Math.Round((decimal)value * (decimal)1.60934, 2);

        /// <summary>
        /// Converts the given value from Statute Miles to Kilometers with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers as a decimal with set decimal places</returns>
        public static decimal ToKilometer(this double value, byte decimalPlaces) => Math.Round((decimal)value * (decimal)1.60934, decimalPlaces);

        /// <summary>
        /// Converts the given value from Statute Miles to Nautical Miles
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a decimal</returns>
        public static decimal ToNauticalMile(this double value) => Math.Round((decimal)value * (decimal)0.868976, 2);

        /// <summary>
        /// Converts the given value from Statute Miles to Nautical Miles with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a decimal with set decimal places</returns>
        public static decimal ToNauticalMile(this double value, byte decimalPlaces) => Math.Round((decimal)value * (decimal)0.868976, decimalPlaces);
    }
}
