namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromMetersPerSecond
    {
        /// <summary>
        /// Converts the given value from Meters Per Second to Miles Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal</returns>
        public static decimal ToMilesPerHour(this double value) => Math.Round((decimal)value * (decimal)2.237, 2);

        /// <summary>
        /// Converts the given value from Meters Per Second to Miles Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles Per Hour as a decimal with set decimal places</returns>
        public static decimal ToMilesPerHour(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)2.237, decimalPlaces);

        /// <summary>
        /// Converts the given value from Meters Per Second to Kilometers Per Hour
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal</returns>
        public static decimal ToKilometersPerHour(this double value) => Math.Round((decimal)value * (decimal)3.6, 2);

        /// <summary>
        /// Converts the given value from Meters Per Second to Kilometers Per Hour with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kilometers Per Hour as a decimal with set decimal places</returns>
        public static decimal ToKilometersPerHour(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)3.6, decimalPlaces);

        /// <summary>
        /// Converts the given value from Meters Per Second to Knots
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal</returns>
        public static decimal ToKnots(this double value) => Math.Round((decimal)value * (decimal)1.944, 2);

        /// <summary>
        /// Converts the given value from Meters Per Second to Knots with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Knots as a decimal with set decimal places</returns>
        public static decimal ToKnots(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)1.944, decimalPlaces);
    }
}
