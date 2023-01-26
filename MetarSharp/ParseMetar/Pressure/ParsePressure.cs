using MetarSharp.Definitions;
using MetarSharp.Exceptions;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    public class ParsePressure
    {
        /// <summary>
        /// this returns the pressure part of the metar
        /// the pressure element always has to be present in the metar, even if not measurable
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        /// <exception cref="ParseException"></exception>
        public static Pressure ReturnPressure(string raw)
        {
            Pressure pressure = new Pressure();

            Regex pressureRegex = new Regex(@"(Q|A)([0-9]{4}|////)", RegexOptions.None);

            MatchCollection pressureMatches = pressureRegex.Matches(raw);

            if (pressureMatches.Count == 0)
            {
                pressure.IsPressureMeasurable = false;
                return pressure;
                //throw new ParseException("Could not find Pressure");
            }

            pressure.PressureRaw = pressureMatches[0].ToString();
            pressure.IsPressureMeasurable = true;

            GroupCollection groups = pressureMatches[0].Groups;

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

            string pressureTypeRaw = groups[1].Value == "A" ? PressureDefinitions.InchesMercuryShort : PressureDefinitions.HectopascalsShort;
            pressure.PressureTypeRaw = pressureTypeRaw;

            double pressureValue = double.TryParse(groups[2].Value, out double pressureVal)
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
                Math.Round(pressureTypeRaw == PressureDefinitions.InchesMercuryShort ? pressureValue : pressureValue / 33.8569518716, 2)
            );
            pressure.PressureAsQnh = Convert.ToInt32(
                Math.Round(pressureTypeRaw == PressureDefinitions.HectopascalsShort ? pressureValue : pressureValue * 33.8569518716, 0)
            );
            
            return pressure;
        }
    }
}
