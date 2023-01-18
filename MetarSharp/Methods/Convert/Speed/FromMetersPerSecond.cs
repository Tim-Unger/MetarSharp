namespace MetarSharp.Methods.Convert.Speed
{
    public static class ConvertFromMetersPerSecond
    {
        public static decimal ToMilesPerHour(this double value)
        {
            return Math.Round((decimal)value * (decimal)2.237, 2);
        }
        public static decimal ToMilesPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)2.237, decimalPlaces);
        }

        public static decimal ToKilometersPerHour(this double value)
        {
            return Math.Round((decimal)value * (decimal)3.6, 2);
        }
        public static decimal ToKilometersPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)3.6, decimalPlaces);
        }

        public static decimal ToKnots(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.944, 2);
        }
        public static decimal ToKnots(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.944, decimalPlaces);
        }
    }
}
