namespace MetarSharp.Extensions
{
    public class NullCheckExtensions
    {
        /// <summary>
        /// This checks if the the input string is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns>whether the string is null/empty/only whitespace</returns>
        public static bool IsStringNullOrEmpty(string input) => input is null || input == string.Empty || input == "" || string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// This checks whether an entire collection is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns>whether the entire collection null or empty</returns>
        public static bool IsEntireCollectionNullOrEmpty<T>(T input)
        {
            return input is null || input as IEnumerable<T> == Enumerable.Empty<T>();
        }

        /// <summary>
        /// This will remove all entries from a collection which are null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns>the given collection without any empty entries</returns>
        public static IEnumerable<string> RemoveEmptyEntriesFromCollection<T>(T input)
        {
            var convertedInput = input as IEnumerable<string> ?? throw new ParseException();
            var cleanedInput = convertedInput.Where(x => IsStringNullOrEmpty(x) == false);

            return cleanedInput;
        }
    }
}
