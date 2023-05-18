namespace MetarSharp.Converter.Distance
{
    public static class ConvertFromNauticalMile
    {
        public static decimal ToMeter(this double value)
        {
            return Math.Round((decimal)value * 1852, 2);
        }

        public static decimal ToMeter(this int value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * 1852, decimalPlaces);
        }

        public static decimal ToKilometer(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.852, 2);
        }

        public static decimal ToKilometer(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.852, decimalPlaces);
        }

        public static decimal ToStatuteMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.15078, 2);
        }

        public static decimal ToStatuteMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.15078, decimalPlaces);
        }
    }
}
