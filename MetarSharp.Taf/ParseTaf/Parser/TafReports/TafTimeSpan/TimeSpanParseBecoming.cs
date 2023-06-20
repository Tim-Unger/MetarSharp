using static MetarSharp.Taf.TimeSpanTypeEnum;
using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Taf.Parse.TimeSpan
{
    internal class TimeSpanBecoming
    {
        internal static MetarSharp.Taf.TafTimeSpan Parse(GroupCollection groups)
        {
            var timeSpan = new MetarSharp.Taf.TafTimeSpan();

            timeSpan.TimeSpanType = TimeSpanType.Becoming;

            timeSpan.TimeSpanRaw = groups[0].Value;

            var startTimeValues = groups[5].Value;

            var startDay = IntTryParseWithThrow(startTimeValues.Substring(0, 2));
            var startHour = IntTryParseWithThrow(startTimeValues.Substring(2, 2));
            var startMinute = 0;

            if(startHour == 24)
            {
                startHour = 23;
                startMinute = 59;
            }

            timeSpan.StartDay = startDay;
            timeSpan.StartHour = startHour;

            var now = DateTime.UtcNow;

            var startDateValues = ParseReportingTime.GetDateValues(startDay, now.Day, now.Month, now.Year);

            var startTime = new DateTime(
                startDateValues.Year,
                startDateValues.Month,
                startDay,
                startHour,
                startMinute,
                00
            );

            timeSpan.StartDateTime = startTime;

            timeSpan.HasEndDate = true;

            var endTimeValues = groups[6].Value;

            var endDay = IntTryParseWithThrow(endTimeValues.Substring(0, 2));
            var endHour = IntTryParseWithThrow(endTimeValues.Substring(2,2));
            var endMinute = 0;

            timeSpan.EndDay = endDay;
            timeSpan.EndHour = endHour;

            if(endHour == 24)
            {
                endHour = 23;
                endMinute = 59;
            }

            var endDateValues = ParseReportingTime.GetDateValues(endDay, now.Day, now.Month, now.Year);

            var endTime = new DateTime(
                endDateValues.Year,
                endDateValues.Month,
                endDay,
                endHour,
                endMinute,
                00
            );

            timeSpan.EndDateTime = endTime;

            timeSpan.ValidityDuration = endTime - startTime;

            return timeSpan;
        }
    }
}
