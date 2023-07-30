using AviationSharp.Vatsim.Data;
using System.Collections.Immutable;
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

            var data = client.GetFromJsonAsync<VatsimData>(dataUrl).Result ?? throw new Exception();

            data.Controllers?.ForEach(x => x.TextAtis = x._textAtis != null ? string.Join(Environment.NewLine, x._textAtis) : null);

            return data;
        }

        public static GeneralInformation GetGenerealInformation() => GetEntireDatafeed().GeneralInformation;

        public static List<Pilot> GetAllPilots() => GetEntireDatafeed().Pilots ?? Enumerable.Empty<Pilot>().ToList();

        public static List<Controller> GetAllControllers() => GetEntireDatafeed().Controllers ?? Enumerable.Empty<Controller>().ToList();

        public static List<Atis> GetAllAtis() => GetEntireDatafeed().Atis ?? Enumerable.Empty<Atis>().ToList();

        public static List<Server> GetAllServers() => GetEntireDatafeed().Servers;

        public static List<Prefile> GetAllPrefiles() => GetEntireDatafeed().Prefiles ?? Enumerable.Empty<Prefile>().ToList();

        public static List<Facility> GetAllFacilities() => GetEntireDatafeed().Facilities;

        public static List<Rating> GetAllRatings() => GetEntireDatafeed().Ratings;

        public static List<PilotRating> GetAllPilotRatings() => GetEntireDatafeed().PilotRatings;

        public static List<MilitaryRating> GetMilitaryRatings() => GetEntireDatafeed().MilitaryRatings;

        public static Controller? FindSingleController(int cid) => SingleController.Get(cid);

        public static Controller? FindSingleController(string search) => SingleController.Get(search);

        public static List<Controller>? FindMultipleControllers(string search) => MultipleControllers.Get(search);

        public static bool IsStationOnline(string callsign) => Station.IsOnline(callsign);

        public static int CurrentTotalConnections => GetEntireDatafeed().GeneralInformation.ConnectedClients;

        public static int CurrentTotalPilots => GetEntireDatafeed().Pilots?.Count ?? 0;

        public static int CurrentTotalControllers => GetEntireDatafeed().Controllers?.Count ?? 0;

        public static int CurrentTotalControllersWithoutObservers => RemoveObserversFromControllers(GetEntireDatafeed());

        public static int CurrentTotalATIS => GetEntireDatafeed().Atis?.Count ?? 0;

        public static int CurrentTotalObservers => GetObserverCount(GetEntireDatafeed());

        public static int CurrentTotalSupervisors => GetEntireDatafeed().Controllers?.Where(x => x.RatingIndex == GetEntireDatafeed().Ratings.First(x => x.ShortName == "SUP").Id).Count() ?? 0;

        public static (int Total, int Pilots, int Controllers, int ATIS, int Observers, int Supervisors) GetTotalConnectionsDistribution()
        {
            var feed = GetEntireDatafeed();

            return
                (
                feed.GeneralInformation.ConnectedClients,
                feed.Pilots?.Count ?? 0,
                RemoveObserversFromControllers(feed),
                feed.Atis?.Count ?? 0,
                GetObserverCount(feed),
                GetSupervisorCount(feed)
                );
        }

        private static int GetObserverCount(VatsimData feed) => feed.Controllers?.Where(x => x.RatingIndex == feed.Ratings.First(x => x.ShortName == "OBS").Id).Count() ?? 0;

        private static int GetSupervisorCount(VatsimData feed) => feed.Controllers?.Where(x => x.RatingIndex == feed.Ratings.First(x => x.ShortName == "SUP").Id || x.RatingIndex == feed.Ratings.First(x => x.ShortName == "ADM").Id).Count() ?? 0;

        private static int RemoveObserversFromControllers(VatsimData feed) => CurrentTotalControllers - GetObserverCount(feed);
    }
}
