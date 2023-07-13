namespace MetarSharp.Records.MedianValue
{
    internal class MedianCeiling
    {
        internal static Metar Get(List<Metar> metars, MidpointRounding? midpointRounding)
        {
            var cleanedInput = GetCloudsWithMesaurableCeiling(metars);

            return GetReturn(cleanedInput, midpointRounding);
        }

        private static List<Metar> GetCloudsWithMesaurableCeiling(List<Metar> metars)
        {
            var measurableClouds = new List<Metar>();
            
            //Runs through all the metars, then adds all metars where the vis is measurable
            metars.ForEach(
                x =>
                    measurableClouds.AddRange(
                        (IEnumerable<Metar>)x.Clouds.Where(
                            y => y.IsCloudMeasurable == true && y.IsVerticalVisibility == false
                        )
                    )
            );

            return measurableClouds;
        }

        private static Metar GetReturn(List<Metar> metars, MidpointRounding? midpointRounding)
        {
            //Sorts each Metars cloud list by highest ceiling first
            metars.ForEach(x => x.Clouds.OrderBy(x => x.CloudCeiling));
            //Sorts all Metars by the cloud ceiling of the cloud with the highest ceiling
            metars.OrderBy(x => x.Clouds.First().CloudCeiling);

            var middleValue = int.Parse(
                Math.Round((double)metars.Count / 2, 0, midpointRounding ?? MidpointRounding.ToEven).ToString()
            );

            //returns the metar in the middle of the sorted list
            return metars[middleValue];
        }
    }
}
