namespace AviationSharp.Metar.Records.AverageValue
{
    internal class AverageRvr
    {
        internal static double Get(List<Metar> metars, int? decimalPlaces)
        {
            var rvrs = GetRVRs(metars);

            return GetAverageRVRValue(rvrs, decimalPlaces ?? 2);
        }

        private static double GetAverageRVRValue(
            List<RunwayVisibility> runwayVisibilities,
            int decimalPlaces
        )
        {
            var sum = 0;
            var count = 0;

            runwayVisibilities.ForEach(
                x =>
                {
                    sum += x.RunwayVisualRange;
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }

        private static List<RunwayVisibility> GetRVRs(List<Metar> metars)
        {
            var rvrs = new List<RunwayVisibility>();

            //Cannot be null as the null check is done in the parent function
            metars.ForEach(x => x.RunwayVisibilities!.ForEach(y => rvrs.Add(y)));

            return rvrs;
        }
    }
}
