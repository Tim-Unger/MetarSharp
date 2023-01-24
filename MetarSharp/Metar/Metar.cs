
namespace MetarSharp
{
    public class Metar
    {
        public string MetarRaw { get; set; }
        //The Airport (EGLL)
        public string Airport { get; set; }
        public ReportingTime ReportingTime;
        public bool IsAutomatedReport { get; set; }
        public Wind Wind;
        public Visibility Visibility;
        public List<RunwayVisibility>? RunwayVisibilities;
        public Weather? Weather;
        //Non-nullable as it must be at least CAVOK
        public List<Cloud> Clouds;
        public Temperature Temperature;
        public Pressure Pressure;
        public List<Trend> Trends;
        public List<RunwayCondition>? RunwayConditions;
        public AdditionalInformation AdditionalInformation;
        public string ReadableReport;
    }
}
