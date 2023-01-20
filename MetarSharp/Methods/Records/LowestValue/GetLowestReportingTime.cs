using MetarSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.LowestValue
{
    internal class LowestReportingTime
    {
        internal static Metar Get(List<Metar> metars)
        {
            return metars.OrderBy(x => x.ReportingTime.ReportingTimeZulu).First();
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetValue(metars),
        };


        private static ReportingTime GetClass(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.ReportingTime.ReportingTimeZulu)
                    .First()
                    .ReportingTime;
        }

        private static DateTime GetValue(List<Metar> metars)
        {
            return metars
                    .OrderBy(x => x.ReportingTime.ReportingTimeZulu)
                    .First()
                    .ReportingTime
                    .ReportingTimeZulu;
        }
    }
}
