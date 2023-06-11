using static MetarSharp.Parse.ParseVisibility;

namespace MetarSharp.Parse
{
    internal class ParseFromKilometer
    {
        internal static Visibility ParseVisibility(GroupCollection groups)
        {
            var visibility = new Visibility();

            #region STANDARD

            visibility.VisibilityRaw = groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            visibility.ReportedVisibility = Math.Round(double.Parse(groups[8].Value), 2);

            visibility.VisibilityUnit = VisibilityUnit.Kilometers;
            visibility.VisibilityUnitRaw = DistanceDefinitions.KilometerShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.KilometerLong;

            #endregion

            if (groups[13].Success)
            {
                visibility.HasVisibilityLowestValue = true;
                visibility.LowestVisibility = Math.Round(double.Parse(groups[14].Value), 2);
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
