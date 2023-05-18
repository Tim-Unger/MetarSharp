using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace MetarSharp.Tests
{
    public class Airport
    {
        public string Icao { get; set; } = "AAAA";
        public string Iata { get; set; } = "AAA";
        public string Name { get; set; } = "Airport";
        public string City { get; set; } = "City";
        public string State { get; set; } = "State";
        public string Country { get; set; } = "Country";
        public string Elevation { get; set; } = "0";
        public string Lat { get; set; } = "0000";
        public string Lon { get; set; } = "0000";
        public string Tz { get; set; } = "UTC";
    }
    internal class GetMetars
    {
        private static readonly HttpClient Client = new();

        public static async Task<List<string>> Metars()
        {
            var letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            var returnMetars = new List<string>();

            var rand = new Random();


            var airports = new List<string>();
            for (var x = 0; x < 500; x++)
            {
                var stringBuilder = new StringBuilder();
                for (var y = 0; y < 4; y++)
                {
                    var letterIndex = rand.Next(0, 26);
                    stringBuilder.Append(letters[letterIndex]);
                }

                airports.Add(stringBuilder.ToString());
            }

            //This should be thread safe and nicer to the Vatsim API than Parallel.ForEach()
            await Task.WhenAll(airports.Select(async x => { returnMetars.Add(await Client.GetStringAsync($"https://metar.vatsim.net/{x}")); await Task.Delay(500); }));
            
            return returnMetars;
        }

        //TODO?
        //private static List<string> GetJson() => await Client.GetFromJsonAsync<List<Airport>>("https://pkgstore.datahub.io/core/airport-codes/airport-codes_json/data/9ca22195b4c64a562a0a8be8d133e700/airport-codes_json.json");
    }    
}
