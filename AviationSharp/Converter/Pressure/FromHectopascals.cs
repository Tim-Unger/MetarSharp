namespace AviationSharp.Converter.Pressure
{
    public static class ConvertFromHectopascals
    {
        /// <summary>
        /// Converts the given value from Hectopascals to Inches Mercury
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Inches Mercury as a decimal</returns>
        public static decimal ToInchesMercury(this double value) => Math.Round((decimal)value * (decimal)0.029529983071445, 2);

        /// <summary>
        /// Converts the given value from Hectopascals to Inches Mercury with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns>the value converted to Inches Mercury as a decimal with set decimal places</returns>
        public static decimal ToInchesMercury(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)0.029529983071445, decimalPlaces);  
    }
}
