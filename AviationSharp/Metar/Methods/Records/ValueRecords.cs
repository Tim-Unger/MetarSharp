using AviationSharp.Metar.Records.AverageValue;
using AviationSharp.Metar.Records.HighestValue;
using AviationSharp.Metar.Records.LowestValue;
using AviationSharp.Metar.Records.MedianValue;

namespace AviationSharp.Metar.Extensions
{
    //TODO an average anpassen
    public enum ValueType
    {
        ColorCode,
        CloudCeiling,
        VerticalVisibility,
        PressureQNH,
        PressureINHG,
        ReportingTime,
        RunwayVisibility,
        TemperatureCelsius,
        TemperatureFahrenheit,
        Visibility,
        LowestVisibility,
        WindDirection,
        WindStrength,
        WindGustStrength
    }

    public enum AverageValueType
    {
        CloudCeiling,
        VerticalVisibility,
        PressureQNH,
        PressureINHG,
        RunwayVisualRange,
        TemperatureCelsius,
        TemperatureFahrenheit,
        DewpointCelsius,
        DewpointFahrenheit,
        Visibility,
        LowestVisibility,
        WindDirection,
        WindStrength,
        WindGustStrength,
    }

    public enum ValueReturnType
    {
        FullMetar,
        JustValueClass,
        OnlyValue
    }
    
    public class ValueRecords
    {
        #region HIGHESTVALUE
        public static Metar GetHighestValue(List<Metar> metars, ValueType valueType)
        {
            return HighestValue.Get(metars, valueType);
        }

        public static Metar GetHighestValue(Metar[] metars, ValueType valueType)
        {
            return HighestValue.Get(metars.ToList(), valueType);
        }
        
        public static Metar GetHighestValue(IEnumerable<Metar> metars, ValueType valueType)
        {
            return HighestValue.Get(metars.ToList(), valueType);
        }
        
        public static dynamic GetHighestValue(List<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            return HighestValue.Get(metars, valueType, returnType);
        }

        public static dynamic GetHighestValue(Metar[] metars, ValueType valueType, ValueReturnType returnType)
        {
            return HighestValue.Get(metars.ToList(), valueType, returnType);
        }
        
        public static dynamic GetHighestValue(IEnumerable<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            return HighestValue.Get(metars.ToList(), valueType, returnType);
        }
        #endregion

        #region LOWESTVALUE

        public static Metar GetLowestValue(List<Metar> metars, ValueType valueType)
        {
            return LowestValue.Get(metars, valueType);
        }

        public static Metar GetLowestValue(Metar[] metars, ValueType valueType)
        {
            return LowestValue.Get(metars.ToList(), valueType);
        }

        public static Metar GetLowestValue(IEnumerable<Metar> metars, ValueType valueType)
        {
            return LowestValue.Get(metars.ToList(), valueType);
        }

        public static dynamic GetLowestValue(List<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            return LowestValue.Get(metars, valueType, returnType);
        }

        public static dynamic GetLowestValue(Metar[] metars, ValueType valueType, ValueReturnType returnType)
        {
            return LowestValue.Get(metars.ToList(), valueType, returnType);
        }

        public static dynamic GetLowestValue(IEnumerable<Metar> metars, ValueType valueType, ValueReturnType returnType)
        {
            return LowestValue.Get(metars.ToList(), valueType, returnType);
        }
        #endregion

        #region AVERAGEVALUE
        public static double GetAverageValue(List<Metar> metars, AverageValueType averageValueType, int decimalPlaces)
        {
            return AverageValue.Get(metars, averageValueType, decimalPlaces);
        }

        public static double GetAverageValue(Metar[] metars, AverageValueType averageValueType, int decimalPlaces)
        {
            return AverageValue.Get(metars.ToList(), averageValueType, decimalPlaces);
        }

        public static double GetAverageValue(IEnumerable<Metar> metars, AverageValueType averageValueType, int decimalPlaces)
        {
            return AverageValue.Get(metars.ToList(), averageValueType, decimalPlaces);
        }
        #endregion

        #region MEDIANVALUE
        public static Metar GetMedianValue(List<Metar> metars, AverageValueType averageValueType)
        {
            return MedianValue.Get(metars, averageValueType);
        }

        public static Metar GetMedianValue(List<Metar> metars, AverageValueType averageValueType, MidpointRounding midpointRounding)
        {
            return MedianValue.Get(metars, averageValueType, midpointRounding);
        }
        #endregion
    }
}