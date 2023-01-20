namespace MetarSharp
{
    public enum CloudType
    {
        Few,
        Scattered,
        Broken,
        Overcast,
        NoSignificantClouds,
        NoCloudsDetected
    }

    public class Cloud
    {
        public bool IsCAVOK { get; set; }
        public bool? IsCloudMeasurable { get; set; }
        public string? CloudRaw { get; set; }
        public CloudType CloudCoverageType { get; set; }
        public string? CloudCoverageTypeRaw { get; set; }
        public string? CloudCoverageTypeDecoded { get; set; }
        public bool? IsCeilingMeasurable { get; set; }
        public int? CloudCeiling { get; set; }

        //TODO Cloud-Ceiling converted to ft
        public bool? HasCumulonimbusClouds { get; set; }
        public bool? IsCBTypeMeasurable { get; set; }
        public string? CBCloudTypeRaw { get; set; }
        public string? CBCloudTypeDecoded { get; set; }
        public bool? IsVerticalVisibility { get; set; }

        //public string? VerticalVisibilityRaw { get; set; }
        public bool? IsVerticalVisibilityMeasurable { get; set; }
        public int? VerticalVisibility { get; set; }
    }
}
