using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MetarDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> list = new();

            string webData = null;
            WebClient wc = new WebClient();
            byte[] raw;
            raw = wc.DownloadData("https://pkgstore.datahub.io/core/airport-codes/airport-codes_json/data/9ca22195b4c64a562a0a8be8d133e700/airport-codes_json.json");
            webData = Encoding.UTF8.GetString(raw);

            Console.WriteLine("Downloaded JSON");

            var icaoListUnformatted = JsonConvert.DeserializeObject<List<Airport>>(webData);

            //List<Airport> icaoList = icaoListUnformatted.FindAll(airport => letters.All(letter => airport.ident.Contains(letter)));
            List<Airport> icaoList = icaoListUnformatted.FindAll(airport => airport.ident.All(char.IsLetter));
            Random random = new();

            List<string> randomIcaos = new();
            while (randomIcaos.Count <= 1000)
            {
                string icao = icaoList[random.Next(0, icaoList.Count)].ident;

                if (!randomIcaos.Contains(icao))
                {
                    randomIcaos.Add(icao);
                }
            }

            Console.WriteLine($"Selected {randomIcaos.Count} Airports");

            List<string> metars = new();

            foreach (var icao in randomIcaos)
            {
                raw = wc.DownloadData("https://metar.vatsim.net/" + icao);
                webData = Encoding.UTF8.GetString(raw);

                if (!String.IsNullOrWhiteSpace(webData) || !String.IsNullOrEmpty(webData))
                {
                    metars.Add(webData);
                    Console.WriteLine($"Metar downloaded for {icao}: {webData}");
                    File.AppendAllText("./Metars.txt", webData + "\n");
                    await Task.Delay(1000);
                }
            }

            //string metarsString = String.Join("\n", metars);

            //File.WriteAllLines("./Metars.txt", metars);

            Console.WriteLine(metars.Count + " Metars downloaded");
        }
    }
}


    




//string s = "Y";
