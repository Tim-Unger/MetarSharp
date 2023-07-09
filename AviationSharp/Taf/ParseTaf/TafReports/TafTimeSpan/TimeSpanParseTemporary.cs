using static AviationSharp.Taf.TimeSpanTypeEnum;

namespace AviationSharp.Taf.Parse.TimeSpan { 
    internal class TimeSpanTemporary
    {
        internal static AviationSharp.Taf.TafTimeSpan Parse(GroupCollection groups)
        {
            var timeSpan = new AviationSharp.Taf.TafTimeSpan();

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
