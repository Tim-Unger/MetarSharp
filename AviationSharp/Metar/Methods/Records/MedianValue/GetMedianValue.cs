namespace AviationSharp.Metar.Records.MedianValue
{
    internal class MedianValue
    {
        internal static Metar Get(List<Metar> metars, AverageValueType averageValueType) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling => MedianCeiling.Get(metars, null),
                AverageValueType.PressureQNH
                or AverageValueType.PressureINHG => MedianPressure.Get(metars, null),
                AverageValueType.TemperatureCelsius
                or AverageValueType.TemperatureFahrenheit => MedianTemperature.Get(metars, null),
                _ => throw new ArgumentOutOfRangeException()
            };

        internal static Metar Get(List<Metar> metars, AverageValueType averageValueType, MidpointRounding midpointRounding
        ) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling => MedianCeiling.Get(metars, midpointRounding),
                AverageValueType.PressureQNH
                or AverageValueType.PressureINHG => MedianPressure.Get(metars, midpointRounding),
                AverageValueType.TemperatureCelsius
                or AverageValueType.TemperatureFahrenheit => MedianTemperature.Get(metars, midpointRounding),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}
