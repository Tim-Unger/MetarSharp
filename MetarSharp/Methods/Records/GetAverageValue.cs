using MetarSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarSharp.Exceptions;

namespace MetarSharp.Methods.Records
{
    //TODO Version without custom decimal places
    internal class AverageValue
    {
        //TODO umlagern/auslagern
        internal static double Get(
            List<Metar> metars,
            AverageValueType averageValueType,
            byte decimalPlaces
        ) =>
            averageValueType switch
            {
                AverageValueType.CloudCeiling
                  => GetAverageCeiling(
                      GetCloudsWithMesaurableCeiling(metars, false),
                      decimalPlaces
                  ),

                AverageValueType.VerticalVisibility
                  => GetAverageVerticalVisibility(
                      GetCloudsWithMesaurableCeiling(metars, true),
                      decimalPlaces
                  ),

                AverageValueType.PressureINHG
                  => GetAveragePressure(
                      metars.Where(x => x.Pressure.IsPressureMeasurable).ToList(),
                      false,
                      decimalPlaces
                  ),

                AverageValueType.PressureQNH
                  => GetAveragePressure(
                      metars.Where(x => x.Pressure.IsPressureMeasurable).ToList(),
                      true,
                      decimalPlaces
                  ),

                AverageValueType.RunwayVisualRange
                  => GetAverageRVRValue(
                      GetRVRs(metars.Where(x => x.RunwayVisibilities != null).ToList()),
                      decimalPlaces
                  ),

                AverageValueType.TemperatureCelsius
                  => GetAverageTemperature(
                      metars.Where(x => x.Temperature.IsTemperatureMeasurable).ToList(),
                      decimalPlaces,
                      true
                  ),

                AverageValueType.TemperatureFahrenheit
                  => GetAverageTemperature(
                      metars.Where(x => x.Temperature.IsTemperatureMeasurable).ToList(),
                      decimalPlaces,
                      false
                  ),

                AverageValueType.DewpointCelsius
                  => GetAverageDewpoint(
                      metars.Where(x => x.Temperature.IsTemperatureMeasurable).ToList(),
                      decimalPlaces,
                      true
                  ),

                AverageValueType.DewpointFahrenheit
                  => GetAverageDewpoint(
                      metars.Where(x => x.Temperature.IsTemperatureMeasurable).ToList(),
                      decimalPlaces,
                      true
                  ),

                AverageValueType.Visibility
                  => GetAverageVisibility(
                      metars.Where(x => x.Visibility.IsVisibilityMeasurable).ToList(),
                      decimalPlaces
                  ),

                AverageValueType.LowestVisibility
                  => GetAverageLowestVisibility(
                      metars.Where(x => x.Visibility.HasVisibilityLowestValue).ToList(),
                      decimalPlaces
                  ),

                AverageValueType.WindDirection
                  => GetAverageWindDirection(
                      metars
                          .Where(
                              x =>
                                  !x.Wind.IsWindCalm
                                  && x.Wind.IsWindMeasurable
                                  && !x.Wind.IsWindVariable
                          )
                          .ToList(),
                      decimalPlaces
                  ),

                AverageValueType.WindStrength
                  => GetAverageWindStrength(
                      metars
                          .Where(
                              x =>
                                  !x.Wind.IsWindCalm
                                  && x.Wind.IsWindMeasurable
                                  && x.Wind.IsWindVariable
                          )
                          .ToList(),
                      decimalPlaces
                  ),

                AverageValueType.WindGustStrength =>GetAverageWindGustStrength(metars.Where(x => x.Wind.IsWindGusting).ToList(), decimalPlaces)
            };

        #region CLOUDS
        private static double GetAverageCeiling(List<Cloud> clouds, byte decimalPlaces)
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

        private static double GetAverageVerticalVisibility(List<Cloud> metars, byte decimalPlaces)
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
        #endregion

        #region PRESSURE
        private static double GetAveragePressure(List<Metar> metars, bool IsQnh, byte decimalPlaces)
        {
            int sum = 0;
            int count = 0;
            if (IsQnh)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Pressure.PressureAsQnh ?? 0;
                        count++;
                    }
                );

                return Math.Round(sum / (double)count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    x.Pressure.PressureAsAltimeter += sum;
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }
        #endregion

        #region RVR
        private static List<RunwayVisibility> GetRVRs(List<Metar> metars)
        {
            var rvrs = new List<RunwayVisibility>();

            metars.ForEach(x => x.RunwayVisibilities.ForEach(y => rvrs.Add(y)));

            return rvrs;
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
        #endregion

        #region TEMPERATURE/DEWPOINT
        private static double GetAverageTemperature(
            List<Metar> metars,
            byte decimalPlaces,
            bool isCelsius
        )
        {
            double sum = 0;
            int count = 0;

            if (isCelsius)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Temperature.TemperatureCelsius;
                        count++;
                    }
                );

                return Math.Round(sum / count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    sum += x.Temperature.TemperatureFahrenheit;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }

        private static double GetAverageDewpoint(
            List<Metar> metars,
            byte decimalPlaces,
            bool isCelsius
        )
        {
            double sum = 0;
            int count = 0;

            if (isCelsius)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Temperature.DewpointCelsius;
                        count++;
                    }
                );

                return Math.Round(sum / count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    sum += x.Temperature.DewpointFahrenheit;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }
        #endregion

        #region VISIBILITY
        public static double GetAverageVisibility(List<Metar> metars, byte decimalPlaces)
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

        public static double GetAverageLowestVisibility(List<Metar> metars, byte decimalPlaces)
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
        #endregion

        #region WIND
        private static double GetAverageWindDirection(List<Metar> metars, byte decimalPlaces)
        {
            double sum = 0;
            int count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindDirection ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }

        private static double GetAverageWindStrength(List<Metar> metars, byte decimalPlaces)
        {
            double sum = 0;
            int count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindStrength ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }

        private static double GetAverageWindGustStrength(List<Metar> metars, byte decimalPlaces)
        {
            double sum = 0;
            int count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindGusts ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }
        #endregion
    }
}
