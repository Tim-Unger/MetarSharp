using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MetarSharp.Benchmarks;

public class Benchmarks
{
    private static readonly List<string> _metars = Enumerable.Repeat(
                "EDDF 072250Z AUTO 01009KT CAVOK 20/13 Q1016 NOSIG",
                2500).ToList();

    //[Benchmark]
    public void ParseMetarsEach()
    {
        _ = _metars.Select(ParseMetar.FromString).ToList();
    }

    [Benchmark]
    public void ParseMetarsAll()
    {
        _ = ParseMetar.FromList(_metars);
    }

    [Benchmark]
    public void ParseMetarsParallel()
    {
        _ = ParseMetar.FromListParallel(_metars);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmarks>();

        Console.WriteLine(summary);
    }
}
