using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestReportingTime
    {
        internal static Metar Get(List<Metar> metars)
        {
            return metars.OrderByDescending(x => x.ReportingTime.ReportingTimeZulu).First();
        }

        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType returnType) => returnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetValue(metars),
        };

        private static ReportingTime GetClass (List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.ReportingTime.ReportingTimeZulu)
                    .First()
                    .ReportingTime;
        }

        private static DateTime GetValue(List<Metar> metars)
        {
            return metars
                    .OrderByDescending(x => x.ReportingTime.ReportingTimeZulu)
                    .First()
                    .ReportingTime
                    .ReportingTimeZulu;
        }
    }
}
