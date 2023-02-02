using MetarSharp.Exceptions;
using static MetarSharp.Parser.Helpers;

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
        public static List<Metar> FromList(List<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.Parse(cleanedInput.ToList());
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

        public static string ToString(Metar metar)
        {
            return Parser.ParseToString.Parse(metar);
        }

        public static List<string> ToStringList(List<Metar> metars)
        {
            return Parser.ParseToStringList.Parse(metars);
        }
    }
}
