using MetarSharp.Exceptions;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    internal class ParseAirport
    {
        public static string ReturnAirport(string raw)
        {
            Regex airportRegex = new Regex(@"^([A-Z]{4})\s", RegexOptions.None);

            MatchCollection airportMatches = airportRegex.Matches(raw);
                

            if (airportMatches.Count == 1)
            {
                return airportMatches[0].Groups[1].Value;
            }

            StackTrace trace = new StackTrace(new StackFrame(true));
            StackFrame stack = trace.GetFrame(0);
            throw new ParseException($"Parse failed in: {stack.GetFileName()} at {stack.GetFileLineNumber() + 1}");
        } 
    }
}
