using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Exceptions
{
    public enum ParseType
    {
        AdditionalInfo,
        CardinalDirection,
        Cloud,
        ColorCode,
        Pressure,
        RecentWeather,
        ReportingTime,
        RunwayCondition,
        RunwayVisibility,
        Temperature,
        Trend,
        Visibility,
        Weather,
        Wind,
        WindShear
    }

    internal class Exceptions
    {
        public static Exception ParseException(ParseType type, string input)
        {
            string messageType = type switch
            {
                ParseType.AdditionalInfo => ""
            };

            string message = $"Could not convert {input} to {messageType}";

            return new Exception(message);
        }
    }
}
