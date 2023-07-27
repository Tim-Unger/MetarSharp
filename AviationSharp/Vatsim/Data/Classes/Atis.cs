using AviationSharp.Metar.Parse;
using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Atis
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

        [JsonPropertyName("atis_code")]
        public string AtisLetter { get; init; } = "";

        [JsonPropertyName("text_atis")]
        private static string[]? _textAtis { get; set; }

        public string? TextAtis = _textAtis is not null ? string.Join(Environment.NewLine, _textAtis) : null;
        
        [JsonPropertyName("last_updated")]
        public string LastUpdateString { get; init; }

        private DateTime _lastUpdate { get; set; }

        public DateTime LastUpdate
        {
            get => _lastUpdate;
            init => _lastUpdate = DateTime.Parse(LastUpdateString);
        }

        [JsonPropertyName("logon_time")]
        public string LogonTimeString { get; init; }

        private DateTime _logonTime { get; set; }

        public DateTime LogonTime
        {
            get => _logonTime;
            init => _logonTime = DateTime.Parse(LastUpdateString);
        }
    }
}
