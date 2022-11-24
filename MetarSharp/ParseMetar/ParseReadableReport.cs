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
            StringBuilder reportBuilder = new StringBuilder();

            //Is Automated
            string ReportType = null;

            ReportType = metar.IsAutomatedReport ? "Automated weather report " : "Weather report ";
            
            reportBuilder.Append(ReportType);

            //Airport
            string Airport = "for " + metar.Airport + "." + "\n";
            reportBuilder.Append(Airport);

            //Reporting Time
            string ReportingTime = null;
            string ReportingDate = null;
            if (metar.ReportingTime.ReportingTimeZulu.Day == DateTime.UtcNow.Day)
            {
                ReportingDate = "Reported today";

                reportBuilder.Append(ReportingDate);
            }
            
            int DayNumber = metar.ReportingTime.ReportingTimeZulu.Day;
            string DayWritten = null;

            //Turns the day into a written day (1st, 2nd, 12th, etc)
            DayWritten = DayNumber switch
            {
                1 or 21 or 31 => DayNumber + "st",
                2 or 22 => DayNumber + "nd",
                3 => DayNumber + "rd",
                _ => DayNumber + "th",
            };
            ReportingDate = "Reported on the " + DayWritten + " of the month";
            

            ReportingTime =
                " at " + metar.ReportingTime.ReportingTimeZulu.ToString("t") + " UTC" + "\n";

            reportBuilder.Append(ReportingTime);

            //Wind
            string Wind = null;
            string WindGust = null;
            string WindVariation = null;
            if (metar.Wind.IsWindCalm)
            {
                Wind = "Wind calm";

                reportBuilder.AppendLine(Wind + WindGust + WindVariation);
            }

            Wind = metar.Wind.IsWindVariable ? 
                    "Wind variable "
                    + metar.Wind.WindStrength
                    + " "
                    + metar.Wind.WindUnitDecoded 
                    :
                    "Wind: "
                    + metar.Wind.WindDirection
                    + " Degrees "
                    + metar.Wind.WindStrength
                    + " "
                    + metar.Wind.WindUnitDecoded;

            WindGust = metar.Wind.IsWindGusting ?
                WindGust =
                    " Gusting up to "
                    + metar.Wind.WindGusts
                    + " "
                    + metar.Wind.WindUnitDecoded
                    + "."
                    :
                    WindVariation =
                    "Variable between "
                    + metar.Wind.WindVariationLow
                    + " Degrees and "
                    + metar.Wind.WindVariationHigh
                    + " Degrees.";

            reportBuilder.AppendLine(Wind + WindGust + WindVariation);

            //Visibility
            string Visibility = null;
            string LowestVisibility = null;
            //TODO CAVOK
            if (metar.Visibility.IsVisibilityMeasurable == false)
            {
                Visibility = "Visibility not measurable";
                    
                reportBuilder.AppendLine(Visibility + LowestVisibility);

            }
            
            Visibility =
                "Visibility: "
                + metar.Visibility.ReportedVisibility
                + " "
                + metar.Visibility.VisibilityUnitDecoded
                + " ";
            

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

            reportBuilder.AppendLine(Visibility + LowestVisibility);

            //RVRs

            if (metar.RunwayVisibilities != null)
            {
                foreach (var RVR in metar.RunwayVisibilities)
                {
                    string Runway = null;

                    if (RVR.ParallelRunwayDesignator != null)
                    {
                        Runway = "Runway-Visibility for Runway " + RVR.Runway;
                        continue;
                    }
                    
                    Runway = "Runway-Visibility for Runway " + RVR.Runway + " ";

                    if (RVR.IsRVRValueMoreOrLess == true)
                    {
                        Visibility =
                            "Runway Visual Range: "
                            + RVR.RVRMoreOrLessDecoded
                            + " than "
                            + RVR.RunwayVisualRange
                            + " Meter ";
                        continue;
                    }
                   
                    Visibility = "Runway Visual Range: " + RVR.RunwayVisualRange + " Meter ";

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
                            continue;
                        }
                        
                        Variation = "Variating up to: " + RVR.RVRVariationValue + " Meter";
                    }

                    string Tendency = " " + RVR.RVRTendencyDecoded;

                    reportBuilder.AppendLine(Runway + Visibility + Variation + Tendency);
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
                    reportBuilder.AppendLine(CloudString);
                    continue;
                }
                
                if (Cloud.IsCloudMeasurable == false)
                {
                    CloudString = "Cloud not measurable";
                    reportBuilder.AppendLine(CloudString);
                    continue;
                }
                    
                if (Cloud.HasCumulonimbusClouds == false)
                {
                    CloudString = (bool)Cloud.IsCeilingMeasurable ? CloudString =
                            "Cloud: "
                            + Cloud.CloudCoverageTypeDecoded
                            + " at "
                            + Cloud.CloudCeiling
                            :
                            CloudString =
                            "Cloud: "
                            + Cloud.CloudCoverageTypeDecoded
                            + " at "
                            + Cloud.CloudCeiling;
                    reportBuilder.AppendLine(CloudString);
                    continue;
                }
                
                if (Cloud.IsCeilingMeasurable == true)
                {
                    CloudString = (bool)Cloud.IsCeilingMeasurable ? CloudString =
                            "Cloud: "
                            + Cloud.CloudCoverageTypeDecoded
                            + " with "
                            + Cloud.CBCloudTypeDecoded
                            + " at "
                            + Cloud.CloudCeiling
                            :
                            CloudString =
                            "Cloud: "
                            + Cloud.CloudCoverageTypeDecoded
                            + " CB-Type not measurable at"
                            + Cloud.CloudCeiling;
                    reportBuilder.AppendLine(CloudString);
                    continue;
                }
                    
                if (Cloud.IsCBTypeMeasurable == true)
                {
                    CloudString = (bool)Cloud.IsCBTypeMeasurable ? CloudString =
                        "Cloud: "
                        + Cloud.CloudCoverageTypeDecoded
                        + " with "
                        + Cloud.CBCloudTypeDecoded
                        + " Ceiling not measurable"
                        :
                        CloudString =
                        "Cloud: "
                        + Cloud.CloudCoverageTypeDecoded
                        + " CB-Type not measurable "
                        + " Ceiling not measurable";
                    reportBuilder.AppendLine(CloudString);
                    continue;
                }

                CloudString = (bool)Cloud.IsVerticalVisibilityMeasurable ? "Vertical Visibility not measurable" : "Vertical Visibility: " + Cloud.VerticalVisibility;
                reportBuilder.AppendLine(CloudString);
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

            reportBuilder.AppendLine(Temperature);
            reportBuilder.AppendLine(Dewpoint);


            //Pressure
            string Pressure = null;

            Pressure = "Pressure: " + metar.Pressure.PressureAsQnh + "hPa" + " or " + metar.Pressure.PressureAsAltimeter + "inHg";

            reportBuilder.AppendLine(Pressure);

            ReadableReport = reportBuilder.ToString();
            return ReadableReport;
        }
    }
}
