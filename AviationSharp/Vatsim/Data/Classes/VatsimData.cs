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

        [JsonPropertyName("facilities")]
        public List<Facility> Facilities { get; init; }

        [JsonPropertyName("ratings")]
        public List<Rating> Ratings { get; init; }

        [JsonPropertyName("pilot_ratings")]
        public List<PilotRating> PilotRatings { get; init; }

        [JsonPropertyName("military_ratings")]
        public List<MilitaryRating> MilitaryRatings { get; init; }
    }
}
