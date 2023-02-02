using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Clouds
    {
        internal static string Append(Metar metar)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var cloud in metar.Clouds)
            {
                StringBuilder cloudBuilder = new StringBuilder();

                string cloudString = null;

                if (cloud.IsCAVOK)
                {
                    //"Ceiling and Visibility Okay" is already set in the Visibility Class,
                    //hence it is not needed a second time
                    continue;
                }

                if (cloud.IsCloudMeasurable == false)
                {
                    cloudString = "Cloud not measurable";
                    stringBuilder.AppendLine(cloudString);
                    continue;
                }

                //TODO
                if (cloud.HasCumulonimbusClouds == false)
                {
                    if (cloud.IsCeilingMeasurable == true)
                    {
                        cloudString = "Cloud: " + cloud.CloudCoverageTypeDecoded + " at " + cloud.CloudCeiling;
                        stringBuilder.AppendLine(cloudString);
                        continue;
                    }

                    cloudString = "Cloud: " + cloud.CloudCoverageTypeDecoded + " Ceiling not measurable";
                    stringBuilder.AppendLine(cloudString);
                    continue;
                }

                if (cloud.IsCeilingMeasurable == true)
                {
                    cloudString = (bool)cloud.IsCeilingMeasurable ? cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " with "
                            + cloud.CBCloudTypeDecoded
                            + " at "
                            + cloud.CloudCeiling
                            :
                            cloudString =
                            "Cloud: "
                            + cloud.CloudCoverageTypeDecoded
                            + " CB-Type not measurable at"
                            + cloud.CloudCeiling;
                    stringBuilder.AppendLine(cloudString);
                    continue;
                }

                if (cloud.IsCBTypeMeasurable == true)
                {
                    cloudString = (bool)cloud.IsCBTypeMeasurable ? cloudString =
                        "Cloud: "
                        + cloud.CloudCoverageTypeDecoded
                        + " with "
                        + cloud.CBCloudTypeDecoded
                        + " Ceiling not measurable"
                        :
                        cloudString =
                        "Cloud: "
                        + cloud.CloudCoverageTypeDecoded
                        + " CB-Type not measurable "
                        + " Ceiling not measurable";
                    stringBuilder.AppendLine(cloudString);
                    continue;
                }

                //if (cloud.IsVerticalVisibilityMeasurable == true || cloud.IsVerticalVisibility == null)
                //{
                //    cloudString = "Vertical Visibility not measurable";
                //    stringBuilder.AppendLine(cloudString);
                //}

                cloudString = "Vertical Visibility: " + cloud.VerticalVisibility;
                stringBuilder.AppendLine(cloudString);
            }

            return stringBuilder.ToString();
        }
    }
}
