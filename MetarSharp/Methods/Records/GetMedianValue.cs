using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records
{
    internal class MedianValue
    {
        internal static Metar Get(List<Metar> metars, AverageValueType averageValueType) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling
                  => GetMedianCeiling(GetCloudsWithMesaurableCeiling(metars, false)),

                AverageValueType.PressureINHG => GetMedianPressure(metars, null),

                AverageValueType.PressureQNH => GetMedianPressure(metars, null),

                AverageValueType.TemperatureCelsius => GetMedianTemperature(metars, null),

                AverageValueType.TemperatureFahrenheit => GetMedianTemperature(metars, null),
            };

        internal static Metar Get(
            List<Metar> metars,
            AverageValueType averageValueType,
            MidpointRounding midpointRounding
        ) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling
                  => GetMedianCeiling(GetCloudsWithMesaurableCeiling(metars, false)),

                AverageValueType.PressureINHG => GetMedianPressure(metars, midpointRounding),

                AverageValueType.PressureQNH => GetMedianPressure(metars, midpointRounding),

                AverageValueType.TemperatureCelsius => GetMedianTemperature(metars, midpointRounding),

                AverageValueType.TemperatureFahrenheit => GetMedianTemperature(metars, midpointRounding),
            };

        private static Metar GetMedianCeiling(List<Metar> clouds)
        {
            //Sorts each Metars cloud list by highest ceiling first
            clouds.ForEach(x => x.Clouds.OrderBy(x => x.CloudCeiling));
            //Sorts all Metars by the cloud ceiling of the cloud with the highest ceiling
            clouds.OrderBy(x => x.Clouds.First().CloudCeiling);

            int middleValue = int.Parse(
                Math.Round((double)clouds.Count / 2, 0, MidpointRounding.ToEven).ToString()
            );

            return clouds[middleValue];
        }

        private static Metar GetMedianPressure(
            List<Metar> metars,
            MidpointRounding? midpointRounding
        )
        {
            //Rounds to the set value by the user, otherwise up
            var medianIndex = (int)Math.Round(
                (double)metars.Count / 2,
                0,
                midpointRounding ?? MidpointRounding.AwayFromZero
            );

            return metars[medianIndex];
        }

        private static Metar GetMedianTemperature(List<Metar> metars, MidpointRounding? midpointRounding)
        {
            var medianIndex = (int)Math.Round((double)metars.Count / 2, 0, midpointRounding ?? MidpointRounding.AwayFromZero);

            return metars[medianIndex];
        }

        private static List<Metar> GetCloudsWithMesaurableCeiling(
            List<Metar> metars,
            bool IsVerticalVis
        )
        {
            var measurableClouds = new List<Metar>();

            if (IsVerticalVis)
            {
                metars.ForEach(
                    x =>
                        measurableClouds.AddRange(
                            (IEnumerable<Metar>)x.Clouds.Where(
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
                        (IEnumerable<Metar>)x.Clouds.Where(
                            y => y.IsCloudMeasurable == true && y.IsVerticalVisibility == false
                        )
                    )
            );

            return measurableClouds;
        }
    }
}
