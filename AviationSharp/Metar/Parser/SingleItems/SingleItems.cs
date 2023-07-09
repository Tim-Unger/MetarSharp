namespace AviationSharp.Metar
{
    public partial class ParseMetar
    {
        public class SingleItem
        {

            /// <summary>
            /// Parses only the AdditionalInformation from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static AdditionalInformation? JustAdditionalInformation(string metar) => Parse.ParseAdditionalOnly.FromString(metar);

            /// <summary>
            /// Parses only the Airport from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static string JustAirport(string metar) => Parse.ParseAirportOnly.FromString(metar);

            /// <summary>
            /// Parses only whether the report is automated from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static bool JustIsAuto(string metar) => Parse.ParseAutoOnly.FromString(metar);

            /// <summary>
            /// Parses only the Clouds from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static List<Cloud> JustClouds(string metar) => Parse.ParseCloudsOnly.FromString(metar);

            /// <summary>
            /// Parses only the Clouds from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>        
            public static Pressure JustPressure(string metar) => Parse.ParsePressureOnly.FromString(metar);

            /// <summary>
            /// Parses only the ReadableReport from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static string JustReadableReport(string metar) => Parse.ReadableReport.ParseReadableReportOnly.FromString(metar.ParseMetar());

            /// <summary>
            /// Parses only the ReportingTime from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static ReportingTime JustReportingTime(string metar) => Parse.ParseReportingTimeOnly.FromString(metar);

            /// <summary>
            /// Parses only the RVRs from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static List<RunwayVisibility> JustRVR(string metar) => Parse.ParseRVROnly.FromString(metar);

            /// <summary>
            /// Parses only the Temperature from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static Temperature JustTemperature(string metar) => Parse.ParseTemperatureOnly.FromString(metar);

            /// <summary>
            /// Parses only the Visibility from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static Visibility JustVisibility(string metar) => Parse.ParseVisibilityOnly.FromString(metar);

            /// <summary>
            /// Parses only the Weather from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static Weather JustWeather(string metar) => Parse.ParseWeatherOnly.FromString(metar);

            /// <summary>
            /// Parses only the Wind from the given string
            /// </summary>
            /// <param name="metar"></param>
            /// <returns></returns>
            public static Wind JustWind(string metar) => Parse.ParseWindOnly.FromString(metar);
        }
    }
}
