using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Server
    {
        [JsonPropertyName("ident")]
        public string Ident { get; init; }

        [JsonPropertyName("hostname_or_ip")]
        public string IpAddress { get; init; }

        [JsonPropertyName("location")]
        public string Location { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("clients_connection_allowed")]
        public int ConnectedClientsCount { get; init; }

        [JsonPropertyName("client_connection_allowed")]
        public bool AreConnectionsAllowed { get; init; }

        [JsonPropertyName("is_sweatbox")]
        public bool IsSweatbox { get; init; }
    }
}
