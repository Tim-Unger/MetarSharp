using MetarSharp.Exceptions;
using System.Net;
using System.Xml;

namespace MetarSharp.Methods.Download
{
    internal class AviationWeather
    {
        internal static List<string> Get(string icao, byte? hours)
        {
            if (string.IsNullOrEmpty(icao))
            {
                throw new ParseException("Input is null or empty");
            }

            WebClient webClient = new WebClient();

            byte hoursNonNull = hours ?? 1;
            string raw = webClient.DownloadString($"https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString={icao}&hoursBeforeNow={hoursNonNull}");

            XmlDocument document = new XmlDocument();

            document.LoadXml(raw);

            var resultNumber = document.GetElementsByTagName("data")[0].Attributes["num_results"].Value ?? throw new ParseException();
            int parseNumber = int.TryParse(resultNumber, out int parse) ? parseNumber = parse : throw new ParseException();

            if(parseNumber == 0)
            {
                throw new ParseException("Could not find ICAO");
            }

            var metars = document.GetElementsByTagName("METAR") ?? throw new ParseException();

            List<string> metarsList = new List<string>();

            foreach (XmlNode metar in metars.Cast<XmlNode>())
            {
                metarsList.Add(metar.ChildNodes[0].InnerText);
            }

            //if(metarsList.Any(x => !x.StartsWith(icao, StringComparison.OrdinalIgnoreCase)))
            //{
            //    throw new ParseException("Something went wrong");
            //}

            return metarsList;
        }
    }
}
