﻿namespace MetarSharp.Methods.Records.AverageValue
{
    internal class AverageVisibility
    {
        internal static double Get(List<Metar> metars, bool isLowestVis, byte? decimalPlaces)
        {
            if (isLowestVis)
            {
                var metarsWithLowestVis = metars.Where(x => x.Visibility.HasVisibilityLowestValue).ToList();

                return GetAverageLowestVisibility(metarsWithLowestVis, decimalPlaces ?? 2 );
            }

            var metarsWithVis = metars.Where(x => x.Visibility.IsVisibilityMeasurable).ToList();

            return GetAverageVisibility(metarsWithVis, decimalPlaces ?? 2);
        }

        private static double GetAverageVisibility(List<Metar> metars, byte decimalPlaces)
        {
            double sum = 0;
            int count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Visibility.ReportedVisibility;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }

        private static double GetAverageLowestVisibility(List<Metar> metars, byte decimalPlaces)
        {
            double sum = 0;
            int count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Visibility.LowestVisibility ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }
    }
}
