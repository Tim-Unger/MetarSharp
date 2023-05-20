namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromKelvin
    {
        /// <summary>
        /// Converts the given value from Kelvin to Celsius
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Celsius as a decimal</returns>
        public static decimal ToCelsius(this double value)
        {
            return Math.Round((decimal)value - (decimal)273.15, 2);
        }

        /// <summary>
        /// Converts the given value from Kelvin to Celsius with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Celsius as a decimal with set decimal places</returns>
        public static decimal ToCelsius(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value - (decimal)273.15, decimalPlaces);
        }

        /// <summary>
        /// Converts the given value from Kelvin to Fahrenheit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Fahrenheit as a decimal</returns>
        public static decimal ToFahrenheit(this double value)
        {
            return Math.Round(((decimal)value - (decimal)273.15) * 9/5 + 32, 2);
        }

        /// <summary>
        /// Converts the given value from Kelvin to Fahrenheit with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Fahrenheit as a decimal with set decimal places</returns>
        public static decimal ToFahrenheit(this double value, byte decimalPlaces)
        {
            return Math.Round(((decimal)value - (decimal)273.15) * 9 / 5 + 32, decimalPlaces);
        }
    }
}
