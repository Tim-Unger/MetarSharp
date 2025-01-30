namespace MetarSharp.Parse
{
    internal class ParseFromMiles
    {
        internal static Visibility ParseVisibility(Visibility visibility, GroupCollection groups, MetarParser? parser)
        {
            visibility.VisibilityRaw = groups[7].Value;
            visibility.IsVisibilityMeasurable = true;
            
            //Vis is less than 1 Mile (e.g. 1/2 SM)
            var hasVisibilitySlash = false;
            double convertedValue = 0;
            if (groups[8].Value.Contains('/'))
            {
                hasVisibilitySlash = true;

                //Find the fraction in the value
                var fractionRegex = new Regex(@"\d/\d");
                var fractionValue = fractionRegex.Match(groups[10].Value).Value;
                
                var rawValue = groups[10].Value;
                var splitValues = fractionValue.Split('/');
                var firstValue = Math.Round(double.Parse(splitValues[0], NumberStyles.Integer), 2);
                var lastValue = Math.Round(double.Parse(splitValues[1].ToString(), NumberStyles.Integer), 2);

                convertedValue = firstValue / lastValue;

                //If there is a space in the value, the value is larger than 1 (e.g. 1 1/2) so we will add the first value to the converted value
                if (rawValue.Contains(' '))
                {
                    var numberRegex = new Regex(@"^\d\s");
                    
                    var numberValue = numberRegex.Match(rawValue).Value;
                    
                    var number = int.Parse(numberValue);
                    
                    convertedValue += number;
                }
            }

            double reportedVisibility = 0;
            
            if (!hasVisibilitySlash)
            {
                reportedVisibility = int.TryParse(groups[10].Value, out var visParse)
                  ? visParse
                  : throw new ParseException(
                        $"Could not convert Visibility {groups[10].Value} to Number"
                    );
            }

            var reportedVisibilityConverted = hasVisibilitySlash ? convertedValue : reportedVisibility;
            visibility.ReportedVisibility = Math.Round(reportedVisibilityConverted,2);

            var visibilityUnit = groups[15].Value;
            
            visibility.VisibilityUnit = visibilityUnit switch
            {
                "SM" => VisibilityUnit.Miles,
                "KM" => VisibilityUnit.Kilometers,
                _ => throw new ParseException("Could not determine Visibility Unit")
            };
            
            visibility.VisibilityUnitRaw = visibilityUnit switch
            {
                "SM" => DistanceDefinitions.StatuteMileShort,
                "KM" => DistanceDefinitions.KilometerShort,
                _ => throw new ParseException("Could not determine Visibility Unit")
            };
            
            visibility.VisibilityUnitDecoded = visibilityUnit switch
            {
                "SM" => DistanceDefinitions.StatuteMileLong,
                "KM" => DistanceDefinitions.KilometerLong,
                _ => throw new ParseException("Could not determine Visibility Unit")
            };

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

            return visibility;
        }
    }
}
