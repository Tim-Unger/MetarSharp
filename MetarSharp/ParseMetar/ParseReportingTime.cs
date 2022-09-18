using System;
using System.Collections.Generic;
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

            Regex ReportingTimeRegex = new Regex("([0-9]{2})([0-9]{4})Z", RegexOptions.None);

            MatchCollection ReportingTimeMatches = ReportingTimeRegex.Matches(raw);

            //TODO
            if(ReportingTimeMatches.Count == 1)
            {
                //TODO
                var MatchToString = ReportingTimeMatches[0].ToString();

                reportingTime.ReportingTimeRaw = MatchToString;
                
                var ReportingDateString = MatchToString.Substring(0, 2);

                bool IsReportingDateInt = int.TryParse(ReportingDateString, out int ReportingDateInt);

                if (IsReportingDateInt)
                {
                    reportingTime.ReportingDateRaw = ReportingDateInt;
                    //TODO DateTime
                }
                else { }

                
                var ReportingTimeString = MatchToString.Substring(2, 4);
            
                bool IsReportingTimeInt = int.TryParse(ReportingDateString, out int ReportingTimeInt);

                if (IsReportingTimeInt)
                {
                    reportingTime.ReportingTimeZuluRaw = ReportingTimeInt;
                    //TODO DateTime

                }
                else { }


            }

            else
            {

            }

            ParseMetar.RawMetarString.RestOfMetar = Regex.Replace(raw, "[0-9]{6}[a-zA-Z]{1}", "");
            return reportingTime; 
        }
    }
}
