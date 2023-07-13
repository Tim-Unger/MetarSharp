namespace MetarSharp.Parse
{
    internal class WeatherFromTrend
    {
        internal static Weather Get(string raw)
        {
            var weather = new Weather();
            var weatherRegex = new Regex(@"(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}");
            GroupCollection groups = weatherRegex.Match(raw).Groups;

            weather.WeatherRaw = groups[0].Value;

            weather.IsInTheVicinity = groups[2].Value == "VC";
            weather.WeatherIntensityRaw = groups[2].Value;

            if (groups[2].Value == "VC")
            {
                weather.WeatherIntensity = null;
                weather.WeatherIntensityDecoded = null;

                return weather;
            }

            (weather.WeatherIntensity, weather.WeatherIntensityDecoded) = groups[2].Value switch
            {
                "-" => (WeatherIntensity.Light, WeatherDefinitions.LightIntensity),
                "" or null => (WeatherIntensity.Normal, WeatherDefinitions.NormalIntensity),
                "+" => (WeatherIntensity.Heavy, WeatherDefinitions.HeavyItensity),
                _ => throw new ParseException()
            };

            var weatherCaptures = groups[3].Captures;

            var weathers = new List<SingleWeather>();
            for (var i = 0; i < weatherCaptures.Count; i++)
            {
                var singleWeather = new SingleWeather
                {
                    WeatherTypeRaw = weatherCaptures[i].Value
                };

                (singleWeather.WeatherType, singleWeather.WeatherTypeDecoded) = GetWeatherType.Get(weatherCaptures[i].Value);

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
            //stringBuilder.Remove(stringBuilder.Length - 1, 1);

            weather.WeatherCombinedDecoded = stringBuilder.ToString().Trim();
            return weather;
        }
    }
}
