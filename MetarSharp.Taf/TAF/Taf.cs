using static MetarSharp.Taf.State;

namespace MetarSharp.Taf
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
        public bool IsProbability { get; set; } = false;

        public TafTimeSpan? TafTimeSpan { get; set; }

        public int? TafProbability { get; set; }

        public Metar Metar { get; set; }
    }
}
