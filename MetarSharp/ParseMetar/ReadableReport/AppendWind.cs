namespace MetarSharp.Parse.ReadableReport
{
    internal class Wind
    {
        internal static string Append(Metar metar)
        {
            string wind = null;
            string windGust = null;
            string windVariation = null;

            if (!metar.Wind.IsWindMeasurable)
            {
                return "Wind not measurable";
            }

            if (metar.Wind.IsWindCalm)
            {
                return "Wind calm";
            }

            wind = ConvertWind(metar);

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
                return "Wind variable "
                    + metar.Wind.WindStrength
                    + " "
                    + metar.Wind.WindUnitDecoded;
            }

            return "Wind: "
                + metar.Wind.WindDirection
                + " Degrees "
                + metar.Wind.WindStrength
                + " "
                + metar.Wind.WindUnitDecoded;
        }

        private static string ConvertGusts(Metar metar)
        {
            return "\n"
                + "Gusting up to "
                + metar.Wind.WindGusts
                + " "
                + metar.Wind.WindUnitDecoded;
        }

        private static string ConvertVariation(Metar metar)
        {
            return "\n"
                + "Variable between "
                + metar.Wind.WindVariationLow
                + " Degrees and "
                + metar.Wind.WindVariationHigh
                + " Degrees.";
        }
    }
}
