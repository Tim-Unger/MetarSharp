using MetarSharp.Definitions;
using MetarSharp.Exceptions;
using System.Text.RegularExpressions;

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
                        cloud.VerticalVisibility = TryParseWithThrow(groups[5].Value, raw) * 100;
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

                    if (cloud.IsCeilingMeasurable == true)
                    {
                        cloud.CloudCeiling = TryParseWithThrow(groups[5].Value, raw) * 100;

                    }

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
                                _ => throw new ParseException("Could not read Cumulonimbus Cloud Type")
                            };
                        }
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

        private static int TryParseWithThrow(string value, string raw)
        {
            return int.TryParse(value, out int converted)
              ? converted
              : throw new ParseException($"Could not convert value {value} {raw} to number");
        }
    }
}
