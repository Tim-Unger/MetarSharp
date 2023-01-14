using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarSharp;
using MetarSharp.Parse;
using static MetarSharp.Parser.Helpers;

namespace MetarSharp.Parser
{
    internal class FromString
    {
        internal static Metar Parse(string input)
        {
            if (IsStringNullOrEmpty(input))
            {
                throw new Exception("input is null or an empty line, check input");
            }

            Metar parsed = new Metar();

            parsed.MetarRaw = input;

            parsed.Airport = ParseAirport.ReturnAirport(input);

            parsed.ReportingTime = ParseReportingTime.ParseReportingTimeNew(input);

            parsed.Wind = ParseWind.ReturnWind(input);

            parsed.IsAutomatedReport = ParseAuto.ReturnIsAutomated(input);

            parsed.Wind = ParseWind.ReturnWind(input);

            parsed.Temperature = ParseTemperature.ReturnTemperature(input);

            parsed.Pressure = ParsePressure.ReturnPressure(input);

            parsed.RunwayVisibilities = ParseRVR.ReturnRVR(input);

            parsed.Clouds = ParseClouds.ReturnClouds(input);

            parsed.Visibility = ParseVisibility.ReturnVisibility(input);

            parsed.Weather = ParseWeather.ReturnWeather(input);

            parsed.AdditionalInformation = ParseAdditional.ReturnAdditional(input);

            parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(parsed);

            return parsed;
        }
    }
}
