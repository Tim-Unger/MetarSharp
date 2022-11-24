using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParsePressure
    {
        public static Pressure ReturnPressure(string raw)
        {
            Pressure pressure = new Pressure();

            Regex PressureRegex = new Regex(@"(Q|A)([0-9]{4})", RegexOptions.None);

            MatchCollection PressureMatches = PressureRegex.Matches(raw);

            if (PressureMatches.Count == 1)
            {
                pressure.PressureRaw = PressureMatches[0].ToString();

                GroupCollection Groups = PressureMatches[0].Groups;

                pressure.PressureType = Groups[1].Value switch
                {
                    "A" => "Altimeter/Inches Mercury",
                    "Q" => "QNH/Hectopascal",
                    //_ => throw new NullReferenceException()
                };

                string pressureTypeRaw = Groups[1].Value == "A" ? "A" : "QNH";
                pressure.PressureTypeRaw = pressureTypeRaw;

                int pressureValue = int.TryParse(Groups[2].Value, out int _pressureVal) ? _pressureVal : 0;
                pressure.PressureOnly = pressureValue;
                pressure.PressureAsAltimeter = Convert.ToInt32(Math.Round(pressureTypeRaw == "A" ? pressureValue : pressureValue / 33.87,0));
                pressure.PressureAsQnh = Convert.ToInt32(Math.Round(pressureTypeRaw == "QNH" ? pressureValue : pressureValue * 33.87, 0));

                if(pressureTypeRaw == "A")
                {
                    pressure.PressureWithSeperator == double.Parse(Groups[2].Value.Substring(0, 2) + "." + Groups[2].Value.Substring(2, 2);
                }
            }

            return pressure;
        }
    }
}
