using static AviationSharp.Metar.Extensions.TryParseExtensions;

namespace AviationSharp.Taf.Parse.TimeSpan
{
    internal class TimeSpanEndDate
    {
        internal static (int day, int hour, DateTime endDate) Parse(GroupCollection groups, DateType dateType)
        {
            var groupIndex = dateType switch
            {
                DateType.Probability => 5,
                DateType.Becoming => 10,
                DateType.Tempo => 13,
                _ => throw new ArgumentOutOfRangeException()
            };

            var endTimeValues = groups[groupIndex].Value;

            var day = IntTryParseWithThrow(endTimeValues.Substring(0, 2));
            var hour = IntTryParseWithThrow(endTimeValues.Substring(2, 2));
            var minute = 0;

            if (hour == 24)
            {
                hour = 23;
                minute = 59;
            }

            var now = DateTime.UtcNow;

            var endDateValues = ParseReportingTime.GetDateValues(day, now.Day, now.Month, now.Year);

            var endTime = new DateTime(
                endDateValues.Year,
                endDateValues.Month,
                day,
                hour,
                minute,
                00
            );

            return (day, hour, endTime);
        }
    }
}
