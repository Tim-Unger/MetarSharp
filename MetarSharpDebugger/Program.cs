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

        var lines = File.ReadAllLines("../Metars.txt");
        List<Metar> metars = new();

        foreach(var line in lines)
        {
            Metar metar = ParseMetar.ParseFromString(line);
            metars.Add(metar);
        }

        ///Just for diagnostics/to check execution time 
        timer.Stop();
        var executeTime = timer.ElapsedMilliseconds;
        var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
    }
}


