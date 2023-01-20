namespace MetarSharp.Definitions
{
    public class MetarDefinition
    {
        public static object? Edit(Definitions definition, string newName) => definition switch
        {
            #region DISTANCE
            Definitions.KilometerShort => DistanceDefinitions.KilometerShort = newName,
            Definitions.KilometerLong => DistanceDefinitions.KilometerLong = newName,
            Definitions.MeterShort => DistanceDefinitions.MeterShort = newName,
            Definitions.MeterLong => DistanceDefinitions.MeterLong = newName,
            Definitions.StatuteMileShort => DistanceDefinitions.StatuteMileShort = newName,
            Definitions.StatuteMileLong => DistanceDefinitions.StatuteMileLong = newName,
            Definitions.MileShort => DistanceDefinitions.MileShort = newName,
            Definitions.MileLong => DistanceDefinitions.MileLong = newName,
            #endregion

            #region CARDINALDIRECTION
            Definitions.NorthShort => CardinalDirectionDefinitions.NorthShort = newName,
            Definitions.NorthLong => CardinalDirectionDefinitions.NorthLong = newName,
            Definitions.NorthEastShort => CardinalDirectionDefinitions.NorthEastShort = newName,
            Definitions.NorthEastLong => CardinalDirectionDefinitions.NorthEastLong = newName,
            Definitions.EastShort => CardinalDirectionDefinitions.EastShort = newName,
            Definitions.EastLong => CardinalDirectionDefinitions.EastLong = newName,
            Definitions.SouthEastShort => CardinalDirectionDefinitions.SouthEastShort = newName,
            Definitions.SouthEastLong => CardinalDirectionDefinitions.SouthEastLong = newName,
            Definitions.SouthShort => CardinalDirectionDefinitions.SouthShort = newName,
            Definitions.SouthLong => CardinalDirectionDefinitions.SouthLong = newName,
            Definitions.SouthWestShort => CardinalDirectionDefinitions.SouthWestShort = newName,
            Definitions.SouthWestLong => CardinalDirectionDefinitions.SouthWestLong = newName,
            Definitions.WestShort => CardinalDirectionDefinitions.WestShort = newName,
            Definitions.WestLong => CardinalDirectionDefinitions.WestLong = newName,
            Definitions.NorthWestShort => CardinalDirectionDefinitions.NorthWestShort = newName,
            Definitions.NorthWestLong => CardinalDirectionDefinitions.NorthWestLong = newName,
            #endregion

            #region CLOUD
            Definitions.CumulonimbusShort => CloudDefintions.CumulonimbusShort = newName,
            Definitions.CumulonimbusLong => CloudDefintions.CumulonimbusLong = newName,
            Definitions.ToweringCumulonimbusShort => CloudDefintions.ToweringCumulonimbusShort = newName,
            Definitions.ToweringCumulonimbusLong => CloudDefintions.ToweringCumulonimbusLong = newName,
            Definitions.FewCloudsShort => CloudDefintions.FewCloudsShort = newName,
            Definitions.FewCloudsLong => CloudDefintions.FewCloudsLong = newName,
            Definitions.ScatteredCloudsShort => CloudDefintions.ScatteredCloudsShort = newName,
            Definitions.ScatteredCloudsLong => CloudDefintions.ScatteredCloudsLong = newName,
            Definitions.BrokenCloudsShort => CloudDefintions.BrokenCloudsShort = newName,
            Definitions.BrokenCloudsLong => CloudDefintions.BrokenCloudsLong = newName,
            Definitions.OvercastCloudsShort => CloudDefintions.OvercastCloudsShort = newName,
            Definitions.OvercastCloudsLong => CloudDefintions.OvercastCloudsLong = newName,
            Definitions.NoSignificantCloudsShort => CloudDefintions.NoSignificantCloudsShort = newName,
            Definitions.NoSignificantCloudsLong => CloudDefintions.NoSignificantCloudsLong = newName,
            Definitions.NoCloudsDetectedShort => CloudDefintions.NoCloudsDetectedShort = newName,
            Definitions.NoCloudsDetectedLong => CloudDefintions.NoCloudsDetectedLong = newName,
            #endregion

            #region PRESSURE
            Definitions.InchesMercuryShort => PressureDefinitions.InchesMercuryShort = newName,
            Definitions.InchesMercuryLong => PressureDefinitions.InchesMercuryLong = newName,
            Definitions.HectopascalsShort => PressureDefinitions.HectopascalsShort = newName,
            Definitions.HectopascalsLong => PressureDefinitions.HectopascalsLong = newName,
            #endregion

            #region RUNWAY
            Definitions.LeftRunwayShort => RunwayDefinition.LeftRunwayShort = newName,
            Definitions.LeftRunwayLong => RunwayDefinition.LeftRunwayLong = newName,
            Definitions.CenterRunwayShort => RunwayDefinition.CenterRunwayShort = newName,
            Definitions.CenterRunwayLong => RunwayDefinition.CenterRunwayLong = newName,
            Definitions.RightRunwayShort => RunwayDefinition.RightRunwayShort = newName,
            Definitions.RightRunwayLong => RunwayDefinition.RightRunwayLong = newName,
            #endregion

            #region WEATHER
            //TODO
            #endregion

            #region WIND
            Definitions.KnotsShort => WindDefinitions.KnotsShort = newName,
            Definitions.KnotsLong => WindDefinitions.KnotsLong = newName,
            Definitions.MilesPerHourShort => WindDefinitions.MilesPerHourShort = newName,
            Definitions.MilesPerHourLong => WindDefinitions.MilesPerHourLong = newName,
            Definitions.MetersPerSecondShort => WindDefinitions.MetersPerSecondShort = newName,
            Definitions.MetersPerSecondLong => WindDefinitions.MetersPerSecondLong = newName,
            #endregion

            #region COLOR
            Definitions.BluePlusShort => ColorCodeDefinitions.BluePlusShort = newName,
            Definitions.BluePlusLong => ColorCodeDefinitions.BluePlusLong = newName,
            Definitions.BlueShort => ColorCodeDefinitions.BlueShort = newName,
            Definitions.BlueLong => ColorCodeDefinitions.BlueLong = newName,
            Definitions.WhiteShort => ColorCodeDefinitions.WhiteShort = newName,
            Definitions.WhiteLong => ColorCodeDefinitions.WhiteLong = newName,
            Definitions.GreenShort => ColorCodeDefinitions.GreenShort = newName,
            Definitions.GreenLong => ColorCodeDefinitions.GreenLong = newName,
            Definitions.YellowShort => ColorCodeDefinitions.YellowShort = newName,
            Definitions.YellowLong => ColorCodeDefinitions.YellowLong = newName,
            Definitions.AmberShort => ColorCodeDefinitions.AmberShort = newName,
            Definitions.AmberLong => ColorCodeDefinitions.AmberLong = newName,
            Definitions.RedShort => ColorCodeDefinitions.RedShort = newName,
            Definitions.RedLong => ColorCodeDefinitions.RedLong = newName,
            Definitions.BlackShort => ColorCodeDefinitions.BlackShort = newName,
            Definitions.BlackLong => ColorCodeDefinitions.BlackLong = newName
            #endregion
        };
    }
}
