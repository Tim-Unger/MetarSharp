using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.ParseOptions;
using MetarSharp.Extensions;
using ValueType = MetarSharp.Extensions.ValueType;

namespace MetarSharpDebugger;

internal class Program
{
    static async Task Main(string[] args)
    {
        ///Just for diagnostics
        var timer = new Stopwatch();
        timer.Start();

        //You can enter your metars here

        MetarDefinition.Edit(Definitions.MeterLong, "Test");
        timer.Stop();

        var lines = File.ReadAllLines("../Metars.txt");
        List<Metar> metars = new();

        foreach(var line in lines)
        {
            Metar metar = ParseMetar.ParseFromString(line);
            metars.Add(metar);
        }

        var timeSince = TimeSinceMetar.GetTimeSinceMetar(metars.First(), ReturnType.FullString, UnitReturnType.AllUnits);
        //dynamic highestcolorcode = ValueRecords.GetLowestValue(metars, ValueType.Wind);
        var av = ValueRecords.GetAverageValue(metars, AverageValueType.CloudCeiling, 2);
        var lo = ValueRecords.GetLowestValue(metars, ValueType.Visibility);
        var gustCount = metars.Where(x => x.Wind.IsWindGusting).ToList().ConvertAll(y => y.Wind.WindRaw);

        ///Just for diagnostics/to check execution time 
        var executeTime = timer.ElapsedMilliseconds;
        var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
    }
}


