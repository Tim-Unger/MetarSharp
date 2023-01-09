namespace MetarSharp.Parser
{
    internal class Helpers
    {
        internal static bool IsStringNullOrEmpty(string input)
        {
            return input == null || input == String.Empty || input == "" || String.IsNullOrWhiteSpace(input);
        }

        internal static bool IsEntireCollectionNullOrEmpty<T>(T input)
        {
            return input == null || input as IEnumerable<T> == Enumerable.Empty<T>();
        }

        internal static IEnumerable<string> RemoveEmptyEntriesFromCollection<T>(T input)
        {

            var convertedInput = input as IEnumerable<string>;

            var cleanedInput = convertedInput.Where(x => IsStringNullOrEmpty(x) == false);

            return  cleanedInput as IEnumerable<string>;
        }
    }
}
