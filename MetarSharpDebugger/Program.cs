using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.Extensions;
using MetarSharp.Converter;
using MetarSharp.Methods.Download;
using System.Diagnostics;
using MetarSharp.Converter.Time;
using System.Reflection;
using MetarSharp.Converter.Distance;

namespace MetarSharpDebugger
{
    internal class Program
    {
        static void Main()
        {
            ///Just for diagnostics
            var timer = new Stopwatch();
            timer.Start();

            //You can enter your metars here
            var lines = File.ReadAllLines("../Metars.txt").ToList();
            var metars = lines.Select(x => ParseMetar.FromString(x)).ToList();

            MetarDefinition.Edit(Definitions.MileLong, "Mile");
            var timeSince = TimeSinceMetar.GetTimeSinceMetar(metars.First(), ReturnType.FullString, UnitReturnType.AllUnits);
            var av = ValueRecords.GetAverageValue(metars, AverageValueType.CloudCeiling, 2);
            var lo = ValueRecords.GetMedianValue(metars, AverageValueType.PressureQNH, MidpointRounding.AwayFromZero);
            var cc = ValueRecords.GetHighestValue(metars, MetarSharp.Extensions.ValueType.CloudCeiling);
            var conv = ConvertFromKilometer.ToMeter(5);
            List<string> metString = ParseMetar.ToStringList(metars);
            var loco = ValueRecords.GetLowestValue(metars, MetarSharp.Extensions.ValueType.ColorCode);
            var clo = ValueRecords.GetHighestValue(metars, MetarSharp.Extensions.ValueType.CloudCeiling);

            ///Just for diagnostics/to check execution time 
            timer.Stop();
            var executeTime = timer.ElapsedMilliseconds;
            var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}

