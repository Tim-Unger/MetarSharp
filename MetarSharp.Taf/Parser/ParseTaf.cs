using MetarSharp.Exceptions;
using static MetarSharp.Extensions.NullCheckExtensions;

namespace MetarSharp.Taf.Parser
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
