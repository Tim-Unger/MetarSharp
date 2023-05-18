using MetarSharp.Exceptions;

namespace MetarSharp.Methods.Records.AverageValue
{
    internal enum WindType
    {
        Direction,
        Strength,
        GustStrength
    }

    internal class AverageWind
    {
        internal static double Get(List<Metar> metars, WindType windType, byte? decimalPlaces)
        {
            var metarsWithWind = metars.Where(x => !x.Wind.IsWindCalm && x.Wind.IsWindMeasurable && !x.Wind.IsWindVariable).ToList();

            return windType switch
            {
                WindType.Direction => GetAverageWindDirection(metars, decimalPlaces ?? 2),
                WindType.Strength => GetAverageWindStrength(metars, decimalPlaces ?? 2),
                WindType.GustStrength => GetAverageWindGustStrength(metars, decimalPlaces ?? 2),
                _ => throw new ParseException()
            };
        }
        private static double GetAverageWindDirection(List<Metar> metars, byte? decimalPlaces)
        {
            double sum = 0;
            var count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindDirection ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces ?? 2);
        }

        private static double GetAverageWindStrength(List<Metar> metars, byte? decimalPlaces)
        {
            double sum = 0;
            var count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindStrength ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces ?? 2);
        }

        private static double GetAverageWindGustStrength(List<Metar> metars, byte? decimalPlaces)
        {
            double sum = 0;
            var count = 0;

            metars.ForEach(
                x =>
                {
                    sum += x.Wind.WindGusts ?? 0;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces ?? 2);
        }
    }
}
