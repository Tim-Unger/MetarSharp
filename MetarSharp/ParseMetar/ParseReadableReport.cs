using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseReadableReport
    {
        public static string ReturnReadableReport(Metar metar)
        {
            string ReadableReport = null;
            StringBuilder ReportBuilder = new StringBuilder();

            //Is Automated
            string ReportType = null;
            if (metar.IsAutomatedReport == true)
            {
                ReportType = "Automated weather report ";
            }
            else
            {
                ReportType = "Weather report ";
            }
            ReportBuilder.Append(ReportType);

            //Airport
            string Airport = "for " + metar.Airport + "." + "\n";
            ReportBuilder.Append(Airport);

            //Reporting Time
            string ReportingTime = null;
            string ReportingDate = null;
            if (metar.ReportingTime.ReportingTimeZulu.Day == DateTime.UtcNow.Day)
            {
                ReportingDate = "Reported today";
            }
            else
            {
                int DayNumber = metar.ReportingTime.ReportingTimeZulu.Day;
                string DayWritten = null;

                //Turns the day into a written day (1st, 2nd, 12th, etc)
                if (DayNumber == 1 || DayNumber == 21 || DayNumber == 31)
                {
                    DayWritten = DayNumber + "st";
                }
                else if (DayNumber == 2 || DayNumber == 22)
                {
                    DayWritten = DayNumber + "nd";
                }
                else if (DayNumber == 3)
                {
                    DayWritten = DayNumber + "rd";
                }
                else
                {
                    DayWritten = DayNumber + "th";
                }

                ReportingDate = "Reported on the " + DayWritten + " of the month";
            }

            ReportingTime =
                " at " + metar.ReportingTime.ReportingTimeZulu.ToString("t") + " UTC" + "\n";

            ReportBuilder.Append(ReportingDate + ReportingTime);

            //Wind
            string Wind = null;
            string WindGust = null;
            string WindVariation = null;
            if (metar.Wind.IsWindCalm)
            {
                Wind = "Wind calm";
            }
            else
            {
                if (metar.Wind.IsWindVariable)
                {
                    Wind =
                        "Wind variable "
                        + metar.Wind.WindStrength
                        + " "
                        + metar.Wind.WindUnitDecoded;
                }
                else
                {
                    Wind =
                        "Wind: "
                        + metar.Wind.WindDirection
                        + " Degrees "
                        + metar.Wind.WindStrength
                        + " "
                        + metar.Wind.WindUnitDecoded;
                }

                if (metar.Wind.IsWindGusting)
                {
                    WindGust =
                        " Gusting up to "
                        + metar.Wind.WindGusts
                        + " "
                        + metar.Wind.WindUnitDecoded
                        + ".";
                }

                if (metar.Wind.isWindDirectionVarying)
                {
                    WindVariation =
                        "Variable between "
                        + metar.Wind.WindVariationLow
                        + " Degrees and "
                        + metar.Wind.WindVariationHigh
                        + " Degrees.";
                }
            }

            ReportBuilder.AppendLine(Wind + WindGust + WindVariation);

            //Visibility
            string Visibility = null;
            string LowestVisibility = null;
            if (metar.Visibility.IsVisibilityMeasurable == false)
            {
                Visibility = "Visibility not measurable";
            }
            else
            {
                Visibility =
                    "Visibility: "
                    + metar.Visibility.ReportedVisibility
                    + " "
                    + metar.Visibility.VisibilityUnitDecoded
                    + " ";
            }

            if (metar.Visibility.HasVisibilityLowestValue)
            {
                LowestVisibility =
                    "Lowest Visibility: "
                    + metar.Visibility.LowestVisibility
                    + " "
                    + metar.Visibility.VisibilityUnitDecoded
                    + " in the"
                    + metar.Visibility.LowestVisibilityDirectionDecoded
                    + " ";
            }

            ReportBuilder.AppendLine(Visibility + LowestVisibility);

            //RVRs

            if (metar.RunwayVisibilities != null)
            {
                foreach (var RVR in metar.RunwayVisibilities)
                {
                    string Runway = null;

                    if (RVR.ParallelRunwayDesignator != null)
                    {
                        Runway = "Runway-Visibility for Runway " + RVR.Runway;
                    }
                    else
                    {
                        Runway = "Runway-Visibility for Runway " + RVR.Runway + " ";
                    }

                    if (RVR.IsRVRValueMoreOrLess == true)
                    {
                        Visibility =
                            "Runway Visual Range: "
                            + RVR.RVRMoreOrLessDecoded
                            + " than "
                            + RVR.RunwayVisualRange
                            + " Meter ";
                    }
                    else
                    {
                        Visibility = "Runway Visual Range: " + RVR.RunwayVisualRange + " Meter ";
                    }

                    string Variation = null;
                    if (RVR.IsRVRVarying == true)
                    {
                        if (RVR.IsRVRVariationMoreOrLess == true)
                        {
                            Variation =
                                "Variating up to: "
                                + RVR.RVRVariationMoreOrLessDecoded
                                + " than "
                                + RVR.RVRVariationValue
                                + " Meter";
                        }
                        else
                        {
                            Variation = "Variating up to: " + RVR.RVRVariationValue + " Meter";
                        }
                    }

                    string Tendency = " " + RVR.RVRTendencyDecoded;

                    ReportBuilder.AppendLine(Runway + Visibility + Variation + Tendency);
                }
            }

            //Weather
            if (metar.Weather != null)
            {
                foreach (var Weather in metar.Weather)
                {
                    //TODO

                }
            }

            //Clouds
            foreach (var Cloud in metar.Clouds)
            {
                string CloudString = null;

                if (Cloud.IsCAVOK)
                {
                    CloudString = "Ceiling and Visibility Okay";
                }
                else if (Cloud.IsVerticalVisibility == false)
                {
                    if (Cloud.IsCloudMeasurable == false)
                    {
                        CloudString = "Cloud not measurable";
                    }
                    else
                    {
                        if (Cloud.HasCumulonimbusClouds == false)
                        {
                            if (Cloud.IsCeilingMeasurable == true)
                            {
                                CloudString =
                                    "Cloud: "
                                    + Cloud.CloudCoverageTypeDecoded
                                    + " at "
                                    + Cloud.CloudCeiling;
                            }
                            else
                            {
                                CloudString =
                                    "Cloud: "
                                    + Cloud.CloudCoverageTypeDecoded
                                    + " Ceiling not measurable";
                            }
                        }
                        else
                        {
                            if (Cloud.IsCeilingMeasurable == true)
                            {
                                if (Cloud.IsCBTypeMeasurable == true)
                                {
                                    CloudString =
                                        "Cloud: "
                                        + Cloud.CloudCoverageTypeDecoded
                                        + " with "
                                        + Cloud.CBCloudTypeDecoded
                                        + " at "
                                        + Cloud.CloudCeiling;
                                }
                                else
                                {
                                    CloudString =
                                        "Cloud: "
                                        + Cloud.CloudCoverageTypeDecoded
                                        + " CB-Type not measurable at"
                                        + Cloud.CloudCeiling;
                                }
                            }
                            else
                            {
                                if (Cloud.IsCBTypeMeasurable == true)
                                {
                                    CloudString =
                                        "Cloud: "
                                        + Cloud.CloudCoverageTypeDecoded
                                        + " with "
                                        + Cloud.CBCloudTypeDecoded
                                        + " Ceiling not measurable";
                                }
                                else
                                {
                                    CloudString =
                                        "Cloud: "
                                        + Cloud.CloudCoverageTypeDecoded
                                        + " CB-Type not measurable "
                                        + " Ceiling not measurable";
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Cloud.IsVerticalVisibilityMeasurable == false)
                    {
                        CloudString = "Vertical Visibility not measurable";
                    }
                    else
                    {
                        CloudString = "Vertical Visibility: " + Cloud.VerticalVisibility;
                    }
                }

                ReportBuilder.AppendLine(CloudString);
            }

            //Temperature
            string Temperature = null;
            string Dewpoint = null;

            Temperature = metar.Temperature.IsTemperatureBelowZero
                ? "Temperature: " + "-" + metar.Temperature.TemperatureOnly + "°C"
                : "Temperature: " + metar.Temperature.TemperatureOnly + "°C";

            Dewpoint = metar.Temperature.IsDewpointBelowZero
                ? "Dewpoint: " + "-" + metar.Temperature.DewpointOnly + "°C"
                : "Dewpoint: " + metar.Temperature.DewpointOnly + "°C";

            ReportBuilder.AppendLine(Temperature);
            ReportBuilder.AppendLine(Dewpoint);


            //Pressure
            string Pressure = null;

            Pressure = "Pressure: " + metar.Pressure.PressureAsQnh + "hPa" + " or " + metar.Pressure.PressureAsAltimeter + "inHg";

            ReportBuilder.AppendLine(Pressure);

            ReadableReport = ReportBuilder.ToString();
            return ReadableReport;
        }
    }
}
