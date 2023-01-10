using System.Timers;
using static MetarSharp.Extensions.Extensions;

namespace MetarSharp.Extensions
{
    public enum ReturnType
    {
        Number,
        NumberWithUnitShort,
        NumberWithUnitLong,
        FullString
    }

    public enum TimeUnit
    {
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks
    }

    public enum UnitReturnType
    {
        OneUnit,
        AllUnitsWithValue,
        AllUnits
    }
    
    //Return type for all will either be string or int
    //Number returns int,
    //All other return string
    public class TimeSinceMetar
    {
        public static dynamic GetTimeSinceMetar(Metar metar, ReturnType returnType) =>
            returnType switch
            {
                ReturnType.Number => JustNumber.Return(metar, null, null),
                ReturnType.NumberWithUnitShort => ShortUnit.Return(metar, null, null),
                ReturnType.NumberWithUnitLong => LongUnit.Return(metar, null, null),
                ReturnType.FullString => FullString.Return(metar, null, null)
            };

        public static dynamic GetTimeSinceMetar(Metar metar, ReturnType returnType, TimeUnit timeUnit) =>
            returnType switch
            {
                ReturnType.Number => JustNumber.Return(metar, timeUnit, null),
                ReturnType.NumberWithUnitShort => ShortUnit.Return(metar, timeUnit, null),
                ReturnType.NumberWithUnitLong => LongUnit.Return(metar, timeUnit, null),
                ReturnType.FullString => FullString.Return(metar, timeUnit, null)
            };

        public static dynamic GetTimeSinceMetar(Metar metar, ReturnType returnType, UnitReturnType unitReturnType) =>
            returnType switch
            {
                ReturnType.Number => JustNumber.Return(metar, null, unitReturnType),
                ReturnType.NumberWithUnitShort => ShortUnit.Return(metar, null, unitReturnType),
                ReturnType.NumberWithUnitLong => LongUnit.Return(metar, null, unitReturnType),
                ReturnType.FullString => FullString.Return(metar, null, unitReturnType)
            };

        public static dynamic GetTimeSinceMetar(Metar metar, ReturnType returnType, TimeUnit timeUnit,
            UnitReturnType unitReturnType) => returnType switch
        {
            ReturnType.Number => JustNumber.Return(metar, timeUnit, unitReturnType),
            ReturnType.NumberWithUnitShort => ShortUnit.Return(metar, timeUnit, unitReturnType),
            ReturnType.NumberWithUnitLong => LongUnit.Return(metar, timeUnit, unitReturnType),
            ReturnType.FullString => FullString.Return(metar, timeUnit, unitReturnType)
        };
    }
}