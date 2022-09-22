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
            Metar Parsed = new Metar();
            string webData = null;
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = null;
            raw = wc.DownloadData(Link);
            webData = Encoding.UTF8.GetString(raw);

            Parsed = ParseFromString(webData);

            return Parsed;
        }


        public static List<Metar> ParseFromList(List<string> MetarsIn)
        {
            List<Metar> Metars = new List<Metar>();

            foreach (var ListMetar in MetarsIn)
            {
                if (ListMetar.StartsWith("http"))
                {
                    Metar AddMetar = new Metar();

                    AddMetar = ParseFromLink(ListMetar);

                    Metars.Add(AddMetar);
                }
                else
                {
                    Metar AddMetar = new Metar();

                    AddMetar = ParseFromString(ListMetar);

                    Metars.Add(AddMetar);
                }
            }
            return Metars;
        }

        //public Metar Parse()
        //{

        //}
    }
}
