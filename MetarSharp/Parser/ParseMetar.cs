using System.Text.Json;
using static MetarSharp.Extensions.NullCheckExtensions;

namespace MetarSharp
{
    public partial class ParseMetar
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
        /// this is the class that parses a metar from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar FromString(string input, MetarParser parser)
        {
            if (IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromString.Parse(input, parser);
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
        /// this parses a metar from a link
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar FromLink(string input, MetarParser parser)
        {
            if (IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromLink.Parse(input, parser);
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
        /// this parses the metar from a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static List<Metar> FromList(IEnumerable<string> input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.Parse(cleanedInput.ToList(), parser);
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
        /// this parses the metar from a list parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static List<Metar> FromListParallel(IEnumerable<string> input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.ParseParallel(cleanedInput.ToList(), parser);
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
        /// this parses the metar from an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar[] FromArray(string[] input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromArray.Parse(cleanedInput.ToArray(), parser);
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
        /// this parses the metar from an array parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar[] FromArrayParallel(string[] input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromArray.ParseParallel(cleanedInput.ToArray(), parser);
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
        /// this parses the metar from any enumerable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static IEnumerable<Metar> FromCollection(IEnumerable<string> input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromCollection.Parse(cleanedInput, parser);
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

        /// <summary>
        /// This parses the metar from any IEnumerable Parallel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<Metar> FromCollectionParallel(IEnumerable<string> input, MetarParser parser)
        {
            if (IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromCollection.ParseParallel(cleanedInput, parser);
        }

        //TODO
        public static string ToString(Metar metar)
        {
            return Parser.ParseToString.Parse(metar);
        }

        //TODO
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

        /// <summary>
        /// Parses the given Metar into a JSON with JsonSerializer Options
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        public static string ToJson(Metar metar, JsonSerializerOptions options) => Parser.ToJson.Parse(metar, options);

        /// <summary>
        /// Parses the given Metar from a string into a JSON
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        public static string ToJson(string metar) => Parser.ToJson.Parse(metar, null);

        /// <summary>
        /// Parses the given Metar from a string into a JSON with JsonSerializer Options
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        public static string ToJson(string metar, JsonSerializerOptions options) => Parser.ToJson.Parse(metar, options);

        /// <summary>
        /// Parses the given Metars into a JSON-List
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static List<string> ToJsonList(IEnumerable<Metar> metars) => Parser.ToJsonList.Parse(metars, null);

        /// <summary>
        /// Parses the given Metars into a JSON-List with JsonSerializer Options
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static List<string> ToJsonList(IEnumerable<Metar> metars, JsonSerializerOptions options) => Parser.ToJsonList.Parse(metars, options);

        /// <summary>
        /// Parses the given Metars into a JSON-List from a list of strings
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static List<string> ToJsonList(IEnumerable<string> metars) => Parser.ToJsonList.Parse(metars, null);

        /// <summary>
        /// Parses the given Metars into a JSON-List from a list of strings with JsonSerializer Options
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static List<string> ToJsonList(IEnumerable<string> metars, JsonSerializerOptions options) => Parser.ToJsonList.Parse(metars, options);

        /// <summary>
        /// Parses the given Metars into a single JSON-String
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static string ListToSingleJsonString(IEnumerable<Metar> metars) => Parser.ToJsonList.ParseToString(metars);

        /// <summary>
        /// Parses the given Metars into a single JSON-String from a list of strings
        /// </summary>
        /// <param name="metars"></param>
        /// <returns></returns>
        public static string ListToSingleJsonString(IEnumerable<string> metars) => Parser.ToJsonList.ParseToString(metars);
    }
}
