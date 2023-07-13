using CsvHelper;
using System.Globalization;

namespace AviationSharp.Airports.Reader
{
    internal class Frequencies
    {
        internal static List<FrequencyDTO> Read()
        {
            var reader = new StreamReader($"{Environment.CurrentDirectory}/DataFiles/airport-frequencies.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<FrequencyDTO>().ToList();
        }
    }
}
