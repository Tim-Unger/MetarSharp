using MetarSharp.Exceptions;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Trend
    {
        internal static string Append(Metar metar)
        {
            //TODO
            StringBuilder stringBuilder = new StringBuilder();

            var trends = metar.Trends;
            if (trends.Any(x => x.TrendType == TrendType.NoSignificantChange))
            {
                return "No significant change";
            }

            foreach (var trend in trends)
            {
                if (trend.IsTimeRestricted)
                {
                    string decodeTimeRestriction = trend.TimeRestrictionType switch
                    {
                        TimeRestrictionType.From => "From",
                        TimeRestrictionType.At => "At",
                        TimeRestrictionType.Until => "Until",
                        _ => throw new ParseException()
                    };

                    DateTime timeRestrictionDateTime = trend.TimeRestrictionDateTime ?? throw new ParseException();
                    string time = timeRestrictionDateTime.ToString("HH:mm");
                    stringBuilder.Append($"{decodeTimeRestriction} {time} Zulu ");
                }

                stringBuilder.Append($"{trend.TrendTypeDecoded ?? throw new ParseException()} ");

                foreach (var singleTrend in trend.TrendList ?? Enumerable.Empty<object>())
                {
                    //Casts the single trend to the appropriate metar class as the list item is an object
                    string parseSingleTrend = singleTrend.GetType().Name switch
                    {
                        "Visibility" => ParseVisibility((MetarSharp.Visibility)singleTrend),
                        "Weather" => ParseWeather((MetarSharp.Weather)singleTrend),
                        "Wind" => ParseWind((MetarSharp.Wind)singleTrend),
                        "Cloud" => ParseCloud((MetarSharp.Cloud)singleTrend),
                        _ => throw new ParseException()
                    };

                    stringBuilder.Append(parseSingleTrend + " ");
                }
            }

            return stringBuilder.ToString();
        }

        //TODO refactor all of these
        private static string ParseVisibility(MetarSharp.Visibility visibility)
        {
            string visibilityString = null;
            //TODO CAVOK
            if (visibility.IsVisibilityMeasurable == false)
            {
                return "Visibility not measurable";
            }

            visibilityString =
                "Visibility: "
                + visibility.ReportedVisibility
                + " "
                + visibility.VisibilityUnitDecoded
                + " ";

            if (visibility.HasVisibilityLowestValue)
            {
                string lowestVisibility =
                    "Lowest Visibility: "
                    + visibility.LowestVisibility
                    + " "
                    + visibility.VisibilityUnitDecoded
                    + " in the"
                    + visibility.LowestVisibilityDirectionDecoded
                    + " ";

                return visibilityString + lowestVisibility;
            }

            return visibilityString;
        }

        private static string ParseWeather(MetarSharp.Weather weather)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (weather.IsRecent)
            {
                stringBuilder.Append("Recent ");
            }

            if (weather.WeatherIntensity != WeatherIntensity.Normal)
            {
                stringBuilder.Append(weather.WeatherIntensityDecoded + " ");
            }

            stringBuilder.Append(weather.WeatherCombinedDecoded + " ");

            if (weather.IsInTheVicinity)
            {
                stringBuilder.Append("In the vicinity");
            }

            return stringBuilder.ToString();
        }

        private static string ParseWind(MetarSharp.Wind wind)
        {
            string windString = null;
            string windGust = null;
            string windVariation = null;

            if (!wind.IsWindMeasurable)
            {
                return "Wind not measurable";
            }

            if (wind.IsWindCalm)
            {
                return "Wind calm";
            }

            windString = ConvertWind(wind);

            if (wind.IsWindGusting)
            {
                windGust = ConvertGusts(wind);
            }

            if (wind.IsWindDirectionVarying)
            {
                windVariation = ConvertVariation(wind);
            }

            return windString + windGust + windVariation;
        }

        private static string ConvertWind(MetarSharp.Wind wind)
        {
            if (wind.IsWindVariable)
            {
                return "Wind variable " + wind.WindStrength + " " + wind.WindUnitDecoded;
            }

            return "Wind: "
                + wind.WindDirection
                + " Degrees "
                + wind.WindStrength
                + " "
                + wind.WindUnitDecoded;
        }

        private static string ConvertGusts(MetarSharp.Wind wind)
        {
            return "\n" + "Gusting up to " + wind.WindGusts + " " + wind.WindUnitDecoded;
        }

        private static string ConvertVariation(MetarSharp.Wind wind)
        {
            return "\n"
                + "Variable between "
                + wind.WindVariationLow
                + " Degrees and "
                + wind.WindVariationHigh
                + " Degrees.";
        }

        private static string ParseCloud(MetarSharp.Cloud cloud)
        {
            string cloudString = null;

            if (cloud.IsCAVOK)
            {
                return "Ceiling and Visibility Okay";
            }

            if (cloud.IsCloudMeasurable == false)
            {
                return "Cloud not measurable";
            }

            //TODO
            if (cloud.HasCumulonimbusClouds == false)
            {
                if (cloud.IsCeilingMeasurable == true)
                {
                    return "Cloud: " + cloud.CloudCoverageTypeDecoded + " at " + cloud.CloudCeiling;
                }

                return "Cloud: " + cloud.CloudCoverageTypeDecoded + " Ceiling not measurable";
            }

            if (cloud.IsCeilingMeasurable == true)
            {
                cloudString = (bool)cloud.IsCeilingMeasurable
                    ? cloudString =
                          "Cloud: "
                          + cloud.CloudCoverageTypeDecoded
                          + " with "
                          + cloud.CBCloudTypeDecoded
                          + " at "
                          + cloud.CloudCeiling
                    : cloudString =
                          "Cloud: "
                          + cloud.CloudCoverageTypeDecoded
                          + " CB-Type not measurable at"
                          + cloud.CloudCeiling;

                return cloudString;
            }

            if (cloud.IsCBTypeMeasurable == true)
            {
                cloudString = (bool)cloud.IsCBTypeMeasurable
                    ? cloudString =
                          "Cloud: "
                          + cloud.CloudCoverageTypeDecoded
                          + " with "
                          + cloud.CBCloudTypeDecoded
                          + " Ceiling not measurable"
                    : cloudString =
                          "Cloud: "
                          + cloud.CloudCoverageTypeDecoded
                          + " CB-Type not measurable "
                          + " Ceiling not measurable";

                return cloudString;
            }

            //TODO null exception here
            if (cloud.IsVerticalVisibilityMeasurable == true || cloud.IsVerticalVisibility == null)
            {
                return "Vertical Visibility not measurable";
            }

            return "Vertical Visibility: " + cloud.VerticalVisibility;
        }
    }
}
