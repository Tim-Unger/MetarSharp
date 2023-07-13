namespace AviationSharp.Metar.Parse
{
    internal class ParseFromKilometer
    {
        internal static Visibility ParseVisibility(GroupCollection groups, MetarParser? parser)
        {
            var visibility = new Visibility();

            visibility.VisibilityRaw = groups[7].Value;

            visibility.IsVisibilityMeasurable = true;

            visibility.ReportedVisibility = Math.Round(double.Parse(groups[8].Value), 2);

            visibility.VisibilityUnit = VisibilityUnit.Kilometers;
            visibility.VisibilityUnitRaw = DistanceDefinitions.KilometerShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.KilometerLong;

            if (parser?.VisibilityUnit is not null)
            {
                var visUnit = (VisibilityUnit)parser.VisibilityUnit;

                visibility.VisibilityUnit = visUnit;
                (visibility.VisibilityUnitRaw, visibility.VisibilityUnitDecoded) = visUnit switch
                {
                    VisibilityUnit.Kilometers => (DistanceDefinitions.KilometerShort, DistanceDefinitions.KilometerLong),
                    VisibilityUnit.Miles => (DistanceDefinitions.MileShort, DistanceDefinitions.MileLong),
                    VisibilityUnit.Meters => (DistanceDefinitions.MeterShort, DistanceDefinitions.MeterLong),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            if (groups[13].Success)
            {
                visibility.HasVisibilityLowestValue = true;
                visibility.LowestVisibility = Math.Round(double.Parse(groups[14].Value), 2);
                (
                    visibility.LowestVisibilityDirection,
                    visibility.LowestVisibilityDirectionDecoded
                ) = GetCardinalDirection.Get(groups[15].Value);
                visibility.LowestVisibilityDirectionRaw = groups[15].Value;
            }

            return visibility;
        }
    }
}
