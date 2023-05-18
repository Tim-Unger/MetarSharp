namespace MetarSharp.Definitions
{
    public enum Definitions
    {
        //TODO units singular or plural (second, seconds)?
        #region DISTANCE
        KilometerShort,
        KilometerLong,
        MeterShort,
        MeterLong,
        StatuteMileShort,
        StatuteMileLong,
        MileShort,
        MileLong,
        #endregion

        #region CARDINALDIRECTION
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
        #endregion

        #region CLOUDTYPE
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
        #endregion

        #region PRESSURE
        InchesMercuryShort,
        InchesMercuryLong,
        HectopascalsShort,
        HectopascalsLong,
        #endregion

        #region RUNWAY
        LeftRunwayShort,
        LeftRunwayLong,
        CenterRunwayShort,
        CenterRunwayLong,
        RightRunwayShort,
        RightRunwayLong,
        #endregion

        #region RVR
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
        #endregion

        #region WIND
        KnotsShort,
        KnotsLong,
        MilesPerHourShort,
        MilesPerHourLong,
        MetersPerSecondShort,
        MetersPerSecondLong,
        #endregion

        #region COLOR
        BluePlusShort,
        BluePlusLong,
        BlueShort,
        BlueLong,
        WhiteShort,
        WhiteLong,
        GreenShort,
        GreenLong,
        YellowShort,
        YellowLong,
        AmberShort,
        AmberLong,
        RedShort,
        RedLong,
        BlackShort,
        BlackLong,
        #endregion

        #region WEATHER
        Recent,
        InTheVicinity,

        LightIntensity,
        NormalIntensity,
        HeavyItensity,

        Patches,
        Partial,
        LowDrifting,
        Blowing,
        Shower,
        Thunderstorm,
        Freezing,
        Drizzle,
        Rain,
        Snow,
        SnowGrains,
        IcePellets,
        Hail,
        SmallHail,
        Unknown,
        Mist,
        Fog,
        Smoke,
        VolcanicAsh,
        WidespreadDust,
        Sand,
        Haze,
        SandWhirls,
        Squall,
        Tornado,
        Sandstorm,
        Duststorm
        #endregion
    }

    public class DefaultDefinitions
    {
        public DistanceDefinitions DistanceDefinitions = new();
        public CardinalDirectionDefinitions CardinalDirectionDefinitions = new();
        public CloudDefintions CloudDefintions = new();
        public PressureDefinitions PressureDefinitions = new();
        public RunwayDefinition RunwayDefinition = new();
        public RVRDefinitions RvrDefinitions = new();
        public WeatherDefinitions WeatherDefinitions = new();
        public WindDefinitions WindDefinitions = new();
        public ColorCodeDefinitions CodeDefinitions = new();
    }
}