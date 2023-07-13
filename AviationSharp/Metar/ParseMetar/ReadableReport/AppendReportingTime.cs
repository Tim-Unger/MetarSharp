namespace AviationSharp.Metar.Parse.ReadableReport
{
    internal class ReportingTime
    {
        private static readonly CultureInfo defaultCulture = new("de-DE");

        /// <summary>
        /// This appends the reporting time and date to the readable report
        /// </summary>
        /// <param name="metar"></param>
        /// <returns>string</returns>
        internal static string Append(Metar metar, CultureInfo? cultureInfo)
        {
            var reportingDate = "";

            var setCulture = cultureInfo ?? defaultCulture;

            var reportingTime =
                $"at {metar.ReportingTime.ReportingTimeZulu.ToString("t", setCulture)} UTC";

            //Returns if the metar was reported today
            if (metar.ReportingTime.ReportingTimeZulu.Day == DateTime.UtcNow.Day)
            {
                reportingDate = "Reported today ";

                return reportingDate + reportingTime;
            }

            //Turns the day into a written day (1st, 2nd, 12th, etc)
            var dayNumber = metar.ReportingTime.ReportingTimeZulu.Day;
            var dayWritten = ConvertDay(dayNumber);

            //returns the written out month in English
            var monthWritten = metar.ReportingTime.ReportingTimeZulu.ToString(
                "MMMM",
                setCulture
            );
            var reportingYear = metar.ReportingTime.ReportingTimeZulu.Year;
            var yearwritten = reportingYear < DateTime.UtcNow.Year ? $" {reportingYear}" : null;
            reportingDate = $"Reported on the {dayWritten} of {monthWritten}{yearwritten}";

            return reportingDate + reportingTime;
        }

        private static string ConvertDay(int dayNumber) =>
            dayNumber switch
            {
                1 or 21 or 31 => dayNumber + "st",
                2 or 22 => dayNumber + "nd",
                3 => dayNumber + "rd",
                _ => dayNumber + "th",
            };
    }
}
