using static MetarSharp.Extensions.DistanceExtensions;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Trend
    {
        internal static string Append(Metar metar)
        {
            var stringBuilder = new StringBuilder();
            var trendElementsDecoded = new List<string>();

            var trends = metar.Trends;
            if (trends.Any(x => x.TrendType == TrendType.NoSignificantChange))
            {
                return "No significant change";
            }

            foreach (var trend in trends)
            {
                foreach (var singleTrend in trend.TrendList ?? Enumerable.Empty<object>())
                {
                    //Casts the single trend to the appropriate metar class as the list item is an object
                    var parseSingleTrend = singleTrend.GetType().Name switch
                    {
                        "Visibility" => ParseVisibility((MetarSharp.Visibility)singleTrend),
                        "Weather" => ParseWeather((MetarSharp.Weather)singleTrend),
                        "Wind" => ParseWind((MetarSharp.Wind)singleTrend),
                        "Cloud" => ParseCloud((MetarSharp.Cloud)singleTrend),
                        _ => throw new ParseException()
                    };

                    trendElementsDecoded.Add(parseSingleTrend);
                }
            }

            return AddCommas(trendElementsDecoded);
        }

        private static string ParseVisibility(MetarSharp.Visibility visibility)
        {
            if (visibility.IsVisibilityMeasurable == false)
            {
                return "Visibility not measurable";
            }

            var visibilityUnit = DistanceValueSingularOrPlural(visibility.ReportedVisibility, visibility.VisibilityUnit);

            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Visibility: {visibility.ReportedVisibility} {visibilityUnit}");

            if (visibility.HasVisibilityLowestValue)
            {
                stringBuilder.Append($" Lowest Visibility: {visibility.LowestVisibility} in the {visibility.LowestVisibilityDirectionDecoded}");

                return stringBuilder.ToString();
            }

            return stringBuilder.ToString();
        }

        private static string ParseWeather(MetarSharp.Weather weather)
        {
            var stringBuilder = new StringBuilder();

            if (weather.IsRecent)
            {
                stringBuilder.Append("Recent ");
            }

            if (weather.WeatherIntensity != WeatherIntensity.Normal)
            {
                stringBuilder.Append(weather.WeatherIntensityDecoded);
            }

            stringBuilder.Append(weather.WeatherCombinedDecoded);

            if (weather.IsInTheVicinity)
            {
                stringBuilder.Append(" In the vicinity");
            }

            return stringBuilder.ToString();
        }

        private static string ParseWind(MetarSharp.Wind wind)
        {
            string? windGust = null;
            string? windVariation = null;

            if (!wind.IsWindMeasurable)
            {
                return "Wind not measurable";
            }

            if (wind.IsWindCalm)
            {
                return "Wind calm";
            }

            var windString = ConvertWind(wind);

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
                return $"Wind variable {wind.WindStrength} {wind.WindUnitDecoded}";
            }

            return $"Wind: {wind.WindDirection} Degrees {wind.WindStrength} {wind.WindUnitDecoded}";
        }

        private static string ConvertGusts(MetarSharp.Wind wind)
        {
            return "\n" + $"Gusting up to {wind.WindGusts} {wind.WindUnitDecoded}";
        }

        private static string ConvertVariation(MetarSharp.Wind wind)
        {
            return "\n" + $"Variable between {wind.WindVariationLow} Degrees and {wind.WindVariationHigh} Degrees.";
        }

        private static string ParseCloud(MetarSharp.Cloud cloud)
        {
            var stringBuilder = new StringBuilder();

            if (cloud.IsCAVOK)
            {
                //"Ceiling and Visibility Okay" is already set in the Visibility Class,
                //hence it is not needed a second time
                return "Ceiling and Visibility Okay";
            }

            if (cloud.IsCloudMeasurable == false)
            {
                stringBuilder.AppendLine("Cloud not measurable");
            }

            var cloudType = Clouds.GetCloudType(cloud);
            var cloudCeiling = Clouds.GetCloudCeiling(cloud);

            stringBuilder.AppendLine(cloudType + cloudCeiling);

            //this removes the last \r\n from the string
            stringBuilder.Length -= 2;

            return stringBuilder.ToString();
        }

        private static string AddCommas(List<string> trendElements)
        {
            var editedList = new List<string>();

            //Adds a comma for every item except the last one
            trendElements.SkipLast(1)
                .ToList()
                .ForEach(x => editedList.Add(x + ", "));

            //Adds the last element to the edited list
            editedList.Add(trendElements.Last());

            //Turns the list into a single string
            var stringBuilder = new StringBuilder();
            editedList.ForEach(x => stringBuilder.AppendLine(x));

            return stringBuilder.ToString();
        }
    }
}
