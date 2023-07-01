namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromKilometersPerHour
    {
        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Miles Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal</returns>
        public static decimal ToMilesPerHour(this double value) => Math.Round((decimal)value / (decimal)1.609, 2);

        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Miles Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal with set decimal places</returns>
        public static decimal ToMilesPerHour(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)1.609, decimalPlaces);

        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Meters Per Second
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal</returns>
        public static decimal ToMetersPerSecond(this double value) => Math.Round((decimal)value / (decimal)3.6, 2);

        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Meters Per Second with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal with set decimal places</returns>
        public static decimal ToMetersPerSecond(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)3.6, decimalPlaces);

        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Knots
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal</returns>
        public static decimal ToKnots(this double value) => Math.Round((decimal)value / (decimal)1.852, 2);

        /// <summary>
        /// Converts the given value from Kilometers Per Hour to Knots with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal with set decimal places</returns>
        public static decimal ToKnots(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)1.852, decimalPlaces);
    }
}
