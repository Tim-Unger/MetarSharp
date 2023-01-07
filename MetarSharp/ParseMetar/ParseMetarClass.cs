using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MetarSharp.Parse;
using System.Diagnostics.Metrics;

namespace MetarSharp
{
    public class ParseMetar
    {
        public class RawMetarString
        {
            public static string RawMetar { get; set; }

            public static string RestOfMetar { get; set; }
        }

        public static Metar ParseFromString(string metar)
        {
            if (CheckIfLineIsNullOrEmpty(metar))
            {
                throw new Exception("Metar is null or an empty line, check input");
            }

            RawMetarString.RawMetar = metar;
            Metar parsed = new Metar();
            RawMetarString.RestOfMetar = RawMetarString.RawMetar;

            parsed.Airport = ParseAirport.ReturnAirport(RawMetarString.RawMetar);

            parsed.ReportingTime = ParseReportingTime.ParseReportingTimeNew(RawMetarString.RawMetar);

            parsed.Wind = ParseWind.ReturnWind(RawMetarString.RawMetar);

            parsed.IsAutomatedReport = ParseAuto.ReturnIsAutomated(RawMetarString.RawMetar);

            parsed.Wind = ParseWind.ReturnWind(RawMetarString.RawMetar);

            parsed.Temperature = ParseTemperature.ReturnTemperature(RawMetarString.RawMetar);

            parsed.Pressure = ParsePressure.ReturnPressure(RawMetarString.RawMetar);

            parsed.RunwayVisibilities = ParseRVR.ReturnRVR(RawMetarString.RawMetar);

            parsed.Clouds = ParseClouds.ReturnClouds(RawMetarString.RawMetar);

            parsed.Visibility = ParseVisibility.ReturnVisibility(RawMetarString.RawMetar);

            parsed.Weather = ParseWeather.ReturnWeather(RawMetarString.RestOfMetar);

            parsed.AdditionalInformation = ParseAdditional.ReturnAdditional(RawMetarString.RawMetar);

            parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(parsed);

            return parsed;
        
        }

        public static Metar ParseFromLink(string Link)
        {
            Metar parsed = new Metar();
            string webData = null;
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = null;
            raw = wc.DownloadData(Link);
            webData = Encoding.UTF8.GetString(raw);

            parsed = ParseFromString(webData);

            return parsed;
        }

        public static List<Metar> ParseFromList(List<string> metarsIn)
        {
            List<Metar> metars = new List<Metar>();

            foreach (var listMetar in metarsIn)
            {
                if (listMetar.StartsWith("http"))
                {
                    Metar addNewMetar = new Metar();

                    addNewMetar = ParseFromLink(listMetar);

                    metars.Add(addNewMetar);
                    continue;
                }
                
                Metar addMetar = new Metar();

                addMetar = ParseFromString(listMetar);

                metars.Add(addMetar);
            }
            return metars;
        }

        private static bool CheckIfLineIsNullOrEmpty(string input)
        {
            if(input == null || input == String.Empty || input == "" || String.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            return false;
        }
    }
}
