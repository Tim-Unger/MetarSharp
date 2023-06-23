using System.Text.Json;
using static MetarSharp.Extensions.NullCheckExtensions;

namespace MetarSharp
{
    public class ParseMetar
    {
        /// <summary>
        /// this is the class that parses a metar from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar FromString(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromString.Parse(input);
        }

        /// <summary>
        /// this parses a metar from a link
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar FromLink(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromLink.Parse(input);
        }

        /// <summary>
        /// this parses the metar from a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static List<Metar> FromList(IEnumerable<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.Parse(cleanedInput.ToList());
        }

        /// <summary>
        /// this parses the metar from a list parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static List<Metar> FromListParallel(IEnumerable<string> input)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.ParseParallel(cleanedInput.ToList());
        }

        /// <summary>
        /// this parses the metar from an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar[] FromArray(string[] input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromArray.Parse(cleanedInput.ToArray());
        }

        /// <summary>
        /// this parses the metar from an array parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar[] FromArrayParallel(string[] input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromArray.ParseParallel(cleanedInput.ToArray());
        }

        /// <summary>
        /// this parses the metar from any enumerable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static IEnumerable<Metar> FromCollection(IEnumerable<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromCollection.Parse(cleanedInput);
        }

        /// <summary>
        /// This parses the metar from any IEnumerable Parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<Metar> FromCollectionParallel(IEnumerable<string> input)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromCollection.ParseParallel(cleanedInput);
        }

        public static string ToString(Metar metar)
        {
            return Parser.ParseToString.Parse(metar);
        }

        public static List<string> ToStringList(List<Metar> metars)
        {
            return Parser.ParseToStringList.Parse(metars);
        }

        /// <summary>
        /// Parses the given Metar into a JSON
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        public static string ToJson(Metar metar) => Parser.ToJson.Parse(metar, null);

        public static string ToJson(Metar metar, JsonSerializerOptions options) => Parser.ToJson.Parse(metar, options);

        public static string ToJson(string metar) => Parser.ToJson.Parse(metar, null);

        public static string ToJson(string metar, JsonSerializerOptions options) => Parser.ToJson.Parse(metar, options);

        public static List<string> ToJsonList(IEnumerable<Metar> metars) => Parser.ToJsonList.Parse(metars, null);

        public static List<string> ToJsonList(IEnumerable<Metar> metars, JsonSerializerOptions options) => Parser.ToJsonList.Parse(metars, options);

        public static List<string> ToJsonList(IEnumerable<string> metars) => Parser.ToJsonList.Parse(metars, null);
        
        public static List<string> ToJsonList(IEnumerable<string> metars, JsonSerializerOptions options) => Parser.ToJsonList.Parse(metars, options);

        public static string ListToSingleJsonString(IEnumerable<Metar> metars) => Parser.ToJsonList.ParseToString(metars);

        public static string ListToSingleJsonString(IEnumerable<string> metars) => Parser.ToJsonList.ParseToString(metars);
    }
}
