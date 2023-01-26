using System.Diagnostics.Metrics;

namespace MetarSharp.Parse.ReadableReport
{
    internal class IsAutomated
    {
        /// <summary>
        /// This appends whether the metar is automated or not
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        internal static string Append(Metar metar)
        {
            return metar.IsAutomatedReport ? "Automated weather report " : "Weather report ";
        }
    }
}
