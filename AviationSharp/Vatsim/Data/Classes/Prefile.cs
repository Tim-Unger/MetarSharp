using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Prefile
    {
        [JsonPropertyName("cid")]
        public int Cid { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; init; }

        [JsonPropertyName("flight_plan")]
        public FlightPlan FlightPlan { get; init; }

        [JsonPropertyName("last_updated")]
        public string LastUpdateTimeString { get; init; }

        private DateTime _lastUpdate { get; set; }

        public DateTime LastUpdate
        {
            get => _lastUpdate;
            init => _lastUpdate = DateTime.Parse(LastUpdateTimeString);
        }
    }
}
