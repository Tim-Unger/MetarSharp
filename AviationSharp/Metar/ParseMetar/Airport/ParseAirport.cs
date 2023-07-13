namespace AviationSharp.Metar.Parse
{
    internal class ParseAirport
    {
        private static readonly Regex _airportRegex = new(@"^([A-Z]{4})\s");

        /// <summary>
        /// This returns the airport part of the metar.
        /// As the airport is always present, this can never be null and always has to be returned
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static string ReturnAirport(string raw) => _airportRegex.Match(raw).Groups[1].Value ?? throw new ParseException("Airport could not be found");
    }

    public class ParseAirportOnly
    {
        public static string FromString(string raw) => ParseAirport.ReturnAirport(raw);
    }
}
