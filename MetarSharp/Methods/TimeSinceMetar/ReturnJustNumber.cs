using static MetarSharp.Extensions.TimeExtensions;

namespace MetarSharp.Extensions
{
    internal class JustNumber
    {
        //TODO UnitReturnType here
        internal static int Return(Metar metar, TimeUnit? timeUnit, UnitReturnType? unitReturnType)
        {
            var elapsedTime = DateTime.UtcNow - metar.ReportingTime.ReportingTimeZulu;

            if (timeUnit != null)
            {
                var value = ReturnSetUnit(elapsedTime, timeUnit.Value);
                var roundValue = Math.Round(value, 0);
                return Convert.ToInt32(roundValue);
            }
            
            if (elapsedTime.Seconds <= 60)
            {
                return elapsedTime.Seconds;
            }

            if (elapsedTime.Minutes <= 60)
            {
                return elapsedTime.Minutes;
            }

            return elapsedTime.Hours <= 24 ? elapsedTime.Hours : elapsedTime.Days;
        }
    }
}