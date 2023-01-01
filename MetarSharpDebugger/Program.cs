using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MetarSharp;
using MetarSharp.ParseOptions;
using MetarSharp.Parser;

namespace MetarSharpDebugger;

internal class Program
{
    static void Main(string[] args)
    {
        ///Just for diagnostics
        Stopwatch timer = new Stopwatch();
        timer.Start();

        List<string> metars = new List<string>();
        using (StreamReader streamReader = new StreamReader("../Metars.txt"))
        {
            string metarListRaw = streamReader.ReadToEnd();
            metars = metarListRaw.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        };

        //You can enter your metars here
        List<Metar> m = new();
        foreach (var metar in metars)
        {
            Metar metarParsed = ParseMetar.ParseFromString(metar);
            m.Add(metarParsed);
        }
        
        //Metar metar = ParseMetar.ParseFromString("KCOU 182054Z 18011KT 10SM 0050E VCTS FEW031 FEW055 BKN120 25/22 A2995 WS R25 RESN BLU RMK HALLO");
        
        ///Just for diagnostics/to check execution time 
        timer.Stop();
        var executeTime = timer.ElapsedMilliseconds;
    }
}


