namespace MetarSharp
{
    public class MetarParser
    {
        //public bool IsReadonly { get; set; } = false;

        public bool CreateReadableReport { get; set; } = true;

        public WindUnit? WindUnit { get; set; }

        public PressureType? PressureType { get; set; }

        public VisibilityUnit? VisibilityUnit { get; set; }

        public DateOnly? OverwriteReportingDate { get; set; }
    }
}
