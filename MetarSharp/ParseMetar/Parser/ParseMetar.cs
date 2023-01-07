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
        public static Metar ParseFromString(string metar)
        {
            if(IsStringNullOrEmpty(metar))
            {
                throw new Exception();
            }

            return FromString.Parse(metar);
        }

        public static Metar ParseFromLink(string link)
        {
            if(IsStringNullOrEmpty(link))
            {
                throw new Exception();
            }

            return FromLink.Parse(link);
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
    }
}
