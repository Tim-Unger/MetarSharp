using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp.Definitions;

namespace MetarSharp.Parse
{
    public class ParseClouds
    {
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

                cloud.CloudRaw = groups[0].Value;
                //Clouds not measurable
                cloud.IsCloudMeasurable = groups[4].Value != "///";
                //Vertical Visibility is used
                bool isVerticalVisibiltiy = groups[4].Value == "VV";
                cloud.IsVerticalVisibility = isVerticalVisibiltiy;
                //Vertical Visibility not measurable

                if (isVerticalVisibiltiy == true)
                {
                    //TODO
                    bool isVerticalVisibilityMeasurable = groups[5].Value != "///";
                    cloud.IsVerticalVisibilityMeasurable = isVerticalVisibilityMeasurable;

                    if (isVerticalVisibilityMeasurable)
                    {
                        cloud.VerticalVisibility = int.TryParse(
                        groups[5].Value,
                        out int verticalVisibiliy
                    )
                      ? verticalVisibiliy
                      : throw new Exception("Could not read Vertical Visibility");
                    }

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

                    cloud.CloudCeiling = int.TryParse(groups[5].Value, out int cloudCeiling)
                      ? cloudCeiling
                      : throw new Exception("Could not read Cloud Ceiling");


                    bool hasCumulonimbusClouds = groups[6].Success;
                    if(hasCumulonimbusClouds)
                    {
                        bool isCbTypeMesaurable = groups[6].Value != "///";
                        cloud.IsCBTypeMeasurable = isCbTypeMesaurable;

                        if(isCbTypeMesaurable)
                        {
                            cloud.CBCloudTypeRaw = groups[6].Value;

                            cloud.CBCloudTypeDecoded = groups[6].Value switch
                            {
                                "CB" => CloudDefintions.CumulonimbusLong,
                                "TC" or "TCU" => CloudDefintions.ToweringCumulonimbusLong,
                                null or "" => null,
                                _ => throw new Exception("Could not read Cumulonimbus Cloud Type")
                            };
                        }
                    }
                }

                clouds.Add(cloud);
            }

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
                _ => throw new Exception("Can't read cloud type")
            };
    }
}
