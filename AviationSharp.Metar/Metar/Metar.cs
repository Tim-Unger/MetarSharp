namespace MetarSharp
{
    public class Metar
    {
        public string? MetarRaw { get; set; } = "";

        public string Airport { get; set; } = "AAAA";

        public ReportingTime ReportingTime = new();

        public bool IsAutomatedReport { get; set; } = false;

        public Wind Wind = new(); 

        public Visibility Visibility = new();

        public List<RunwayVisibility>? RunwayVisibilities;

        public Weather? Weather = new();

        public List<Cloud> Clouds = new();

        public Temperature Temperature = new();

        public Pressure Pressure = new();

        public List<Trend> Trends = new();

        public List<RunwayCondition>? RunwayConditions;

        public AdditionalInformation AdditionalInformation = new();

        public string? ReadableReport = null;
    }
}
