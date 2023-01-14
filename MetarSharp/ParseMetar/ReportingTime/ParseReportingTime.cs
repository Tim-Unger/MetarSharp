using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp.Exceptions;

namespace MetarSharp.Parse
{
    internal class ParseReportingTime
    {
        public static ReportingTime ParseReportingTimeNew(string raw)
        {
            ReportingTime reportingTime = new();

            Regex reportingTimeRegex = new("([0-9]{2})([0-9]{2})([0-9]{2})Z", RegexOptions.None);

            MatchCollection reportingTimeMatches = reportingTimeRegex.Matches(raw);

            GroupCollection missingGroups = null;
            bool isNormalParseFailed = false;
            if (reportingTimeMatches.Count == 0)
            {
                isNormalParseFailed = true;
                
                Regex missingLetterRegex = new("([0-9]{2})([0-9]{1})([0-9]{2})Z", RegexOptions.None);

                var matches = missingLetterRegex.Matches(raw);

                if (matches.Count == 0)
                {
                    throw new ParseException("Could not find Reporting Time");
                }

                missingGroups = matches[0].Groups;

            }

            GroupCollection normalGroups = null;

            if (!isNormalParseFailed)
            {
                normalGroups = reportingTimeMatches[0].Groups;
            }

            var groups = isNormalParseFailed ? missingGroups : normalGroups;

            reportingTime.ReportingTimeRaw = groups[0].Value;

            var reportingDate = TryParseWithThrow(groups[1].Value);
            reportingTime.ReportingDateRaw = reportingDate;

            var reportingHour = TryParseWithThrow(groups[2].Value);
            var reportingMinute = TryParseWithThrow(groups[3].Value);
            reportingTime.ReportingTimeZuluRaw = TryParseWithThrow(
                groups[2].Value + groups[3].Value
            );

            var yearNow = DateTime.UtcNow.Year;
            var monthNow = DateTime.UtcNow.Month;
            var dayNow = DateTime.UtcNow.Day;

            //This switch is very complicated, I am sorry
            var dateValues = reportingDate switch
            {
                //current day equals reporting day
                int when reportingDate == dayNow => new Tuple<int, int>(monthNow,yearNow),
                
                //current day is larger than reporting day
                //= this month
                int when reportingDate < dayNow => new Tuple<int, int>(monthNow, yearNow),
                
                //current day is smaller than reporting day
                //and days in month are greater or equal than reporting day
                //= last month
                int
                    when reportingDate > dayNow
                        && DateTime.DaysInMonth(yearNow, RemoveMonths(1)) >= reportingDate
                  => new Tuple<int,int>(RemoveMonths(1),RemoveMonthsYear(1)),
                
                //current day is smaller than reporting day
                //and days in month are smaller than reporting day
                //= month before last
                int
                    when reportingDate > dayNow
                        && DateTime.DaysInMonth(yearNow, RemoveMonths(2)) >= reportingDate
                    => new Tuple<int, int>(RemoveMonths(2),RemoveMonthsYear(1)),

                _ => throw new Exception("Could not convert Reporting Date")
            };

            DateTime ReportingDateTime =
                new(dateValues.Item2, dateValues.Item1, reportingDate, reportingHour, reportingMinute, 00);

            reportingTime.ReportingTimeZulu = ReportingDateTime;
            return reportingTime;
        }
        private static int TryParseWithThrow(string value)
        {
            return int.TryParse(value, out int converted)
              ? converted
              : throw new Exception($"Could not convert value {value} to number");
        }

        private static int RemoveMonths(int months)
        {
            return DateTime.UtcNow.AddMonths(-months).Month;
        }

        private static int RemoveMonthsYear(int months)
        {
            return DateTime.UtcNow.AddMonths(-months).Year;
        }
    }
}
