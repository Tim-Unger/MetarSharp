using static AviationSharp.Taf.TimeSpanTypeEnum;

namespace AviationSharp.Taf
{
    public class TafTimeSpan
    {
        public TimeSpanType TimeSpanType { get; set; }

        public string TimeSpanRaw { get; set; }

        public int StartDay { get; set; }

        public int StartHour { get; set; }

        public int? StartMinute { get; set; }

        public DateTime StartDateTime { get; set; }

        public bool HasEndDate { get; set; } = true;

        public int? EndDay { get; set; }

        public int? EndHour { get; set; }

        public DateTime? EndDateTime { get; set; }

        public TimeSpan? ValidityDuration { get; set; }
    }
}
