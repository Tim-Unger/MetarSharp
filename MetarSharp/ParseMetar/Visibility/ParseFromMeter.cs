using static MetarSharp.Parse.ParseVisibility;
namespace MetarSharp.Parse
{
    internal class ParseFromMeter
    {
        internal static Visibility ParseVisibility(Visibility visibility, GroupCollection groups, MetarParser? parser)
        {
            visibility.VisibilityRaw = groups[1].Value.TrimStart();

            visibility.ReportedVisibility = Math.Round(double.Parse(groups[3].Value), 2);

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
                visibility.LowestVisibility = Math.Round(double.Parse(groups[5].Value), 2);
                (
                    visibility.LowestVisibilityDirection,
                    visibility.LowestVisibilityDirectionDecoded
                ) = GetCardinalDirection.Get(groups[6].Value);

            }

            return visibility;
        }
    }
}
