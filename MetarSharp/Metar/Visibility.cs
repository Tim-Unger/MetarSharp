using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public enum VisibilityUnit
    {
        Meters,
        Miles,
        Kilometers
    }
    public class Visibility
    {
        public string VisibilityRaw { get; set; }
        public bool IsVisibilityMeasurable { get; set; }
        public double ReportedVisibility { get; set; }
        public VisibilityUnit VisibilityUnit { get; set; }
        public string VisibilityUnitRaw { get; set; }
        public string VisibilityUnitDecoded { get; set; }
        public bool HasVisibilityLowestValue { get; set; }
        public double? LowestVisibility { get; set; }
        public CardinalDirection LowestVisibilityDirection { get; set; }
        public string? LowestVisibilityDirectionRaw { get; set; }
        public string? LowestVisibilityDirectionDecoded { get; set; }
    }
}
