using static MetarSharp.Taf.TimeSpanTypeEnum;
using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Taf.Parse.TimeSpan
{
    internal class TimeSpanFrom
    {
        internal static MetarSharp.Taf.TafTimeSpan Parse(GroupCollection groups)
        {
            var timeSpan = new MetarSharp.Taf.TafTimeSpan();

            timeSpan.TimeSpanType = TimeSpanType.From;

            timeSpan.TimeSpanRaw = groups[0].Value;

            var timeValues = groups[3].Value;

            var day = IntTryParseWithThrow(timeValues.Substring(0, 2));
            var hour = IntTryParseWithThrow(timeValues.Substring(2, 2));
            var minute = IntTryParseWithThrow(timeValues.Substring(4, 2));

            timeSpan.StartDay = day;
            timeSpan.StartHour = hour;
            timeSpan.StartMinute = minute;

            var now = DateTime.UtcNow;

            var dateValues = ParseReportingTime.GetDateValues(day, now.Day, now.Month, now.Year);

            timeSpan.StartDateTime = new DateTime(
                dateValues.Year,
                dateValues.Month,
                day,
                hour,
                minute,
                00
            );

            timeSpan.HasEndDate = false;

            return timeSpan;
        }
    }
}
