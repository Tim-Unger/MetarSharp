using MetarSharp.Taf.Parse.TimeSpan;

namespace MetarSharp.Taf.Parse
{
    internal class TafTimeSpan
    {
        private static readonly Regex _timeSpanRegex = new(@"((PROB([0-9]{2})\s)?([0-9]{2}[0-9]{2})/([0-9]{2}[0-9]{2})|(FM)([0-9]{2}[0-9]{4})|(BCMG)\s([0-9]{2}[0-9]{2})/([0-9]{2}[0-9]{2})|(TEMPO)\s([0-9]{2}[0-9]{2})/([0-9]{2}[0-9]{2}))");

        internal static MetarSharp.Taf.TafTimeSpan? Parse(string raw)
        {
            GroupCollection groups = _timeSpanRegex.Match(raw).Groups ?? throw new ParseException();

            return groups[0].Value switch
            {
                string when groups[0].Value.StartsWith("FM") => TimeSpanFrom.Parse(groups),
                string when groups[0].Value.StartsWith("BCMG") => TimeSpanBecoming.Parse(groups),
                string when groups[0].Value.StartsWith("TEMPO") => TimeSpanTemporary.Parse(groups),
                string when groups[0].Value.StartsWith("PROB") => TimeSpanProb.Parse(groups),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
