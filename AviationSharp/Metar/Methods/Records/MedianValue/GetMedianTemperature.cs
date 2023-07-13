namespace AviationSharp.Metar.Records.MedianValue
{
    internal class MedianTemperature
    {
        internal static Metar Get(List<Metar> metars, MidpointRounding? midpointRounding)
        {
            var measurableMetars = metars
                .Where(x => x.Temperature.IsTemperatureMeasurable)
                .ToList();

            var medianIndex = (int)Math.Round(
                (double)measurableMetars.Count / 2,
                0,
                midpointRounding ?? MidpointRounding.AwayFromZero
            );

            return measurableMetars[medianIndex];
        }
    }
}
