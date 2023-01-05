using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp.Definitions;

namespace MetarSharp.Parse
{
    public class ParsePressure
    {
        public static Pressure ReturnPressure(string raw)
        {
            Pressure pressure = new Pressure();

            Regex pressureRegex = new Regex(@"(Q|A)([0-9]{4}|////)", RegexOptions.None);

            MatchCollection pressureMatches = pressureRegex.Matches(raw);

            if (pressureMatches.Count == 0)
            {
                pressure.IsPressureMeasurable = false;
                return pressure;
                //throw new Exception("Could not find Pressure");
            }

            pressure.PressureRaw = pressureMatches[0].ToString();

            GroupCollection groups = pressureMatches[0].Groups;

            if (groups[2].Value == "////")
            {
                pressure.IsPressureMeasurable = false;
                return pressure;
            }

            (pressure.PressureTypeString, pressure.PressureType) = groups[1].Value switch
            {
                "A" => (PressureDefinitions.InchesMercuryLong, PressureType.InchesMercury),
                "Q" => (PressureDefinitions.HectopascalsLong, PressureType.Hectopascal),
                _ => throw new Exception("Pressure Type could not be converted")
            };

            string pressureTypeRaw = groups[1].Value == "A" ? PressureDefinitions.InchesMercuryShort : PressureDefinitions.HectopascalsShort;
            pressure.PressureTypeRaw = pressureTypeRaw;

            int pressureValue = int.TryParse(groups[2].Value, out int _pressureVal)
              ? _pressureVal
              : 0;
            pressure.PressureOnly = pressureValue;
            pressure.PressureAsAltimeter = Convert.ToInt32(
                Math.Round(pressureTypeRaw == PressureDefinitions.InchesMercuryShort ? pressureValue : pressureValue / 33.8569518716, 0)
            );
            pressure.PressureAsQnh = Convert.ToInt32(
                Math.Round(pressureTypeRaw == PressureDefinitions.HectopascalsShort ? pressureValue : pressureValue * 33.8569518716, 0)
            );

            if (pressureTypeRaw == "A")
            {
                string pressureWithSeparatorOne = groups[2].Value.Substring(0, 2) + ".";
                string pressureWithSeparatorTwo = groups[2].Value.Length == 4 ? groups[2].Value.Substring(2, 2) : groups[2].Value.Substring(2, 1) + "0";

                pressure.PressureWithSeperator = pressureWithSeparatorOne + pressureWithSeparatorTwo;
            }

            return pressure;
        }
    }
}
