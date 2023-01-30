namespace MetarSharp
{
    public enum PressureType
    {
        InchesMercury,
        Hectopascal
    }

    public class Pressure
    {
        public bool IsPressureMeasurable { get; set; } = true;

        public string PressureRaw { get; set; } = "Q9999";

        public PressureType? PressureType { get; set; }

        public string PressureTypeString { get; set; } = "None";

        public string PressureTypeRaw { get; set; } = "NaN";

        public double PressureOnly { get; set; }

        public int? PressureAsQnh { get; set; }

        public double? PressureAsAltimeter { get; set; }
    }
}
