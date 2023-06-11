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
    }

    public class TafReport
    {
        //(PROB([0-9]{1,3}))|(FM([0-9]{2}[0-9]{4})|BCMG|TEMPO)(.*)(?=)(PROB([0-9]{1,3}))|(FM([0-9]{2}[0-9]{4})|BCMG|TEMPO)
        public TafTimeSpan TafTimeSpan { get; set; }

        public int? TafProbability { get; set; }

        public Metar Metar { get; set; }
    }
}
