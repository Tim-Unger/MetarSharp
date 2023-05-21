using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    public class ParseReadableReport
    {
        /// <summary>
        /// this creates a readable report of the entire metar.
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        public static string ReturnReadableReport(Metar metar)
        {
            var reportBuilder = new StringBuilder();

            //Is Automated
            reportBuilder.Append(IsAutomated.Append(metar));

            //Airport
            reportBuilder.Append(Airport.Append(metar));

            reportBuilder.AppendLine();

            //Reporting Time
            reportBuilder.AppendLine(ReportingTime.Append(metar));

            //Wind
            reportBuilder.AppendLine(Wind.Append(metar));

            //Visibility
            reportBuilder.AppendLine(Visibility.Append(metar));

            //RVRs
            //Null check is not really necessary, just to prevent any possible exceptions
            if (metar.RunwayVisibilities != null && metar.RunwayVisibilities.Count > 0)
            {
                reportBuilder.AppendLine(RVR.Append(metar));
            }

            //Weather
            if (metar.Weather != null && metar.Weather.Weathers.Count > 0)
            {
                reportBuilder.AppendLine(Weather.Append(metar));
            }

            //Clouds
            if(!metar.Clouds.Any(x => x.IsCAVOK))
            {
                reportBuilder.AppendLine(Clouds.Append(metar));
            }

            //Temperature
            reportBuilder.Append(Temperature.Append(metar)).Append(' ');

            //Dewpoint
            reportBuilder.AppendLine(Dewpoint.Append(metar));

            //Pressure
            reportBuilder.AppendLine(Pressure.Append(metar));

            //Trends
            if(metar.Trends.Count == 0)
            {
                return reportBuilder.ToString();
            }

            if(metar.Trends.Count > 0)
            {
                metar.Trends.ForEach(trend => { reportBuilder.Append(TrendBase.Append(trend)); reportBuilder.AppendLine(Trend.Append(metar)); });
            }

            return reportBuilder.ToString();
        }
    }
}
