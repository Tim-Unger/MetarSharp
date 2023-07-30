using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim
{
    public class VatsimRegion
    {
        [JsonPropertyName("id")]
        public string ShortName { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("director")]
        private static string _directorCidString { get; set; }

        private static int _directorCid { get; set; }

        //TODO setter not working properly
        public int DirectorCID
        {
            get => _directorCid;
            set => _directorCid = int.Parse(_directorCidString);
        }

        public List<VatsimDivision> DivisionsInRegion { get; set; }
    }
}
