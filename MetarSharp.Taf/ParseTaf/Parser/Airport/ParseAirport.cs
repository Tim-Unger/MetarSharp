using MetarSharp.Exceptions;
using System.Text.RegularExpressions;

namespace MetarSharp.Taf.Parse
{
    internal class ParseAirport
    {
        private static readonly Regex _airportRegex = new(@"^([A-Z]{4})\s");

        internal static string ReturnAirport(string raw)
        {

            var airportMatches = _airportRegex.Matches(raw);

            if (airportMatches.Count != 1)
            {
                throw new ParseException("Airport could not be found");
            }

            return airportMatches[0].Groups[1].Value;
        }
    }
}
