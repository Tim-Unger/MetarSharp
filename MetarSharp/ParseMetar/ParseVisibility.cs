using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseVisibility
    {
        public static Visibility ReturnVisibility(string raw)
        {
            Visibility visibility = new Visibility();

            Regex VisibilityRegex = new Regex(
                @"([0-9]{4})\s(?:([0-9]{4}))(?:(N|NE|E|SE|S|SW|W|NW))",
                RegexOptions.None
            );

            return visibility;
        }
    }
}
