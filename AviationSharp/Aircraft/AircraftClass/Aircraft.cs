using System.Text.Json.Serialization;

namespace AviationSharp.Aircraft
{
    public partial class Aircraft
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TypeDesignator { get; set; }
        public AircraftType AircraftType { get; set; }
        public EngineType EngineType { get; set; }
        public int? EngineCount { get; set; }
        public WakeTurbulenceCategory WakeTurbulenceCategory { get; set; }
        public string WakeTurbulenceCategoryShort { get; set; }
    }

    internal class AircraftDTO
    {
        [JsonPropertyName("ManufacturerCode")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("ModelFullName")]
        public string Model { get; set; }

        [JsonPropertyName("Designator")]
        public string TypeDesignator { get; set; }

        [JsonPropertyName("AircraftDescription")]
        public string AircraftType { get; set; }

        public string EngineType { get; set; }
        public string EngineCount { get; set; }

        [JsonPropertyName("WTC")]
        public string WakeTurbulenceCategory { get; set; }


        //Disregardable
        public string Description { get; set; }
        public string WTG { get; set; }
    }
}
