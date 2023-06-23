using MetarSharp.Parse;
//ReadableReport has its own Namespace to prevent any clashing of Variable Names within ReadableReport
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
        public static Metar Parse(string input) => ParseMetar(input, null);

        public static Metar Parse(string input, MetarParser parser) =>  ParseMetar(input, parser);

        private static Metar ParseMetar(string input, MetarParser? parser)
        {
            var parsed = new Metar()
            {
                MetarRaw = input,

                Airport = ParseAirport.ReturnAirport(input),

                ReportingTime = ParseReportingTime.ReturnReportingTime(input),

                IsAutomatedReport = ParseAuto.ReturnIsAutomated(input),

                Wind = ParseWind.ReturnWind(input),

                Visibility = ParseVisibility.ReturnVisibility(input),

                RunwayVisibilities = ParseRVR.ReturnRVR(input),

                Weather = ParseWeather.ReturnWeather(input),

                Clouds = ParseClouds.ReturnClouds(input),

                Temperature = ParseTemperature.ReturnTemperature(input),

                Pressure = ParsePressure.ReturnPressure(input),

                //Not yet implemented
                //RunwayConditions = ;

                AdditionalInformation = ParseAdditional.ReturnAdditional(input),
            };

            parsed.Trends = ParseTrend.ReturnTrend(input, parsed);

            parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(parsed);

            //if (parser.IsReadonly)
            //{
            //    return new Readonly
            //}

            return parsed;
        }
    }
}
