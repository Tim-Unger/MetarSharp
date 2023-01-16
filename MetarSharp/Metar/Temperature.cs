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
        public double TemperatureCelsius { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public bool IsTemperatureBelowZero { get; set; }
        public double DewpointCelsius { get; set; }
        public double DewpointFahrenheit { get; set; }
        public bool IsDewpointBelowZero { get; set; }
    }
}
