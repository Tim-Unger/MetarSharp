using MetarSharp;
using MetarSharp.Downloader;
using System.Diagnostics;
using System.Text;
using MetarSharp.Taf;
using MetarSharp.Taf.Parser;

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
            var metars = ParseMetar.FromListParallel(lines);

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


            var taf = ParseTaf.FromString("KXYZ 051730Z 0518/0624 31008KT 3SM - SHRA BKN020 FM052300 30006KT 5SM - SHRA OVC030 PROB30 0604/0606 VRB20G35KT 1SM TSRA BKN015CB FM060600 25010KT 4SM - SHRA OVC050 TEMPO 0608/0611 2SM - SHRA OVC030 RMK NXT FCST BY 00Z = ");
            ///Just for diagnostics/to check execution time
            //timer.Stop();
            //var executeTime = timer.ElapsedMilliseconds;
            //var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
        }
    }
}
