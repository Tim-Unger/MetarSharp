namespace AviationSharp.Metar.Parse
{
    internal class GetCloudType
    {
        internal static (CloudType, string) Get(string input) =>
            input.ToUpper() switch
            {
                "FEW" => (CloudType.Few, CloudDefintions.FewCloudsLong),
                "SCT" => (CloudType.Scattered, CloudDefintions.ScatteredCloudsLong),
                "BKN" => (CloudType.Broken, CloudDefintions.BrokenCloudsLong),
                "OVC" => (CloudType.Overcast, CloudDefintions.OvercastCloudsLong),
                "NSC" => (CloudType.NoSignificantClouds, CloudDefintions.NoSignificantCloudsLong),
                "NCD" => (CloudType.NoCloudsDetected, CloudDefintions.NoCloudsDetectedLong),
                _ => throw new ParseException("Can't read cloud type")
            };
    }
}
