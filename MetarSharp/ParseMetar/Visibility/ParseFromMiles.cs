namespace MetarSharp.Parse
{
    internal class ParseFromMiles
    {
        internal static Visibility ParseVisibility(GroupCollection groups)
        {
            var visibility = new Visibility()
            {
                VisibilityRaw = groups[7].Value,

                IsVisibilityMeasurable = true
            };

            //Vis is less than 1 Mile (1/2 SM)
            var hasVisibilitySlash = false;
            double convertedValue = 0;
            if (groups[8].Value.Contains('/'))
            {
                var indexNegative = groups[10].Success ? 1 : 0;
                hasVisibilitySlash = true;

                var valueArray = groups[8].Value.ToCharArray();
                var firstValue = Math.Round(double.Parse(valueArray[indexNegative].ToString()), 2);
                var lastValue = Math.Round(double.Parse(valueArray.Last().ToString()), 2);

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
                reportedVisibility = int.TryParse(groups[8].Value, out var visParse)
                  ? visParse
                  : throw new ParseException(
                        $"Could not convert Visibility {groups[8].Value} to Number"
                    );
            }

            var reportedVisibilityConverted = hasVisibilitySlash ? convertedValue : reportedVisibility;
            visibility.ReportedVisibility = Math.Round(reportedVisibilityConverted,2);

            visibility.VisibilityUnit = VisibilityUnit.Miles;
            visibility.VisibilityUnitRaw = DistanceDefinitions.StatuteMileShort;
            visibility.VisibilityUnitDecoded = DistanceDefinitions.StatuteMileLong;

            return visibility;
        }
    }
}
