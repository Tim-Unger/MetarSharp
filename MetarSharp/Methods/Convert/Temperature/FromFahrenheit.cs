namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromFahrenheit
    {
        /// <summary>
        /// Converts the given value from Fahrenheit to Celsius
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Celsius as a decimal</returns>
        public static decimal ToCelsius(this double value) => Math.Round(((decimal)value - 32) * 5/9, 2);

        /// <summary>
        /// Converts the given value from Fahrenheit to Celsius with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Celsius as a decimal with set decimal places</returns>
        public static decimal ToCelsius(this double value, byte decimalPlaces) => Math.Round(((decimal)value - 32) * 5 / 9, decimalPlaces);

        /// <summary>
        /// Converts the given value from Fahrenheit to Kelvin
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kelvin as a decimal</returns>
        public static decimal ToKelvin(this double value) => Math.Round(((decimal)value - 32) * 5 / 9 + (decimal)273.15, 2);

        /// <summary>
        /// Converts the given value from Fahrenheit to Kelvin with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kelvin as a decimal with set decimal places</returns>
        public static decimal ToKelvin(this double value, byte decimalPlaces) => Math.Round(((decimal)value - 32) * 5 / 9 + (decimal)273.15, decimalPlaces);
    }
}
