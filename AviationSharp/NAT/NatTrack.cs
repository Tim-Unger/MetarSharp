using System.Text.Json.Serialization;

namespace AviationSharp.NAT
{
    public enum Direction
    {
        Unknown,
        Westbound,
        Eastbound,
        Both
    }

    public class NatTrack
    {
        public string Id { get; init; }

        public int TMI { get; init; }

        public List<Route> RoutePoints { get; init; }

        public List<int> FlightLevels { get; init; }

        public Direction Direction { get; init; }

        public DateTime ValidFrom { get; init; }

        public DateTime ValidTo { get; init; }
    }

    public class Route
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("latitude")]
        public float Latitude { get; init; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; init; }
    }

    internal class NatTrackDTO
    {
        public string id { get; set; }
        public string tmi { get; set; }
        public List<Route> route { get; set; }
        public List<int> flightLevels { get; set; }
        public int direction { get; set; }
        public string validFrom { get; set; }
        public string validTo { get; set; }
    }
}
