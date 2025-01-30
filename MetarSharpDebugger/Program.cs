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
            var lines = File.ReadAllLines("../metars.txt").ToList();
            var metars = ParseMetar.FromList(lines);
            //You can enter your metars here
            var metar = @"EGLL 202124Z AUTO 27009KT 1 1/4SM BR BKN016 BKN038 22/21 A3018 RMK AO2".ConvertMetarToJson();
        }
    }
}
