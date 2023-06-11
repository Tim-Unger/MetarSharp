namespace MetarSharp
{
    public static class CollectionExtensions
    {
        public static List<Metar> ParseMetars(this IEnumerable<string> raw) =>
            ParseMetar.FromList(raw);

        public static List<Metar> ParseMetarsParallel(this IEnumerable<string> raw) =>
            ParseMetar.FromListParallel(raw);

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
    }
}
