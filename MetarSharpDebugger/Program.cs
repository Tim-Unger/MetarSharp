using MetarSharp;
using MetarSharp.Downloader;
using System.Diagnostics;
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
            var metars = ParseMetar.FromList(lines);

            var metar = DownloadMetar.FromVatsimSingle("EDDF").Parse();

            var stringBuilder = new StringBuilder();

            metars
                .Where(x => x.RunwayVisibilities != null && x.RunwayVisibilities.Count > 1)
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
