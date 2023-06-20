namespace MetarSharp.Parse
{
    internal class GetCloudType
    {
        internal static (MetarSharp.CloudType, string) Get(string input) =>
            input.ToUpper() switch
            {
                "FEW" => (MetarSharp.CloudType.Few, CloudDefintions.FewCloudsLong),
                "SCT" => (MetarSharp.CloudType.Scattered, CloudDefintions.ScatteredCloudsLong),
                "BKN" => (MetarSharp.CloudType.Broken, CloudDefintions.BrokenCloudsLong),
                "OVC" => (MetarSharp.CloudType.Overcast, CloudDefintions.OvercastCloudsLong),
                "NSC" => (MetarSharp.CloudType.NoSignificantClouds, CloudDefintions.NoSignificantCloudsLong),
                "NCD" => (MetarSharp.CloudType.NoCloudsDetected, CloudDefintions.NoCloudsDetectedLong),
                _ => throw new ParseException("Can't read cloud type")
            };
    }
}
