using System.Text.Json;

namespace AviationSharp.Airports.Reader
{
    internal class Airports
    {
        internal static List<Airport> Read()
        {

            var content = File.ReadAllText($"{Environment.CurrentDirectory}/DataFiles/Airports.json");
            return JsonSerializer.Deserialize<List<Airport>>(content) ?? throw new Exception();
        }
    }
}
