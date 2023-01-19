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
using MetarSharp.Methods.Convert.Pressure;
using MetarSharp.Methods.Convert.Temperature;
using MetarSharp.Methods.Convert.Speed;
using MetarSharp.Methods.Convert.Time;

namespace MetarSharpDebugger {

    internal class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable IDE0059

            ///Just for diagnostics
            var timer = new Stopwatch();
            timer.Start();

            //You can enter your metars here

            MetarDefinition.Edit(Definitions.MeterLong, "Test");
            timer.Stop();

            var lines = File.ReadAllLines("../Metars.txt");
            List<Metar> metars = new();

            var link = ParseMetar.FromLink("https://metar.vatsim.net/eddf");
            foreach (var line in lines)
            {
                Metar metar = ParseMetar.FromString(line);
                metars.Add(metar);
            }

            var timeSince = TimeSinceMetar.GetTimeSinceMetar(metars.First(), ReturnType.FullString, UnitReturnType.AllUnits);
            //dynamic highestcolorcode = ValueRecords.GetLowestValue(metars, ValueType.Wind);
            var av = ValueRecords.GetAverageValue(metars, AverageValueType.CloudCeiling, 2);
            var lo = ValueRecords.GetMedianValue(metars, AverageValueType.PressureQNH, MidpointRounding.AwayFromZero);
            var conv = ConvertFromYears.ToMilliseconds(300);
    
            ///Just for diagnostics/to check execution time 
            var executeTime = timer.ElapsedMilliseconds;
            var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}

