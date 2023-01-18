namespace MetarSharp.Methods.Convert.Pressure
{
    public static class ConvertFromHectopascals
    {
        public static decimal ToInchesMercury(this double value)
        {
            return Math.Round((decimal)value * (decimal)0.029529983071445, 2);
        }
        public static decimal ToInchesMercury(this double value, byte decimalPlaces)
        {
            return Math.Round((decimal)value * (decimal)0.029529983071445, decimalPlaces);
        }
    }
}
