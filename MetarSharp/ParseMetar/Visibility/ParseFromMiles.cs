﻿using MetarSharp.Definitions;
using System.Text.RegularExpressions;
using MetarSharp.Exceptions;

namespace MetarSharp.Parse
{
    internal class ParseFromMiles
    {
        internal static Visibility ParseVisibility(GroupCollection groups)
        {
            Visibility visibility = new();

            visibility.VisibilityRaw = groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            //Vis is less than 1 Mile (1/2 SM)
            bool hasVisibilitySlash = false;
            double convertedValue = 0;
            if (groups[8].Value.Contains('/'))
            {
                int indexNegative = groups[10].Success ? 1 : 0;
                hasVisibilitySlash = true;

                var valueArray = groups[8].Value.ToCharArray();
                double firstValue = double.Parse(valueArray[indexNegative].ToString());
                double lastValue = double.Parse(valueArray.Last().ToString());

                convertedValue = firstValue / lastValue;
            }

            

            double reportedVisibility = 0;
            
            //Vis less than 1/4 SM
            if (groups[10].Success)
            {
                reportedVisibility = 0;
            }

            if (!hasVisibilitySlash)
            {
                reportedVisibility = int.TryParse(groups[8].Value, out int visParse)
                  ? visParse
                  : throw new ParseException(
                        $"Could not convert Visibility {groups[8].Value} to Number"
                    );
            }
            double reportedVisibilityConverted = hasVisibilitySlash ? convertedValue : reportedVisibility;
            visibility.ReportedVisibility = reportedVisibilityConverted;

            visibility.VisibilityUnit = VisibilityUnit.Miles;
            visibility.VisibilityUnitRaw = DistanceDefinitions.StatuteMileShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.StatuteMileLong;

            return visibility;
        }
    }
}
