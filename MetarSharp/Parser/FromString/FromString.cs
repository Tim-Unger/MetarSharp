using MetarSharp.Parse;
//ReadableReport has its own Namespace to prevent any clashing of Variable Names within ReadableReport
using MetarSharp.Parse.ReadableReport;

namespace MetarSharp.Parser
{
    internal class FromString
    {
        /// <summary>
        /// This is the main parser (or rather the publicly accessible extension) class which calls all the individual parts of the metar parser
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Metar Parse(string input) => ParseMetar(input, null);

        public static Metar Parse(string input, MetarParser parser) =>  ParseMetar(input, parser);

        private static Metar ParseMetar(string input, MetarParser? parser)
        {
            var parserNonNull = parser ?? new MetarParser() { CreateReadableReport = true };

            var parsed = new Metar()
            {
                MetarRaw = input,

                Airport = ParseAirport.ReturnAirport(input),

                ReportingTime = ParseReportingTime.ReturnReportingTime(input, parser),

                IsAutomatedReport = ParseAuto.ReturnIsAutomated(input),

                Wind = ParseWind.ReturnWind(input, parser),

                Visibility = ParseVisibility.ReturnVisibility(input, parser),

                RunwayVisibilities = ParseRVR.ReturnRVR(input),

                Weather = ParseWeather.ReturnWeather(input),

                Clouds = ParseClouds.ReturnClouds(input),

                Temperature = ParseTemperature.ReturnTemperature(input),

                Pressure = ParsePressure.ReturnPressure(input, parser),

                //Not yet implemented
                //RunwayConditions = ;

                AdditionalInformation = ParseAdditional.ReturnAdditional(input),
            };

            parsed.Trends = ParseTrend.ReturnTrend(input, parsed);

            if (!parserNonNull.CreateReadableReport)
            {
                return parsed;
            }

            parsed.ReadableReport = ParseReadableReport.ReturnReadableReport(parsed, parserNonNull.CultureInfo ?? null);

            //if (parser.IsReadonly)
            //{
            //    return new Readonly
            //}

            return parsed;
        }
    }
}
