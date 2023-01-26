using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Weather
    {
        /// <summary>
        /// This adds the weather to the readable report
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        internal static string Append(Metar metar)
        {
#pragma warning disable CS8602

            var weather = metar.Weather;

            StringBuilder stringBuilder = new StringBuilder();

            if(weather.IsRecent)
            {
                stringBuilder.Append("Recent ");
            }

            if(weather.WeatherIntensity != WeatherIntensity.Normal)
            {
                stringBuilder.Append(weather.WeatherIntensityDecoded + " ");
            }

            stringBuilder.Append(weather.WeatherCombinedDecoded + " ");

            if (weather.IsInTheVicinity)
            {
                stringBuilder.Append("In the vicinity");
            }

            return stringBuilder.ToString();
        }
    }
}
