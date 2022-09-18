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

                if (Groups[1].Value == "A")
                {
                    pressure.PressureType = "Altimeter/Inches Mercury";
                    pressure.PressureTypeRaw = "A";

                    if (int.TryParse(Groups[2].Value, out int Pressure))
                    {
                        pressure.PressureOnly = Pressure;
                        pressure.PressureAsAltimeter = Pressure;

                        if (
                            double.TryParse(
                                Groups[2].Value.Substring(0, 2)
                                    + "."
                                    + Groups[2].Value.Substring(2, 2),
                                out double AltimeterWithDecimal
                            )
                        )
                        {
                            pressure.PressureWithSeperator = AltimeterWithDecimal.ToString();
                            double QNH = AltimeterWithDecimal * 33.87;
                            pressure.PressureAsQnh = Convert.ToInt32(Math.Round(QNH, 0));
                        }
                    }
                }

                if (Groups[1].Value == "Q")
                {
                    pressure.PressureType = "QNH/Hectopascal";
                    pressure.PressureTypeRaw = "QNH";

                    if (int.TryParse(Groups[2].Value, out int Pressure))
                    {
                        pressure.PressureOnly = Pressure;
                        pressure.PressureAsQnh = Pressure;

                        double AltimeterUnrounded = Pressure / 33.87;

                        pressure.PressureAsAltimeter = Convert.ToInt32(
                            Math.Round(AltimeterUnrounded, 0)
                        );
                    }
                }
            }

            return pressure;
        }
    }
}
