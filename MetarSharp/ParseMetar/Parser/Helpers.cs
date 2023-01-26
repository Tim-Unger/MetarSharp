using MetarSharp.Exceptions;

namespace MetarSharp.Parser
{
    internal class Helpers
    {
        /// <summary>
        /// This checks if the the input string is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static bool IsStringNullOrEmpty(string input)
        {
            return input == null || input == string.Empty || input == "" || string.IsNullOrWhiteSpace(input);
        }

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
            var convertedInput = input as IEnumerable<string>;

            if(convertedInput == null)
            {
                throw new ParseException();
            }

            var cleanedInput = convertedInput.Where(x => IsStringNullOrEmpty(x) == false);

            return cleanedInput;
        }
    }
}
