namespace AviationSharp.Converter.Distance
{
    public static class ConvertFromKilometer
    {
        public static double ToCentimeter(this double value) => Math.Round(value * 100_000, 2);

        public static double ToCentimeter(this double value, int decimalPlaces) => Math.Round(value * 100_000, decimalPlaces);

        public static double ToFeet(this double value) => Math.Round(value * 3281, 2);

        public static double ToFeet(this double value, int decimalPlaces) => Math.Round(value * 3281, decimalPlaces);

        public static double ToInches(this double value) => Math.Round(value * 39_370, 2);

        public static double ToInches(this double value, int decimalPlaces) => Math.Round(value * 39_370, decimalPlaces);

        /// <summary>
        /// Converts the given value from Kilometers to Meters
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Meters as a double</returns>
        public static double ToMeter(this double value) => Math.Round(value * 1000, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Meters with a given amount of double places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="doublePlaces"></param>
        /// <returns>the value converted to Meters as a double with set double places</returns>
        public static double ToMeter(this double value, int doublePlaces) => Math.Round(value * 1000, doublePlaces);

        /// <summary>
        /// Converts the given value from Kilometers to Statute Miles ("normal miles")
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Miles as a double</returns>
        public static double ToStatuteMile(this double value) => Math.Round(value * 0.621371, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Statute Miles ("normal miles") with set double places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="doublePlaces"></param>
        /// <returns>the value converted to Miles as a double with set double places</returns>
        public static double ToStatuteMile(this double value, int doublePlaces) => Math.Round(value * 0.621371, doublePlaces);

        /// <summary>
        /// Converts the given value from Kilometers to Nautical Miles ("normal miles")
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a double</returns>
        public static double ToNauticalMile(this double value) => Math.Round(value * 0.539957, 2);

        /// <summary>
        /// Converts the given value from Kilometers to Nautical Miles ("normal miles") with set double places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Nautical Miles as a double with set double places</returns>
        public static double ToNauticalMile(this double value, int doublePlaces) => Math.Round(value * 0.539957, doublePlaces);

        public static double ToYards(this double value) => Math.Round(value * 1094, 2);

        public static double ToYards(this double value, int decimalPlaces) => Math.Round(value * 1094, decimalPlaces);
    }
}
