﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Methods.Records.AverageValue
{
    internal class AverageCeiling
    {
        internal static double Get(List<Metar> metars, byte? decimalPlaces, bool isVerticalVis)
        {
            if (isVerticalVis)
            {
                return AverageVerticalVis(GetCloudsWithMesaurableCeiling(metars, isVerticalVis), decimalPlaces ?? 2);
            }

            return AverageClouds(GetCloudsWithMesaurableCeiling(metars, isVerticalVis), decimalPlaces ?? 2);
        }

        private static double AverageClouds(List<Cloud> clouds, byte decimalPlaces)
        {
            int sum = 0;
            int count = 0;

            //TODO ?? operator
            clouds.ForEach(
                x =>
                {
                    sum += x.CloudCeiling ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }

        private static double AverageVerticalVis(List<Cloud> metars, byte decimalPlaces)
        {
            int sum = 0;
            int count = 0;

            metars.ForEach(
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
