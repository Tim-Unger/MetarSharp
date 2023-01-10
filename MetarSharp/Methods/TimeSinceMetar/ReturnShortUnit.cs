using static MetarSharp.Extensions.Extensions;

namespace MetarSharp.Extensions
{
    internal class ShortUnit
    {
        internal static string Return(Metar metar, TimeUnit? timeUnit, UnitReturnType? unitReturnType)
        {
            var elapsedTime = DateTime.UtcNow - metar.ReportingTime.ReportingTimeZulu;

            if (timeUnit != null)
            {
                return ReturnSetUnit(elapsedTime, timeUnit.Value) + ReturnUnitString(timeUnit.Value, UnitType.Short);
            }

            if (unitReturnType != null)
            {
                return unitReturnType switch
                {
                    UnitReturnType.OneUnit => ReturnOneUnit(elapsedTime),
                    UnitReturnType.AllUnits => ReturnAllUnits(elapsedTime),
                    UnitReturnType.AllUnitsWithValue => ReturnAllUnitsWithValue(elapsedTime)
                };
            }

            return ReturnAllUnitsWithValue(elapsedTime);

        }

        private static string ReturnOneUnit(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds <= 60)
            {
                return elapsedTime.Seconds + ReturnUnitString(TimeUnit.Seconds, UnitType.Short);
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return elapsedTime.Minutes + ReturnUnitString(TimeUnit.Minutes, UnitType.Short);
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return elapsedTime.Hours + ReturnUnitString(TimeUnit.Hours, UnitType.Short);
            }
            
            return elapsedTime.Days + ReturnUnitString(TimeUnit.Days, UnitType.Short);
        }

        //TODO Edit Time Definitions
        private static string ReturnAllUnits(TimeSpan elapsedTime)
        {
            return $"{elapsedTime.Days}d {elapsedTime.Hours}h {elapsedTime.Minutes}m {elapsedTime.Seconds}s";
        }
        
        private static string ReturnAllUnitsWithValue(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds <= 60)
            {
                return $"{elapsedTime.Seconds}s";
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return $"{elapsedTime.Minutes}m {elapsedTime.Seconds}s";
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return $"{elapsedTime.Hours}h {elapsedTime.Minutes}m {elapsedTime.Seconds}s";
            }
            
            return $"{elapsedTime.Days}d {elapsedTime.Hours}h {elapsedTime.Minutes}m {elapsedTime.Seconds}s";
        }
    }
}