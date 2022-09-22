using System.Globalization;

namespace MetarSharp
{
    public class Metar
    {
        //The Airport (EGLL)
        public string Airport { get; set; }

        public ReportingTime ReportingTime;

        public bool IsAutomatedReport { get; set; }

        public Wind Wind;

        public Visibility Visibility;

        public List<RunwayVisibility>? RunwayVisibilities;

        public List<Weather>? Weather;

        //Non-nullable as it must be at least CAVOK
        public List<Cloud> Clouds;

        public Temperature Temperature;

        public Pressure Pressure;

        public Trend Trend;

        public List<RunwayCondition>? RunwayConditions;

        public AdditionalInformation AdditionalInformation;

        public string ReadableReport;
    }

    //TODO define custom Date
    public class ReportingTime
    {
        public string ReportingTimeRaw { get; set; }

        //The Reporting Date (01)
        public int ReportingDateRaw { get; set; }

        //The Reporting Time (1100)
        public int ReportingTimeZuluRaw { get; set; }

        /*
         * The Reporting Time as DateTime:
         * If the current day matches the day of the report, it will use the current day
         * If not, it will check if the day has passed in the current month
         * If not, it will check if the day has passed in the preceding month
         * If not (e.g. 31st in February) it will use the month before that
         */
        public DateTime ReportingTimeZulu { get; set; }

        //TODO
        //public DateTime ReportingTimeMyTime { get; set; }

    }

    public class Wind
    {
        //The Wind as String (23008KT)
        public string WindRaw { get; set; }

        public bool IsWindCalm { get; set; }

        //The Wind Direction (230)
        public int? WindDirection { get; set; }

        //The Wind Strength (3)
        public int? WindStrength { get; set; }

        //The Wind Unit (KT)
        public string WindUnitRaw { get; set; }

        public string WindUnitDecoded { get; set; }
        //Whether there are Wind Gusts
        public bool IsWindGusting { get; set; }

        //Strength of the Wind Gusts (10)
        public int? WindGusts { get; set; }

        //Whether the Wind is VRB (true)
        public bool IsWindVariable { get; set; }

        public bool isWindDirectionVarying { get; set; }

        public string? WindDirectionVariationRaw { get; set; }
        //The lowest direction of the Wind
        public int? WindVariationLow { get; set; }

        //The highest direction of the Wind
        public int? WindVariationHigh { get; set; }
    }

    public class Visibility
    {
        public string VisibilityRaw { get; set; }

        public bool IsVisibilityMeasurable { get; set; }

        public int ReportedVisibility { get; set; }

        public string VisibilityUnitRaw { get; set; }

        public string VisibilityUnitDecoded { get; set; }

        public bool HasVisibilityLowestValue { get; set; }

        public int? LowestVisibility { get; set; }

        public string? LowestVisibilityDirectionRaw { get; set; }

        public string? LowestVisibilityDirectionDecoded { get; set; }
    }

    //TODO
    public class RunwayVisibility
    {
        public string RunwayVisibilityRaw { get; set; }

        public string Runway { get; set; }

        //TODO IsParallelRunway bool?
        public string? ParallelRunwayDesignator { get; set; }
        public string? ParallelRunwayDesignatorDecoded { get; set; }
        public int RunwayVisualRange { get; set; }
        //TODO
        public bool? IsRVRValueMoreOrLess { get; set; }

        //TODO more or less raw
        public string RVRMoreOrLessDecoded { get; set; }
        public string RVRTendencyRaw { get; set; }
        
        //TODO Custom definitions for decoded strings
        public string RVRTendencyDecoded { get; set; }
        public bool? IsRVRVarying { get; set; }
        public bool? IsRVRVariationMoreOrLess { get; set; }

        //TODO more or less raw

        public string? RVRVariationMoreOrLessDecoded { get; set; }
        public int? RVRVariationValue { get; set; }

        //TODO überflüssig?
        public string? RVRVariationTendencyRaw { get; set; }
        public string? RVRVariationTendencyDecoded { get; set; }
    
    }

    public class Weather
    {
        public string WeatherRaw { get; set; }

        public string WeatherIntensity { get; set; }

        public string WeatherIntensityDecoded { get; set; }

        public bool? IsInTheVicinity { get; set; }

        public bool? IsRecent { get; set; }

        public string WeatherCodeRaw { get; set; }

        public string WeatherDecoded { get; set; }
    }

    //TODO
    public class Cloud
    {
        public bool IsCAVOK { get; set; }
        public bool? IsCloudMeasurable { get; set; }
        public string? CloudRaw { get; set; }
        public string? CloudCoverageTypeRaw { get; set; }
        public string? CloudCoverageTypeDecoded { get; set; }
        public bool? IsCeilingMeasurable { get; set; }
        public int? CloudCeiling { get; set; }
        
        //TODO Cloud-Ceiling converted to ft
        public bool? HasCumulonimbusClouds { get; set; }
        public bool? IsCBTypeMeasurable { get; set; }
        public string? CBCloudTypeRaw { get; set; }
        public string? CBCloudTypeDecoded { get; set; }
        public bool? IsVerticalVisibility { get; set; }
        //public string? VerticalVisibilityRaw { get; set; }
        public bool? IsVerticalVisibilityMeasurable { get; set; }
        public int? VerticalVisibility { get; set; }
    }

    public class Temperature
    {
        public string TemperatureRaw { get; set; }

        public bool IsTemperatureBelowZero { get; set; }
        public int TemperatureOnly { get; set; }

        public bool IsDewpointBelowZero { get; set; }

        public int DewpointOnly { get; set; }
    }

    public class Pressure
    {
        public string PressureRaw { get; set; }

        public string PressureType { get; set; }

        public string PressureTypeRaw { get; set; }

        public int PressureOnly { get; set; }

        public string? PressureWithSeperator { get; set; }

        public int? PressureAsQnh { get; set; }

        public int? PressureAsAltimeter { get; set; }
    }
    
    //TODO?
    public class Trend
    {
        public bool IsNOSIG { get; set; }

        public string? TrendRaw { get; set; }
        //TODO To enum?
        public string? TrendType { get; set; }

        public bool? IsTimeRestricted { get; set; }

        public int? TimeRestrictionRaw { get; set; }

        public DateTime? TimeRestrictionDateTime { get; set; }

    }

    public class RunwayCondition
    {
        public string? RunwayConditionRaw { get; set; }
    }

    public class AdditionalInformation
    {
        public string? AdditionalInformationRaw { get; set; }

        public List<RecentWeather>? RecentWeather { get; set; }

        public List<WindShear>? WindShear { get; set; }

        public enum ColorCode
        {
            NIL,
            BLUPLUS,
            BLU,
            WHT,
            GRN,
            YLO,
            AMB,
            RED,
            BLACK,
        }

        public string? Remarks { get; set; }
    }

    public class RecentWeather
    {
        public string RecentWeatherRaw { get; set; }

        public string RecentWeatherTypeRaw { get; set; }

        public string RecentWeatherDecoded { get; set; }
    }

    public class WindShear
    {
        public string WindShearRaw { get; set; }

        public bool IsAllRunways { get; set; }

        public int? Runway { get; set; }
    }
}
