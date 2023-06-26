using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;

namespace MetarSharp.Benchmarks;

public class Benchmarks
{
    private static readonly List<string> _metars = Enumerable.Repeat(
                "LFSB 221730Z AUTO 21021G62KT 160V240 0700 R15/1400U R33/1600U +TSRA FG FEW004/// SCT010/// BKN020/// ///CB 15/15 Q1018 TEMPO VRB15G30KT 2000 TSRA ",
                2500).ToList();

    private static readonly string _metar = _metars.First();

    //[Benchmark]
    public void ParseMetarsEach()
    {
        _ = _metars.Select(ParseMetar.FromString).ToList();
    }

    //[Benchmark]
    public void ParseMetarsAll()
    {
        _ = ParseMetar.FromList(_metars);
    }

    //[Benchmark]
    public void ParseMetarsParallel()
    {
        _ = ParseMetar.FromListParallel(_metars);
    }

    [Benchmark]
    public void JustAdditional()
    {
        _ = ParseMetar.SingleItem.JustAdditionalInformation(_metar);
    }

    [Benchmark]
    public void JustAirport()
    {
        _ = ParseMetar.SingleItem.JustAirport(_metar);
    }

    [Benchmark]
    public void JustAuto()
    {
        _ = ParseMetar.SingleItem.JustIsAuto(_metar);
    }

    [Benchmark]
    public void JustClouds() 
    {
        _ = ParseMetar.SingleItem.JustClouds(_metar);
    }

    [Benchmark]
    public void JustPressure()
    {
        _ = ParseMetar.SingleItem.JustPressure(_metar);
    }

    [Benchmark]
    public void JustReadableReport()
    {
        _ = ParseMetar.SingleItem.JustReadableReport(_metar);
    }

    [Benchmark]
    public void JustReportingTime()
    {
        _ = ParseMetar.SingleItem.JustReportingTime(_metar);
    }

    [Benchmark]
    public void JustRVR()
    {
        _ = ParseMetar.SingleItem.JustRVR(_metar);
    }

    [Benchmark]
    public void JustTemperature()
    {
        _ = ParseMetar.SingleItem.JustTemperature(_metar);
    }

    [Benchmark]
    public void JustVisibility()
    {
        _ = ParseMetar.SingleItem.JustVisibility(_metar);
    }

    [Benchmark]
    public void JustWeather()
    {
        _ = ParseMetar.SingleItem.JustWeather(_metar);
    }

    [Benchmark]
    public void JustWind()
    {
        _ = ParseMetar.SingleItem.JustWind(_metar);
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
