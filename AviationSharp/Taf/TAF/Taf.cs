using static AviationSharp.Taf.State;
using AviationSharp.Metar;

namespace AviationSharp.Taf
{
    public class Taf
    {
        public string Airport { get; set; }

        public ReportingTime ReportingTime { get; set; }

        public Validity Validity { get; set; }

        public TafState? TafState { get; set; }

        public List<TafReport> TafReports { get; set; }

        public string Remarks { get; set; }

        public string ReadableReport { get; set; }
    }

    public class TafReport
    {
        public bool HasProbability { get; set; } = false;

        public TafTimeSpan? TafTimeSpan { get; set; }

        public int? TafProbability { get; set; }
        
        public Wind? Wind { get; set; } = new();

        public Visibility? Visibility { get; set; } = new();

        //public List<RunwayVisibility>? RunwayVisibilities { get; set; }

        public Weather? Weather { get; set; }

        public List<Cloud>? Clouds { get; set; } = new();

        public Temperature? Temperature { get; set; } = new();

        public Pressure? Pressure { get; set; } = new();
    }
}
