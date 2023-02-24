﻿using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.Extensions;
using MetarSharp.Methods.Convert.Time;
using MetarSharp.Methods.Download;
using System.Diagnostics;
#pragma warning disable IDE0059

namespace MetarSharpDebugger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///Just for diagnostics
            var timer = new Stopwatch();
            timer.Start();

            //You can enter your metars here
            var lines = File.ReadAllLines("../Metars.txt");
            List<Metar> metars = new();

            foreach (var line in lines)
            {
                Metar metar = ParseMetar.FromString(line);
                metars.Add(metar);
            }

            var strings = DownloadMetar.FromAviationWeather("eddf", 5);
            var timeSince = TimeSinceMetar.GetTimeSinceMetar(metars.First(), ReturnType.FullString, UnitReturnType.AllUnits);
            var av = ValueRecords.GetAverageValue(metars, AverageValueType.CloudCeiling, 2);
            var lo = ValueRecords.GetMedianValue(metars, AverageValueType.PressureQNH, MidpointRounding.AwayFromZero);
            var conv = ConvertFromYears.ToMilliseconds(300);
            var metString = ParseMetar.ToStringList(metars);

            ///Just for diagnostics/to check execution time 
            timer.Stop();
            var executeTime = timer.ElapsedMilliseconds;
            var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}

