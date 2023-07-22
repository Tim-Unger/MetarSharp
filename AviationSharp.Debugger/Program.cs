using AviationSharp;
using AviationSharp.Airacs;
using AviationSharp.Aircraft;
using AviationSharp.Metar;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace AviationSharpDebugger
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

            //6var airports = SearchAirports.GetAllAirports();

            var info = Information.Get();
            }
    }
}
