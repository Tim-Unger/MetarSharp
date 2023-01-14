using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public enum TrendType
    {
        NoSignificantChange,
        Becoming,
        Tempo,
    }
    public class Trend
    {
        //TODO move NOSIG
        //public bool IsNOSIG { get; set; }
        public string? TrendRaw { get; set; }
        public TrendType TrendType { get; set; }
        public string? TrendTypeRaw { get; set; }
        public bool? IsTimeRestricted { get; set; }
        public int? TimeRestrictionRaw { get; set; }
        public DateTime? TimeRestrictionDateTime { get; set; }
    }
}
