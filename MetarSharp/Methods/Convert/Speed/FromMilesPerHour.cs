namespace MetarSharp.Converter.Speed
{
    public static class ConvertFromMilesPerHour
    {
        public static decimal ToKilometersPerHour(this double value)
        {
            return Math.Round((decimal)value * (decimal)1.609, 2);
        }
        public static decimal ToKilometersPerHour(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)1.609, decimalPlaces);
        }

        public static decimal ToMetersPerSecond(this double value)
        {
            return Math.Round((decimal)value / (decimal)2.237, 2);
        }
        public static decimal ToMetersPerSecond(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)2.237, decimalPlaces);
        }

        public static decimal ToKnots(this double value)
        {
            return Math.Round((decimal)value / (decimal)1.151, 2);
        }
        public static decimal ToKnots(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value / (decimal)1.151, decimalPlaces);
        }
    }
}
