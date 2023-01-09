using MetarSharp.Parser;
using static MetarSharp.Parser.Helpers;

namespace MetarSharp
{
    public class ParseMetar
    {
        public static Metar ParseFromString(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new Exception();
            }

            return FromString.Parse(input);
        }

        public static Metar ParseFromLink(string input)
        {
            if(IsStringNullOrEmpty(input))
            {
                throw new Exception();
            }

            return FromLink.Parse(input);
        }

        public static List<Metar> ParseFromList(List<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new Exception();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return FromList.Parse(cleanedInput.ToList());
        }

        public static Metar[] ParseFromArray(string[] input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new Exception();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return FromArray.Parse(cleanedInput.ToArray());
        }

        public static IEnumerable<Metar> ParseFromCollection(IEnumerable<string> input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new Exception();
            }

            var cleanedInput = RemoveEmptyEntriesFromCollection(input);

            return FromCollection.Parse(cleanedInput);
        }
    }
}
