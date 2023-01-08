using MetarSharp.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            RemoveEmptyEntriesFromCollection(input);

            return FromList.Parse(input);
        }

        public static Metar[] ParseFromArray(string[] input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new Exception();
            }

            RemoveEmptyEntriesFromCollection(input);

            return FromArray.Parse(input);
        }

        public static IEnumerable<Metar> ParseFromCollection<T>(T input)
        {
            if(IsEntireCollectionNullOrEmpty(input))
            {
                throw new Exception();
            }

            RemoveEmptyEntriesFromCollection(input);

            return FromCollection.Parse(input);
        }
    }
}
