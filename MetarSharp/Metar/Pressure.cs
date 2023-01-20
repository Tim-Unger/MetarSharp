namespace MetarSharp
{
    public enum PressureType
    {
        InchesMercury,
        Hectopascal
    }

    public class Pressure
    {
        public bool IsPressureMeasurable { get; set; }
        public string PressureRaw { get; set; }
        public PressureType? PressureType { get; set; }
        public string PressureTypeString { get; set; }
        public string PressureTypeRaw { get; set; }
        public double PressureOnly { get; set; }
        public int? PressureAsQnh { get; set; }
        public double? PressureAsAltimeter { get; set; }
    }
}
