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
        RawMetarString.RawMetar  = "KAUS 092135Z 26018G35KT 090V180 R29L/M0900VP1800D 8SM 1500S -TSRA BR CAVOK  SCT045CB BKN060 OVC080 30/21 A2992 RMK FQT";

        Regex ReportingTimeRegex = new Regex(@"^([A-Z]{4})\s", RegexOptions.None);

        MatchCollection Matches = ReportingTimeRegex.Matches(RawMetarString.RawMetar);

        var Groups = Matches[0].Groups;
        Metar Metar = ParseMetar.ParseFromString("KAUS 092135Z 26018G35KT 090V180 R29L/M0900VP1800D 8SM 1500S -TSRA BR CAVOK  SCT045CB BKN060 OVC080 30/21 A2992 RMK FQT");
        string Readablereport = Metar.ReadableReport;
    }
}


