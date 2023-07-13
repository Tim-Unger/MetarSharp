using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Parse
{
    internal class ParseClouds
    {
        private static readonly Regex _cloudRegex = new(@"((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))");

        /// <summary>
        /// this returns a list of all clouds in the metar.
        /// if the report is CAVOK or if no clouds are reported, it will return an empty enumerable
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static List<Cloud> ReturnClouds(string raw)
        {
            var clouds = new List<Cloud>();

            foreach (Match cloudMatch in _cloudRegex.Matches(raw).Cast<Match>())
            {
                var cloud = new Cloud();

                GroupCollection groups = cloudMatch.Groups;

                //CAVOK
                if (groups[0].Value == "CAVOK")
                {
                    cloud.IsCAVOK = true;

                    continue;
                }

                cloud.IsCAVOK = false;

                cloud.CloudRaw = groups[0].Value;

                //Clouds not measurable
                cloud.IsCloudMeasurable = groups[4].Value != "///";

                //Vertical Visibility is used
                var isVerticalVisibiltiy = groups[4].Value == "VV";
                cloud.IsVerticalVisibility = isVerticalVisibiltiy;

                //Vertical Visibility not measurable
                if (isVerticalVisibiltiy == true)
                {
                    (cloud.VerticalVisibilityRaw, cloud.IsVerticalVisibilityMeasurable, cloud.VerticalVisibility) = VerticalVisibility.Get(groups);

                    clouds.Add(cloud);
                    continue;
                }

                //Clouds Measurable
                if (groups[4].Value != "///")
                {
                    cloud.IsVerticalVisibility = false;
                    cloud.IsCloudMeasurable = true;
                    cloud.CloudCoverageTypeRaw = groups[4].Value;

                    (cloud.CloudCoverageType, cloud.CloudCoverageTypeDecoded) = GetCloudType.Get(
                        groups[4].Value
                    );

                    cloud.IsCeilingMeasurable = groups[5].Value != "///";

                    if (cloud.IsCeilingMeasurable == true)
                    {
                        cloud.CloudCeiling = IntTryParseWithThrow(groups[5].Value) * 100;
                    }

                    var hasCumulonimbusClouds = groups[6].Success;

                    if(hasCumulonimbusClouds)
                    {
                        (bool, string, string) cbTuple = CBClouds.Get(groups);

                        cloud.IsCBTypeMeasurable = cbTuple.Item1;
                        cloud.CBCloudTypeRaw = cbTuple.Item2;
                        cloud.CBCloudTypeDecoded = cbTuple.Item3;
                    }
                }

                clouds.Add(cloud);
            }

            //This will only return the list if it has any clouds
            if(clouds.Count > 0)
            {
                return clouds;
            }

            //It will otherwise return a CAVOK Element
            Cloud emptyCloud = new() { IsCAVOK = true, CloudCeiling = 9999, IsCeilingMeasurable = true, IsCloudMeasurable = true, CloudRaw = "CAVOK" };
            clouds.Add(emptyCloud);
            return clouds;
        }
    }

    public class ParseCloudsOnly
    {
        public static List<Cloud> FromString(string raw) => ParseClouds.ReturnClouds(raw) ?? Enumerable.Empty<Cloud>().ToList();
    }
}
