using MetarSharp.Exceptions;

using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Taf.Parse
{
    internal class DateValues
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }

    internal class ParseReportingTime
    {
        internal static ReportingTime ReturnReportingTime(string raw)
        {
            var reportingTime = new ReportingTime();

            var reportingTimeRegex = new Regex("([0-9]{2})([0-9]{2})([0-9]{2})Z", RegexOptions.None);

            MatchCollection reportingTimeMatches = reportingTimeRegex.Matches(raw);

            GroupCollection? missingGroups = null;
            var isNormalParseFailed = false;
            if (reportingTimeMatches.Count == 0)
            {
                isNormalParseFailed = true;

                var missingLetterRegex =
                    new Regex("([0-9]{2})([0-9]{1})([0-9]{2})Z", RegexOptions.None);

                var matches = missingLetterRegex.Matches(raw);

                if (matches.Count == 0)
                {
                    throw new ParseException("Could not find Reporting Time");
                }

                missingGroups = matches[0].Groups;
            }

            GroupCollection? normalGroups = null;

            if (!isNormalParseFailed)
            {
                normalGroups = reportingTimeMatches[0].Groups;
            }

            var groups = (isNormalParseFailed ? missingGroups : normalGroups) ?? throw new ParseException();

            reportingTime.ReportingTimeRaw = groups[0].Value;

            var reportingDate = IntTryParseWithThrow(groups[1].Value);
            reportingTime.ReportingDateRaw = reportingDate;

            var reportingHour = IntTryParseWithThrow(groups[2].Value);
            var reportingMinute = IntTryParseWithThrow(groups[3].Value);
            reportingTime.ReportingTimeZuluRaw = IntTryParseWithThrow(
                groups[2].Value + groups[3].Value
            );

            var yearNow = DateTime.UtcNow.Year;
            var monthNow = DateTime.UtcNow.Month;
            var dayNow = DateTime.UtcNow.Day;

            //This switch is very complicated, I am sorry

            var dateValues = GetDateValues(reportingDate, dayNow, monthNow, yearNow);


            reportingTime.ReportingTimeZulu = new DateTime(
                    dateValues.Year,
                    dateValues.Month,
                    reportingDate,
                    reportingHour,
                    reportingMinute,
                    00
                );

            return reportingTime;
        }

        /// <summary>
        /// This removes the given number of months from the current UTC-DateTime and returns the Month of the DateTime
        /// Will throw if you use a negative number
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        private static int RemoveMonths(int months) =>
            months > 0
                ? DateTime.UtcNow.AddMonths(-months).Month
                : throw new ParseException("Please use a positive number");

        /// <summary>
        /// This removes the given number of months from the current UTC-DateTime and returns the year of the DateTime
        /// Will throw if you use a negative number
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        private static int RemoveMonthsYear(int months) =>
            months > 0
                ? DateTime.UtcNow.AddMonths(-months).Year
                : throw new ParseException("Please use a positive number");

        internal static DateValues GetDateValues(int reportingDate, int dayNow, int monthNow, int yearNow) => reportingDate switch
        {
            //current day equals reporting day
            //=> today
            int when reportingDate == dayNow => new DateValues { Month = monthNow, Year = yearNow},

            //current day is larger than reporting day
            //=> this month
            int when reportingDate < dayNow => new DateValues { Month = monthNow, Year = yearNow },

            //current day is smaller than reporting day
            //and days in month are greater or equal than reporting day
            //=> last month
            int
                when reportingDate > dayNow
                    && DateTime.DaysInMonth(yearNow, RemoveMonths(1)) >= reportingDate
              => new DateValues { Month = RemoveMonths(1), Year = RemoveMonthsYear(1) },

            //current day is smaller than reporting day
            //and days in month are smaller than reporting day
            //=> month before last
            int
                when reportingDate > dayNow
                    && DateTime.DaysInMonth(yearNow, RemoveMonths(2)) >= reportingDate
              => new DateValues { Month = RemoveMonths(2), Year = RemoveMonthsYear(1) },

            _ => throw new ParseException("Could not convert Reporting Date")
        };
    }
}
