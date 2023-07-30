using AviationSharp.Vatsim.Data;
using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim
{
    public partial class VatsimData
    {
        [JsonPropertyName("general")]
        public GeneralInformation GeneralInformation { get; init; }

        [JsonPropertyName("pilots")]
        public List<Pilot>? Pilots { get; init; }

        [JsonPropertyName("controllers")]
        public List<Controller>? Controllers { get; init; }

        [JsonPropertyName("atis")]
        public List<Atis>? Atis { get; init; }

        [JsonPropertyName("servers")]
        public List<Server> Servers { get; init; }

        [JsonPropertyName("prefiles")]
        public List<Prefile>? Prefiles { get; init; }

        [JsonPropertyOrder(-4)]
        [JsonPropertyName("facilities")]
        public List<Facility> Facilities { get; init; }

        [JsonPropertyOrder(-3)]
        [JsonPropertyName("ratings")]
        public List<Rating> Ratings { get; init; }

        [JsonPropertyOrder(-2)]
        [JsonPropertyName("pilot_ratings")]
        public List<PilotRating> PilotRatings { get; init; }

        [JsonPropertyOrder(-1)]
        [JsonPropertyName("military_ratings")]
        public List<MilitaryRating> MilitaryRatings { get; init; }
    }
}
