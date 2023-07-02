
using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Taf.Parse
{
    internal class ParseValidity
    {
        internal static Validity ReturnValidity(string raw)
        {
            var validity = new Validity();

            var validityRegex = new Regex("([0-9]{2})([0-9]{2})/([0-9]{2})([0-9]{2})");

            var tafValidityGroups = validityRegex.Matches(raw)[0].Groups;

            validity.ValidityRaw = tafValidityGroups[0].Value;

            var startDay = IntTryParseWithThrow(tafValidityGroups[1].Value);
            var startHour = IntTryParseWithThrow(tafValidityGroups[2].Value);

            validity.StartWindowRaw = $"{startDay}{startHour}";

            validity.StartDay = startDay;

            validity.StartHour = startHour;

            var dayNow = DateTime.UtcNow.Day;
            var monthNow = DateTime.UtcNow.Month;
            var yearNow = DateTime.UtcNow.Year;

            var startDateValues = ParseReportingTime.GetDateValues(startDay, dayNow, monthNow, yearNow);

            var startMinute = 0;

            //DateTime does not allow 24 as an hour since it is technically the next day, so we use 23:59 instead
            if (startHour == 24)
            {
                startHour = 23;
                startMinute = 59;
            }

            var startDateTime = new DateTime
                (
                    startDateValues.Year,
                    startDateValues.Month,
                    startDay,
                    startHour,
                    startMinute,
                    00
                );

            validity.StartDateTime = startDateTime;

            var endDay = IntTryParseWithThrow(tafValidityGroups[3].Value);
            var endHour = IntTryParseWithThrow(tafValidityGroups[4].Value);

            validity.EndWindowRaw = $"{endDay}{endHour}";

            validity.EndDay = endDay;

            validity.EndHour = endHour;

            var endDateValues = ParseReportingTime.GetDateValues(endDay, dayNow, monthNow, yearNow);

            var endMinute = 0;

            //DateTime does not allow 24 as an hour since it is technically the next day, so we use 23:59 instead
            if(endHour == 24)
            {
                endHour = 23;
                endMinute = 59;
            }

            var endDateTime = new DateTime
                (
                    endDateValues.Year,
                    endDateValues.Month,
                    endDay,
                    endHour,
                    endMinute,
                    00
                );

            validity.EndDateTime = endDateTime;

            validity.ValidityDuration = endDateTime - startDateTime;

            return validity;
        }
    }
}
