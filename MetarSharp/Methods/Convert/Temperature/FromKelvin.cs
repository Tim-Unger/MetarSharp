﻿namespace MetarSharp.Converter.Temperature
{
    public static class ConvertFromKelvin
    {
        public static decimal ToCelsius(this double value)
        {
            return Math.Round((decimal)value - (decimal)273.15, 2);
        }

        public static decimal ToCelsius(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value - (decimal)273.15, decimalPlaces);
        }

        public static decimal ToFahrenheit(this double value)
        {
            return Math.Round(((decimal)value - (decimal)273.15) * 9/5 + 32, 2);
        }

        public static decimal ToFahrenheit(this double value, byte decimalPlaces)
        {
            return Math.Round(((decimal)value - (decimal)273.15) * 9 / 5 + 32, decimalPlaces);
        }
    }
}
