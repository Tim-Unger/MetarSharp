using MetarSharp.Exceptions;

namespace MetarSharp.Extensions
{
    internal class TimeExtensions

    {
        /// <summary>
        /// returns the correct value of the elapsed time, depending on how many time is elapsed
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="timeUnit"></param>
        /// <returns>double</returns>
        /// <exception cref="ParseException"></exception>
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

        /// <summary>
        /// returns the correct short unit string, depending on what time unit you want
        /// </summary>
        /// <param name="timeUnit"></param>
        /// <param name="unitType"></param>
        /// <param name="value"></param>
        /// <returns>the time unit as a short single letter or fully written out either in singular or plural</returns>
        /// <exception cref="ParseException"></exception>
        internal static string ReturnUnitString(TimeUnit timeUnit, UnitType unitType, int value)
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

            return TimeValueSingularOrPlural(value, timeUnit);

        }

        /// <summary>
        ///  returns time in either singular or plural depending on the value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="timeUnit"></param>
        /// <returns>the time unit written out either in singular or plural</returns>
        /// <exception cref="ParseException"></exception>
        internal static string TimeValueSingularOrPlural(int value, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => value > 1 ? "seconds" : "second",
            TimeUnit.Minutes => value > 1 ? "minutes" : "minute",
            TimeUnit.Hours => value > 1 ? "hours" : "hour",
            TimeUnit.Days => value > 1 ? "days" : "day",
            TimeUnit.Weeks => value > 1 ? "weeks" : "week",
            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// returns the correct value of the elapsed time, depending on how much time is elapsed
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <returns>int of the highest elapsed time</returns>
        internal static int GetCorrectTimeValue(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds <= 60)
            {
                return elapsedTime.Seconds;
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return elapsedTime.Minutes;
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return elapsedTime.Hours;
            }

            return elapsedTime.Days;
        }
    }
}
