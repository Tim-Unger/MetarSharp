using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class Temperature
    {
        public bool IsTemperatureMeasurable { get; set; }
        public string TemperatureRaw { get; set; }
        public bool IsTemperatureBelowZero { get; set; }
        public int? TemperatureOnly { get; set; } 
        public bool IsDewpointBelowZero { get; set; }
        public int? DewpointOnly { get; set; }
    }
}
