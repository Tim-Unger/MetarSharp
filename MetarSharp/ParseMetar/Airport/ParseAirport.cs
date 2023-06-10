namespace MetarSharp.Parse
{
    internal class ParseAirport
    {
        /// <summary>
        /// This returns the airport part of the metar.
        /// As the airport is always present, this can never be null and always has to be returned
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
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
