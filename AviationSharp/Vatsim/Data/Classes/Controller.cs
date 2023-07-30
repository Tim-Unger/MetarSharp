using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Controller
    {
        [JsonPropertyName("cid")]
        public int Cid { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; init; }

        [JsonPropertyName("frequency")]
        public string Frequency { get; init; }

        [JsonPropertyName("facility")]
        public int FacilityTypeIndex { get; init; }

        //public Facility FacilityType { get; init; } //TODO

        [JsonPropertyName("rating")]
        public int RatingIndex { get; init; }

        //public Rating Rating { get; init; } //TODO

        [JsonPropertyName("server")]
        public string Server { get; init; }

        [JsonPropertyName("visual_range")]
        public int VisualRange { get; init; }

        [JsonPropertyName("text_atis")]
        internal string? _textAtis { get; set; }

        public string? TextAtis { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdate { get; init; }

        //DateTime _lastUpdate { get; set; }

        //public DateTime LastUpdate
        //{
        //    get => _lastUpdate;
        //    init => _lastUpdate = DateTime.Parse(LastUpdateString);
        //}

        [JsonPropertyName("logon_time")]
        public DateTime LogonTime { get; init; }

        //DateTime _logonTime { get; set; }

        //public DateTime LogonTime
        //{
        //    get => _logonTime;
        //    init => _logonTime = DateTime.Parse(LastUpdateString);
        //}
    }
}
