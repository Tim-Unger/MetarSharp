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
            string readableReport = null;
            StringBuilder reportBuilder = new StringBuilder();

            //Is Automated
            string reportType = null;

            reportType = metar.IsAutomatedReport ? "Automated weather report " : "Weather report ";
            
            reportBuilder.Append(reportType);

            //Airport
            string airport = "for " + metar.Airport + "." + "\n";
            reportBuilder.Append(airport);

            //Reporting Time
            string reportingTime = null;
            string reportingDate = null;
            if (metar.ReportingTime.ReportingTimeZulu.Day == DateTime.UtcNow.Day)
            {
                reportingDate = "Reported today";

                reportBuilder.Append(reportingDate);
            }
            
            int dayNumber = metar.ReportingTime.ReportingTimeZulu.Day;

            //Turns the day into a written day (1st, 2nd, 12th, etc)
            string dayWritten = dayNumber switch
            {
                1 or 21 or 31 => dayNumber + "st",
                2 or 22 => dayNumber + "nd",
                3 => dayNumber + "rd",
                _ => dayNumber + "th",
            };
            reportingDate = "Reported on the " + dayWritten + " of the month";
            

            reportingTime =
                " at " + metar.ReportingTime.ReportingTimeZulu.ToString("t") + " UTC" + "\n";

            reportBuilder.Append(reportingTime);

            //Wind
            string wind = null;
            string windGust = null;
            string windVariation = null;
            if (metar.Wind.IsWindCalm)
            {
                wind = "Wind calm";

                reportBuilder.AppendLine(wind + windGust + windVariation);
            }

            wind = metar.Wind.IsWindVariable ? 
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

            windGust = metar.Wind.IsWindGusting ?
                windGust =
                    " Gusting up to "
                    + metar.Wind.WindGusts
                    + " "
                    + metar.Wind.WindUnitDecoded
                    + "."
                    :
                    windVariation =
                    "Variable between "
                    + metar.Wind.WindVariationLow
                    + " Degrees and "
                    + metar.Wind.WindVariationHigh
                    + " Degrees.";

            reportBuilder.AppendLine(wind + windGust + windVariation);

            //Visibility
            string visibility = null;
            string lowestVisibility = null;
            //TODO CAVOK
            if (metar.Visibility.IsVisibilityMeasurable == false)
            {
                visibility = "Visibility not measurable";
                    
                reportBuilder.AppendLine(visibility + lowestVisibility);

            }
            
            visibility =
                "Visibility: "
                + metar.Visibility.ReportedVisibility
                + " "
                + metar.Visibility.VisibilityUnitDecoded
                + " ";
            

            if (metar.Visibility.HasVisibilityLowestValue)
            {
                lowestVisibility =
                    "Lowest Visibility: "
                    + metar.Visibility.LowestVisibility
                    + " "
                    + metar.Visibility.VisibilityUnitDecoded
                    + " in the"
                    + metar.Visibility.LowestVisibilityDirectionDecoded
                    + " ";
            }

            reportBuilder.AppendLine(visibility + lowestVisibility);

            //RVRs

            if (metar.RunwayVisibilities != null)
            {
                foreach (var RVR in metar.RunwayVisibilities)
                {
                    string runway = null;

                    if (RVR.ParallelRunwayDesignator != null)
                    {
                        runway = "Runway-Visibility for Runway " + RVR.Runway;
                        continue;
                    }
                    
                    runway = "Runway-Visibility for Runway " + RVR.Runway + " ";

                    if (RVR.IsRVRValueMoreOrLess == true)
                    {
                        visibility =
                            "Runway Visual Range: "
                            + RVR.RVRMoreOrLessDecoded
                            + " than "
                            + RVR.RunwayVisualRange
                            + " Meter ";
                        continue;
                    }
                   
                    visibility = "Runway Visual Range: " + RVR.RunwayVisualRange + " Meter ";

                    string variation = null;
                    if (RVR.IsRVRVarying == true)
                    {
                        if (RVR.IsRVRVariationMoreOrLess == true)
                        {
                            variation =
                                "Variating up to: "
                                + RVR.RVRVariationMoreOrLessDecoded
                                + " than "
                                + RVR.RVRVariationValue
                                + " Meter";
                            continue;
                        }
                        
                        variation = "Variating up to: " + RVR.RVRVariationValue + " Meter";
                    }

                    string tendency = " " + RVR.RVRTendencyDecoded;

                    reportBuilder.AppendLine(runway + visibility + variation + tendency);
                }   
            }

            //Weather
            if (metar.Weather != null)
            {
                foreach (var weather in metar.Weather)
                {
                    //TODO
                }
            }

            //Clouds
            foreach (var cloud in metar.Clouds)
            {
                string cloudString = null;

                if (cloud.IsCAVOK)
                {
                    cloudString = "Ceiling and Visibility Okay";
                    reportBuilder.AppendLine(cloudString);
                    continue;
                }
                
                if (cloud.IsCloudMeasurable == false)
                {
                    cloudString = "Cloud not measurable";
                    reportBuilder.AppendLine(cloudString);
                    continue;
                }
                    
                if (cloud.HasCumulonimbusClouds == false)
                {  
                    cloudString = (bool)cloud.IsCeilingMeasurable ? cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " at "
                            + cloud.CloudCeiling
                            :
                            cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " at "
                            + cloud.CloudCeiling;
                    reportBuilder.AppendLine(cloudString);
                    continue;
                }
                
                if (cloud.IsCeilingMeasurable == true)
                {   
                    cloudString = (bool)cloud.IsCeilingMeasurable ? cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " with "
                            + cloud.CBCloudTypeDecoded
                            + " at "
                            + cloud.CloudCeiling
                            :
                            cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " CB-Type not measurable at"
                            + cloud.CloudCeiling;
                    reportBuilder.AppendLine(cloudString);
                    continue;
                }
                    
                if (cloud.IsCBTypeMeasurable == true)
                {
                    cloudString = (bool)cloud.IsCBTypeMeasurable ? cloudString =
                        "Cloud: "
                        + cloud.CloudCoverageTypeDecoded
                        + " with "
                        + cloud.CBCloudTypeDecoded
                        + " Ceiling not measurable"
                        :
                        cloudString =
                        "Cloud: "
                        + cloud.CloudCoverageTypeDecoded
                        + " CB-Type not measurable "
                        + " Ceiling not measurable";
                    reportBuilder.AppendLine(cloudString);
                    continue;
                }

                //TODO null exception here
                cloudString = (bool)cloud.IsVerticalVisibilityMeasurable ? "Vertical Visibility not measurable" : "Vertical Visibility: " + cloud.VerticalVisibility;
                reportBuilder.AppendLine(cloudString);
            }

            //Temperature
            string temperature = null;
            string dewpoint = null;

            temperature = metar.Temperature.IsTemperatureBelowZero
                ? "Temperature: " + "-" + metar.Temperature.TemperatureOnly + "°C"
                : "Temperature: " + metar.Temperature.TemperatureOnly + "°C";

            dewpoint = metar.Temperature.IsDewpointBelowZero
                ? "Dewpoint: " + "-" + metar.Temperature.DewpointOnly + "°C"
                : "Dewpoint: " + metar.Temperature.DewpointOnly + "°C";

            reportBuilder.AppendLine(temperature);
            reportBuilder.AppendLine(dewpoint);


            //Pressure
            string pressure = null;

            pressure = "Pressure: " + metar.Pressure.PressureAsQnh + "hPa" + " or " + metar.Pressure.PressureAsAltimeter + "inHg";

            reportBuilder.AppendLine(pressure);

            readableReport = reportBuilder.ToString();
            return readableReport;
        }
    }
}
