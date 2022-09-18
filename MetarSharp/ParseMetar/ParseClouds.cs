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
        public static List<Cloud> ReturnClouds (string raw)
        {
            List<Cloud> clouds = new List<Cloud>();

            Regex CloudRegex = new Regex(@"((CAVOK)|((FEW|SCT|BKN|OVC|VV|NSC|NCD|///)([0-9]{3}|///)(CB|TCU|///)?))", RegexOptions.None);

            foreach (Match CloudMatch in CloudRegex.Matches(raw))
            {
                Cloud cloud = new Cloud();

                GroupCollection Groups = CloudMatch.Groups;

                if (Groups[0].Value == "CAVOK")
                {
                    cloud.IsCAVOK = true;
                }
                else
                {
                    cloud.CloudRaw = Groups[0].Value;

                    //Clouds not measurable
                    if (Groups[2].Value == "///")
                    {
                        cloud.IsCloudMeasurable = false;
                    }
                    //Clouds not measurable, Vertical Visibility is used instead
                    else if (Groups[2].Value == "VV")
                    {
                        cloud.IsVerticalVisibility = true;
                        if (Groups[3].Value == "///")
                        {
                            cloud.IsVerticalVisibilityMeasurable = false;
                        }
                        else
                        {
                            cloud.IsVerticalVisibilityMeasurable = true;

                            if (int.TryParse(Groups[3].Value, out int VerticalVisibility))
                            {
                                cloud.VerticalVisibility = VerticalVisibility;
                            }
                        }
                    }
                    //Clouds Measurable
                    else
                    {
                        cloud.IsCloudMeasurable = true;
                        cloud.CloudCoverageTypeRaw = Groups[2].Value;

                        string CloudTypeDecoded = null;
                        switch (Groups[2].Value)
                        {
                            case "Few":
                                CloudTypeDecoded = "Few Clouds";
                                break;
                            case "SCT":
                                CloudTypeDecoded = "Scattered Clouds";
                                break;
                            case "BKN":
                                CloudTypeDecoded = "Broken Clouds";
                                break;
                            case "OVC":
                                CloudTypeDecoded = "Overcast Clouds";
                                break;
                            case "NSC":
                                CloudTypeDecoded = "No Significant Clouds";
                                break;
                            case "NCD":
                                CloudTypeDecoded = "No Clouds Detected";
                                break;

                        }
                        cloud.CloudCoverageTypeDecoded = CloudTypeDecoded;

                        if (Groups[3].Value == "///")
                        {
                            cloud.IsCeilingMeasurable = false;
                        }
                        else
                        {
                            cloud.IsCeilingMeasurable = true;
                            
                            if (int.TryParse(Groups[3].Value, out int CloudCeiling))
                            {
                                cloud.CloudCeiling = CloudCeiling;
                            }
                        }

                        if (Groups[4].Success == true)
                        {
                            if (Groups[4].Value == "///")
                            {
                                cloud.IsCBTypeMeasurable = false;
                            }
                            else
                            {
                                cloud.IsCBTypeMeasurable = true;
                                cloud.HasCumulonimbusClouds = true;
                                cloud.CBCloudTypeRaw = Groups[4].Value;

                                string CBTypeDecoded = null;
                                switch (Groups[4].Value)
                                {
                                    case "CB":
                                        CBTypeDecoded = "Cumulonimbus Clouds";
                                        break;
                                    case "TC": case "TCU":
                                        CBTypeDecoded = "Towering Cumulonimbus Clouds";
                                        break;
                                }
                                cloud.CBCloudTypeDecoded = CBTypeDecoded;
                            }
                            
                        }
                        else
                        {
                            cloud.HasCumulonimbusClouds = false;
                        }
                    }
                    

                }
            }

            return clouds;
        }
    }
}
