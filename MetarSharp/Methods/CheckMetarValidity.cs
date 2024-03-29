﻿namespace MetarSharp
{
    public static class MetarValidity
    {
        private static readonly Regex _validityRegex = new("[A-Z]{4}\\s[0-9]{5,6}Z");

        public static bool IsValid(string raw) => _validityRegex.IsMatch(raw);

        public static bool AreAllValid(IEnumerable<string> raw) => raw.All(x => IsValid(x));

        public static List<bool> AreValidIndividually(IEnumerable<string> raw) =>
            raw.Select(x => IsValid(x))
            .ToList();

        public static List<(bool isValid, string rawMetar)> CheckWithMetars(IEnumerable<string> raw)
        {
            var tuples = new List<(bool, string)>();

            raw.ToList().ForEach(x => tuples.Add((IsValid(x), x)));

            return tuples;
        }

        public static List<string> ShowInvalid(IEnumerable<string> raw) =>
            CheckWithMetars(raw)
            .Where(x => !x.isValid)
            .Select(x => x.rawMetar)
            .ToList();

        public static List<string> RemoveInvalid(IEnumerable<string> raw) =>
            CheckWithMetars(raw)
            .Where(x => x.isValid)
            .Select(x => x.rawMetar)
            .ToList();

        /// <summary>
        /// Tries to parse a string to a Metar otherwise throws
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static Metar TryParseMetar(string raw)
        {
            try
            {
                return ParseMetar.FromString(raw);
            }
            catch (ParseException ex)
            {
                throw ex;
            }
        }
    }
}
