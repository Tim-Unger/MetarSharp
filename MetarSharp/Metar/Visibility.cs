namespace MetarSharp
{
    public enum VisibilityUnit
    {
        Meters,
        Miles,
        Kilometers
    }
    
    public enum MoreOrLessType
    {
        More,
        Less
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

        public CardinalDirection? LowestVisibilityDirection { get; set; } = null;

        public string? LowestVisibilityDirectionRaw { get; set; }

        public string? LowestVisibilityDirectionDecoded { get; set; }

        public bool IsVisibilityMoreOrLess { get; set; } = false;
        
        public MoreOrLessType? VisibilityMoreOrLessType { get; set; }
        
        public string? VisibilityMoreOrLessRaw { get; set; }
        
        public string? VisibilityMoreOrLessDecoded { get; set; }
    }
}
