using MetarSharp.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{


    public class ParseWeather
    {
        public static Weather ReturnWeather(string raw)
        {
            Weather weather = new ();

            //TODO
            Regex weatherRegex = new Regex(@"(?<!(TEMPO|RMK|TREND|BECMG).*)\s(RE)?(-|\+|VC)?(MI|BC|BL|SH|TS|FZ|DZ|RA|SN|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|SQ|FC|SS){1,}\s", RegexOptions.None);

            MatchCollection weatherMatches = weatherRegex.Matches(raw);

            if (weatherMatches.Count == 0)
            {
                return null;
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

            List<SingleWeather> weathers = new List<SingleWeather>();
            for (var i = 0; i < weatherCaptures.Count; i++)
            {
                var singleWeather = new SingleWeather();
                singleWeather.WeatherTypeRaw = weatherCaptures[i].Value;
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

            if (weather.WeatherIntensity != WeatherIntensity.Moderate)
            {
                stringBuilder.Append(weather.WeatherIntensityDecoded).Append(' ');
            }
            
            weather.Weathers.ForEach(x => stringBuilder.Append(x.WeatherTypeDecoded).Append(' '));

            weather.WeatherCombinedDecoded = stringBuilder.ToString();
            return weather;
        }

        private static (WeatherIntensity, string) GetWeatherIntensity(GroupCollection groups) =>
            groups[3].Value switch
            {
                "-" => (WeatherIntensity.Light,"Light"),
                "" or null => (WeatherIntensity.Moderate, "Moderate"),
                "+" => (WeatherIntensity.Heavy, "Heavy"),
                _ => throw  new ParseException()
            };

        private static (WeatherType, string) GetWeatherType(string input) => input switch
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
            _ => (WeatherType.Unknown, "Unknow")
        };

    }
}
