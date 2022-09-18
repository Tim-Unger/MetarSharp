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

        Regex ReportingTimeRegex = new Regex(@"([0-9]{3})([0-9]{1,2})((G)?(?:([0-9]{1,3})))([A-Z]{2,3})(?( (?:(([0-9]{3})V([0-9]{3})))))", RegexOptions.None);

        MatchCollection Matches = ReportingTimeRegex.Matches(RawMetarString.RawMetar);

        var Groups = Matches[0].Groups;



        Wind MetarWind = MetarSharp.Parse.ParseWind.ReturnWind("KAUS 092135Z 26018G35KT 090V180 8SM -TSRA BR SCT045CB BKN060 OVC080 30/21 A2992 RMK FQT");

        var winddirection = MetarWind.WindDirection;
    }
}


