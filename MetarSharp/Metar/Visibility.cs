namespace MetarSharp
{
    public enum VisibilityUnit
    {
        Meters,
        Miles,
        Kilometers
    }
    public class Visibility
    {
        public string VisibilityRaw { get; set; } = "None";

        public bool IsVisibilityMeasurable { get; set; }

        public double ReportedVisibility { get; set; }

        public VisibilityUnit VisibilityUnit { get; set; }

        public string VisibilityUnitRaw { get; set; } = "None";

        public string VisibilityUnitDecoded { get; set; } = "None";

        public bool HasVisibilityLowestValue { get; set; }

        public double? LowestVisibility { get; set; }

        public CardinalDirection LowestVisibilityDirection { get; set; }

        public string? LowestVisibilityDirectionRaw { get; set; }

        public string? LowestVisibilityDirectionDecoded { get; set; }
    }
}
