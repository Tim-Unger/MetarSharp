
namespace MetarSharp
{
    public class Metar
    {
        public string? MetarRaw { get; set; } = "";

        public string Airport { get; set; } = "AAAA";

        public ReportingTime ReportingTime = new ReportingTime();

        public bool IsAutomatedReport { get; set; } = false;

        public Wind Wind = new Wind(); 

        public Visibility Visibility = new Visibility();

        public List<RunwayVisibility>? RunwayVisibilities;

        public Weather? Weather = new Weather();

        public List<Cloud> Clouds = new List<Cloud>();

        public Temperature Temperature = new Temperature();

        public Pressure Pressure = new Pressure();

        public List<Trend> Trends = new List<Trend>();

        public List<RunwayCondition>? RunwayConditions;

        public AdditionalInformation AdditionalInformation = new AdditionalInformation();

        public string ReadableReport = "";
    }
}
