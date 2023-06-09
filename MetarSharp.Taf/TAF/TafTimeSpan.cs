﻿using static MetarSharp.Taf.TimeSpanTypeEnum;

namespace MetarSharp.Taf
{
    public class TafTimeSpan
    {
        public TimeSpanType TimeSpanType { get; set; }

        public string TimeSpanRaw { get; set; }

        public int StartDay { get; set; }

        public int StartHour { get; set; }

        public DateTime StartDateTime { get; set; }

        public int EndDay { get; set; }

        public int EndHour { get; set; }

        public DateTime EndDateTime { get; set; }

        public int ValidityDuration { get; set; }
    }
}
