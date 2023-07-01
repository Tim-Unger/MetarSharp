using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace MetarSharp
{
    public static class CollectionExtensions
    {
        public static List<Metar> ParseMetars(this IEnumerable<string> raw) =>
            ParseMetar.FromList(raw);

        public static List<Metar> ParseMetarsParallel(this IEnumerable<string> raw) =>
            ParseMetar.FromListParallel(raw);

        //TODO async extension methods
        //public static async Task<List<Metar>> ParseMetarsAsync(this IEnumerable<string> raw) => ParseMetar.FromList(raw);

        public static bool TryParseAllMetars(this IEnumerable<string> raw, out List<Metar> metars)
        {
            try
            {
                var metarsTemp = new List<Metar>();

                Parallel.ForEach(raw, x => metarsTemp.Add(ParseMetar.FromString(x)));
                metars = metarsTemp;

                return true;
            }
            catch
            {
                metars = Enumerable.Empty<Metar>().ToList();
                return false;
            }
        }

        public static bool AreAllMetarsValid(this IEnumerable<string> raw) =>
            MetarValidity.AreAllValid(raw);

        public static List<string> ShowInvalidMetars(this IEnumerable<string> raw) =>
            MetarValidity.ShowInvalid(raw);

        public static List<string> RemoveInvalidMetars(this IEnumerable<string> raw) =>
            MetarValidity.RemoveInvalid(raw);

        public static List<(bool isValid, string rawMetar)> CheckWithMetars(this IEnumerable<string> raw) => MetarValidity.CheckWithMetars(raw);

        public static List<bool> AreMetarsValidIndividually(this IEnumerable<string> raw) => MetarValidity.AreValidIndividually(raw);

        public static List<string> ConvertToJson(this IEnumerable<string> raw) => raw.Select(x => ParseMetar.ToJson(ParseMetar.FromString(x))).ToList();

        public static List<string> ConvertToJson(this IEnumerable<Metar> raw) => raw.Select(x => ParseMetar.ToJson(x)).ToList();

        public static List<string> ConvertToJsonParallel(this IEnumerable<string> raw)
        {
            var result = new List<string>();

            var readonlyRaw = raw.ToImmutableList();

            Parallel.ForEach(readonlyRaw, x => result.Add(ParseMetar.ToJson(ParseMetar.FromString(x))));

            return result;
        }

        public static List<string> ConvertToJsonParallel(this IEnumerable<Metar> raw)
        {
            var result = new List<string>();

            var readonlyRaw = raw.ToImmutableList();

            Parallel.ForEach(readonlyRaw, x => result.Add(ParseMetar.ToJson(x)));

            return result;
        }
    }
}
