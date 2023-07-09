using System.Text.Json;

namespace AviationSharp.Metar.Parser
{
    internal class ToJsonList
    {
        internal static List<string> Parse(IEnumerable<string> raw, JsonSerializerOptions? options) => raw.Select(x => ToJson.Parse(ParseMetar.FromString(x), options)).ToList();

        internal static List<string> Parse(IEnumerable<Metar> raw, JsonSerializerOptions? options) => raw.Select(x => ToJson.Parse(x, options)).ToList();

        internal static string ParseToString(IEnumerable<string> raw)
        {
            var stringBuilder = new StringBuilder();
            
            raw.ToList().ForEach(x => stringBuilder.AppendLine(ToJson.Parse(x, null)));

            return stringBuilder.ToString();
        }

        internal static string ParseToString(IEnumerable<Metar> raw)
        {
            var stringBuilder = new StringBuilder();

            raw.ToList().ForEach(x => stringBuilder.AppendLine(ToJson.Parse(x, null)));

            return stringBuilder.ToString();
        }
    }
}
