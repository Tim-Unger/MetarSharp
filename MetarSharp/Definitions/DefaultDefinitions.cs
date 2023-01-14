namespace MetarSharp.Definitions
{
    public enum Definitions
    {
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
        BlackLong
        #endregion

        #region WEATHER

        

        #endregion
    }

    public class DefaultDefinitions
    {
        public DistanceDefinitions DistanceDefinitions;
        public CardinalDirectionDefinitions CardinalDirectionDefinitions;
        public CloudDefintions CloudDefintions;
        public PressureDefinitions PressureDefinitions;
        public RunwayDefinition RunwayDefinition;
        public RVRDefinitions RvrDefinitions;
        public WeatherDefinitions WeatherDefinitions;
        public WindDefinitions WindDefinitions;
        public ColorCodeDefinitions CodeDefinitions;
    }

    

    

    

    

    

    

   

    
}
