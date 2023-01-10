namespace MetarSharp.Extensions
{
    internal class Extensions
    {
        internal static double ReturnSetUnit(TimeSpan timeSpan, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => timeSpan.TotalSeconds,
            TimeUnit.Minutes => timeSpan.TotalMinutes,
            TimeUnit.Hours => timeSpan.TotalHours,
            TimeUnit.Days => timeSpan.TotalDays,
            TimeUnit.Weeks => timeSpan.TotalDays / 7
        };

        internal enum UnitType
        {
            Long,
            Short
        }

        internal static string ReturnUnitString(TimeUnit timeUnit, UnitType unitType)
        {
            if (unitType == UnitType.Short)
            {
                return timeUnit switch
                {
                    TimeUnit.Seconds => "s",
                    TimeUnit.Minutes => "m",
                    TimeUnit.Hours => "h",
                    TimeUnit.Days => "d",
                    TimeUnit.Weeks => "w"
                };
            }

            //TODO single value (second)
            return timeUnit switch
            {
                TimeUnit.Seconds => "seconds",
                TimeUnit.Minutes => "minutes",
                TimeUnit.Hours => "hours",
                TimeUnit.Days => "days",
                TimeUnit.Weeks => "weeks"
            };
            
        }

        internal static string TimeValueSingularOrPlural(int value, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => value > 1 ? "seconds" : "second",
            TimeUnit.Minutes => value > 1 ? "minutes" : "minute",
            TimeUnit.Hours => value > 1 ? "hours" : "hour",
            TimeUnit.Days => value > 1 ? "days" : "day",
            TimeUnit.Weeks => value > 1 ? "weeks" : "week"
        };
    }
}