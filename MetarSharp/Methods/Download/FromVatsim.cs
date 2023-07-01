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

        internal static List<string> Multiple(string icao)
        {
            if(string.IsNullOrWhiteSpace(icao))
            {
                throw new ParseException("Input is null or empty");
            }

            if (icao.Length > 4)
            {
                throw new ParseException("Maximum ICAO Length can be 4 characters");
            }

            var raw = _client.GetStringAsync($"https://metar.vatsim.net/{icao}").Result;

            //\n\n is just here in case Vatsim does weird stuff with the metars
            return raw.Split(new string[] { "\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        internal static List<string> MultipleIcaos(params string[] icaos)
        {
            if (icaos.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                throw new ParseException("Input is null or empty");
            }

            if (icaos.Any(x => x.Length > 4))
            {
                throw new ParseException("Maximum ICAO Length can be 4 characters");
            }

            var raw = icaos.Select(x =>  _client.GetStringAsync($"https://metar.vatsim.net/{x}").Result);

            return raw.ToList();
        }
    }
}