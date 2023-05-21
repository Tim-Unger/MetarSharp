using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.Extensions;
using MetarSharp.Converter;
using MetarSharp.Downloader;
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

            var metar = ParseMetar.FromString(DownloadMetar.FromVatsimSingle("EDDF"));

            ///Just for diagnostics/to check execution time 
            timer.Stop();
            var executeTime = timer.ElapsedMilliseconds;
            var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}

