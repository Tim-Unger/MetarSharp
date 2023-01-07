namespace MetarSharp.Parse.Additional
{
    internal class RecentWeatherParse
    {
        internal static RecentWeather Parse(GroupCollection groups)
        {
            RecentWeather recent = new RecentWeather();

            recent.RecentWeatherRaw = groups[2].Value;

            recent.RecentWeatherTypeRaw = groups[4].Value;

            recent.RecentWeatherDecoded = null; //TODO

            return recent;
        }
    }
}