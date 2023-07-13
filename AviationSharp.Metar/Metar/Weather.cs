namespace MetarSharp
{
    public enum WeatherIntensity
    {
        Light = -1,
        Normal = 0,
        Heavy = 1,
    }
    
    public enum WeatherType
    {
        Patches,
        Partial,
        LowDrifting,
        Blowing,
        Shower,
        Thunderstorm,
        Freezing,
        Drizzle,
        Rain,
        Snow,
        SnowGrains,
        IcePellets,
        Hail,
        SmallHail,
        Unknown,
        Mist,
        Fog,
        Smoke,
        VolcanicAsh,
        WidespreadDust,
        Sand,
        Haze,
        SandWhirls,
        Squall,
        Tornado,
        Sandstorm,
        Duststorm
    }

    public class Weather
    {
        public string WeatherRaw { get; set; } = "None"; 

        public string WeatherIntensityRaw { get; set; } = "None";

        public WeatherIntensity? WeatherIntensity { get; set; }

        public string? WeatherIntensityDecoded { get; set; }

        public List<SingleWeather> Weathers { get; set; } = new List<SingleWeather>();

        public string WeatherCombinedDecoded { get; set; } = "None";

        public bool IsInTheVicinity { get; set; }

        public bool IsRecent { get; set; }
    }

    public class SingleWeather
    {
        public string WeatherTypeRaw { get; set; } = "None";

        public WeatherType WeatherType { get; set; }
        
        public string WeatherTypeDecoded { get; set; } = "None"; 
    }
}
