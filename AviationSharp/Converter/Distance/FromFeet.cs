namespace AviationSharp.Converter.Distance
{
    public static class ConvertFromFeet
    {
        public static double ToCentimeters(this double value) => Math.Round(value * 30.48, 2);

        public static double ToCentimeters(this double value, int decimalPlaces) => Math.Round(value * 30.48, decimalPlaces);

        public static double ToInches(this double value) => Math.Round(value * 12, 2);

        public static double ToInches(this double value, int decimalPlaces) => Math.Round(value * 12, decimalPlaces);

        public static double ToKilometers(this double value) => Math.Round(value / 3281, 2);

        public static double ToKilometers(this double value, int decimalPlaces) => Math.Round(value / 3281, decimalPlaces);

        public static double ToMeters(this double value) => Math.Round(value / 3.281, 2);

        public static double ToMeters(this double value, int decimalPlaces) => Math.Round(value / 3.281, decimalPlaces);

        public static double ToNauticalMiles(this double value) => Math.Round(value / 6076, 2);

        public static double ToNauticalMiles(this double value, int decimalPlaces) => Math.Round(value / 6076, decimalPlaces);

        public static double ToStatuteMiles(this double value) => Math.Round(value / 5280, 2);

        public static double ToStatuteMiles(this double value, int decimalPlaces) => Math.Round(value / 5280, decimalPlaces);

        public static double ToYards(this double value) => Math.Round(value / 3, 2);

        public static double ToYards(this double value, int decimalPlaces) => Math.Round(value / 3, decimalPlaces);
    }
}
