namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromFahrenheit
    {
        public static decimal ToCelsius(this double value)
        {
            return Math.Round(((decimal)value - 32) * 5/9, 2);
        }

        public static decimal ToCelsius(this double value, byte decimalPlaces)
        {
            return Math.Round(((decimal)value - 32) * 5/9, decimalPlaces);
        }

        public static decimal ToKelvin(this double value)
        {
            return Math.Round(((decimal)value - 32) * 5/9 + (decimal)273.15, 2);
        }

        public static decimal ToKelvin(this double value, byte decimalPlaces)
        {
            return Math.Round(((decimal)value - 32) * 5 / 9 + (decimal)273.15, decimalPlaces);
        }
    }
}
