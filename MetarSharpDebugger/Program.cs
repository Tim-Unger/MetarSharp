using AviationSharp;
using AviationSharp.Airacs;
using AviationSharp.Airports;
using AviationSharp.Calculator;
using AviationSharp.Converter.Height;
using AviationSharp.Metar;
using AviationSharp.NAT;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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

            var metar = @"LFSB 221730Z AUTO 21021G62KT 160V240 0700 R15/1400U R33/1600U +TSRA FG FEW004/// SCT010/// BKN020/// ///CB 15/15 Q1018 TEMPO VRB15G30KT 2000 TSRA ".ConvertMetarToJson();

            var stringBuilder = new StringBuilder();

            File.WriteAllText("../ReadableReports.txt", "");
            File.WriteAllText("../ReadableReports.txt", stringBuilder.ToString());

            using (StreamWriter streamFile = File.CreateText("../MetarJson.txt"))
            {
                streamFile.Write(ParseMetar.ListToSingleJsonString(metars.Take(10)));
            }

            var airports = SearchAirports.GetAllAirports();

            var tracks = Airacs.GetCurrent();

            var cw = Crosswind.Calculate();
            //AviationSharp.Airports.Reader.AirportJson.Write();
            //var taf = ParseTaf.FromString("KXYZ 051730Z 0518/0624 31008KT 3SM - SHRA BKN020 FM052300 30006KT 5SM - SHRA OVC030 PROB30 0604/0606 VRB20G35KT 1SM TSRA BKN015CB BCMG 0417/0503 25010KT 4SM - SHRA OVC050 TEMPO 0608/0611 2SM - SHRA OVC030 RMK NXT FCST BY 00Z = ");

            //var multiple = DownloadMetar.FromVatsimMultipleIcaos("edds", "eddf", "eddm").ParseMetars();

            ///Just for diagnostics/to check execution time
            //timer.Stop();
            //var executeTime = timer.ElapsedMilliseconds;
            //var timerPerMetar = Math.Round((double)executeTime / metars.Count, 5);
            }
    }
}
