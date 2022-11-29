using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MetarSharp;
using MetarSharp.ParseOptions;
using MetarSharp.Parser;

namespace MetarSharpDebugger;

internal class Program
{
    public class RawMetarString
    {
        public static string RawMetar { get; set; }

        public static string RestOfMetar { get; set; }
    }
    static async Task Main(string[] args)
    {
        ///Just for diagnostics
        Stopwatch timer = new Stopwatch();
        timer.Start();

        //You can enter your metars here
        Metar metar = ParseMetar.ParseFromString("KCOU 182054Z 18011KT 10SM 0050E VCTS FEW031 FEW055 BKN120 25/22 A2995 WS R25 RESN BLU RMK HALLO");

        ///Just for diagnostics/to check execution time 
        timer.Stop();
        var executeTime = timer.ElapsedMilliseconds;
    }
}


