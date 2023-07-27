using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data 
{ 
    public class FlightPlan

    {
        [JsonPropertyName("flight_rules")]
        public string FlightRuleShort { get; init; } = "I";

        private FlightRule _flightRule { get; set; }

        public FlightRule FlightRule 
        { 
            get => _flightRule;
            init => _flightRule = FlightRuleShort switch
            {
                "I" => FlightRule.IFR,
                "V" => FlightRule.VFR,
                _ => FlightRule.SVFR, //TODO Check DataFeeed for the correct names for SVFR and DVFR
            };
        }

        [JsonPropertyName("aircraft")]
        public string Aircraft { get; init; }

        [JsonPropertyName("aircraft_faa")]
        public string AircraftFAA { get; init; }

        [JsonPropertyName("aircraft_short")]
        public string AircraftShort { get; init; }

        [JsonPropertyName("departure")]
        public string DepartureAirport { get; init; }

        [JsonPropertyName("arrival")]
        public string ArrivalAirport { get; init; }

        [JsonPropertyName("alternate")]
        public string? AlternateAirport { get; init; }

        [JsonPropertyName("cruise_tas")]
        public string CruiseTAS { get; init; }

        [JsonPropertyName("altitude")]
        public string Altitude { get; init; }

        private int? _flightLevel { get; set; }

        public int? FlightLevel
        {
            get => _flightLevel;
            init => _flightLevel = value > 3000 ? value / 100 : null;
        }

        [JsonPropertyName("deptime")]
        public string DepartureTimeString { get; init; }

        private TimeOnly _departureTime { get; set; }

        public TimeOnly DepartureTime
        {
            get => _departureTime;
            init => _departureTime = new TimeOnly(int.Parse(DepartureTimeString[..2]), int.Parse(DepartureTimeString[2..]));
        }

        [JsonPropertyName("enroute_time")]
        public string EnrouteTimeString { get; init; }

        private TimeSpan _enrouteTime { get; set; }

        public TimeSpan EnrouteTime
        {
            get => _enrouteTime;
            init => _enrouteTime = new TimeSpan(int.Parse(EnrouteTimeString[..2]), int.Parse(EnrouteTimeString[2..]), 0);
        }

        [JsonPropertyName("fuel_time")]
        public string FuelTimeString { get; init; }

        private TimeSpan _fuelTime { get; set; }

        public TimeSpan FuelTime
        {
            get => _fuelTime;
            init => _fuelTime = new TimeSpan(int.Parse(FuelTimeString[..2]), int.Parse(FuelTimeString[2..]), 0);
        }

        [JsonPropertyName("remarks")]
        public string Remarks { get; init; }

        [JsonPropertyName("route")]
        public string FullRoute { get; init; }

        private List<string> _routePoints { get; set; }

        public List<string> RoutePoints
        {
            get => _routePoints;
            init => _routePoints = FullRoute.Trim().Split("\\s+").ToList();
        }

        [JsonPropertyName("revision_id")]
        public int RevisionID { get; init; }

        [JsonPropertyName("assigned_transponder")]
        public string AssignedTransponder { get; init; }
    }
}
