namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromCelsius
    {
        /// <summary>
        /// Converts the given value from Celsius to Fahrenheit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Fahrenheit as a decimal</returns>
        public static decimal ToFahrenheit(this double value) => Math.Round(((decimal)value * 9 / 5) + 32, 2);

        /// <summary>
        /// Converts the given value from Celsius to Fahrenheit with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Fahrenheit as a decimal with set decimal places</returns>
        public static decimal ToFahrenheit(this double value, byte decimalPlaces) => Math.Round(((decimal)value * 9 / 5) + 32, decimalPlaces);

        /// <summary>
        /// Converts the given value from Celsius to Kelvin
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kelvin as a decimal</returns>
        public static decimal ToKelvin(this double value) => Math.Round((decimal)value + (decimal)273.15, 2);

        /// <summary>
        /// Converts the given value from Celsius to Kelvin with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Kelvin as a decimal with set decimal places</returns>
        public static decimal ToKelvin(this double value, byte decimalPlaces) => Math.Round((decimal)value + (decimal)273.15, decimalPlaces);
    }
}
