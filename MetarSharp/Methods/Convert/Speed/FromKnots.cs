namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromKnots
    {
        /// <summary>
        /// Converts the given value from Knots to Miles Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal</returns>
        public static decimal ToMilesPerHour(this double value) => Math.Round((decimal)value * (decimal)1.151, 2);

        /// <summary>
        /// Converts the given value from Knots to Miles Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal with set decimal places</returns>
        public static decimal ToMilesPerHour(this double value, byte decimalPlaces) => Math.Round((decimal)value * (decimal)1.151, decimalPlaces);

        /// <summary>
        /// Converts the given value from Knots to Meters Per Second
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal</returns>
        public static decimal ToMetersPerSecond(this double value) => Math.Round((decimal)value / (decimal)1.944, 2);

        /// <summary>
        /// Converts the given value from Knots to Meters Per Second with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters Per Second as a decimal with set decimal places</returns>
        public static decimal ToMetersPerSecond(this double value, byte decimalPlaces) => Math.Round((decimal)value / (decimal)1.944, decimalPlaces);

        /// <summary>
        /// Converts the given value from Knots to Kilometers Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal</returns>
        public static decimal ToKilometersPerHour(this double value) => Math.Round((decimal)value * (decimal)1.852, 2);

        /// <summary>
        /// Converts the given value from Knots to Kilometers Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal with set decimal places</returns>
        public static decimal ToKilometersPerHour(this double value, byte decimalPlaces) => Math.Round((decimal)value * (decimal)1.852, decimalPlaces);
    }
}
