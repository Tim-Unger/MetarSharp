namespace AviationSharp.Metar.Parse.ReadableReport
{
    internal class Weather
    {
        /// <summary>
        /// This adds the weather to the readable report
        /// </summary>
        /// <param name="metar"></param>
        /// <returns>string</returns>
        internal static string Append(Metar metar)
        {
            var weather = metar.Weather;

            var stringBuilder = new StringBuilder();

            //Null Check is done one level up
            if(weather!.IsRecent)
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
