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

        public static Metar ParseFromString(in string Metar)
        {
            RawMetarString.RawMetar = Metar;
            Metar Parsed = new Metar();

            Parsed.Airport = ParseAirport.ReturnAirport(RawMetarString.RawMetar);

            Parsed.ReportingTime = ParseReportingTime.ReturnReportingTime(RawMetarString.RawMetar);

            Parsed.Wind = ParseWind.ReturnWind(RawMetarString.RawMetar);

            Parsed.IsAutomatedReport = ParseAuto.ReturnIsAutomated(RawMetarString.RawMetar);

            Parsed.Temperature = ParseTemperature.ReturnTemperature(RawMetarString.RawMetar);

            Parsed.Pressure = ParsePressure.ReturnPressure(RawMetarString.RawMetar);

            Parsed.RunwayVisibilities = ParseRVR.ReturnRVR(RawMetarString.RawMetar);

            Parsed.Clouds = ParseClouds.ReturnClouds(RawMetarString.RawMetar);

            Parsed.Visibility = ParseVisibility.ReturnVisibility(RawMetarString.RawMetar);
            //TODO Weather

            Parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(Parsed);

            
            return Parsed;
        }

        public Metar ParseFromLink()
        {
            return null;
        }

        //public Metar Parse()
        //{

        //}
    }
}
