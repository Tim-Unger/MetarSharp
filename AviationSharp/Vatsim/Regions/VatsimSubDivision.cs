using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim
{
    public class VatsimSubDivision
    {
        [JsonPropertyName("code")]
        public string ShortName { get; init; }

        [JsonPropertyName("fullname")]
        public string FullName { get; init; }

        [JsonPropertyName("parentdivision")]
        public string ParentDivision { get; init; }
    }
}
