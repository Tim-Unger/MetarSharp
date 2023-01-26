using MetarSharp.Exceptions;
using MetarSharp.Parse;
using static MetarSharp.Parser.Helpers;
using MetarSharp.Parse.ReadableReport;

namespace MetarSharp.Parser
{
    internal class FromString
    {
        /// <summary>
        /// This is the main parser class which calls all the individual parts of the metar parser 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static Metar Parse(string input)
        {
            if (IsStringNullOrEmpty(input))
            {
                throw new ParseException("input is null or an empty line, check input");
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

            parsed.Trends = ParseTrend.ReturnTrend(input, parsed);

            parsed.AdditionalInformation = ParseAdditional.ReturnAdditional(input);

            parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(parsed);

            return parsed;
        }
    }
}
