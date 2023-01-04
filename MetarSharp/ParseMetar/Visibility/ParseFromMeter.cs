using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    internal class ParseFromMeter
    {
        internal static Visibility ParseVisibiltiy(GroupCollection groups)
        {
            Visibility visibility = new();

            visibility.VisibilityRaw = groups[1].Value.TrimStart();

            return visibility;
        }
    }
}
