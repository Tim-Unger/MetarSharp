namespace MetarSharp.Extensions
{
    internal class HighestValue
    {
        internal static Metar Get(List<Metar> metars, ValueType valueType) => valueType switch
        {
            ValueType.ColorCode => metars.Where(x => x.AdditionalInformation.ColorCode != null)
                .ToList()
                .OrderByDescending(x => x.AdditionalInformation.ColorCode.Color)
                .First(),
            ValueType.Pressure => metars.OrderByDescending(x => x.Pressure.PressureOnly).First(),
            ValueType.ReportingTime => metars.OrderByDescending(x => x.ReportingTime.ReportingTimeZulu).First(),
            // ValueType.RunwayVisibility => metars.Where(x => x.RunwayVisibilities != null)
            //     .ToList()
            //     .SelectMany(x => x).ToList().First()
            ValueType.Temperature => metars.Where(x => x.Temperature.IsTemperatureMeasurable)
                .ToList()
                .OrderByDescending(x => (int)x.Temperature.TemperatureCelsius)
                .First(),
            ValueType.Visibility => metars.Where(x => x.Visibility.IsVisibilityMeasurable)
                .ToList()
                .OrderByDescending(x => x.Visibility.ReportedVisibility)
                .First(),
            ValueType.Wind => metars.Where(x => x.Wind.IsWindMeasurable)
                .ToList()
                .OrderByDescending(x => x.Wind.WindStrength)
                .First()
        };

        internal static dynamic Get(List<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            switch (valueType)
            {
                case ValueType.ColorCode:
                    var colorCodeHighest = metars.Where(x => x.AdditionalInformation.ColorCode != null)
                        .ToList()
                        .OrderByDescending(x => x.AdditionalInformation.ColorCode.Color)
                        .First();
                    return GetReturnType(colorCodeHighest, valueType, returnType);
                
                case ValueType.Pressure:
                    var pressureHighest = metars.OrderByDescending(x => x.Pressure.PressureOnly).First();
                    return GetReturnType(pressureHighest, valueType, returnType);
                
                case ValueType.ReportingTime:
                    var reportingTimeHighest = metars.OrderByDescending(x => x.ReportingTime.ReportingTimeZulu).First();
                    return GetReturnType(reportingTimeHighest, valueType, returnType);
                
                case ValueType.RunwayVisibility:
                    //var rvrHighest = 
                    break;
                
                case ValueType.Temperature:
                    var temperatureHighest = metars.Where(x => x.Temperature.IsTemperatureMeasurable)
                        .ToList()
                        .OrderByDescending(x => (int)x.Temperature.TemperatureCelsius)
                        .First();
                    return GetReturnType(temperatureHighest, valueType, returnType);
                
                case ValueType.Visibility:
                    var visibilityHighest = metars.Where(x => x.Visibility.IsVisibilityMeasurable)
                        .ToList()
                        .OrderByDescending(x => x.Visibility.ReportedVisibility)
                        .First();
                    return GetReturnType(visibilityHighest, valueType, returnType);
                
                case ValueType.Wind:
                    var windHighest = metars.Where(x => x.Wind.IsWindMeasurable)
                        .ToList()
                        .OrderByDescending(x => x.Wind.WindStrength)
                        .First();
                    return GetReturnType(windHighest, valueType, returnType);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null);
            }
            
            //You should not be able to get here
            throw new Exception();
        }

        //TODO idk
        private static dynamic GetReturnType(Metar metar, ValueType valueType, ValueReturnType returnType)
        {
            return valueType switch
            {
                ValueType.ColorCode => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.AdditionalInformation.ColorCode,
                    ValueReturnType.OnlyValue => metar.AdditionalInformation.ColorCode.Color
                },
                ValueType.Pressure => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.Pressure,
                    ValueReturnType.OnlyValue => metar.Pressure.PressureOnly
                },
                ValueType.ReportingTime => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.ReportingTime,
                    ValueReturnType.OnlyValue => metar.ReportingTime.ReportingTimeZulu
                },
                ValueType.Temperature => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.Temperature,
                    ValueReturnType.OnlyValue => metar.Temperature.TemperatureCelsius
                },
                ValueType.Visibility => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.Visibility,
                    ValueReturnType.OnlyValue => metar.Visibility.ReportedVisibility
                },
                ValueType.Wind => returnType switch
                {
                    ValueReturnType.FullMetar => metar,
                    ValueReturnType.JustValueClass => metar.Wind,
                    ValueReturnType.OnlyValue => metar.Wind.WindStrength
                },
                ValueType.RunwayVisibility => throw new NotImplementedException(),
                _ => throw new Exception()
            };
        }
    }
}