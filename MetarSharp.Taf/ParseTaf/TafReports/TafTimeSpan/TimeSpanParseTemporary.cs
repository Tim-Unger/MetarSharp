using static MetarSharp.Taf.TimeSpanTypeEnum;

namespace MetarSharp.Taf.Parse.TimeSpan { 
    internal class TimeSpanTemporary
    {
        internal static MetarSharp.Taf.TafTimeSpan Parse(GroupCollection groups)
        {
            var timeSpan = new MetarSharp.Taf.TafTimeSpan();

            timeSpan.TimeSpanType = TimeSpanType.Temporary;

            timeSpan.TimeSpanRaw = groups[0].Value;

            var (startDay, startHour, startDate) = TimeSpanStartDate.Parse(groups, DateType.Tempo);

            timeSpan.StartDay = startDay;
            timeSpan.StartHour = startHour;
            timeSpan.StartDateTime = startDate;

            timeSpan.HasEndDate = true;

            var (endDay, endHour, endDate) = TimeSpanEndDate.Parse(groups, DateType.Tempo);

            timeSpan.EndDay = endDay;
            timeSpan.EndHour = endHour;
            timeSpan.EndDateTime = endDate;

            timeSpan.ValidityDuration = endDate - startDate;

            return timeSpan;
        }
    }
}
