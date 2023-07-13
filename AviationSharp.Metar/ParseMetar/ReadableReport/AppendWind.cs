namespace MetarSharp.Parse.ReadableReport
{
    internal class Wind
    {
        internal static string Append(Metar metar)
        {
            string? windGust = null;
            string? windVariation = null;

            if (!metar.Wind.IsWindMeasurable)
            {
                return "Wind not measurable";
            }

            if (metar.Wind.IsWindCalm)
            {
                return "Wind calm";
            }

            var wind = ConvertWind(metar);

            if (metar.Wind.IsWindGusting)
            {
                windGust = ConvertGusts(metar);
            }

            if (metar.Wind.IsWindDirectionVarying)
            {
                windVariation = ConvertVariation(metar);
            }

            return wind + windGust + windVariation;
        }

        private static string ConvertWind(Metar metar)
        {
            if (metar.Wind.IsWindVariable)
            {
                return $"Wind variable {metar.Wind.WindStrength} {metar.Wind.WindUnitDecoded}";
            }

            var windDirection = metar.Wind.WindDirection.ToString() ?? throw new ParseException();

            //This adds a leading zero if the windDirection does not have 3 digits (50 => 050)
            windDirection = windDirection.Length == 3 ? windDirection : $"0{windDirection}";

            return $"Wind: {windDirection} Degrees {metar.Wind.WindStrength} {metar.Wind.WindUnitDecoded}";
        }

        private static string ConvertGusts(Metar metar) =>
            $" gusting up to {metar.Wind.WindGusts} {metar.Wind.WindUnitDecoded}";

        private static string ConvertVariation(Metar metar) =>
            $" variable between {metar.Wind.WindVariationLow} Degrees and {metar.Wind.WindVariationHigh} Degrees.";
    }
}
