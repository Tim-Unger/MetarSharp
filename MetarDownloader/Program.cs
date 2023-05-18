using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace MetarDownloader
{
    class Program
    {
        static async Task Main()
        {
            var list = new List<string>();

            Console.WriteLine("Downloaded JSON");

            var client = new HttpClient();
            var icaoListUnformatted = await client.GetFromJsonAsync<List<Airport>>("https://pkgstore.datahub.io/core/airport-codes/airport-codes_json/data/9ca22195b4c64a562a0a8be8d133e700/airport-codes_json.json");

            //List<Airport> icaoList = icaoListUnformatted.FindAll(airport => letters.All(letter => airport.ident.Contains(letter)));
            List<Airport> icaoList = icaoListUnformatted!.FindAll(airport => airport.ident.All(char.IsLetter));
            Random random = new();

            List<string> randomIcaos = new();
            while (randomIcaos.Count <= 1000)
            {
                var icao = icaoList[random.Next(0, icaoList.Count)].ident;

                if (!randomIcaos.Contains(icao))
                {
                    randomIcaos.Add(icao);
                }
            }

            Console.WriteLine($"Selected {randomIcaos.Count} Airports");

            List<string> metars = new();

            foreach (var icao in randomIcaos)
            {
                var metar = await client.GetStringAsync($"https://metar.vatsim.net/{icao}");

                if (!string.IsNullOrWhiteSpace(metar) || !string.IsNullOrEmpty(metar))
                {
                    metars.Add(metar);
                    Console.WriteLine($"Metar downloaded for {icao}: {metar}");
                    File.AppendAllText("./Metars.txt", metar + "\n");
                    await Task.Delay(1000);
                }
            }

            Console.WriteLine(metars.Count + " Metars downloaded");
        }
    }
}
