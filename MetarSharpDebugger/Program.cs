using MetarSharp;
using MetarSharp.Definitions;
using MetarSharp.Extensions;
using MetarSharp.Converter;
using MetarSharp.Downloader;
using System.Diagnostics;
using MetarSharp.Converter.Time;
using System.Reflection;
using MetarSharp.Converter.Distance;
using System.Text;

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

            var stringBuilder = new StringBuilder();

            metars
                //.Where(x => x.Trends != null && x.Trends.Any(x => x.TrendType != TrendType.NoSignificantChange))
                //.ToList()
                //.Where(x => x.Trends.Any(x => x.TrendList.Count > 3))
                .Where(x => x.RunwayVisibilities.Count > 1)
                .Take(10)
                .Select(x => x.ReadableReport)
                .ToList()
                .ForEach(x => stringBuilder.AppendLine(x).AppendLine());

            File.WriteAllText("../ReadableReports.txt", "");
            File.WriteAllText("../ReadableReports.txt", stringBuilder.ToString());

            ///Just for diagnostics/to check execution time
            timer.Stop();
            var executeTime = timer.ElapsedMilliseconds;
            var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}
