using System;
using System.Text.RegularExpressions;
using MetarSharp;

namespace MetarSharpDebugger;

internal class Program
{
    public class RawMetarString
    {
        public static string RawMetar { get; set; }

        public static string RestOfMetar { get; set; }
    }
    static void Main(string[] args)
    {
        RawMetarString.RawMetar  = "KAUS 092135Z 26018G35KT 090V180 8SM -TSRA BR SCT045CB BKN060 OVC080 30/21 A2992 RMK FQT";

        Regex ReportingTimeRegex = new Regex(@"(Q|A)([0-9]{4})", RegexOptions.None);

        MatchCollection Matches = ReportingTimeRegex.Matches(RawMetarString.RawMetar);

        var Groups = Matches[0].Groups;
        string PressureWithDecimal = Groups[2].Value.Substring(0, 2) + "." + Groups[2].Value.Substring(2, 2);

        if (double.TryParse(Groups[2].Value.Substring(0, 2) + "." + Groups[2].Value.Substring(2, 2), out double AltimeterWithDecimal))
        {
            string st = AltimeterWithDecimal.ToString();
            double QNH = AltimeterWithDecimal * 33.87;
            int test = Convert.ToInt32(Math.Round(QNH, 0));
        }

    }
}


