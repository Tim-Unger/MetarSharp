namespace AviationSharp.Metar.Parse.Additional
{
    internal class RecentWeatherParse
    {
        internal static RecentWeather Parse(GroupCollection groups)
        {
            var recent = new RecentWeather
            {
                RecentWeatherRaw = groups[2].Value,

                RecentWeatherTypeRaw = groups[4].Value
            };

            var weatherDecoded = GetWeatherType.Get(groups[4].Value).Item2;
            recent.RecentWeatherDecoded = $"Recent {weatherDecoded}";

            return recent;
        }
    }
}