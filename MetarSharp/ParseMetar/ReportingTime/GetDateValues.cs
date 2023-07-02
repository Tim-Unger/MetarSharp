namespace MetarSharp.Parse
{
    internal class GetDateValues
    {
        internal static DateValues Get(int reportingDate, int dayNow, int monthNow, int yearNow) => reportingDate switch
        {
            //current day equals reporting day
            //=> today
            int when reportingDate == dayNow => new DateValues { Month = monthNow, Year = yearNow },

            //current day is larger than reporting day
            //=> this month
            int when reportingDate < dayNow => new DateValues { Month = monthNow, Year = yearNow },

            //current day is smaller than reporting day
            //and days in month are greater or equal than reporting day
            //=> last month
            int
                when reportingDate > dayNow
                    && DateTime.DaysInMonth(yearNow, Months.Remove(1)) >= reportingDate
              => new DateValues { Month = Months.Remove(1), Year = Year.RemoveMonths(1) },

            //current day is smaller than reporting day
            //and days in month are smaller than reporting day
            //=> month before last
            int
                when reportingDate > dayNow
                    && DateTime.DaysInMonth(yearNow, Months.Remove(2)) >= reportingDate
              => new DateValues { Month = Months.Remove(2), Year = Year.RemoveMonths(1) },

            _ => throw new ParseException("Could not convert Reporting Date")
        };
    }
}
