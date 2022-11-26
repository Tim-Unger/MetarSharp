using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                cloud.IsVerticalVisibility = groups[4].Value == "VV";
                //Vertical Visibility not measurable
                cloud.IsVerticalVisibilityMeasurable = groups[5].Value != "///";

                cloud.VerticalVisibility = int.TryParse(groups[5].Value, out int verticalVisibiliy) ? verticalVisibiliy : throw new Exception("Could not read Vertical Visibility");

                //Clouds Measurable
                if (groups[4].Value != "///")
                {
                    cloud.IsVerticalVisibility = false;
                    cloud.IsCloudMeasurable = true;
                    cloud.CloudCoverageTypeRaw = groups[4].Value;

                    cloud.CloudCoverageTypeDecoded = groups[4].Value.ToUpper() switch
                    {
                        "FEW" => "Few Clouds",
                        "SCT" => "Scattered Clouds",
                        "BKN" => "Broken Clouds",
                        "OVC" => "Overcast Clouds",
                        "NSC" => "No Significant Clouds",
                        "NCD" => "No Clouds detected",
                        _ => "Can't read Clouds"

                    };

                    cloud.IsCeilingMeasurable = groups[4].Value != "///";

                    cloud.CloudCeiling = int.TryParse(groups[5].Value, out int cloudCeiling) ? cloudCeiling : throw new Exception("Could not read Cloud Ceiling");

                    cloud.IsCBTypeMeasurable = groups[6].Value != "///";

                    cloud.HasCumulonimbusClouds = groups[6].Success;
                    cloud.CBCloudTypeRaw = groups[6].Value;

                    cloud.CBCloudTypeDecoded = groups[6].Value switch
                    {
                        "CB" => "Cumulonimbus Clouds",
                        "TC" or "TCU" => "Towering Cumulonimbus Clouds",
                        null or "" => null,
                        _ => throw new Exception("Could not read Cumulonimbus Cloud Type")
                    };
                }

                clouds.Add(cloud);
            }

            return clouds;
        }
    }
}
