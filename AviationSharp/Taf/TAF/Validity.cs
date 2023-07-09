namespace AviationSharp.Taf
{
    public class Validity
    {
        public string ValidityRaw { get; set; }

        public string StartWindowRaw { get; set; }

        public int StartDay { get; set; }

        public int StartHour { get; set; }

        public DateTime StartDateTime { get; set; }

        public string EndWindowRaw { get; set; }

        public int EndDay { get; set; }

        public int EndHour { get; set; }

        public DateTime EndDateTime { get; set; }

        public TimeSpan ValidityDuration { get; set; }
    }
}
