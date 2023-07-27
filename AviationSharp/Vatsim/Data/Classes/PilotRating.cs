using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class PilotRating
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        [JsonPropertyName("long_name")]
        public string LongName { get; set; }
    }
}
