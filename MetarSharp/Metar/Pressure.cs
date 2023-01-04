using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public enum PressureType
    {
        InchesMercury,
        Hectopascal
    }

    public class Pressure
    {
        public bool IsPressureMeasurable { get; set; }
        public string PressureRaw { get; set; }

        public PressureType? PressureType { get; set; }
        public string PressureTypeString { get; set; }

        public string PressureTypeRaw { get; set; }

        public int PressureOnly { get; set; }

        public string? PressureWithSeperator { get; set; }

        public int? PressureAsQnh { get; set; }

        public int? PressureAsAltimeter { get; set; }
    }
}
