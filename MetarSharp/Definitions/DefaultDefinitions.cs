namespace MetarSharp.Definitions
{
    public enum Definitions
    {
        KilometerShort,
        KilometerLong,
        MeterShort,
        MeterLong,
        StatuteMileShort,
        StatuteMileLong,
        MileShort,
        MileLong,
        NorthShort,
        NorthLong,
        NorthEastShort,
        NorthEastLong,
        EastShort,
        EastLong,
        SouthEastShort,
        SouthEastLong,
        SouthShort,
        SouthLong,
        SouthWestShort,
        SouthWestLong,
        WestShort,
        WestLong,
        NorthWestShort,
        NorthWestLong,
        CumulonimbusShort,
        CumulonimbusLong,
        ToweringCumulonimbusShort,
        ToweringCumulonimbusLong,
        FewCloudsShort,
        FewCloudsLong,
        ScatteredCloudsShort,
        ScatteredCloudsLong,
        BrokenCloudsShort,
        BrokenCloudsLong,
        OvercastCloudsShort,
        OvercastCloudsLong,
        NoSignificantCloudsShort,
        NoSignificantCloudsLong,
        NoCloudsDetectedShort,
        NoCloudsDetectedLong,
        InchesMercuryShort,
        InchesMercuryLong,
        HectopascalsShort,
        HectopascalsLong,
        LeftRunwayShort,
        LeftRunwayLong,
        CenterRunwayShort,
        CenterRunwayLong,
        RightRunwayShort,
        RightRunwayLong,
        TendencyUpwardShort,
        TendencyUpwardLong,
        TendencyStagnantShort,
        TendencyStagnantLong,
        TendencyDownwardShort,
        TendencyDownwardLong,
        ValueLessThanShort,
        ValueLessThanLong,
        ValueMoreThanShort,
        ValueMoreThanLong,
        KnotsShort,
        KnotsLong,
        MilesPerHourShort,
        MilesPerHourLong,
        MetersPerSecondShort,
        MetersPerSecondLong
    }

    public class DistanceDefinitions
    {
        public static string KilometerShort { get; set; } = "KM";
        public static string KilometerLong { get; set; } = "Kilometer";
        public static string MeterShort { get; set; } = "M";
        public static string MeterLong { get; set; } = "Meter";
        public static string StatuteMileShort { get; set; } = "SM";
        public static string StatuteMileLong { get; set; } = "Statute Mile";
        public static string MileShort { get; set; } = "MI";
        public static string MileLong { get; set; } = "Mile";
    }

    public class CardinalDirectionDefinitions
    {
        public static string NorthShort { get; set; } = "N";
        public static string NorthLong { get; set; } = "North";
        public static string NorthEastShort { get; set; } = "NE";
        public static string NorthEastLong { get; set; } = "North-East";
        public static string EastShort { get; set; } = "E";
        public static string EastLong { get; set; } = "East";
        public static string SouthEastShort { get; set; } = "SE";
        public static string SouthEastLong { get; set; } = "South-East";
        public static string SouthShort { get; set; } = "S";
        public static string SouthLong { get; set; } = "South";
        public static string SouthWestShort { get; set; } = "SW";
        public static string SouthWestLong { get; set; } = "South-West";
        public static string WestShort { get; set; } = "W";
        public static string WestLong { get; set; } = "West";
        public static string NorthWestShort { get; set; } = "NW";
        public static string NorthWestLong { get; set; } = "North-West";
    }

    public class CloudDefintions
    {
        public static string CumulonimbusShort { get; set; } = "CB";
        public static string CumulonimbusLong { get; set; } = "Cumulonimbus";
        public static string ToweringCumulonimbusShort { get; set; } = "TCU";
        public static string ToweringCumulonimbusLong { get; set; } = "Towering Cumulonimbus";
        public static string FewCloudsShort { get; set; } = "FEW";
        public static string FewCloudsLong { get; set; } = "Few Clouds";
        public static string ScatteredCloudsShort { get; set; } = "SCT";
        public static string ScatteredCloudsLong { get; set; } = "Scattered Clouds";
        public static string BrokenCloudsShort { get; set; } = "BKN";
        public static string BrokenCloudsLong { get; set; } = "Broken Clouds";
        public static string OvercastCloudsShort { get; set; } = "OVC";
        public static string OvercastCloudsLong { get; set; } = "Overcast Clouds";
        public static string NoSignificantCloudsShort { get; set; } = "NSC";
        public static string NoSignificantCloudsLong { get; set; } = "No Significant Clouds";
        public static string NoCloudsDetectedShort { get; set; } = "NCD";
        public static string NoCloudsDetectedLong { get; set; } = "No Clouds Detected";
    }

    public class PressureDefinitions
    {
        public static string InchesMercuryShort { get; set; } = "A";
        public static string InchesMercuryLong { get; set; } = "Inches Mercury";
        public static string HectopascalsShort { get; set; } = "QNH";
        public static string HectopascalsLong { get; set; } = "Hectopascals";
    }

    public class RunwayDefinition
    {
        public static string LeftRunwayShort { get; set; } = "L";
        public static string LeftRunwayLong { get; set; } = "Left";
        public static string CenterRunwayShort { get; set; } = "C";
        public static string CenterRunwayLong { get; set; } = "Center";
        public static string RightRunwayShort { get; set; } = "R";
        public static string RightRunwayLong { get; set; } = "Right";
    }

    public class RVRDefinitions
    {
        public static string TendencyUpwardShort { get; set; } = "U";
        public static string TendencyUpwardLong { get; set; } = "Upward";
        public static string TendencyStagnantShort { get; set; } = "N";
        public static string TendencyStagnantLong { get; set; } = "Stagnant";
        public static string TendencyDownwardShort { get; set; } = "D";
        public static string TendencyDownwardLong { get; set; } = "Downward";
        public static string ValueLessThanShort { get; set; } = "M";
        public static string ValueLessThanLong { get; set; } = "Less";
        public static string ValueMoreThanShort { get; set; } = "P";
        public static string ValueMoreThanLong { get; set; } = "More";
    }

    //TODO
    public class WeatherDefinitions
    {
    }

    public class WindDefinitions
    {
        public static string KnotsShort { get; set; } = "KT";
        public static string KnotsLong { get; set; } = "Knots";
        public static string MilesPerHourShort { get; set; } = "MPH";
        public static string MilesPerHourLong { get; set; } = "Miles Per Hour";
        public static string MetersPerSecondShort { get; set; } = "MPS";
        public static string MetersPerSecondLong { get; set; } = "Meters Per Second";
    }
}
