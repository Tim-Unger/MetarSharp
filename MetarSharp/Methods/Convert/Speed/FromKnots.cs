namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromKnots
    {
        public static decimal ToMilesPerHour(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.151, 2);
        }
        public static decimal ToMilesPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.151, decimalPlaces);
        }

        public static decimal ToMetersPerSecond(this double value)
        {
            return Math.Round((decimal)value / (decimal)1.944, 2);
        }
        public static decimal ToMetersPerSecond(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)1.944, decimalPlaces);
        }

        public static decimal ToKilometersPerHour(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.852, 2);
        }
        public static decimal ToKilometersPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.852, decimalPlaces);
        }
    }
}
