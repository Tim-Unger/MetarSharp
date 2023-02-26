using MetarSharp.Definitions;
using MetarSharp.Exceptions;
using System.Text.RegularExpressions;
using static MetarSharp.Extensions.Helpers;

namespace MetarSharp.Parse
{
    public class ParseClouds
    {
        /// <summary>
        /// this returns a list of all clouds in the metar.
        /// if the report is CAVOK or if no clouds are reported, it will return an empty enumerable
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static List<Cloud> ReturnClouds(string raw)
        {
            List<Cloud> clouds = new List<Cloud>();

            Regex cloudRegex = new Regex(
                @"((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))",
                RegexOptions.None
            );

            foreach (Match cloudMatch in cloudRegex.Matches(raw).Cast<Match>())
            {
                Cloud cloud = new Cloud();

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
                bool isVerticalVisibiltiy = groups[4].Value == "VV";
                cloud.IsVerticalVisibility = isVerticalVisibiltiy;

                //Vertical Visibility not measurable
                if (isVerticalVisibiltiy == true)
                {
                    (string, bool, int?) verticalVisTuple = GetVerticalVisibility(groups);

                    cloud.VerticalVisibilityRaw = verticalVisTuple.Item1;
                    cloud.IsVerticalVisibilityMeasurable = verticalVisTuple.Item2;
                    cloud.VerticalVisibility = verticalVisTuple.Item3;

                    clouds.Add(cloud);
                    continue;
                }

                //Clouds Measurable
                if (groups[4].Value != "///")
                {
                    cloud.IsVerticalVisibility = false;
                    cloud.IsCloudMeasurable = true;
                    cloud.CloudCoverageTypeRaw = groups[4].Value;

                    (cloud.CloudCoverageType, cloud.CloudCoverageTypeDecoded) = GetCloudType(
                        groups[4].Value
                    );

                    cloud.IsCeilingMeasurable = groups[5].Value != "///";

                    if (cloud.IsCeilingMeasurable == true)
                    {
                        cloud.CloudCeiling = IntTryParseWithThrow(groups[5].Value) * 100;
                    }

                    bool hasCumulonimbusClouds = groups[6].Success;
                    if(hasCumulonimbusClouds)
                    {
                        (bool, string, string) cbTuple = GetCBClouds(groups);

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
            //TODO better empty element
            Cloud emptyCloud = new() { IsCAVOK = true, CloudCeiling = 9999, IsCeilingMeasurable = true, IsCloudMeasurable = true };
            clouds.Add(emptyCloud);
            return clouds;
        }

        private static (CloudType, string) GetCloudType(string input) =>
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

        private static (string, bool, int?) GetVerticalVisibility(GroupCollection groups)
        {
            string verticalVisibilityRaw = groups[4].Value + groups[5].Value;

            bool isVerticalVisibilityMeasurable = groups[5].Value != "///";

            int? verticalVisibility = null;
            if (isVerticalVisibilityMeasurable)
            {
                verticalVisibility = IntTryParseWithThrow(groups[5].Value) * 100;
            }

            return (verticalVisibilityRaw, isVerticalVisibilityMeasurable, verticalVisibility);
        }

        private static (bool, string, string) GetCBClouds(GroupCollection groups)
        {
            bool isCbTypeMesaurable = groups[6].Value != "///";

            string CBCloudTypeRaw = "";
            string CBCloudTypeDecoded = "";

            if (isCbTypeMesaurable)
            {
                CBCloudTypeRaw = groups[6].Value;

                CBCloudTypeDecoded = groups[6].Value switch
                {
                    "CB" => CloudDefintions.CumulonimbusLong,
                    "TC" or "TCU" => CloudDefintions.ToweringCumulonimbusLong,
                    _ => throw new ParseException("Could not read Cumulonimbus Cloud Type")
                };
            }

            return (isCbTypeMesaurable, CBCloudTypeRaw, CBCloudTypeDecoded);
        }
    }
}
