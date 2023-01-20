namespace MetarSharp.Methods.Convert.Distance
{
    public static class ConvertFromStatuteMile
    {
        public static decimal ToMeter(this double value)
        {
            return Math.Round((decimal)value * (decimal)1609.34, 2);
        }

        public static decimal ToMeter(this int value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1609.34, decimalPlaces);
        }

        public static decimal ToKilometer(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.60934, 2);
        }

        public static decimal ToKilometer(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.60934, decimalPlaces);
        }

        public static decimal ToNauticalMile(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.868976, 2);
        }

        public static decimal ToNauticalMile(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.868976, decimalPlaces);
        }
    }
}
