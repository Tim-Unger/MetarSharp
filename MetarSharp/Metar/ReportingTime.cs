using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp
{
    public class ReportingTime
    {
        public string ReportingTimeRaw { get; set; }
        //The Reporting Date (01)
        public int ReportingDateRaw { get; set; }
        //The Reporting Time (1100)
        public int ReportingTimeZuluRaw { get; set; }
        /*
         * The Reporting Time as DateTime:
         * If the current day matches the day of the report, it will use the current day
         * If not, it will check if the day has passed in the current month
         * If not, it will check if the day has passed in the preceding month
         * If not (e.g. 31st in February) it will use the month before that
         */
        public DateTime ReportingTimeZulu { get; set; }
        //TODO
        //public DateTime? ReportingTimeCustom { get; set; }
    }
}
