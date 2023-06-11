namespace MetarSharp.Parse
{
    internal class ParseVisibility
    {
        private static readonly Regex _visibilityRegex = new(@"(\s([0-9]{4})(?:\s|$)(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(\s((([0-9]{1,2})|(M)?([0-9]/[0-9](?>[0-9])?))(SM|KM))\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s");

        internal static Visibility ReturnVisibility(string raw)
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
                return ParseFromMeter.ParseVisibility(groups);
            }

            if (groups[12].Value == "SM")
            {
                return ParseFromMiles.ParseVisibility(groups);
            }

            if (groups[12].Value == "KM")
            {
                return ParseFromKilometer.ParseVisibility(groups);
            }

            //This also covers the //// case
            return new Visibility { IsVisibilityMeasurable = false };
        }
    }
}
