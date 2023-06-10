namespace MetarSharp.Records.AverageValue
{
    internal class AverageValue
    {
        //These return only the value
        internal static double Get(List<Metar> metars, AverageValueType averageValueType) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling => AverageCeiling.Get(metars, null, false),
                AverageValueType.VerticalVisibility => AverageCeiling.Get(metars, null, true),
                AverageValueType.PressureINHG => AveragePressure.Get(metars, null, false),
                AverageValueType.PressureQNH => AveragePressure.Get(metars, null, true),
                AverageValueType.RunwayVisualRange => AverageRvr.Get(metars, null),
                AverageValueType.TemperatureCelsius => AverageTempDewpoint.Get(metars, true, true, null),
                AverageValueType.TemperatureFahrenheit => AverageTempDewpoint.Get(metars, false, true, null),
                AverageValueType.DewpointCelsius => AverageTempDewpoint.Get(metars, true, false, null),
                AverageValueType.DewpointFahrenheit => AverageTempDewpoint.Get(metars, false, false, null),
                AverageValueType.Visibility => AverageVisibility.Get(metars, false, null),
                AverageValueType.LowestVisibility => AverageVisibility.Get(metars, true, null),
                AverageValueType.WindDirection => AverageWind.Get(metars, WindType.Direction, null),
                AverageValueType.WindStrength => AverageWind.Get(metars, WindType.Strength, null),
                AverageValueType.WindGustStrength => AverageWind.Get(metars, WindType.GustStrength, null),
                _ => throw new ArgumentOutOfRangeException()
            };

        internal static double Get(List<Metar> metars, AverageValueType averageValueType, byte decimalPlaces) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling => AverageCeiling.Get(metars, decimalPlaces, false),
                AverageValueType.VerticalVisibility => AverageCeiling.Get(metars, decimalPlaces, true),
                AverageValueType.PressureINHG => AveragePressure.Get(metars, decimalPlaces, false),
                AverageValueType.PressureQNH => AveragePressure.Get(metars, decimalPlaces, true),
                AverageValueType.RunwayVisualRange => AverageRvr.Get(metars, decimalPlaces),
                AverageValueType.TemperatureFahrenheit => AverageTempDewpoint.Get(metars, false, true, decimalPlaces),
                AverageValueType.DewpointCelsius => AverageTempDewpoint.Get(metars, true, false, decimalPlaces),
                AverageValueType.DewpointFahrenheit => AverageTempDewpoint.Get(metars, false, false, decimalPlaces),
                AverageValueType.Visibility => AverageVisibility.Get(metars, false, decimalPlaces),
                AverageValueType.LowestVisibility => AverageVisibility.Get(metars, true, decimalPlaces),
                AverageValueType.WindDirection => AverageWind.Get(metars, WindType.Direction, decimalPlaces),
                AverageValueType.WindStrength => AverageWind.Get(metars, WindType.Strength, decimalPlaces),
                AverageValueType.WindGustStrength => AverageWind.Get(metars, WindType.GustStrength, decimalPlaces),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}
