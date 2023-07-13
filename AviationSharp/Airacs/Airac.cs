using System.Text.Json.Serialization;

namespace AviationSharp.Airacs
{
    public class Airac
    {
        public int CycleNumberInYear { get; init; }
        public int Ident { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; set; }
    }

    public class AiracDTO
    {
        [JsonPropertyName("cycleNumberInYear")]
        public int CycleNumberInYear { get; set; }

        [JsonPropertyName("ident")]
        public int Ident { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }
    }
}