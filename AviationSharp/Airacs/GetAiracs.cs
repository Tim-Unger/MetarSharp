using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AviationSharp.Airacs
{
    public partial class Airacs
    {
        public static List<Airac> GetAll()
        {
            var client = new HttpClient();

            var ping = new Ping().Send("1.1.1.1");

            //User has no Internet
            if (ping.Status != IPStatus.Success) 
            {
                return CreateOffline(null, null, null);
            }

            var content = client.GetStringAsync("https://api.tim-u.me/airacs").Result;

            var airacs = JsonSerializer.Deserialize<List<AiracDTO>>(content) ?? throw new Exception();

            return airacs
                .Select(
                    x =>
                        new Airac()
                        {
                            CycleNumberInYear = x.CycleNumberInYear,
                            Ident = x.Ident,
                            StartDate = DateOnly.Parse(x.StartDate),
                            EndDate = DateOnly.Parse(x.StartDate).AddDays(28)
                        }
                )
                .ToList();
        }

        public static Airac GetCurrent() =>
            GetAll().First(x => x.StartDate < DateOnlyNow() && x.EndDate > DateOnlyNow())
            ?? throw new Exception();

        public static Airac GetNext() =>
            GetAll().First(x => x.EndDate > DateOnlyNow() && x.StartDate > DateOnlyNow())
            ?? throw new Exception();

        public static Airac? GetByIdent(int ident) => GetAll().First(x => x.Ident == ident) ?? null;

        public static List<Airac> GetByYear(int year) =>
            GetAll().Where(x => x.StartDate.Year == year).ToList();
        
        private static DateOnly DateOnlyNow() => DateOnly.FromDateTime(DateTime.UtcNow);
    }
}