namespace AviationSharp.NAT
{
    public partial class NatTracks
    {
        public static readonly DateTime UnixZeroDate = new(1970, 1, 1);
        public static readonly DateTime UnixMaxDate = new(2038, 1, 19);

        public static List<NatTrack> GetConcordeTracks() => new()
        {
            new NatTrack
            {
                Id = "SO",
                TMI = GetTodaysTMI(),
                RoutePoints = SOPoints,
                FlightLevels = ConcordeFlightlevels,
                Direction = Direction.Both,
                ValidFrom = UnixZeroDate,
                ValidTo = UnixMaxDate,
            },
            new NatTrack
            {
                Id = "SN",
                TMI = GetTodaysTMI(),
                RoutePoints = SNPoints,
                FlightLevels = ConcordeFlightlevels,
                Direction = Direction.Eastbound,
                ValidFrom = UnixZeroDate,
                ValidTo = UnixMaxDate
            },
            new NatTrack
            {
                Id = "SM",
                TMI = GetTodaysTMI(),
                RoutePoints = SMPoints,
                FlightLevels = ConcordeFlightlevels,
                Direction = Direction.Westbound,
                ValidFrom = UnixZeroDate,
                ValidTo = UnixMaxDate
            }
        };

        public static readonly List<Route> SOPoints = new()
        {
            new Route
            {
                Name = "SO15W",
                Latitude = 48.4F,
                Longitude = -15
            },
            new Route
            {
                Name = "SO20W",
                Latitude = 48.48F,
                Longitude = -20
            },
            new Route
            {
                Name = "SO30W",
                Latitude = 48.22F,
                Longitude = -30
            },
            new Route
            {
                Name = "SO40W",
                Latitude = 47.04F,
                Longitude = -40
            },
            new Route
            {
                Name = "SO50W",
                Latitude = 44.45F,
                Longitude = -50
            },
            new Route
            {
                Name = "SO52W",
                Latitude = 44.1F,
                Longitude = -52
            },
            new Route
            {
                Name = "SO60W",
                Latitude = 42,
                Longitude = -60
            }
        };

        public static readonly List<Route> SNPoints = new()
        {
            new Route
            {
                Name = "SN67W",
                Latitude = 40.25F,
                Longitude = -67
            },
            new Route
            {
                Name = "SN65W",
                Latitude = 41.1F,
                Longitude = -65
            },
            new Route
            {
                Name = "SN60W",
                Latitude = 43.07F,
                Longitude = -60
            },
            new Route
            {
                Name = "SN52W",
                Latitude = 45.1F,
                Longitude = -52.3F
            },
            new Route
            {
                Name = "SN50W",
                Latitude = 45.54F,
                Longitude = -50
            },
            new Route
            {
                Name = "SN40W",
                Latitude = 48.1F,
                Longitude = -40
            },
            new Route
            {
                Name = "SN30W",
                Latitude = 49.26F,
                Longitude = -30
            },
            new Route
            {
                Name = "SN20W",
                Latitude = 49.49F,
                Longitude = -20
            },
            new Route
            {
                Name = "SN15W",
                Latitude = 49.41F,
                Longitude = -15
            }
        };

        public static readonly List<Route> SMPoints = new()
        {
            new Route
            {
                Name = "SM15W",
                Latitude = 50.41F,
                Longitude = -15
            },
            new Route
            {
                Name = "SM20W",
                Latitude = 50.5F,
                Longitude = -20
            },
            new Route
            {
                Name = "SM30W",
                Latitude = 50.3F,
                Longitude = -30
            },
            new Route
            {
                Name = "SM40W",
                Latitude = 49.16F,
                Longitude = -40
            },
            new Route
            {
                Name = "SM50W",
                Latitude = 47.03F,
                Longitude = -50
            },
            new Route
            {
                Name = "SM53W",
                Latitude = 46.1F,
                Longitude = -53
            },
            new Route
            {
                Name = "SM60W",
                Latitude = 44.14F,
                Longitude = -60
            },
            new Route
            {
                Name = "SM65W",
                Latitude = 42.26F,
                Longitude = -65
            },
            new Route
            {
                Name = "SM67W",
                Latitude = 42,
                Longitude = -67
            }
        };

        public static readonly List<int> ConcordeFlightlevels = new()
        {
            500,
            510,
            520,
            530,
            540,
            550,
            560,
            570,
            580,
            590,
            600
        };
    }
}