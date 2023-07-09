using System.Xml;

namespace AviationSharp.Metar.Downloader
{
    internal class AviationWeather
    {
        internal static List<string> Get(string icao, int? hours)
        {
            if (string.IsNullOrEmpty(icao))
            {
                throw new ParseException("Input is null or empty");
            }

            var client = new HttpClient();

            var hoursNonNull = hours ?? 1;
            var raw = client.GetStringAsync($"https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString={icao}&hoursBeforeNow={hoursNonNull}")!.Result;

            var document = new XmlDocument();

            document.LoadXml(raw);

            var resultNumber = document.GetElementsByTagName("data")[0].Attributes["num_results"]!.Value ?? throw new ParseException();
            var parseNumber = int.TryParse(resultNumber, out var parse) ? parse : throw new ParseException();

            if(parseNumber == 0)
            {
                throw new ParseException("Could not find ICAO");
            }

            var metars = document.GetElementsByTagName("METAR").Cast<XmlNode>() ?? throw new ParseException();

            if(metars.Any(x => x.ChildNodes.Count == 0))
            {
                throw new NullReferenceException();
            }

            return metars.Select(x => x.ChildNodes[0]!.InnerText).ToList();
        }
    }
}
