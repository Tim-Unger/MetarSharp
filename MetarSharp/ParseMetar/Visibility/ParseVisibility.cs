namespace MetarSharp.Parse
{
    internal class ParseVisibility
    {
        private static readonly Regex _visibilityRegex = new(@"(\s(P|M)?(?>\s)?([0-9]{4})(?:\s|$)(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|(((P|M)?(?>\s)?(([0-9]{1,2})(?>\s)?|((\d{1}\s)?([0-9]/[0-9](?>[0-9])?(?>\s)?)))(SM|KM))\s(([0-9]{4})(N|NE|E|SE|S|SW|W|NW))?)|\s(////)\s");

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

            var visibility = new Visibility();
            
            if (groups[3].Success)
            {
                //Visibility contains a P or M indicator
                if (groups[2].Success)
                {
                    visibility.IsVisibilityMoreOrLess = true;
                    
                    visibility.VisibilityMoreOrLessRaw = groups[2].Value;
                    
                    visibility.VisibilityMoreOrLessType = groups[2].Value switch
                    {
                        "P" => MoreOrLessType.More,
                        "M" => MoreOrLessType.Less,
                        _ => null
                    };
                    
                    visibility.VisibilityMoreOrLessDecoded = groups[2].Value switch
                    {
                        "P" => "More",
                        "M" => "Less",
                        _ => null
                    };
                }
                
                return ParseFromMeter.ParseVisibility(visibility, groups, parser ?? null);
            }

            if (groups[15].Value is "SM" or "KM")
            {
                //Visibility contains a P or M indicator
                if (groups[9].Success)
                {
                    visibility.IsVisibilityMoreOrLess = true;
                    
                    visibility.VisibilityMoreOrLessRaw = groups[9].Value;
                    
                    visibility.VisibilityMoreOrLessType = groups[9].Value switch
                    {
                        "P" => MoreOrLessType.More,
                        "M" => MoreOrLessType.Less,
                        _ => null
                    };
                    
                    visibility.VisibilityMoreOrLessDecoded = groups[9].Value switch
                    {
                        "P" => "More",
                        "M" => "Less",
                        _ => null
                    };
                    
                    //visibility.VisibilityMoreOrLessValue = int.TryParse()
                }
                return ParseFromMiles.ParseVisibility(visibility, groups, parser ?? null);
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
