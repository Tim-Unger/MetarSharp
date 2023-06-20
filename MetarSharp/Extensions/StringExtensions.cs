namespace MetarSharp
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parses the Metar from a string
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static Metar ParseMetar(this string raw) => MetarSharp.ParseMetar.FromString(raw);

        /// <summary>
        /// Tries to parse a string to a Metar otherwise throws
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static Metar TryParseMetar(this string raw)
        {
            try
            {
                return MetarSharp.ParseMetar.FromString(raw);
            }
            catch (ParseException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Whether a string is a valid Metar, returns false if it is not
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static bool IsValidMetar(this string raw) => MetarValidity.IsValid(raw);
    }
}
