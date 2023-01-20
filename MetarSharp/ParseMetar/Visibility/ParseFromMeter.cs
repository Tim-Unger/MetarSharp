using MetarSharp.Definitions;
using System.Text.RegularExpressions;
using static MetarSharp.Parse.ParseVisibility;

namespace MetarSharp.Parse
{
    internal class ParseFromMeter
    {
        internal static Visibility ParseVisibiltiy(GroupCollection groups)
        {
            Visibility visibility = new();

            #region STANDARD
            visibility.VisibilityRaw = groups[1].Value.TrimStart();

            visibility.ReportedVisibility = double.Parse(groups[2].Value);

            visibility.IsVisibilityMeasurable = true;
            
            visibility.VisibilityUnit = VisibilityUnit.Meters;
            visibility.VisibilityUnitRaw = DistanceDefinitions.MeterShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.MeterLong;

            #endregion

            if (groups[4].Success)
            {
                visibility.HasVisibilityLowestValue = true;

                visibility.LowestVisibilityDirectionRaw = groups[4].Value;
                visibility.LowestVisibility = double.Parse(groups[4].Value);
                (
                    visibility.LowestVisibilityDirection,
                    visibility.LowestVisibilityDirectionDecoded
                ) = GetCardinalDirection(groups[5].Value);

            }
            return visibility;
        }
    }
}
