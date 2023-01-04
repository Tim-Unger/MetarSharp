using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class WindShear
    {
        public string WindShearRaw { get; set; }

        public bool IsAllRunways { get; set; }

        public int? Runway { get; set; }
    }
}
