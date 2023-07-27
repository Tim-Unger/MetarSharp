using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class GeneralInformation
    {
        [JsonPropertyName("version")]
        public int Version { get; init; }

        [JsonPropertyName("reload")]
        public int Reload { get; init; }

        [JsonPropertyName("update")]
        public string Update { get; init; }

        [JsonPropertyName("update_timestamp")]
        public string UpdateTimestamp { get; init; }

        private DateTime _updateTime { get; set; }
        public DateTime UpdateTime
        {
            get => _updateTime;
            set => _updateTime = DateTime.Parse(Update);
        }

        [JsonPropertyName("connected_clients")]
        public int ConnectedClients { get; init; }

        [JsonPropertyName("unique_users")]
        public int UniqueUsers { get; init; }
    }
}
