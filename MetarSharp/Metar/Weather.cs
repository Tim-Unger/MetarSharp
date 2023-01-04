using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class Weather
    {
        public string WeatherRaw { get; set; }

        public string WeatherIntensity { get; set; }

        public string WeatherIntensityDecoded { get; set; }

        public bool? IsInTheVicinity { get; set; }

        public bool? IsRecent { get; set; }

        public string WeatherCodeRaw { get; set; }

        public string WeatherDecoded { get; set; }
    }
}
