using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MetarSharp.Benchmarks;

public class BenchMarks
{
    private static List<string> metars { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var largeList =
            Enumerable.Repeat(
                "KSKX 091200Z AUTO 29015G23KT 10SM CLR 00/M16 A2994 RMK AO2 PK WND 30028/2211 SLP149 T00001161 FZRANO BLU",
                10000).ToList();
        //var lines = File.ReadAllLines("../Metars.txt");
        metars = largeList;
    }

    [Benchmark]
    public void ParseMetarsEach()
    {
        var parse = metars.Select(x => ParseMetar.FromString(x)).ToList();
    }

    [Benchmark]
    public void ParseMetarsAll()
    {
        var parse = ParseMetar.FromList(metars);
    }

    [Benchmark]
    public void ParseMetarsForEach()
    {
        List<Metar> metarList = new();
        
        foreach (var metar in metars)
        {
            metarList.Add(ParseMetar.FromString(metar));
        }
    }

    [Benchmark]
    public void ParseSingleMetar()
    {
        var rand = new Random(42069).Next(0, metars.Count);

        var parse = ParseMetar.FromString(metars[rand]);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchMarks>();
    }
}
