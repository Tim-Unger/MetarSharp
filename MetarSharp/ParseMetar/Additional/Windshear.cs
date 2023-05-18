using MetarSharp.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse.Additional
{
    internal class WindshearParse
    {
        internal static WindShear Parse(MatchCollection matches)
        {
            var wind = new WindShear();

            var stringBuilder = new StringBuilder();
            matches.ToList().ForEach(x => stringBuilder.Append(x.ToString().Append(' ')));
            wind.WindShearRaw = stringBuilder.ToString();

            var runways = new List<string>();

            if (matches.Count == 1)
            {
                GroupCollection groups = matches[0].Groups;

                if (groups[0].Value == "WS ALL RWY")
                {
                    wind.IsAllRunways = true;

                    return wind;
                }

                runways.Add(groups[2].Value);
                wind.Runways = runways;

                return wind;
            }

            foreach(Match match in matches.Cast<Match>()) 
            {
                GroupCollection groups = match.Groups;
                
                wind.IsAllRunways = false;

                runways.Add(groups[2].Value);

                wind.Runways = runways;
            }

            return wind;
        }
    }
}