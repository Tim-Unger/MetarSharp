using static MetarSharp.Extensions.TimeExtensions;

namespace MetarSharp.Extensions
{
    internal class ShortUnit
    {
        internal static string Return(Metar metar, TimeUnit? timeUnit, UnitReturnType? unitReturnType)
        {
            var elapsedTime = DateTime.UtcNow - metar.ReportingTime.ReportingTimeZulu;

            if (timeUnit != null)
            {
                var value = GetCorrectTimeValue(elapsedTime);
                return ReturnSetUnit(elapsedTime, timeUnit.Value) + ReturnUnitString(timeUnit.Value, UnitType.Short, value);
            }

            if (unitReturnType != null)
            {
                return unitReturnType switch
                {
                    UnitReturnType.OneUnit => ReturnOneUnit(elapsedTime),
                    UnitReturnType.AllUnits => ReturnAllUnits(elapsedTime),
                    UnitReturnType.AllUnitsWithValue => ReturnAllUnitsWithValue(elapsedTime),
                    _ => throw new ParseException()
                };
            }

            return ReturnAllUnitsWithValue(elapsedTime);

        }

        private static string ReturnOneUnit(TimeSpan elapsedTime)
        {
            var elapsed = 0;
            if (elapsedTime.TotalSeconds <= 60)
            {
                elapsed = elapsedTime.Seconds;
                return elapsedTime.Seconds + ReturnUnitString(TimeUnit.Seconds, UnitType.Short, elapsed);
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                elapsed = elapsedTime.Minutes;
                return elapsedTime.Minutes + ReturnUnitString(TimeUnit.Minutes, UnitType.Short, elapsed);
            }

            if (elapsedTime.TotalHours <= 24)
            {
                elapsed = elapsedTime.Hours;
                return elapsedTime.Hours + ReturnUnitString(TimeUnit.Hours, UnitType.Short, elapsed);
            }

            elapsed = elapsedTime.Days;
            return elapsedTime.Days + ReturnUnitString(TimeUnit.Days, UnitType.Short, elapsed);
        }

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