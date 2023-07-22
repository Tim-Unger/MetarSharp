namespace AviationSharp.Airacs
{
    public partial class Airacs
    {
        public static List<Airac> CreateCustom() => CreateOffline(null, null, null);

        public static List<Airac> CreateCustom(int amount) => CreateOffline(amount, null, null);

        public static List<Airac> CreateCustom(int amount, int airacLength) => CreateOffline(amount, null, airacLength);

        public static List<Airac> CreateCustom(int amount, DateOnly startDate) => CreateOffline(amount, startDate, null);

        public static List<Airac> CreateCustom(DateOnly startDate, int airacLength) => CreateOffline(null, startDate, airacLength);
        
        public static List<Airac> CreateCustom(int amount, DateOnly startDate, int airacLength) => CreateOffline(amount, startDate, airacLength);


        //TODO correct ident with custom date
        //public static List<Airac> CreateCustom(int amount, DateOnly startDate) => CreateOffline(amount, startDate);

        private static List<Airac> CreateOffline(int? amount, DateOnly? startDate, int? length)
        {
            var airacs = new List<Airac>();

            var airacCount = amount ?? 20;
            var airacLength = length ?? 28;

            var cycleNumber = 2307;
            var start = startDate ?? new DateOnly(2023, 07, 13);

            while (DateOnlyNow() > startDate && DateOnlyNow() > start.AddDays(airacLength))
            {
                startDate = start.AddDays(airacLength);

                if (DateOnlyNow().Year != start.Year)
                {
                    cycleNumber = int.Parse($"{start.Year.ToString().Substring(2, 2)}01");
                    break;
                }

                cycleNumber++;
            }

            for (var i = 0; i < airacCount; i++)
            {
                var nextCycle = start.AddDays(airacLength);
                var currentDate = start;

                airacs.Add(new Airac()
                {
                    CycleNumberInYear = int.Parse(cycleNumber.ToString().Substring(3, 1)),
                    Ident = cycleNumber,
                    StartDate = start,
                    EndDate = nextCycle
                });

                cycleNumber++;

                start = start.AddDays(airacLength);

                if (nextCycle.Year != currentDate.Year)
                {
                    cycleNumber = int.Parse($"{nextCycle.Year.ToString().Substring(2, 2)}01");
                }
            }

            return airacs;
        }

    }
}
