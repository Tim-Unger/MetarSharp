using System.Net.Http.Json;

namespace AviationSharp.Vatsim
{
    public partial class Vatsim
    {
        private static readonly HttpClient Client = new();

        private static readonly string RegionsUrl = "https://api.vatsim.net/api/regions/";

        private static readonly string DivisionsUrl = "https://api.vatsim.net/api/divisions/";

        private static readonly string SubDivisionsUrl = "https://api.vatsim.net/api/subdivisions/";

        public static List<VatsimRegion> GetAllRegions()
        {
            var regions = Client
                .GetFromJsonAsync<List<VatsimRegion>>(RegionsUrl)
                .Result ?? throw new Exception();

            var divisions = GetAllDivisions();

            regions.ForEach(x => x.DivisionsInRegion = divisions.Where(y => y.ParentDivision == x.ShortName).ToList());

            return regions;
        }

        public static List<VatsimDivision> GetAllDivisions()
        {
            var divisions =
                Client
                    .GetFromJsonAsync<List<VatsimDivision>>(DivisionsUrl)
                    .Result ?? throw new Exception();

            divisions.ForEach(x => x.HasSubdivisions = x.HasSubDivisionsInt == 1);

            var subDivisions = GetAllSubDivisions();

            divisions
                .Where(x => x.HasSubdivisions)
                .ToList()
                .ForEach(
                    x =>
                        x.SubDivisions = subDivisions
                            .Where(y => y.ParentDivision == x.ShortName)
                            .ToList()
                );

            return divisions;
        }

        public static List<VatsimSubDivision> GetAllSubDivisions() =>
            Client
                .GetFromJsonAsync<List<VatsimSubDivision>>(
                    SubDivisionsUrl
                )
                .Result ?? throw new Exception();

        public static List<VatsimRegion> GetOnlyRegions() => Client.GetFromJsonAsync<List<VatsimRegion>>(RegionsUrl).Result ?? throw new Exception();

        public static List<VatsimDivision> GetOnlyDivisions() => Client.GetFromJsonAsync<List<VatsimDivision>>(DivisionsUrl).Result ?? throw new Exception();

        public static List<VatsimSubDivision> GetOnlySubDivisions() => Client.GetFromJsonAsync<List<VatsimSubDivision>>(SubDivisionsUrl).Result ?? throw new Exception();
    }
}
