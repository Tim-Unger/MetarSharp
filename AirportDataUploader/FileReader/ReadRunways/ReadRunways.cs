using CsvHelper;
using System.Globalization;

namespace AviationSharp.Airports.Reader
{
    internal class Runways
    {
        internal static List<RunwayDTO> Read()
        {
            var reader = new StreamReader($"{Environment.CurrentDirectory}/DataFiles/runways.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            return csv.GetRecords<RunwayDTO>().ToList();
        }
    }
}
