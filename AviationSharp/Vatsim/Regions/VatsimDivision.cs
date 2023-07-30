using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim
{
    public class VatsimDivision
    {
        [JsonPropertyName("id")]
        public string ShortName { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("parentregion")]
        public string ParentDivision { get; init; }

        [JsonPropertyName("subdivisionallowed")]
        //TODO
        public int HasSubDivisionsInt { get; init; }

        public bool HasSubdivisions { get; set; }

        public List<VatsimSubDivision>? SubDivisions { get; set; }
    }
}
