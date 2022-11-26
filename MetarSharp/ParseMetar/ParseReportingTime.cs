using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    internal class ParseReportingTime
    {
        public static ReportingTime ReturnReportingTime(string raw)
        {
            ReportingTime reportingTime = new ReportingTime();

            Regex reportingTimeRegex = new Regex(
                "([0-9]{2})([0-9]{2})([0-9]{2})Z",
                RegexOptions.None
            );

            MatchCollection reportingTimeMatches = reportingTimeRegex.Matches(raw);

            if (reportingTimeMatches.Count == 1)
            {
                //TODO
                GroupCollection groups = reportingTimeMatches[0].Groups;

                reportingTime.ReportingTimeRaw = reportingTimeMatches[0].ToString();

                var reportingDateString = groups[1].Value;

                if (int.TryParse(reportingDateString, out int reportingDateInt))
                {
                    reportingTime.ReportingDateRaw = reportingDateInt;
                    //TODO DateTime
                }

                var reportingTimeString = groups[2].Value + groups[3].Value;

                reportingTime.ReportingTimeZuluRaw = int.TryParse(
                    reportingTimeString,
                    out int reportingTimeInt
                )
                  ? reportingTimeInt
                  : throw new Exception("Could not read Reporting Time");
                //TODO DateTime

                //Report is from today
                int reportingHour = int.TryParse(groups[2].Value, out int reportingHourInt)
                  ? reportingHourInt
                  : throw new Exception("Could not read Reporting Hour");
                int reportingMinute = int.TryParse(groups[3].Value, out int reportingMinuteInt)
                  ? reportingMinuteInt
                  : throw new Exception("Could not read Reporting Minute");

                int currentYear = DateTime.UtcNow.Year;
                int currentMonth = DateTime.UtcNow.Month;
                int currentDay = DateTime.UtcNow.Day;

                int lastMonth = DateTime.UtcNow.AddMonths(-1).Month;
                int monthBeforeLastMonth = DateTime.UtcNow.AddMonths(-2).Month;

                int daysInLastMonth = DateTime.DaysInMonth(
                    DateTime.UtcNow.Year,
                    DateTime.UtcNow.AddMonths(-1).Month
                );
                int daysInMonthBeforeLast = DateTime.DaysInMonth(
                    DateTime.UtcNow.Year,
                    DateTime.UtcNow.AddMonths(-2).Month
                );

                DateTime reportingTimeDateTime = reportingDateInt switch
                {
                    //Metar is from the current day
                    int when reportingDateInt == currentDay
                      => new DateTime(
                          currentYear,
                          currentMonth,
                          currentDay,
                          reportingHour,
                          reportingMinute,
                          00
                      ),
                    //Metar is from the current month
                    int when reportingDateInt < currentDay
                      => new DateTime(
                          currentYear,
                          currentMonth,
                          reportingDateInt,
                          reportingHour,
                          reportingMinute,
                          00
                      ),
                    //Metar is from last month
                    int
                        when reportingDateInt >= daysInLastMonth
                            && reportingDateInt <= daysInMonthBeforeLast
                      => new DateTime(
                          //To cover case where last month would be December
                          DateTime.UtcNow.AddMonths(-1).Year,
                          lastMonth,
                          reportingDateInt,
                          reportingHour,
                          reportingMinute,
                          00
                      ),
                    //Metar is from the month before last Month
                    int
                        when reportingDateInt <= daysInLastMonth
                            && reportingDateInt >= daysInMonthBeforeLast
                      => new DateTime(
                          //To cover case where last month would be November
                          DateTime.UtcNow.AddMonths(-2).Year,
                          monthBeforeLastMonth,
                          reportingDateInt,
                          reportingHour,
                          reportingMinute,
                          00
                      ),
                    _ => throw new Exception("Could not find Reporting Month of Metar")
                };

                reportingTime.ReportingTimeZulu = reportingTimeDateTime;

                //if (DateTime.UtcNow.Day == ReportingDateInt)
                //{
                //    DateTime ReportingTime = new DateTime(
                //        DateTime.UtcNow.Year,
                //        DateTime.UtcNow.Month,
                //        DateTime.UtcNow.Day,
                //        ReportingHour,
                //        ReportingMinute,
                //        00
                //    );

                //    reportingTime.ReportingTimeZulu = ReportingTime;
                //}

                //Report is from this month
                //if (DateTime.UtcNow.Day > ReportingDateInt)
                //{
                //    DateTime ReportingTime = new DateTime(
                //        DateTime.UtcNow.Year,
                //        DateTime.UtcNow.Month,
                //        ReportingDateInt,
                //        ReportingHour,
                //        ReportingMinute,
                //        00
                //    );

                //    reportingTime.ReportingTimeZulu = ReportingTime;
                //}
                //else
                //{
                //    //Report is from last month
                //    var LastMonth = DateTime.UtcNow.AddMonths(-1).Month;
                //    if (DateTime.DaysInMonth(DateTime.UtcNow.Year, LastMonth) <= ReportingDateInt)
                //    {
                //        DateTime ReportingTime = new DateTime(
                //            DateTime.UtcNow.Year,
                //            LastMonth,
                //            ReportingDateInt,
                //            ReportingHour,
                //            ReportingMinute,
                //            00
                //        );

                //        reportingTime.ReportingTimeZulu = ReportingTime;
                //    }
                //    //Report is from the month before that
                //    else
                //    {
                //        DateTime ReportingTime = new DateTime(
                //            DateTime.UtcNow.Year,
                //            LastMonth - 1,
                //            ReportingDateInt,
                //            ReportingHour,
                //            ReportingMinute,
                //            00
                //        );

                //        reportingTime.ReportingTimeZulu = ReportingTime;
                //    }
            }
            return reportingTime;
        }
    }
}
