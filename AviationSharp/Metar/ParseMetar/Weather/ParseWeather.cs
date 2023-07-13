namespace AviationSharp.Metar.Parse
{
    internal class ParseWeather
    {

        private static readonly Regex _weatherRegex = new(@"(?<!(TEMPO|RMK|TREND|BECMG).*)\s(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s");

        internal static Weather ReturnWeather(string raw)
        {
            Weather weather = new ();

            MatchCollection weatherMatches = _weatherRegex.Matches(raw);

            if (weatherMatches.Count == 0)
            {
                return new Weather() { Weathers = Enumerable.Empty<SingleWeather>().ToList() };
            }

            var groups = weatherMatches[0].Groups;

            weather.WeatherRaw = groups[0].Value;

            weather.IsRecent = groups[2].Success;
            weather.IsInTheVicinity = groups[3].Value == "VC";
            weather.WeatherIntensityRaw = groups[3].Value;

            if (groups[3].Value == "VC")
            {
                weather.WeatherIntensity = null;
                weather.WeatherIntensityDecoded = null;

                return weather;
            }

            (weather.WeatherIntensity, weather.WeatherIntensityDecoded) = GetWeatherIntensity.Get(groups);

            var weatherCaptures = groups[4].Captures;

            var weathers = new List<SingleWeather>();
            foreach (Capture capture in weatherCaptures.Cast<Capture>())
            {
                var singleWeather = new SingleWeather
                {
                    WeatherTypeRaw = capture.Value
                };

                (singleWeather.WeatherType, singleWeather.WeatherTypeDecoded) = GetWeatherType.Get(capture.Value);
                
                weathers.Add(singleWeather);
            }

            weather.Weathers = weathers;
            
            StringBuilder stringBuilder = new();
            
            if (weather.IsRecent)
            {
                stringBuilder.Append("Recent").Append(' ');
            }

            if (weather.IsInTheVicinity)
            {
                stringBuilder.Append("Vicinity").Append(' ');
            }

            if (weather.WeatherIntensity != WeatherIntensity.Normal)
            {
                stringBuilder.Append(weather.WeatherIntensityDecoded).Append(' ');
            }
            
            weather.Weathers.ForEach(x => stringBuilder.Append(x.WeatherTypeDecoded).Append(' '));

            //Removes the last space from the combined string
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            weather.WeatherCombinedDecoded = stringBuilder.ToString();
            return weather;
        }
    }

    /// <summary>
    /// Public extension to the ParseWeather Class to access the Method from outside the namespace
    /// </summary>
    public class ParseWeatherOnly
    {
        public static Weather FromString(string raw) => ParseWeather.ReturnWeather(raw);
    }
}
