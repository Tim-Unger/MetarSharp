namespace AviationSharp.Converter.Height
{
    public static class ConvertFromInches
    {
        public static double ToCentimeters(this double value) => Math.Round(value * 2.54, 2);

        public static double ToCentimeters(this double value, int decimalPlaces) => Math.Round(value * 2.54, decimalPlaces);

        public static double ToFeet(this double value) => Math.Round(value / 12, 2);

        public static double ToFeet(this double value, int decimalPlaces) => Math.Round(value / 12, decimalPlaces);

        public static double ToKilometers(this double value) => Math.Round(value / 39370, 2);

        public static double ToKilometers(this double value, int decimalPlaces) => Math.Round(value / 39370, decimalPlaces);

        public static double ToMeters(this double value) => Math.Round(value / 39.37, 2);

        public static double ToMeters(this double value, int decimalPlaces) => Math.Round(value / 39.37, decimalPlaces);

        public static double ToNauticalMiles(this double value) => Math.Round(value / 72910, 2);

        public static double ToNauticalMiles(this double value, int decimalPlaces) => Math.Round(value / 72910, decimalPlaces);

        public static double ToStatuteMiles(this double value) => Math.Round(value / 63360, 2);

        public static double ToStatuteMiles(this double value, int decimalPlaces) => Math.Round(value / 63360, decimalPlaces);

        public static double ToYards(this double value) => Math.Round(value / 36, 2);
        
        public static double ToYards(this double value, int decimalPlaces) => Math.Round(value / 36, decimalPlaces);
    }
}
