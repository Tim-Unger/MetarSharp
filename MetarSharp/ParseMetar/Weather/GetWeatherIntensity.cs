namespace MetarSharp.Parse
{
    internal class GetWeatherIntensity
    {
        internal static (WeatherIntensity, string) Get(GroupCollection groups) =>
            groups[3].Value switch
            {
                "-" => (WeatherIntensity.Light, WeatherDefinitions.LightIntensity),
                "" or null => (WeatherIntensity.Normal, WeatherDefinitions.NormalIntensity),
                "+" => (WeatherIntensity.Heavy, WeatherDefinitions.HeavyItensity),
                _ => throw new ParseException()
            };
    }
}
