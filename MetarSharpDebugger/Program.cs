using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.ParseOptions;

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

        MetarDefinition.Edit(Definitions.MeterLong, "Meta");
        timer.Stop();

        var lines = File.ReadAllLines("../Metars.txt");
        List<Metar> metars = new();

        foreach(var line in lines)
        {
            Metar metar = ParseMetar.ParseFromString(line);
            metars.Add(metar);
        }

        var gustCount = metars.Where(x => x.Wind.IsWindGusting == true).ToList().ConvertAll(y => y.Wind.WindRaw);
        ///Just for diagnostics/to check execution time 
        var executeTime = timer.ElapsedMilliseconds;
        var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
    }
}


