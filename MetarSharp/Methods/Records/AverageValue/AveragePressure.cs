namespace MetarSharp.Methods.Records.AverageValue
{
    internal class AveragePressure
    {
        internal static double Get(List<Metar> metars, byte? decimaPlaces, bool isQnh)
        {
            var metarsWithPressure = metars.Where(x => x.Pressure.IsPressureMeasurable).ToList();

            if (isQnh)
            {
                return GetAveragePressure(metarsWithPressure, true, decimaPlaces ?? 2);
            }

            return GetAveragePressure(metarsWithPressure, true, decimaPlaces ?? 2);
        }

        private static double GetAveragePressure(List<Metar> metars, bool IsQnh, byte decimalPlaces)
        {
            var sum = 0;
            var count = 0;
            if (IsQnh)
            {
                metars.ForEach(
                    x =>
                    {
                        sum += x.Pressure.PressureAsQnh ?? 0;
                        count++;
                    }
                );

                return Math.Round(sum / (double)count, decimalPlaces);
            }

            metars.ForEach(
                x =>
                {
                    x.Pressure.PressureAsAltimeter += sum;
                    count++;
                }
            );

            return Math.Round(sum / (double)count, decimalPlaces);
        }
    }
}
