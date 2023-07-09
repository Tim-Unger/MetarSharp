namespace MetarSharp.Converter.Distance
{
    public static class ConvertFromNauticalMile
    {
        /// <summary>
        /// Converts the given value from Nautical  Miles to Meters
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a decimal</returns>
        public static decimal ToMeter(this double value) => Math.Round((decimal)value * 1852, 2);

        /// <summary>
        /// Converts the given value from Nautical Miles to Meters with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a decimal with set decimal places</returns>
        public static decimal ToMeter(this int value, int decimalPlaces) => Math.Round((decimal)value * 1852, decimalPlaces);

        /// <summary>
        /// Converts the given value from Nautical Miles to Kilometers
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers as a decimal</returns>
        public static decimal ToKilometer(this double value) => Math.Round((decimal)value * (decimal)1.852, 2);

        /// <summary>
        /// Converts the given value from Nautical Miles to Kilometers with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns>the value converted to Kilometers as a decimal with set decimal places</returns>
        public static decimal ToKilometer(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)1.852, decimalPlaces);

        /// <summary>
        /// Converts the given value from Nautical Miles to Statute Miles ("Regular" Miles)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a decimal</returns>
        public static decimal ToStatuteMile(this double value) => Math.Round((decimal)value * (decimal)1.15078, 2);

        /// <summary>
        /// Converts the given value from Nautical Miles to Statute Miles ("Regular" Miles) with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a decimal with set decimal places</returns>
        public static decimal ToStatuteMile(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)1.15078, decimalPlaces);
    }
}
