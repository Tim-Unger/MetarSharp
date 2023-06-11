using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Parse
{
    internal class DateValues
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }

    internal class ParseReportingTime
    {
        private static readonly Regex _reportingTimeRegex = new("([0-9]{2})([0-9]{2})([0-9]{2})Z");
        internal static ReportingTime ReturnReportingTime(string raw)
        {
            ReportingTime reportingTime = new();

            MatchCollection reportingTimeMatches = _reportingTimeRegex.Matches(raw);

            GroupCollection? missingGroups = null;

            //In very rare cases the reporting time of the is missing the last letter, so we need to check if the reporting time is valid even if a letter is missing
            var isNormalParseFailed = false;
            if (reportingTimeMatches.Count == 0)
            {
                isNormalParseFailed = true;

                Regex missingLetterRegex =
                    new("([0-9]{2})([0-9]{1})([0-9]{2})Z", RegexOptions.None);

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

            var dateValues = GetDateValues.Get(reportingDate, dayNow, monthNow, yearNow);

            DateTime ReportingDateTime =
                new(
                    dateValues.Year,
                    dateValues.Month,
                    reportingDate,
                    reportingHour,
                    reportingMinute,
                    00
                );

            reportingTime.ReportingTimeZulu = ReportingDateTime;
            return reportingTime;
        }
    }
}
