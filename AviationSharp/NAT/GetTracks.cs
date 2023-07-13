using System.Text.Json;

namespace AviationSharp.NAT
{
    public enum FlighlevelType
    {
        Even,
        Odd
    }

    public class NatTracks
    {
        public static List<NatTrack> GetCurrent()
        {
            var client = new HttpClient();

            var content =
                client.GetStringAsync("https://api.tim-u.me/nattracks").Result
                ?? throw new Exception();

            var tracks =
                JsonSerializer.Deserialize<List<NatTrackDTO>>(content) ?? throw new Exception();

            return tracks
                .Select(
                    x =>
                        new NatTrack()
                        {
                            Id = x.id,
                            TMI = int.Parse(x.tmi),
                            RoutePoints = x.route,
                            FlightLevels = x.flightLevels.Select(x => x / 100).ToList(),
                            Direction = x.direction switch
                            {
                                0 => Direction.Unknown,
                                1 => Direction.Westbound,
                                2 => Direction.Eastbound,
                                _ => throw new ArgumentOutOfRangeException()
                            },
                            ValidFrom = ParseUnixStamp(long.Parse(x.validFrom)),
                            ValidTo = ParseUnixStamp(long.Parse(x.validTo)),
                        }
                )
                .ToList();
        }

        public static NatTrack? GetById(string id) => GetCurrent().First(x => x.Id == id) ?? null;

        public static List<NatTrack>? GetByDirection(Direction direction) =>
            GetCurrent().Where(x => x.Direction == direction).ToList() ?? null;

        public static List<NatTrack>? GetByFlightlevelByEvenOrOdd(FlighlevelType type) =>
            GetCurrent()
                .Where(
                    x =>
                        x.FlightLevels.Any(
                            x =>
                                type switch
                                {
                                    FlighlevelType.Even => int.IsEvenInteger(x),
                                    FlighlevelType.Odd => int.IsOddInteger(x),
                                    _ => throw new ArgumentOutOfRangeException()
                                }
                        )
                )
                .ToList() ?? null;

        public static DateOnly GetDayFromTMI(int tmi) => DateOnly.FromDateTime(new DateTime(DateTime.UtcNow.Year, 1, 1, 0, 0, 0).AddDays(tmi));

        public static int GetTodaysTMI() => DateTime.UtcNow.DayOfYear;


        //TODO Concorde Tracks

        private static DateTime ParseUnixStamp(long unixTime) =>
            DateTime.UnixEpoch.AddSeconds(unixTime);
    }
}
