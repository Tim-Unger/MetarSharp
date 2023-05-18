using MetarSharp.Exceptions;

namespace MetarSharp.Extensions
{
    internal class Helpers
    {
        #region TIME

        /// <summary>
        /// returns the correct value of the elapsed time, depending on how many time is elapsed
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="timeUnit"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static string TimeValueSingularOrPlural(int value, TimeUnit timeUnit) => timeUnit switch
        {
            TimeUnit.Seconds => value > 1 ? "seconds" : "second",
            TimeUnit.Minutes => value > 1 ? "minutes" : "minute",
            TimeUnit.Hours => value > 1 ? "hours" : "hour",
            TimeUnit.Days => value > 1 ? "days" : "day",
            TimeUnit.Weeks => value > 1 ? "weeks" : "week",
            _ => throw new ParseException()
        };


        /// <summary>
        /// returns the correct value of the elapsed time, depending on how many time is elapsed
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <returns></returns>
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
        #endregion

        #region DISTANCE

        /// <summary>
        /// returns distance in either singular or plural depending on the value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="visibilityUnit"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static string DistanceValueSingularOrPlural(double value, VisibilityUnit visibilityUnit) => visibilityUnit switch
        {
            VisibilityUnit.Meters => value > 1 ? "Meters" : "Meter",
            VisibilityUnit.Kilometers => value > 1 ? "Kilometer" : "Kilometers",
            VisibilityUnit.Miles => value > 1 ? "Miles" : "Mile",
            _ => throw new ParseException()
        };
        #endregion

        #region TRYPARSE
        /// <summary>
        /// Parses string to an int and throws if the parse fails
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static int IntTryParseWithThrow(string value)
        {
            return int.TryParse(value, out var converted) ? converted : throw new ParseException($"Could not convert value {value} to number");
        }

        /// <summary>
        /// Parses string to a double and throws if the parse fails
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static double DoubleTryParseWithThrow(string value)
        {
            return double.TryParse(value, out var converted) ? converted : throw new ParseException($"Could not convert value {value} to number");
        }
        #endregion

        #region NULLCHECKS
        /// <summary>
        /// This checks if the the input string is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static bool IsStringNullOrEmpty(string input) => input == null || input == string.Empty || input == "" || string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// This checks whether an entire collection is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static bool IsEntireCollectionNullOrEmpty<T>(T input)
        {
            return input == null || input as IEnumerable<T> == Enumerable.Empty<T>();
        }

        /// <summary>
        /// This will remove all entries from a collection which are null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static IEnumerable<string> RemoveEmptyEntriesFromCollection<T>(T input)
        {
            var convertedInput = input as IEnumerable<string> ?? throw new ParseException();
            var cleanedInput = convertedInput.Where(x => IsStringNullOrEmpty(x) == false);

            return cleanedInput;
        }
        #endregion
    }
}