namespace MetarSharp.Converter.Distance
{
    public static class ConvertFromKilometer
    {
        /// <summary>
        /// Converts the given value from Kilometers to Meters
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a double</returns>
        public static decimal ToMeter(this double value) => Math.Round((decimal)value * 1000, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Meters with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns>the value converted to Meters as a double with set decimal places</returns>
        public static decimal ToMeter(this int value, int decimalPlaces) => Math.Round((decimal)value * 1000, decimalPlaces);

        /// <summary>
        /// Converts the given value from Kilometers to Statute Miles ("normal miles")
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a double</returns>
        public static decimal ToStatuteMile(this double value) => Math.Round((decimal)value * (decimal)0.621371, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Statute Miles ("normal miles") with set decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns>the value converted to Miles as a double with set decimal places</returns>
        public static decimal ToStatuteMile(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)0.621371, decimalPlaces);

        /// <summary>
        /// Converts the given value from Kilometers to Nautical Miles ("normal miles")
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a double</returns>
        public static decimal ToNauticalMile(this double value) => Math.Round((decimal)value * (decimal)0.539957, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Nautical Miles ("normal miles") with set decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a double with set decimal places</returns>
        public static decimal ToNauticalMile(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)0.539957, decimalPlaces);
    }
}
