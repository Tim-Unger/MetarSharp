namespace AviationSharp.Airacs
{
    public partial class Airacs
    {
        public static Airac? GetByDate(DateOnly date) =>
            GetAll().First(x => x.StartDate < date && x.EndDate > date) ?? null;

        public static Airac? GetByDate(string date)
        {
            var dateRegex = new Regex(
                @"(20[2-3][0-9])(?>_|-|/|)?(0[1-9]|1[0-2])(?>_|-|/|)?(0[1-9]|1[0-9]|2[0-9]|3[0-1])"
            );

            if (!dateRegex.IsMatch(date))
            {
                throw new Exception(
                    "Please use a valid ISO9601 compliant date (20231231 or 2023/12/31 or 2023_05_17)"
                );
            }

            var groups = dateRegex.Match(date).Groups;

            var year = int.Parse(groups[1].Value);

            var month = int.Parse(groups[2].Value);

            var day = int.Parse(groups[3].Value);

            var dateOnly = new DateOnly(year, month, day);

            return GetAll().First(x => x.StartDate < dateOnly && x.EndDate > dateOnly) ?? null;
        }
    }
}
