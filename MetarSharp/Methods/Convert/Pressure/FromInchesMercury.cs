namespace MetarSharp.Converter.Pressure
{
    public static class ConvertFromInchesMercury
    {
        public static decimal ToHectopascals(this double value)
        {
            return Math.Round((decimal)value * (decimal)33.86388666666671, 2);
        }
        public static decimal ToHectopascals(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)33.86388666666671, decimalPlaces);
        }
    }
}
