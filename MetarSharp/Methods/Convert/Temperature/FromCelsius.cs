namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromCelsius
    {
        public static decimal ToFahrenheit(this double value)
        {
            return Math.Round(((decimal)value * 9 / 5) + 32, 2);
        }

        public static decimal ToFahrenheit(this double value, byte decimalPlaces)
        {
            return Math.Round(((decimal)value * 9 / 5) + 32, decimalPlaces);
        }

        public static decimal ToKelvin(this double value)
        {
            return Math.Round((decimal)value + (decimal)273.15, 2);
        }

        public static decimal ToKelvin(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value + (decimal)273.15, decimalPlaces);
        }
    }
}
