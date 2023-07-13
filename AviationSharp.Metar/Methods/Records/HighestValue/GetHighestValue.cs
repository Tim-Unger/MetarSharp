using ValueType = MetarSharp.Extensions.ValueType;

namespace MetarSharp.Records.HighestValue
{
    internal class HighestValue
    {
        internal static Metar Get(List<Metar> metars, ValueType valueType) =>
            valueType switch
            {
                ValueType.ColorCode => HighestColorCode.Get(metars),
                ValueType.CloudCeiling => HighestCeiling.Get(metars),
                ValueType.VerticalVisibility => HighestVerticalVisibility.Get(metars),
                ValueType.PressureQNH => HighestPressure.GetQNH(metars),
                ValueType.PressureINHG => HighestPressure.GetINHG(metars),
                ValueType.ReportingTime => HighestReportingTime.Get(metars),
                ValueType.RunwayVisibility => throw new NotImplementedException(),  //TODO
                ValueType.TemperatureCelsius or ValueType.TemperatureFahrenheit => HighestTemperature.Get(metars),
                ValueType.Visibility => HighestVisibility.Get(metars),
                ValueType.WindStrength => HighestWindStrength.Get(metars),
                _ => throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null)
            };

        internal static dynamic Get(List<Metar> metars, ValueType valueType, ValueReturnType returnType) => valueType switch
        {
            ValueType.CloudCeiling => HighestCeiling.GetReturn(metars, returnType),
            ValueType.ColorCode => HighestColorCode.GetReturn(metars, returnType),
            ValueType.PressureQNH => HighestPressure.GetQNHReturn(metars, returnType, true),
            ValueType.PressureINHG => HighestPressure.GetINHGReturn(metars, returnType, false),
            ValueType.ReportingTime => HighestReportingTime.GetReturn(metars, returnType),
            ValueType.RunwayVisibility => throw new NotImplementedException(), //TODO
            ValueType.TemperatureCelsius => HighestTemperature.GetReturn(metars, returnType, true),
            ValueType.TemperatureFahrenheit => HighestTemperature.GetReturn(metars, returnType, false),
            ValueType.Visibility => HighestVisibility.GetReturn(metars, returnType),
            ValueType.WindStrength => HighestWindStrength.GetReturn(metars, returnType),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
