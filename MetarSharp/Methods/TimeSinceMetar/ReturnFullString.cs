using System.ComponentModel.Design.Serialization;
using static MetarSharp.Extensions.Extensions;
namespace MetarSharp.Extensions
{
    internal class FullString
    {
        internal static string Return(Metar metar, TimeUnit? timeUnit, UnitReturnType? unitReturnType)
        {
            var elapsedTime = DateTime.UtcNow - metar.ReportingTime.ReportingTimeZulu;

            if (timeUnit != null)
            {
                return
                    $"Reported {ReturnSetUnit(elapsedTime, timeUnit.Value)} {ReturnUnitString(timeUnit.Value, UnitType.Long)} ago";
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
                return $"Reported {elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return $"Reported {elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} ago";
            }
            
            if (elapsedTime.TotalHours <= 24)
            {
                return $"Reported {elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} ago";
            }

            return $"Reported {elapsedTime.Days} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} ago";
        }
        
        private static string ReturnAllUnits(TimeSpan elapsedTime)
        {
            return $"Reported {elapsedTime.Days} {TimeValueSingularOrPlural(elapsedTime.Days, TimeUnit.Days)}" +
                   $" {elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                   $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                   $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
        }
        
        private static string ReturnAllUnitsWithValue(TimeSpan elapsedTime)
        {
            if (elapsedTime.TotalSeconds <= 60)
            {
                return $"Reported {elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
            }

            if (elapsedTime.TotalMinutes <= 60)
            {
                return $"Reported {elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)}" +
                       $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
            }

            if (elapsedTime.TotalHours <= 24)
            {
                return $"Reported {elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                       $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                       $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
            }
            
            return $"Reported {elapsedTime.Days} {TimeValueSingularOrPlural(elapsedTime.Days, TimeUnit.Days)} " +
                   $"{elapsedTime.Hours} {TimeValueSingularOrPlural(elapsedTime.Hours, TimeUnit.Hours)} " +
                   $"{elapsedTime.Minutes} {TimeValueSingularOrPlural(elapsedTime.Minutes, TimeUnit.Minutes)} " +
                   $"{elapsedTime.Seconds} {TimeValueSingularOrPlural(elapsedTime.Seconds, TimeUnit.Seconds)} ago";
        }
    }
}