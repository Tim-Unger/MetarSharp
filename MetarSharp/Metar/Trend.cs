using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    //TODO?
    public class Trend
    {
        public bool IsNOSIG { get; set; }

        public string? TrendRaw { get; set; }

        //TODO To enum?
        public string? TrendType { get; set; }

        public bool? IsTimeRestricted { get; set; }

        public int? TimeRestrictionRaw { get; set; }

        public DateTime? TimeRestrictionDateTime { get; set; }
    }
}
