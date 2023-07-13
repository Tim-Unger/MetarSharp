using System.Text.Json;
using System.Text.RegularExpressions;

namespace AviationSharp.Airacs
{
    

    public class Airacs
    {
        public static List<Airac> GetAll()
        {
            var client = new HttpClient();

            var content = client.GetStringAsync("https://api.tim-u.me/airacs").Result;

            var airacs = JsonSerializer.Deserialize<List<AiracDTO>>(content);

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

        public static Airac GetCurrent() => GetAll().First(x => x.StartDate < DateOnlyNow() && x.EndDate > DateOnlyNow()) ?? throw new Exception();

        public static Airac GetNext() => GetAll().First(x => x.EndDate > DateOnlyNow() && x.StartDate > DateOnlyNow()) ?? throw new Exception();

        public static Airac? GetByIdent(int ident) => GetAll().First(x => x.Ident == ident) ?? null;

        public static Airac? GetByDate(DateOnly date) => GetAll().First(x => x.StartDate < date && x.EndDate > date) ?? null;

        public static Airac? GetByDate(string date) 
        {
            var dateRegex = new Regex(@"(20[2-3][0-9])(?>_|-|)?(0[1-9]|1[0-2])(?>_|-|)?(0[1-9]|1[0-9]|2[0-9]|3[0-1])");

            if (!dateRegex.IsMatch(date))
            {
                throw new Exception("Please use a valid ISO9601 compliant date (20231231 or 2023/12/31 or 2023_05_17)");
            }

            var groups = dateRegex.Match(date).Groups;

            var year = int.Parse(groups[1].Value);

            var month = int.Parse(groups[2].Value);

            var day = int.Parse(groups[3].Value);

            var dateOnly = new DateOnly(year, month, day);

            return GetAll().First(x => x.StartDate < dateOnly && x.EndDate > dateOnly) ?? null;
        }

        public static List<Airac> GetByYear(int year) => GetAll().Where(x => x.StartDate.Year == year).ToList();
    
        private static DateOnly DateOnlyNow() => DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
