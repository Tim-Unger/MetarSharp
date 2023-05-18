using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace MetarSharp.Tests
{
    public class Airport
    {
        public string Icao { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Elevation { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Tz { get; set; }
    }
    internal class GetMetars
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<List<string>> Metars()
        {
            var letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            List<string> returnMetars = new List<string>();

            Random rand = new Random();


            List<string> airports = new List<string>();
            for (int x = 0; x < 500; x++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int y = 0; y < 4; y++)
                {
                    int letterIndex = rand.Next(0, 26);
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
