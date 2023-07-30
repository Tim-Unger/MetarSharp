using AviationSharp.Vatsim.Data;
using System.Net.Http.Json;

namespace AviationSharp.Vatsim.Stats
{
    public class VatsimStats
    {
        private static readonly HttpClient Client = new HttpClient();

        public static VatsimStatsUser GetUserOverview(int cid)
        {
            if (!cid.IsValidCID())
            {
                throw new Exception("CID is not valid or active");
            }

            var user =
                Client
                    .GetFromJsonAsync<VatsimStatsUser>($"https://api.vatsim.net/api/ratings/{cid}/")
                    .Result ?? throw new Exception("User was not found");

            user.Cid = int.Parse(user.CidString);

            var regions = Vatsim.GetAllRegions();

            user.VatsimRegion = regions.First(x => x.ShortName == user.RegionShort);

            user.TimeOnVatsim = GetTimeDistribution(
                DateTime.Now.Subtract(user.RegistrationDate).TotalHours
            );

            var yearsOnVatsim = int.Parse(Math.Round((double)user.TimeOnVatsim.Days / 365, 0).ToString());
            user.YearsOnVatsim = yearsOnVatsim == 0 ? 1 : yearsOnVatsim;

            var ratingHours =
                Client
                    .GetFromJsonAsync<RatingHoursDTO>(
                        $"https://api.vatsim.net/api/ratings/{cid}/rating_times/"
                    )
                    .Result ?? throw new Exception();

            var totalHours = ratingHours.AtcHours + ratingHours.PilotHours;

            user.TotalHours = totalHours;
            user.ControllerHours = ratingHours.AtcHours;
            user.PilotHours = ratingHours.PilotHours;

            user.TotalTimeDistribution = GetTimeDistribution(totalHours);
            user.ControllerTimeDistribution = GetTimeDistribution(ratingHours.AtcHours);
            user.PilotTimeDistribution = GetTimeDistribution(ratingHours.PilotHours);

            user.RatingHourDistribution = GetRatingHours(ratingHours, user.RatingIndex);

            return user;
        }

        public static VatsimStatsUser GetUserOverview(Controller controller) =>
            GetUserOverview(controller.Cid);

        public static VatsimStatsUser GetUserOverview(Pilot pilot) => GetUserOverview(pilot.Cid);

        private static (int Days, int Hours, int Minutes) GetTimeDistribution(double totalTime)
        {
            var timeSpan = TimeSpan.FromHours(totalTime);

            return (timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
        }

        private static List<RatingHour> GetRatingHours(RatingHoursDTO ratingHours, int rating)
        {
            //SUS or OBS
            if (rating < 1)
            {
                return Enumerable.Empty<RatingHour>().ToList();
            }

            return rating switch
            {
                //S1
                2 => new List<RatingHour>() { GetS1Hours(ratingHours) },
                //S2
                3 => new List<RatingHour>() { GetS1Hours(ratingHours), GetS1Hours(ratingHours) },
                //S3
                4
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours)
                  },
                //C1
                5
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                  },
                //C2
                6
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                  },
                //C3
                7
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                  },
                //I1
                8
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                      GetI1Hours(ratingHours),
                  },
                //I2
                9
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                      GetI1Hours(ratingHours),
                      GetI2Hours(ratingHours),
                  },
                //I3
                10
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                      GetI1Hours(ratingHours),
                      GetI2Hours(ratingHours),
                      GetI3Hours(ratingHours),
                  },
                //SUP
                11
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                      GetI1Hours(ratingHours),
                      GetI2Hours(ratingHours),
                      GetI3Hours(ratingHours),
                      GetSUPHours(ratingHours)
                  },
                //ADM
                12
                  => new List<RatingHour>()
                  {
                      GetS1Hours(ratingHours),
                      GetS2Hours(ratingHours),
                      GetS3Hours(ratingHours),
                      GetC1Hours(ratingHours),
                      GetC2Hours(ratingHours),
                      GetC3Hours(ratingHours),
                      GetI1Hours(ratingHours),
                      GetI2Hours(ratingHours),
                      GetI3Hours(ratingHours),
                      GetSUPHours(ratingHours),
                      GetADMHours(ratingHours)
                  },

                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static RatingHour GetS1Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "S1",
                TotalHours = ratingHours.S1Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.S1Hours)
            };

        private static RatingHour GetS2Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "S2",
                TotalHours = ratingHours.S2Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.S2Hours),
            };

        private static RatingHour GetS3Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "S3",
                TotalHours = ratingHours.S3Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.S3Hours),
            };

        private static RatingHour GetC1Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "C1",
                TotalHours = ratingHours.C1Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.C1Hours),
            };

        //Not in use
        private static RatingHour GetC2Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "C2",
                TotalHours = 0,
                TotalTimeDistribution = GetTimeDistribution(0),
            };

        private static RatingHour GetC3Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "C3",
                TotalHours = ratingHours.C3Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.C3Hours),
            };

        private static RatingHour GetI1Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "I1",
                TotalHours = ratingHours.I1Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.I1Hours),
            };

        //Also not in use
        private static RatingHour GetI2Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "I2",
                TotalHours = 0,
                TotalTimeDistribution = GetTimeDistribution(0),
            };

        private static RatingHour GetI3Hours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "I3",
                TotalHours = ratingHours.I3Hours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.I3Hours),
            };

        private static RatingHour GetSUPHours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "SUP",
                TotalHours = ratingHours.SUPHours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.SUPHours),
            };

        private static RatingHour GetADMHours(RatingHoursDTO ratingHours) =>
            new()
            {
                Rating = "ADM",
                TotalHours = ratingHours.ADMHours,
                TotalTimeDistribution = GetTimeDistribution(ratingHours.ADMHours),
            };
    }
}
