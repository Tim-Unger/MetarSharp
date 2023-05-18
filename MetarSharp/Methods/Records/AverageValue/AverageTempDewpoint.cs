namespace MetarSharp.Methods.Records.AverageValue
{
    internal class AverageTempDewpoint
    {
        internal static double Get(List<Metar> metars, bool isCelsius, bool isTemperature, byte? decimalPlaces)
        {
            var metarsWithTemp = metars.Where(x => x.Temperature.IsTemperatureMeasurable).ToList();

            if (isTemperature)
            {
                if (isCelsius)
                {
                    return GetAverageTemperature(metarsWithTemp, decimalPlaces ?? 2 , true);
                }

                return GetAverageTemperature(metarsWithTemp, decimalPlaces ?? 2, false);
            }

            if (isCelsius)
            {
                return GetAverageDewpoint(metarsWithTemp, decimalPlaces ?? 2, true);
            }

            return GetAverageDewpoint(metarsWithTemp, decimalPlaces ?? 2, false);

        }

        private static double GetAverageTemperature(
            List<Metar> metars,
            byte decimalPlaces,
            bool isCelsius
        )
        {
            double sum = 0;
            var count = 0;

            if (isCelsius)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Temperature.TemperatureCelsius;
                        count++;
                    }
                );

                return Math.Round(sum / count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    sum += x.Temperature.TemperatureFahrenheit;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }

        private static double GetAverageDewpoint(
            List<Metar> metars,
            byte decimalPlaces,
            bool isCelsius
        )
        {
            double sum = 0;
            var count = 0;

            if (isCelsius)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Temperature.DewpointCelsius;
                        count++;
                    }
                );

                return Math.Round(sum / count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    sum += x.Temperature.DewpointFahrenheit;
                    count++;
                }
            );

            return Math.Round(sum / count, decimalPlaces);
        }
    }
}
