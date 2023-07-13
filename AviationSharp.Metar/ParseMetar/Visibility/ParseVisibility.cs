namespace MetarSharp.Parse
{
    internal class ParseVisibility
    {
        private static readonly Regex _visibilityRegex = new(@"(\s([0-9]{4})(?:\s|$)(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(\s((([0-9]{1,2})|(M)?([0-9]/[0-9](?>[0-9])?))(SM|KM))\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s");

        internal static Visibility ReturnVisibility(string raw, MetarParser? parser)
        {
            MatchCollection matches = _visibilityRegex.Matches(raw);

            if (matches.Count == 0)
            {
                if (Regex.IsMatch(raw, @"\sAUTO\s") || Regex.IsMatch(raw, @"\sCAVOK\s"))
                {
                    return new Visibility()
                    {
                        IsVisibilityMeasurable = true,
                        ReportedVisibility = 9999,
                        VisibilityRaw = "9999",
                        VisibilityUnitRaw = "M"
                    };
                }

                throw new ParseException("Could not find Visibility");
            }

            GroupCollection groups = matches[0].Groups;
            if (groups[2].Success)
            {
                return ParseFromMeter.ParseVisibility(groups, parser ?? null);
            }

            if (groups[12].Value == "SM")
            {
                return ParseFromMiles.ParseVisibility(groups, parser ?? null);
            }

            if (groups[12].Value == "KM")
            {
                return ParseFromKilometer.ParseVisibility(groups, parser ?? null);
            }

            //This also covers the //// case
            return new Visibility { IsVisibilityMeasurable = false };
        }
    }

    /// <summary>
    /// Public extension to the ParseVisibility Class to access the Method from outside the namespace
    /// </summary>
    public class ParseVisibilityOnly
    {
        public static Visibility FromString(string raw) => ParseVisibility.ReturnVisibility(raw, null);
    }
}
