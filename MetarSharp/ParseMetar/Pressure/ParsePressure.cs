using AviationSharp.Converter.Pressure;

namespace MetarSharp.Parse
{
    internal class ParsePressure
    {
        private static readonly Regex _pressureRegex = new(@"(Q|A)([0-9]{4}|////)");

        /// <summary>
        /// this returns the pressure part of the metar
        /// the pressure element always has to be present in the metar, even if not measurable
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        internal static Pressure ReturnPressure(string raw, MetarParser? parser)
        {
            var pressure = new Pressure();

            MatchCollection pressureMatches = _pressureRegex.Matches(raw);

            if (pressureMatches.Count == 0)
            {
                pressure.IsPressureMeasurable = false;
                return pressure;
            }

            pressure.PressureRaw = pressureMatches[0].ToString();
            pressure.IsPressureMeasurable = true;

            var groups = pressureMatches[0].Groups;

            if (groups[2].Value == "////")
            {
                pressure.IsPressureMeasurable = false;
                return pressure;
            }

            pressure.IsPressureMeasurable = true;

            (pressure.PressureTypeString, pressure.PressureType) = groups[1].Value switch
            {
                "A" => (PressureDefinitions.InchesMercuryLong, PressureType.InchesMercury),
                "Q" => (PressureDefinitions.HectopascalsLong, PressureType.Hectopascal),
                _ => throw new ParseException("Pressure Type could not be converted")
            };

            var pressureTypeRaw = groups[1].Value == "A" ? PressureDefinitions.InchesMercuryShort : PressureDefinitions.HectopascalsShort;
            pressure.PressureTypeRaw = pressureTypeRaw;

            if (parser?.PressureType is not null)
            {
                pressure.PressureType = parser.PressureType;
                (pressure.PressureTypeRaw, pressure.PressureTypeString) = parser.PressureType switch
                {
                    PressureType.Hectopascal => (PressureDefinitions.InchesMercuryShort, PressureDefinitions.InchesMercuryLong),
                    PressureType.InchesMercury => (PressureDefinitions.HectopascalsShort, PressureDefinitions.HectopascalsLong),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            var pressureValue = double.TryParse(groups[2].Value, out var pressureVal)
             ? pressureVal
             : 0;

            //Divides the pressure by 100 to get the correct inHG value
            //(the regex will return 2992 without a separator, so the division is necessary)
            //so 2992 will become 29.92 and be correct
            if (pressure.PressureType == PressureType.InchesMercury)
            {
                pressureValue /= 100;
            }
           
            pressure.PressureOnly = pressureValue;
            pressure.PressureAsAltimeter = Convert.ToDouble(
                Math.Round(pressureTypeRaw == PressureDefinitions.InchesMercuryShort ? pressureValue : (double)ConvertFromHectopascals.ToInchesMercury(pressureValue), 2)
            );
            pressure.PressureAsQnh = Convert.ToInt32(
                Math.Round(pressureTypeRaw == PressureDefinitions.HectopascalsShort ? pressureValue : (double)ConvertFromInchesMercury.ToHectopascals(pressureValue))
            );
            
            return pressure;
        }
    }

    public class ParsePressureOnly
    {
        public static Pressure FromString(string raw) => ParsePressure.ReturnPressure(raw, null);
    }
}
