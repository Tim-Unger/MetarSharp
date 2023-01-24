using MetarSharp.Exceptions;
using static MetarSharp.Parser.Helpers;

namespace MetarSharp
{
    public class ParseMetar
    {
        public static Metar FromString(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromString.Parse(input);
        }

        public static Metar FromLink(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromLink.Parse(input);
        }

        public static List<Metar> FromList(List<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromList.Parse(cleanedInput.ToList());
        }

        public static Metar[] FromArray(string[] input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromArray.Parse(cleanedInput.ToArray());
        }

        public static IEnumerable<Metar> FromCollection(IEnumerable<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new ParseException();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return Parser.FromCollection.Parse(cleanedInput);
        }
    }
}
