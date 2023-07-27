using AviationSharp.Vatsim.Data;
using System.Net.Http.Json;

namespace AviationSharp.Vatsim
{
    public partial class VatsimData
    {
        public static VatsimData GetEntireDatafeed()
        {
            var client = new HttpClient();

            //TODO dynamic URL
            var dataUrl = "https://data.vatsim.net/v3/vatsim-data.json";

            return client.GetFromJsonAsync<VatsimData>(dataUrl).Result ?? throw new Exception();
        }

        public static GeneralInformation GetGenerealInformation() => GetEntireDatafeed().GeneralInformation;

        public static List<Pilot> GetAllPilots() => GetEntireDatafeed().Pilots ?? Enumerable.Empty<Pilot>().ToList();

        public static List<Controller> GetAllControllers => GetEntireDatafeed().Controllers ?? Enumerable.Empty<Controller>().ToList();

        public static List<Atis> GetAllAtis => GetEntireDatafeed().Atis ?? Enumerable.Empty<Atis>().ToList();

        public static List<Server> GetAllServers => GetEntireDatafeed().Servers;

        public static List<Prefile> GetAllPrefiles => GetEntireDatafeed().Prefiles ?? Enumerable.Empty<Prefile>().ToList();

        public static List<Facility> GetAllFacilities => GetEntireDatafeed().Facilities;

        public static List<Rating> GetAllRatings => GetEntireDatafeed().Ratings;

        public static List<PilotRating> GetAllPilotRatings => GetEntireDatafeed().PilotRatings;

        public static List<MilitaryRating> GetMilitaryRatings => GetEntireDatafeed().MilitaryRatings;
    }
}
