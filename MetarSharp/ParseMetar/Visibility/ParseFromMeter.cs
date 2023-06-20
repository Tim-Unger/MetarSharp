using static MetarSharp.Parse.ParseVisibility;

namespace MetarSharp.Parse
{
    internal class ParseFromMeter
    {
        internal static Visibility ParseVisibility(GroupCollection groups)
        {
            var visibility = new Visibility();

            #region STANDARD
            visibility.VisibilityRaw = groups[1].Value.TrimStart();

            visibility.ReportedVisibility = Math.Round(double.Parse(groups[2].Value), 2);

            visibility.IsVisibilityMeasurable = true;
            
            visibility.VisibilityUnit = VisibilityUnit.Meters;
            visibility.VisibilityUnitRaw = DistanceDefinitions.MeterShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.MeterLong;

            #endregion

            if (groups[4].Success)
            {
                visibility.HasVisibilityLowestValue = true;

                visibility.LowestVisibilityDirectionRaw = groups[4].Value;
                visibility.LowestVisibility = Math.Round(double.Parse(groups[4].Value), 2);
                (
                    visibility.LowestVisibilityDirection,
                    visibility.LowestVisibilityDirectionDecoded
                ) = GetCardinalDirection.Get(groups[5].Value);

            }

            return visibility;
        }
    }
}
