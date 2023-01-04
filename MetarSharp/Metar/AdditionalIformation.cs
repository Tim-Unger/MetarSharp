using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class AdditionalInformation
    {
        public string? AdditionalInformationRaw { get; set; }

        public List<RecentWeather>? RecentWeather { get; set; }

        public List<WindShear>? WindShear { get; set; }

        public ColorCode ColorCode { get; set; }

        public string? Remarks { get; set; }
    }
}
