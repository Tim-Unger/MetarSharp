namespace MetarSharp.Converter.Distance
{

    public static class ConvertFromMeter
    {
        /// <summary>
        /// Converts the given value from Meters to Kilometers
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers as a decimal</returns>
        public static decimal ToKilometer(this double value) => Math.Round((decimal)value / 1000, 2);

        /// <summary>
        /// Converts the given value from Meters to Kilometers with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers as a decimal with set decimal places</returns>
        public static decimal ToKilometer(this int value, int decimalPlaces) => Math.Round((decimal)value / 1000, decimalPlaces);

        /// <summary>
        /// Converts the given value from Meters to Statute Miles ("normal miles")
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a decimal</returns>
        public static decimal ToStatuteMile(this double value) => Math.Round((decimal)value * (decimal)0.000621371, 2);

        /// <summary>
        /// Converts the given value from Meters to  Statute Miles ("normal miles") with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a decimal with set decimal places</returns>
        public static decimal ToStatuteMile(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)0.000621371, decimalPlaces);

        /// <summary>
        /// Converts the given value from Meters to Nautical Miles
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a decimal</returns>
        public static decimal ToNauticalMile(this double value) => Math.Round((decimal)value * (decimal)0.000539957, 2);

        /// <summary>
        /// Converts the given value from Meters to Nautical Miles with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a decimal with set decimal places</returns>
        public static decimal ToNauticalMile(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)0.000539957, decimalPlaces);
    }
}
