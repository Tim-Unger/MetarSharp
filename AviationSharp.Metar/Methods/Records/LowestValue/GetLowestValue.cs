using ValueType = MetarSharp.Extensions.ValueType;

namespace MetarSharp.Records.LowestValue
{
    internal class LowestValue
    {
        internal static Metar Get(List<Metar> metars, ValueType valueType) => valueType switch
        {
            ValueType.ColorCode => LowestColorCode.Get(metars),
            ValueType.PressureQNH or ValueType.PressureINHG => LowestPressure.Get(metars),
            ValueType.ReportingTime => LowestReportingTime.Get(metars),
            ValueType.RunwayVisibility => throw new NotImplementedException(), //TODO
            ValueType.TemperatureCelsius or ValueType.TemperatureFahrenheit => LowestTemperature.Get(metars),
            ValueType.Visibility => LowestVisibility.Get(metars),
            ValueType.WindStrength => LowestWindSpeed.Get(metars),
            _ => throw new ArgumentOutOfRangeException()
        };

        internal static dynamic Get(List<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            return valueType switch
            {
                ValueType.ColorCode => LowestColorCode.GetReturn(metars, returnType),
                ValueType.PressureQNH => LowestPressure.GetReturn(metars, returnType, true),
                ValueType.PressureINHG => LowestPressure.GetReturn(metars, returnType, false),
                ValueType.ReportingTime => LowestReportingTime.GetReturn(metars, returnType),
                ValueType.RunwayVisibility => throw new NotImplementedException(),
                ValueType.TemperatureCelsius => LowestTemperature.GetReturn(metars, returnType, true),
                ValueType.TemperatureFahrenheit => LowestTemperature.GetReturn(metars, returnType, false),
                ValueType.Visibility => LowestVisibility.GetReturn(metars, returnType),
                ValueType.WindStrength => LowestWindSpeed.GetReturn(metars, returnType),
                _ => throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null),
            };
        }
    }
}