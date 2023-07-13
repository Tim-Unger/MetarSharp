namespace AviationSharp.Metar.Records.MedianValue
{
    internal class MedianPressure
    {
        internal static Metar Get(List<Metar> metars, MidpointRounding? midpointRounding)
        {
            var measurableMetars = metars.Where(x => x.Pressure.IsPressureMeasurable).ToList();

            //Rounds to the set value by the user, otherwise up
            var medianIndex = (int)Math.Round(
                (double)measurableMetars.Count / 2,
                0,
                midpointRounding ?? MidpointRounding.AwayFromZero
            );

            return measurableMetars[medianIndex];
        }
    }
}
