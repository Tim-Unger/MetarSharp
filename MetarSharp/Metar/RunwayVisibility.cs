namespace MetarSharp
{
    public enum ParallelRunwayDesignator
    {
        Left,
        Center,
        Right
    }

    //TODO
    public class RunwayVisibility
    {
        public string RunwayVisibilityRaw { get; set; } = "";

        public string Runway { get; set; } = "45R";

        public bool IsParallelRunway { get; set; }

        public ParallelRunwayDesignator? ParallelRunwayDesignator { get; set; }

        public string? ParallelRunwayDesignatorRaw { get; set; }

        public string? ParallelRunwayDesignatorDecoded { get; set; }

        public int RunwayVisualRange { get; set; }

        //TODO
        public bool? IsRVRValueMoreOrLess { get; set; }

        //TODO more or less raw
        public string? RVRMoreOrLessDecoded { get; set; }

        public string? RVRTendencyRaw { get; set; }

        public string? RVRTendencyDecoded { get; set; }

        public bool? IsRVRVarying { get; set; }

        public bool? IsRVRVariationMoreOrLess { get; set; }

        //TODO more or less raw

        public string? RVRVariationMoreOrLessDecoded { get; set; }

        public int? RVRVariationValue { get; set; }

        //TODO überflüssig?

        public string? RVRVariationTendencyRaw { get; set; }

        public string? RVRVariationTendencyDecoded { get; set; }
    }
}
