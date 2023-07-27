using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Rating
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("short")]
        public string ShortName { get; set; }

        [JsonPropertyName("long")]
        public string LongName { get; set; }
    }
}
