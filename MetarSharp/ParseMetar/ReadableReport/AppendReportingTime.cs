using Gee.External.Capstone.Arm64;
using System.Globalization;

namespace MetarSharp.Parse.ReadableReport
{
    internal class ReportingTime
    {
        /// <summary>
        /// This appends the reporting time and date to the readable report
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        internal static string Append(Metar metar)
        {
            string reportingDate = "";

            string reportingTime =
                " at " + metar.ReportingTime.ReportingTimeZulu.ToString("t") + " UTC" + "\n";

            if (metar.ReportingTime.ReportingTimeZulu.Day == DateTime.UtcNow.Day)
            {
                reportingDate = "Reported today";

                return reportingDate + ' ' + reportingTime;
            }

            //Turns the day into a written day (1st, 2nd, 12th, etc)
            int dayNumber = metar.ReportingTime.ReportingTimeZulu.Day;
            string dayWritten = ConvertDay(dayNumber);

            string monthWritten = metar.ReportingTime.ReportingTimeZulu.ToString("MMMM", new CultureInfo("en-UK"));
            reportingDate = "Reported on the " + dayWritten + " of " + monthWritten;

            return reportingDate + ' ' + reportingTime;
        }

        private static string ConvertDay(int dayNumber) => dayNumber switch
        {
            1 or 21 or 31 => dayNumber + "st",
            2 or 22 => dayNumber + "nd",
            3 => dayNumber + "rd",
            _ => dayNumber + "th",
        };
    }
}
