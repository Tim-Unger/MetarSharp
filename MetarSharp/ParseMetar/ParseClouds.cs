using System;
using System.Collections.Generic;
using System.Linq;
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

            Regex CloudRegex = new Regex(
                @"((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))",
                RegexOptions.None
            );

            foreach (Match CloudMatch in CloudRegex.Matches(raw).Cast<Match>())
            {
                Cloud cloud = new Cloud();

                GroupCollection Groups = CloudMatch.Groups;

                //CAVOK
                if (Groups[0].Value == "CAVOK")
                {
                    cloud.IsCAVOK = true;

                    continue;
                }

                cloud.CloudRaw = Groups[0].Value;
                //Clouds not measurable
                cloud.IsCloudMeasurable = Groups[4].Value != "///";
                //Vertical Visibility is used
                cloud.IsVerticalVisibility = Groups[4].Value == "VV";
                //Vertical Visibility not measurable
                cloud.IsVerticalVisibilityMeasurable = Groups[5].Value != "///";

                if (int.TryParse(Groups[5].Value, out int VerticalVisibility))
                {
                    cloud.VerticalVisibility = VerticalVisibility;
                }

                //Clouds Measurable
                if (Groups[4].Value != "///")
                {
                    cloud.IsVerticalVisibility = false;
                    cloud.IsCloudMeasurable = true;
                    cloud.CloudCoverageTypeRaw = Groups[4].Value;

                    cloud.CloudCoverageTypeDecoded = Groups[4].Value.ToUpper() switch
                    {
                        "FEW" => "Few Clouds",
                        "SCT" => "Scattered Clouds",
                        "BKN" => "Broken Clouds",
                        "OVC" => "Overcast Clouds",
                        "NSC" => "No Significant Clouds",
                        "NCD" => "No Clouds detected",
                        _ => "Can't read C"

                    };

                    cloud.IsCeilingMeasurable = Groups[4].Value != "///";

                    if (int.TryParse(Groups[5].Value, out int CloudCeiling))
                    {
                        cloud.CloudCeiling = CloudCeiling;
                    }

                    cloud.IsCBTypeMeasurable = Groups[6].Value != "///";

                    cloud.HasCumulonimbusClouds = Groups[6].Success;
                    cloud.CBCloudTypeRaw = Groups[6].Value;

                    cloud.CBCloudTypeDecoded = Groups[6].Value switch
                    {
                        "CB" => "Cumulonimbus Clouds",
                        "TC" or "TCU" => "Towering Cumulonimbus Clouds",
                        _ => ""
                    };
                    switch (Groups[6].Value)
                    {
                        case "CB":
                            CBTypeDecoded = "Cumulonimbus Clouds";
                            break;
                        case "TC":
                        case "TCU":
                            CBTypeDecoded = "Towering Cumulonimbus Clouds";
                            break;
                    }
                    cloud.CBCloudTypeDecoded = CBTypeDecoded;
                }

                clouds.Add(cloud);
            }

            return clouds;
        }
    }
}
