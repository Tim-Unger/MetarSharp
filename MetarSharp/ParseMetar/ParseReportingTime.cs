using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public enum 
    internal class ParseReportingTime
    {
        public static ReportingTime ReturnReportingTime(string raw)
        {
            ReportingTime reportingTime = new ReportingTime();

            Regex ReportingTimeRegex = new Regex(
                "([0-9]{2})([0-9]{2})([0-9]{2})Z",
                RegexOptions.None
            );

            MatchCollection ReportingTimeMatches = ReportingTimeRegex.Matches(raw);

            if (ReportingTimeMatches.Count == 1)
            {
                //TODO
                GroupCollection Groups = ReportingTimeMatches[0].Groups;

                reportingTime.ReportingTimeRaw = ReportingTimeMatches[0].ToString();

                var ReportingDateString = Groups[1].Value;

                if (int.TryParse(ReportingDateString, out int ReportingDateInt))
                {
                    reportingTime.ReportingDateRaw = ReportingDateInt;
                    //TODO DateTime
                }

                var ReportingTimeString = Groups[2].Value + Groups[3].Value;
                
                reportingTime.ReportingTimeZuluRaw = int.TryParse(ReportingTimeString, out int _timeOut) ? _timeOut: 0000;
                //TODO DateTime

                //Report is from today
                int ReportingHour = Convert.ToInt32(Groups[2].Value);
                int ReportingMinute = Convert.ToInt32(Groups[3].Value);

                int day = DateTime.UtcNow.Day == ReportingDateInt ? DateTime.UtcNow.Day : ReportingDateInt;
                int thisMonthOrLastMonth = DateTime.UtcNow.Month > ReportingDateInt ? DateTime.UtcNow.Month : DateTime.UtcNow.AddMonths(-1).Month;
                int lastMonthOrBefore = DateTime.DaysInMonth(DateTime.UtcNow.Year, thisMonthOrLastMonth) <= ReportingDateInt ? thisMonthOrLastMonth : thisMonthOrLastMonth - 1;

                //TODO
                //DateTime reportingDateTime = new DateTime(
                //    DateTime.UtcNow.Year,
                //    month,
                //    day,
                //    ReportingHour,
                //    ReportingMinute,
                //    00
                //    );

                if (DateTime.UtcNow.Day == ReportingDateInt)
                {
                    DateTime ReportingTime = new DateTime(
                        DateTime.UtcNow.Year,
                        DateTime.UtcNow.Month,
                        DateTime.UtcNow.Day,
                        ReportingHour,
                        ReportingMinute,
                        00
                    );

                    reportingTime.ReportingTimeZulu = ReportingTime;
                }

                //Report is from this month
                if (DateTime.UtcNow.Day > ReportingDateInt)
                {
                    DateTime ReportingTime = new DateTime(
                        DateTime.UtcNow.Year,
                        DateTime.UtcNow.Month,
                        ReportingDateInt,
                        ReportingHour,
                        ReportingMinute,
                        00
                    );

                    reportingTime.ReportingTimeZulu = ReportingTime;

                }
                else
                {
                    //Report is from last month
                    var LastMonth = DateTime.UtcNow.AddMonths(-1).Month;
                    if (DateTime.DaysInMonth(DateTime.UtcNow.Year, LastMonth) <= ReportingDateInt)
                    {
                        DateTime ReportingTime = new DateTime(
                            DateTime.UtcNow.Year,
                            LastMonth,
                            ReportingDateInt,
                            ReportingHour,
                            ReportingMinute,
                            00
                        );

                        reportingTime.ReportingTimeZulu = ReportingTime;

                    }
                    //Report is from the month before that
                    else
                    {
                        DateTime ReportingTime = new DateTime(
                            DateTime.UtcNow.Year,
                            LastMonth - 1,
                            ReportingDateInt,
                            ReportingHour,
                            ReportingMinute,
                            00
                        );

                        reportingTime.ReportingTimeZulu = ReportingTime;

                    }
                }
            }

            return reportingTime;
        }
    }
}
