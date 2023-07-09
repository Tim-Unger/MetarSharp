using System.Text.Json;

namespace AviationSharp.Metar.Parser
{
    internal class ToJson
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        internal static string Parse(Metar metar, JsonSerializerOptions? options) => JsonSerializer.Serialize(GetMetar(metar), options ?? _options);

        internal static string Parse(string raw, JsonSerializerOptions? options) => JsonSerializer.Serialize(GetMetar(ParseMetar.FromString(raw)), options ?? _options);

        private static object GetMetar(Metar metar) => new
        {
            metar.MetarRaw,
            metar.Airport,
            metar.ReportingTime,
            metar.IsAutomatedReport,
            metar.Wind,
            metar.Visibility,
            metar.RunwayVisibilities,
            metar.Weather,
            metar.Clouds,
            metar.Temperature,
            metar.Pressure,
            metar.Trends,
            metar.RunwayConditions,
            metar.ReadableReport,
            metar.AdditionalInformation
        };
    }
}
