namespace MetarSharp.Parse
{
    internal class ParseWeather
    {
        internal static Weather ReturnWeather(string raw)
        {
            Weather weather = new ();

            var weatherRegex = new Regex(@"(?<!(TEMPO|RMK|TREND|BECMG).*)\s(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s", RegexOptions.None);

            MatchCollection weatherMatches = weatherRegex.Matches(raw);

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

            (weather.WeatherIntensity, weather.WeatherIntensityDecoded) = GetWeatherIntensity(groups);

            var weatherCaptures = groups[4].Captures;

            var weathers = new List<SingleWeather>();
            for (var i = 0; i < weatherCaptures.Count; i++)
            {
                var singleWeather = new SingleWeather
                {
                    WeatherTypeRaw = weatherCaptures[i].Value
                };

                (singleWeather.WeatherType, singleWeather.WeatherTypeDecoded) = GetWeatherType(weatherCaptures[i].Value);
                
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

        internal static Weather GetWeatherFromTrend(string raw)
        {
            var weather = new Weather();
            var weatherRegex = new Regex(@"(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s");
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

                (singleWeather.WeatherType, singleWeather.WeatherTypeDecoded) = GetWeatherType(weatherCaptures[i].Value);

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

        internal static (WeatherIntensity, string) GetWeatherIntensity(GroupCollection groups) =>
            groups[3].Value switch
            {
                "-" => (WeatherIntensity.Light,WeatherDefinitions.LightIntensity),
                "" or null => (WeatherIntensity.Normal, WeatherDefinitions.NormalIntensity),
                "+" => (WeatherIntensity.Heavy, WeatherDefinitions.HeavyItensity),
                _ => throw  new ParseException()
            };

        internal static (WeatherType, string) GetWeatherType(string input) => input switch
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
