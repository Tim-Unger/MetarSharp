namespace MetarSharp
{
    public enum WeatherIntensity
    {
        Light,
        Moderate,
        Heavy
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

    public enum Precipitation
    {
        
    }

    public enum Clouding
    {
        
    }

    public enum OtherWeather
    {
        
    }
    public class Weather
    {
        public string WeatherRaw { get; set; }
        public string WeatherIntensityRaw { get; set; }
        public WeatherIntensity? WeatherIntensity { get; set; }
        public string? WeatherIntensityDecoded { get; set; }
        public List<SingleWeather> Weathers { get; set; }
        public string WeatherCombinedDecoded { get; set; }
        public bool IsInTheVicinity { get; set; }
        public bool IsRecent { get; set; }
    }

    public class SingleWeather
    {
        public string WeatherTypeRaw { get; set; }
        public WeatherType WeatherType { get; set; }
        
        public string WeatherTypeDecoded { get; set; } 
    }
}
