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
        //Regex ReportingTimeRegex = new Regex(@"^([A-Z]{4})\s", RegexOptions.None);

        //MatchCollection Matches = ReportingTimeRegex.Matches(RawMetarString.RawMetar);

        //var Groups = Matches[0].Groups;
        Metar Metar = ParseMetar.ParseFromString("KCOU 182054Z 18011KT 10SM VCTS FEW031 FEW055 BKN120 25/22 A2995 WS R25 RESN BLU RMK HALLO");

        string Readablereport = Metar.ReadableReport;
    }
}


