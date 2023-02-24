﻿using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Clouds
    {
        internal static string Append(Metar metar)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Cloud cloud in metar.Clouds)
            {
                StringBuilder cloudBuilder = new StringBuilder();

                string cloudString = null;

                if (cloud.IsCAVOK || cloud.CloudCoverageType == CloudType.NoCloudsDetected)
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

                string cloudType = GetCloudType(cloud);
                string cloudCeiling = GetCloudCeiling(cloud);

                cloudString = cloudType + cloudCeiling;

                stringBuilder.AppendLine(cloudString);
            }

            //this removes the last \r\n from the string
            if(stringBuilder.Length > 2)
            {
                stringBuilder.Length -= 2;
            }

            return stringBuilder.ToString();
        }

#pragma warning disable CS8603
        //TODO pragma
        internal static string GetCloudType(Cloud cloud)
        {
            if (cloud.IsCloudMeasurable == false)
            {
                return "Cloud type not measurable";
            }

            if(cloud.IsCBTypeMeasurable== false)
            {
                return "Cumulonimbus Cloud type not measurable";
            }

            if (cloud.HasCumulonimbusClouds == true)
            {
                return cloud.CBCloudTypeDecoded;
            }

            if(cloud.IsVerticalVisibility == true)
            {
                return "Vertical Visibility";
            }

            return cloud.CloudCoverageTypeDecoded;
        }

        internal static string GetCloudCeiling(Cloud cloud)
        {
            if(cloud.IsCeilingMeasurable == false)
            {
                return ", Ceiling not measurable";
            }

            if(cloud.IsVerticalVisibilityMeasurable == false)
            {
                return ", not measurable";
            }

            if(cloud.IsVerticalVisibilityMeasurable == true)
            {
                return ' ' + cloud.VerticalVisibility.ToString();
            }

            return " at " + cloud.CloudCeiling.ToString() + "ft";
        }
    }
}
