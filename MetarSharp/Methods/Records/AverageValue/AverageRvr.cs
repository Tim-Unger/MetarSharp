using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.AverageValue
{
    internal class AverageRvr
    {
        internal static double Get(List<Metar> metars, byte? decimalPlaces)
        {
            var rvrs = GetRVRs(metars);

            return GetAverageRVRValue(rvrs, decimalPlaces ?? 2);
        }

        private static double GetAverageRVRValue(
            List<RunwayVisibility> runwayVisibilities,
            byte decimalPlaces
        )
        {
            int sum = 0;
            int count = 0;

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

#pragma warning disable CS8602
            //this is fine as the null check is done in the parent function
            metars.ForEach(x => x.RunwayVisibilities.ForEach(y => rvrs.Add(y)));

            return rvrs;
        }
    }
}
