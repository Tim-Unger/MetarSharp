using System.Text.RegularExpressions;
using MetarSharp.Parser;

namespace MetarSharp.Parse.Additional
{
    internal class RecentWeatherParse
    {
        internal static RecentWeather Parse(GroupCollection groups)
        {
            RecentWeather recent = new RecentWeather();

            recent.RecentWeatherRaw = groups[2].Value;

            recent.RecentWeatherTypeRaw = groups[4].Value;

            string weatherDecoded = ParseWeather.GetWeatherType(groups[4].Value).Item2;
            recent.RecentWeatherDecoded = $"Recent {weatherDecoded}";

            return recent;
        }
    }
}