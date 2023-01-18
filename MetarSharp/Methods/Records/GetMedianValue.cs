using MetarSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records
{
    internal class MedianValue
    {
        internal static Metar Get(List<Metar> metars, AverageValueType averageValueType) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling
                  => GetMedianCeiling(GetCloudsWithMesaurableCeiling(metars, false)),
            };

        private static Metar GetMedianCeiling(List<Metar> clouds) 
        {
            //Sorts each Metars cloud list by highest ceiling first
            clouds.ForEach(x => x.Clouds.OrderBy(x => x.CloudCeiling));
            //Sorts all Metars by the cloud ceiling of the cloud with the highest ceiling
            clouds.OrderBy(x => x.Clouds.First().CloudCeiling);

            int middleValue = int.Parse(Math.Round((double)clouds.Count / 2, 0, MidpointRounding.ToEven).ToString());

            return clouds[middleValue];
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
