using AviationSharp.Converter.Time;
using AviationSharp.Vatsim.Data;
using System.Text.Json.Serialization;

namespace AviationSharp.Vatsim.Stats
{
    public class RatingHour
    {
        public string Rating { get; set; }

        public double TotalHours { get; set; }

        public (int Days, int Hours, int Minutes) TotalTimeDistribution { get; set; }
    }

    public class VatsimStatsUser
    {
        [JsonPropertyName("id")]
        public string CidString { get; set; }

        public int Cid { get; set; }

        //private static int _cid { get; set; }

        //public int Cid
        //{
        //    get => _cid;
        //    init => _cid = int.Parse(_cidString);
        //}

        [JsonPropertyName("rating")]
        public int RatingIndex { get; init; }

        //TODO
        //public Rating Rating

        [JsonPropertyName("militaryrating")]
        public int MilitaryRating { get; init; }

        [JsonPropertyName("susp_date")]
        public DateTime? SuspensionDate { get; init; }

        [JsonPropertyName("reg_date")]
        public DateTime RegistrationDate { get; init; }

        public (int Days, int Hours, int Minutes) TimeOnVatsim { get; set; }

        public int YearsOnVatsim { get; set; }

        [JsonPropertyName("region")]
        public string RegionShort { get; init; }

        //TODO Set in Constructor
        public VatsimRegion VatsimRegion { get; set; }

        [JsonPropertyName("division")]
        public string DivisionShort { get; init; }

        [JsonPropertyName("subdivision")]
        public string SubDivisionShort { get; init; }

        public double TotalHours { get; set; }

        public (int Days, int Hours, int Minutes) TotalTimeDistribution { get; set; }

        public double ControllerHours { get; set; }

        public (int Days, int Hours, int Minutes) ControllerTimeDistribution { get; set; }

        public double PilotHours { get; set; }

        public (int Days, int Hours, int Minutes) PilotTimeDistribution { get; set; }

        public List<RatingHour> RatingHourDistribution { get; set; }
    }

    internal class RatingHoursDTO
    {
        [JsonPropertyName("id")]
        public int Cid { get; init; }

        [JsonPropertyName("atc")]
        public double AtcHours { get; init; }

        [JsonPropertyName("pilot")]
        public double PilotHours { get; init; }

        [JsonPropertyName("s1")]
        public double S1Hours { get; init; }

        [JsonPropertyName("s2")]
        public double S2Hours { get; init;}

        [JsonPropertyName("s3")]
        public double S3Hours { get; init;}

        [JsonPropertyName("c1")]
        public double C1Hours { get; init; }

        [JsonPropertyName("c2")]
        public double C2Hours { get; init; }

        [JsonPropertyName("c3")]
        public double C3Hours { get; init;}

        [JsonPropertyName("i1")]
        public double I1Hours { get; init; }

        [JsonPropertyName("i2")]
        public double I2Hours { get; init;}

        [JsonPropertyName("i3")]
        public double I3Hours { get; init;}

        [JsonPropertyName("sup")]
        public double SUPHours { get; init; }

        [JsonPropertyName("adm")]
        public double ADMHours { get; init; }
    }
}
