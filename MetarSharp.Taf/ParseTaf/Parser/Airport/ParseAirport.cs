using MetarSharp.Exceptions;
using System.Text.RegularExpressions;

namespace MetarSharp.Taf.Parse
{
    internal class ParseAirport
    {
        internal static string ReturnAirport(string raw)
        {

            var airportRegex = new Regex(@"^([A-Z]{4})\s", RegexOptions.None);

            var airportMatches = airportRegex.Matches(raw);

            if (airportMatches.Count != 1)
            {
                throw new ParseException("Airport could not be found");
            }

            return airportMatches[0].Groups[1].Value;
        }
    }
}
