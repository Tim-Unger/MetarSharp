namespace AviationSharp.Metar.Parse
{
    internal class ParseFromMeter
    {
        internal static Visibility ParseVisibility(GroupCollection groups, MetarParser? parser)
        {
            var visibility = new Visibility();

            visibility.VisibilityRaw = groups[1].Value.TrimStart();

            visibility.ReportedVisibility = Math.Round(double.Parse(groups[2].Value), 2);

            visibility.IsVisibilityMeasurable = true;
            
            visibility.VisibilityUnit = VisibilityUnit.Meters;
            visibility.VisibilityUnitRaw = DistanceDefinitions.MeterShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.MeterLong;

            if(parser?.VisibilityUnit is not null)
            {
                var visUnit = (VisibilityUnit)parser.VisibilityUnit;

                visibility.VisibilityUnit = visUnit;
                (visibility.VisibilityUnitRaw, visibility.VisibilityUnitDecoded) = visUnit switch
                {
                    VisibilityUnit.Kilometers => (DistanceDefinitions.KilometerShort,  DistanceDefinitions.KilometerLong),
                    VisibilityUnit.Miles => (DistanceDefinitions.MileShort, DistanceDefinitions.MileLong),
                    VisibilityUnit.Meters => (DistanceDefinitions.MeterShort, DistanceDefinitions.MeterLong),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

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
