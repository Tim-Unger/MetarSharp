using static AviationSharp.Metar.Extensions.TryParseExtensions;

namespace AviationSharp.Taf.Parse.TimeSpan
{
    internal enum DateType
    {
        Probability,
        Tempo,
        Becoming
    }

    internal class TimeSpanStartDate
    {
        internal static (int day, int hour, DateTime startDate) Parse(GroupCollection groups, DateType dateType)
        {
            var groupIndex = dateType switch
            {
                DateType.Probability => 4,
                DateType.Becoming => 9,
                DateType.Tempo => 12,
                _ => throw new ArgumentOutOfRangeException(nameof(dateType)),
            };

            var startTimeValues = groups[groupIndex].Value;

            var day = IntTryParseWithThrow(startTimeValues.Substring(0, 2));
            var hour = IntTryParseWithThrow(startTimeValues.Substring(2, 2));
            var minute = 0;

            if (hour == 24)
            {
                hour = 23;
                minute = 59;
            }

            var now = DateTime.UtcNow;

            var startDateValues = ParseReportingTime.GetDateValues(day, now.Day, now.Month, now.Year);

            var startDate = new DateTime(
                startDateValues.Year,
                startDateValues.Month,
                day,
                hour,
                minute,
                00
            );

            return (day, hour, startDate);
        }
    }
}
