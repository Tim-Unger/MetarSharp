using MetarSharp.Extensions;
using MetarSharp.Methods.Records.LowestValue;
using ValueType = MetarSharp.Extensions.ValueType;

namespace MetarSharp.Methods.Records.HighestValue
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
                ValueType.ReportingTime => HighestReportingTime.Get(metars),
                ValueType.RunwayVisibility => throw new NotImplementedException(),  //TODO
                ValueType.TemperatureCelsius or ValueType.TemperatureFahrenheit => HighestTemperature.Get(metars),
                ValueType.Visibility => HighestVisibility.Get(metars),
                ValueType.WindStrength => HighestWindStrength.Get(metars),
                _ => throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null)
            };

        internal static dynamic Get(List<Metar> metars, ValueType valueType, ValueReturnType returnType) => valueType switch
        {
            ValueType.ColorCode => LowestColorCode.GetReturn(metars, returnType),
            ValueType.PressureQNH => LowestPressure.GetReturn(metars, returnType, true),
            ValueType.PressureINHG => LowestPressure.GetReturn(metars, returnType, false),
            ValueType.ReportingTime => LowestReportingTime.GetReturn(metars, returnType),
            ValueType.RunwayVisibility => throw new NotImplementedException(), //TODO
            ValueType.TemperatureCelsius => LowestTemperature.GetReturn(metars, returnType, true),
            ValueType.TemperatureFahrenheit => LowestTemperature.GetReturn(metars, returnType, false),
            ValueType.Visibility => LowestVisibility.GetReturn(metars, returnType),
            ValueType.WindStrength => LowestWindSpeed.GetReturn(metars, returnType),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
