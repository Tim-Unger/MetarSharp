using MetarSharp.Exceptions;

namespace MetarSharp.Extensions
{
    //TODO Class name
    internal class Extensions
    {
        #region TIME
        internal static double ReturnSetUnit(TimeSpan timeSpan, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => timeSpan.TotalSeconds,
            TimeUnit.Minutes => timeSpan.TotalMinutes,
            TimeUnit.Hours => timeSpan.TotalHours,
            TimeUnit.Days => timeSpan.TotalDays,
            TimeUnit.Weeks => timeSpan.TotalDays / 7,
            _ => throw new ParseException()
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
                    TimeUnit.Weeks => "w",
                    _ => throw new ParseException()
                };
            }

            //TODO single value (second)
            return timeUnit switch
            {
                TimeUnit.Seconds => "seconds",
                TimeUnit.Minutes => "minutes",
                TimeUnit.Hours => "hours",
                TimeUnit.Days => "days",
                TimeUnit.Weeks => "weeks",
                _ => throw new ParseException()
            };
            
        }

        internal static string TimeValueSingularOrPlural(int value, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => value > 1 ? "seconds" : "second",
            TimeUnit.Minutes => value > 1 ? "minutes" : "minute",
            TimeUnit.Hours => value > 1 ? "hours" : "hour",
            TimeUnit.Days => value > 1 ? "days" : "day",
            TimeUnit.Weeks => value > 1 ? "weeks" : "week",
            _ => throw new ParseException()
        };

        #endregion

        #region DISTANCE

        internal static string DistanceValueSingularOrPlural(double value, VisibilityUnit visibilityUnit) => visibilityUnit switch
        {
            VisibilityUnit.Meters => value > 1 ? "Meters" : "Meter",
            VisibilityUnit.Kilometers => value > 1 ? "Kilometer" : "Kilometers",
            VisibilityUnit.Miles => value > 1 ? "Mile" : "Miles",
            _ => throw new ParseException()
        };
        #endregion
    }
}