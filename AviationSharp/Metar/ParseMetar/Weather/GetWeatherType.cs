namespace AviationSharp.Metar.Parse
{
    internal class GetWeatherType
    {
        internal static (WeatherType, string) Get(string input) => input switch
        {
            "BC" => (WeatherType.Patches, "Patches"),
            "BL" => (WeatherType.Blowing, "Blowing"),
            "SH" => (WeatherType.Shower, "Shower"),
            "TS" => (WeatherType.Thunderstorm, "Thunderstorm"),
            "FZ" => (WeatherType.Freezing, "Freezing"),

            "DZ" => (WeatherType.Drizzle, "Drizzle"),
            "RA" => (WeatherType.Rain, "Rain"),
            "SN" => (WeatherType.Snow, "Snow"),
            "PL" => (WeatherType.IcePellets, "Ice Pellets"),
            "GR" => (WeatherType.Hail, "Hail"),

            "GS" => (WeatherType.SmallHail, "Small Hail"),
            "UP" => (WeatherType.Unknown, "Unknown"),
            "BR" => (WeatherType.Mist, "Mist"),
            "FG" => (WeatherType.Fog, "Fog"),
            "FU" => (WeatherType.Smoke, "Smoke"),
            "SA" => (WeatherType.Sand, "Sand"),
            "HZ" => (WeatherType.Haze, "Haze"),

            "SQ" => (WeatherType.Squall, "Squall"),
            "FC" => (WeatherType.Tornado, "Tornado"),
            "SS" => (WeatherType.Sandstorm, "Sand Storm"),
            _ => (WeatherType.Unknown, "Unknown")
        };
    }
}
