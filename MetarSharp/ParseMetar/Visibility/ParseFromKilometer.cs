using MetarSharp.Definitions;
using MetarSharp.ParseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MetarSharp.Parse.ParseVisibility;

namespace MetarSharp.Parse
{
    internal class ParseFromKilometer
    {
        internal static Visibility ParseVisibility(GroupCollection groups)
        {
            Visibility visibility = new();

            #region STANDARD

            visibility.VisibilityRaw = groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            visibility.ReportedVisibility = double.Parse(groups[8].Value);

            visibility.VisibilityUnit = VisibilityUnit.Kilometers;
            visibility.VisibilityUnitRaw = DistanceDefinitions.KilometerShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.KilometerLong;

            #endregion

            if (groups[13].Success)
            {
                visibility.HasVisibilityLowestValue = true;
                visibility.LowestVisibility = double.Parse(groups[14].Value);
                (
                    visibility.LowestVisibilityDirection,
                    visibility.LowestVisibilityDirectionDecoded
                ) = GetCardinalDirection(groups[15].Value);
                visibility.LowestVisibilityDirectionRaw = groups[15].Value;
            }

            return visibility;
        }
    }
}
