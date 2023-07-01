namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromMilesPerHour
    {
        /// <summary>
        /// Converts the given value from Miles Per Hour to Kilometers Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal</returns>
        public static decimal ToKilometersPerHour(this double value) => Math.Round((decimal)value * (decimal)1.609, 2);

        /// <summary>
        /// Converts the given value from Miles Per Hour to Kilometers Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal with set decimal places</returns>
        public static decimal ToKilometersPerHour(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)1.609, decimalPlaces);

        /// <summary>
        /// Converts the given value from Miles Per Hour to Meters Per Second
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal</returns>
        public static decimal ToMetersPerSecond(this double value) => Math.Round((decimal)value / (decimal)2.237, 2);

        /// <summary>
        /// Converts the given value from Miles Per Hour to Meters Per Second with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal with set decimal places</returns>
        public static decimal ToMetersPerSecond(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)2.237, decimalPlaces);

        /// <summary>
        /// Converts the given value from Miles Per Hour to Knots
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal</returns>
        public static decimal ToKnots(this double value) => Math.Round((decimal)value / (decimal)1.151, 2);

        /// <summary>
        /// Converts the given value from Miles Per Hour to Knots with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal with set decimal places</returns>
        public static decimal ToKnots(this double value, int decimalPlaces) => Math.Round((decimal)value / (decimal)1.151, decimalPlaces);
    }
}
