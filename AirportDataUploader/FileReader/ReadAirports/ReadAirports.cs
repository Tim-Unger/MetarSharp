using CsvHelper;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace AviationSharp.Airports.Reader
{
    internal class Airports
    {
        private static List<RunwayDTO> _runways = Runways.Read().OrderBy(x => int.Parse(x.airport_ref)).ToList();
        private static List<long> ExecutionTimes = new();

        internal static List<Airport> Read()
        {
            var content = File.ReadAllText($"{Environment.CurrentDirectory}/DataFiles/Airports.json");
            return JsonSerializer.Deserialize<List<Airport>>(content) ?? throw new Exception();
        }

        internal static List<AirportDTO> ReadToDTO()
        {
            var reader = new StreamReader($"{Environment.CurrentDirectory}/DataFiles/airports.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<AirportDTO>().ToList();
        }
    }
}
