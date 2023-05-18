namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestCeiling
    {
        //TODO implement
        internal static Metar Get(List<Metar> metars)
        {
            var cloudsSorted = metars.SelectMany(x => x.Clouds)
                .ToList()
                .OrderByDescending(x => x.CloudCeiling)
                .First();

            return new Metar();
            //return metars.Where(x => !x.Clouds.Any(x => x.IsCAVOK) || x.Clouds.Any(x => x.is)); 
        }
    }
}
