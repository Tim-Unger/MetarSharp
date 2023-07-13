namespace MetarSharp
{
    public class Temperature
    {
        public bool IsTemperatureMeasurable { get; set; }

        public string TemperatureRaw { get; set; } = "None";

        public double TemperatureCelsius { get; set; }

        public double TemperatureFahrenheit { get; set; }

        public bool IsTemperatureBelowZero { get; set; }

        public double DewpointCelsius { get; set; }

        public double DewpointFahrenheit { get; set; }

        public bool IsDewpointBelowZero { get; set; }
    }
}
