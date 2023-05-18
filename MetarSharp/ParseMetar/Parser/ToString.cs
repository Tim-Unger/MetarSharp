using System.Text;

namespace MetarSharp.Parser
{
    public class ParseToString
    {
        internal static string Parse(Metar metar)
        {
            //TODO implement
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(metar.Airport + " ");

            stringBuilder.Append(metar.ReportingTime.ReportingTimeZulu.ToString("ddHHmmZ") + " ");

            if(metar.IsAutomatedReport)
            {
                stringBuilder.Append("AUTO" + " ");
            }

            stringBuilder.Append(metar.Wind.WindRaw);
            return stringBuilder.ToString();
        }
    }
}
