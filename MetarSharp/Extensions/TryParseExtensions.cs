namespace MetarSharp.Extensions
{
    public class TryParseExtensions
    {
        /// <summary>
        /// Parses string to an int and throws if the parse fails
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the parsed int otherwise throws</returns>
        /// <exception cref="ParseException"></exception>
        public static int IntTryParseWithThrow(string value)
        {
            return int.TryParse(value, out var converted) ? converted : throw new ParseException($"Could not convert value {value} to number");
        }

        /// <summary>
        /// Parses string to a double and throws if the parse fails
        /// </summary>
        /// <param name="value"></param>
        /// <returns>the parsed double, otherwise throws</returns>
        /// <exception cref="ParseException"></exception>
        public static double DoubleTryParseWithThrow(string value)
        {
            return double.TryParse(value, out var converted) ? converted : throw new ParseException($"Could not convert value {value} to number");
        }
    }
}
