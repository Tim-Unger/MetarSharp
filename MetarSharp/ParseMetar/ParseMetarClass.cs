using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MetarSharp.Parse;

namespace MetarSharp
{
    public class ParseMetar
    {
        public class RawMetarString
        {
            public static string RawMetar { get; set; }

            public static string RestOfMetar { get; set; }
        }

        public static Metar ParseFromString(string Metar)
        {
            RawMetarString.RawMetar = Metar;
            Metar Parsed = new Metar();
            RawMetarString.RestOfMetar = RawMetarString.RawMetar;

            Parsed.Airport = ParseAirport.ReturnAirport(RawMetarString.RawMetar);

            Parsed.ReportingTime = ParseReportingTime.ReturnReportingTime(RawMetarString.RawMetar);

            Parsed.Wind = ParseWind.ReturnWind(RawMetarString.RawMetar);

            Parsed.IsAutomatedReport = ParseAuto.ReturnIsAutomated(RawMetarString.RawMetar);

            Parsed.Temperature = ParseTemperature.ReturnTemperature(RawMetarString.RawMetar);

            Parsed.Pressure = ParsePressure.ReturnPressure(RawMetarString.RawMetar);

            Parsed.RunwayVisibilities = ParseRVR.ReturnRVR(RawMetarString.RawMetar);

            Parsed.Clouds = ParseClouds.ReturnClouds(RawMetarString.RawMetar);

            Parsed.Visibility = ParseVisibility.ReturnVisibility(RawMetarString.RawMetar);

            Parsed.Weather = ParseWeather.ReturnWeather(RawMetarString.RestOfMetar);

            Parsed.AdditionalInformation = ParseAdditional.ReturnAdditional(RawMetarString.RawMetar);

            Parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(Parsed);
            
            return Parsed;
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

        //public Metar Parse()
        //{

        //}
    }
}
