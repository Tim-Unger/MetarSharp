using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public enum WeatherDescriptor
    {
        Patches,
        Partial,
        [EnumMember(Value = "Low Drifting")]
        LowDrifting,
        Blowing,
        Shower,
        Thunderstorm,
        Freezing
    }

    public enum Precipitation
    {
        Drizzle,
        Rain,
        Snow,
        [EnumMember(Value = "Snow Grains")]
        SnowGrains,
        [EnumMember(Value = "Ice Pellets")]
        IcePellets,
        Hail,
        [EnumMember(Value = "Small Hail")]
        SmallHail,
        Unknown
    }

    public enum Clouding
    {
        Mist,
        Fog,
        Smoke,
        [EnumMember(Value = "Volcanic Ash")]
        VolcanicAsh,
        [EnumMember(Value = "Widespread Dust")]
        WidespreadDust,
        Sand,
        Haze
    }

    public enum OtherWeather
    {
        [EnumMember(Value = "Sand Whirls")]
        SandWhirls,
        Squall,
        Tornado,
        Sandstorm,
        Duststorm
    }

    public class ParseWeather
    {
        public static List<Weather> ReturnWeather(string raw)
        {
            List<Weather> weather = new List<Weather>();

            //TODO
            Regex weatherRegex = new Regex(@"((RE)?)((\+|-|VC)?)((MI|BC|PR|DR|BL|SH|TS|FZ|DZ|RA|SN|SG|PL|GR|GS|UP|BR|FG|FU|VA|DU|SA|HZ|PO|SQ|FC|SS|DS))", RegexOptions.None);

            MatchCollection weatherMatches = weatherRegex.Matches(raw);

            if (weatherMatches.Count > 0)
            {
                foreach (Match match in weatherMatches.Cast<Match>())
                {
                    Weather singleWeather = new Weather();
                    GroupCollection groups = match.Groups;

                    singleWeather.WeatherRaw = groups[0].Value;

                    if (groups[3].Success == false)
                    {
                        singleWeather.WeatherIntensity = " ";
                        singleWeather.WeatherIntensityDecoded = "Normal";
                        continue;
                    }

                    (singleWeather.WeatherIntensity, singleWeather.WeatherIntensityDecoded) = groups[3].Value switch
                    {
                        "+" => ("+", "Strong"),
                        "\\-" => ("-", "Light"),
                        null or "" => (null, null),
                        _ => ("", "")//TODO//throw new Exception()
                    } ;
                }
            }

            return weather;
        }
    }
}
