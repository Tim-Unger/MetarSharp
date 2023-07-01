namespace MetarSharp.Converter.Pressure
{
    public static class ConvertFromInchesMercury
    {
        /// <summary>
        /// Converts the given value from Inches Mercury to Hectopascals
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Hectopascals as a decimal</returns>
        public static int ToHectopascals(this double value) => (int)Math.Round(value * 33.86388666666671, 0);

        /// <summary>
        /// Converts the given value from Inches Mercury to Hectopascals with a given amount of decimal places
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the value converted to Hectopascals as a decimal with set decimal places</returns>
        public static decimal ToHectopascals(this double value, int decimalPlaces) => Math.Round((decimal)value * (decimal)33.86388666666671, decimalPlaces);
    }
}
