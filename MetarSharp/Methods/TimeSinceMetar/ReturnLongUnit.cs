using static MetarSharp.Extensions.Extensions;

namespace MetarSharp.Extensions
{
    internal class LongUnit
    {
        internal static string Return(Metar metar, TimeUnit? timeUnit, UnitReturnType? unitReturnType)
        {
            var elapsedTime = DateTime.UtcNow - metar.ReportingTime.ReportingTimeZulu;

            if (timeUnit != null)
            {
                return ReturnSetUnit(elapsedTime, timeUnit.Value) + ReturnUnitString(timeUnit.Value, UnitType.Long);
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
                return elapsedTime.Seconds + " " + ReturnUnitString(TimeUnit.Seconds, UnitType.Long);
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return elapsedTime.Minutes + " " + ReturnUnitString(TimeUnit.Minutes, UnitType.Long);
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return elapsedTime.Hours + " " + ReturnUnitString(TimeUnit.Hours, UnitType.Long);
            }
            
            return elapsedTime.Days + " " + ReturnUnitString(TimeUnit.Days, UnitType.Long);
        }

        private static string ReturnAllUnits(TimeSpan elapsedTime)
        {
            return $"{elapsedTime.Days} {TimeValueSingularOrPlural(elapsedTime.Days, TimeUnit.Days)} " +
                   $"{elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                   $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                   $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)}";
        }
        
        private static string ReturnAllUnitsWithValue(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds <= 60)
            {
                return $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)}";
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                       $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)}";
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return $"{elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                       $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                       $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)}";
            }
            
            return $"{elapsedTime.Days} {TimeValueSingularOrPlural(elapsedTime.Days, TimeUnit.Days)} " +
                   $"{elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                   $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)}" +
                   $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)}";
        }
    }
}