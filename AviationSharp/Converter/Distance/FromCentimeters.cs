namespace AviationSharp.Converter.Height
{
    public static class FromCentimeter
    {
        public static double ToFeet(this double value) => Math.Round(value / 30.48, 2);

        public static double ToFeet(this double value, int decimalPlaces) => Math.Round(value / 30.48, decimalPlaces);

        public static double ToInches(this double value) => Math.Round(value / 2.54, 2);

        public static double ToInches(this double value, int decimalPlaces) => Math.Round(value / 2.54, decimalPlaces);

        public static double ToKilometers(this double value) => Math.Round(value / 10_000, 2);

        public static double ToKilometers(this double value, int decimalPlaces) => Math.Round(value / 10_000, decimalPlaces);

        public static double ToMeters(this double value) => Math.Round(value / 100, 2);

        public static double ToMeters(this double value, int decimalPlaces) => Math.Round(value / 100, decimalPlaces);

        public static double ToNauticalMiles(this double value) => Math.Round(value / 185_200, 2);

        public static double ToNauticalMiles(this double value, int decimalPlaces) => Math.Round(value / 185_200, decimalPlaces);

        public static double ToStatuteMiles(this double value) => Math.Round(value / 160_900, 2);

        public static double ToStatuteMiles(this double value, int decimalPlaces) => Math.Round(value / 160_900, decimalPlaces);

        public static double ToYards(this double value) => Math.Round(value / 91.44, 2);

        public static double ToYards(this double value, int decimalPlaces) => Math.Round(value / 91.44, decimalPlaces);
    }
}
