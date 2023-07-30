using System;
using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Data
{
    public class Pilot
    {
        [JsonPropertyName("cid")]
        public int Cid { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; init; }

        //TODO Server Class
        [JsonPropertyName("server")]
        public string Server { get; init; }

        [JsonPropertyName("pilot_rating")]
        public int PilotRatingIndex { get; init; } 

        //TODO
        private PilotRating _pilotRating { get; set; }

        //public PilotRating PilotRating
        //{
        //    get => _pilotRating;
        //    init => _pilotRating = 
        //}

        [JsonPropertyName("military_rating")]
        public int MilitaryRatingIndex { get; init; }

        private MilitaryRating _militaryRating { get; init; }

        public MilitaryRating MilitaryRating { get; init;
        }

        [JsonPropertyName("latitude")]
        public float Latitude { get; init; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; init; }

        [JsonPropertyName("altitude")]
        public int Altitude { get; init; }

        private int? _flightLevel { get; set; }

        //TODO correct Flightlevel writing (035 instead of 35)
        public int? Flightlevel
        {
            get => _flightLevel;
            set => _flightLevel = value > 3000 ? value / 100 : null;
        }

        [JsonPropertyName("groundspeed")]
        public int GroundSpeed { get; init; }

        [JsonPropertyName("transponder")]
        public string Transponder { get; init; }

        [JsonPropertyName("heading")]
        public int Heading { get; init; }

        [JsonPropertyName("qnh_i_hg")]
        public double QnhInHg { get; init; }

        [JsonPropertyName("qnh_mb")]
        public double QnhMb { get; init; }

        [JsonPropertyName("flight_plan")]
        public FlightPlan FlightPlan { get; init; }

        [JsonPropertyName("logon_time")]
        public string LogonTimeString { get; init; }

        private DateTime _logonTime { get; set; }

        public DateTime LogonTime
        {
            get => _logonTime;
            init => _logonTime = DateTime.Parse(LogonTimeString);
        }

        [JsonPropertyName("last_updated")]
        public string LastUpdateTimeString { get; init; }

        private DateTime _lastUpdate { get; set; }

        public DateTime LastUpdate
        {
            get => _lastUpdate;
            init => _lastUpdate = DateTime.Parse(LastUpdateTimeString);
        }
    }
}
