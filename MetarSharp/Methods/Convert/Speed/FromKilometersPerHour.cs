namespace MetarSharp.Methods.Convert.Speed
{
    public static class ConvertFromKilometersPerHour
    {
        public static decimal ToMilesPerHour(this double value)
        {
            return Math.Round((decimal)value / (decimal)1.609, 2);
        }
        public static decimal ToMilesPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)1.609, decimalPlaces);
        }

        public static decimal ToMetersPerSecond(this double value)
        {
            return Math.Round((decimal)value / (decimal)3.6, 2);
        }
        public static decimal ToMetersPerSecond(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)3.6, decimalPlaces);
        }

        public static decimal ToKnots(this double value)
        {
            return Math.Round((decimal)value / (decimal)1.852, 2);
        }
        public static decimal ToKnots(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)1.852, decimalPlaces);
        }
    }
}
