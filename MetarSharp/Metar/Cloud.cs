namespace MetarSharp
{
    public enum CloudType
    {
        NoCloudsDetected,
        NoSignificantClouds,
        Few,
        Scattered,
        Broken,
        Overcast,
    }

    public class Cloud
    {
        public bool IsCAVOK { get; set; } = true;

        public bool IsCloudMeasurable { get; set; }

        public string? CloudRaw { get; set; }

        public CloudType CloudCoverageType { get; set; } = CloudType.NoCloudsDetected;

        public string? CloudCoverageTypeRaw { get; set; }

        public string? CloudCoverageTypeDecoded { get; set; }

        public bool? IsCeilingMeasurable { get; set; }

        public int? CloudCeiling { get; set; }

        public bool? HasCumulonimbusClouds { get; set; }

        public bool? IsCBTypeMeasurable { get; set; }

        public string? CBCloudTypeRaw { get; set; }

        public string? CBCloudTypeDecoded { get; set; }

        public bool? IsVerticalVisibility { get; set; }

        public string? VerticalVisibilityRaw { get; set; }

        public bool? IsVerticalVisibilityMeasurable { get; set; }

        public int? VerticalVisibility { get; set; }

    }
}
