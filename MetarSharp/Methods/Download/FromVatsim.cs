namespace MetarSharp.Downloader
{
    internal class Vatsim
    {
        private static readonly HttpClient _client = new();

        internal static async Task<string> Single(string icao)
        {
            if(icao.Length > 4)
            {
                throw new ParseException("The maximum Length of the ICAO can be four letters");
            }

            if (icao.Length < 4)
            {
                throw new ParseException("Please use a four letter ICAO, for multiple metars, please use FromVatsimMultiple");
            }

            var metar = await _client.GetStringAsync($"https://metar.vatsim.net/{icao}");

            if (string.IsNullOrEmpty(metar))
            {
                throw new ParseException();
            }

            return metar;
        }

        internal static async Task<List<string>> Multiple(string icao)
        {
            if(string.IsNullOrWhiteSpace(icao))
            {
                throw new ParseException("Input is null or empty");
            }

            if (icao.Length > 4)
            {
                throw new ParseException("Maximum ICAO Length can be 4 characters");
            }

            var raw = await _client.GetStringAsync($"https://metar.vatsim.net/{icao}");

            //\n\n is just here in case Vatsim does weird stuff with the metars
            return raw.Split(new string[] { "\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
