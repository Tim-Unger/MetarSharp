namespace MetarSharp
{
    public enum ParallelRunwayDesignator
    {
        Left,
        Center,
        Right
    }

    public class RunwayVisibility
    {
        public string RunwayVisibilityRaw { get; set; } = "";

        public string Runway { get; set; } = "";

        public bool IsParallelRunway { get; set; }

        public ParallelRunwayDesignator? ParallelRunwayDesignator { get; set; }

        public string? ParallelRunwayDesignatorRaw { get; set; }

        public string? ParallelRunwayDesignatorDecoded { get; set; }

        public int RunwayVisualRange { get; set; }

        public bool? IsRVRValueMoreOrLess { get; set; }

        public string? RVRMoreOrLessDecoded { get; set; }

        public string? RVRTendencyRaw { get; set; }

        public string? RVRTendencyDecoded { get; set; }

        public bool? IsRVRVarying { get; set; }

        public bool? IsRVRVariationMoreOrLess { get; set; }

        public string? RVRVariationMoreOrLessDecoded { get; set; }

        public int? RVRVariationValue { get; set; }

        public string? RVRVariationTendencyRaw { get; set; }

        public string? RVRVariationTendencyDecoded { get; set; }
    }
}
