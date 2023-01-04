using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

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
    public class Rootobject
    {
        internal class GetMetars
        {
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

                string webData = null;
                WebClient wc = new WebClient();
                foreach (var airport in airports)
                {
                    byte[] raw = wc.DownloadData("https://metar.vatsim.net/" + airport);
                    webData = Encoding.UTF8.GetString(raw);

                    returnMetars.Add(webData);

                    await Task.Delay(5000);
                }
                return returnMetars;
            }

            private static List<string> getJson()
            {
                List<string> list = new List<string>();

                string webData = null;
                WebClient wc = new WebClient();
                byte[] raw = wc.DownloadData("https://pkgstore.datahub.io/core/airport-codes/airport-codes_json/data/9ca22195b4c64a562a0a8be8d133e700/airport-codes_json.json");
                webData = Encoding.UTF8.GetString(raw);

                var icaoList = JsonConvert.DeserializeObject<List<Airport>>(webData);

                return list;
            }
        }     
    }
}
