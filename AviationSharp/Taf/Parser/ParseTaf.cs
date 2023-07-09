using AviationSharp.Metar.Exceptions;
using static AviationSharp.Metar.Extensions.NullCheckExtensions;

namespace AviationSharp.Taf.Parser
{
    public class ParseTaf
    {
        public static Taf FromString(string input)
        {
            if (IsStringNullOrEmpty(input))
            {
                throw new ParseException();
            }

            return Parser.FromString.Parse(input);
        }
    }
}
