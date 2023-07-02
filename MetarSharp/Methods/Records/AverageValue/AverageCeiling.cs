namespace MetarSharp.Records.AverageValue
{
    internal class AverageCeiling
    {
        internal static double Get(List<Metar> metars, int? decimalPlaces, bool isVerticalVis)
        {
            if (isVerticalVis)
            {
                return AverageVerticalVis(GetCloudsWithMesaurableCeiling(metars, isVerticalVis), decimalPlaces ?? 2);
            }

            return AverageClouds(GetCloudsWithMesaurableCeiling(metars, isVerticalVis), decimalPlaces ?? 2);
        }

        private static double AverageClouds(List<Cloud> clouds, int decimalPlaces)
        {
            var sum = 0;
            var count = 0;

            clouds.RemoveAll(x => x.CloudCeiling is null);

            clouds.ForEach(
                x =>
                {
                    sum += x.CloudCeiling ?? throw new ParseException();
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }

        private static double AverageVerticalVis(List<Cloud> clouds, int decimalPlaces)
        {
            var sum = 0;
            var count = 0;

            clouds.RemoveAll(x => x.VerticalVisibility is null);

            clouds.ForEach(
                x =>
                {
                    sum += x.VerticalVisibility ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }

        private static List<Cloud> GetCloudsWithMesaurableCeiling(
            List<Metar> metars,
            bool IsVerticalVis
        )
        {
            var measurableClouds = new List<Cloud>();

            if (IsVerticalVis)
            {
                metars.ForEach(
                    x =>
                        measurableClouds.AddRange(
                            x.Clouds.Where(
                                y =>
                                    y.IsVerticalVisibility == true
                                    && y.IsVerticalVisibilityMeasurable == true
                            )
                        )
                );

                return measurableClouds;
            }

            metars.ForEach(
                x =>
                    measurableClouds.AddRange(
                        x.Clouds.Where(
                            y => y.IsCloudMeasurable == true && y.IsVerticalVisibility == false
                        )
                    )
            );

            return measurableClouds;
        }

        
    }
}
