using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MetarSharp.Converter;
using MetarSharp.Converter.Distance;
using MetarSharp.Converter.Pressure;
using MetarSharp.Converter.Speed;
using MetarSharp.Converter.Temperature;
using MetarSharp.Converter.Time;
using MetarSharp.Downloader;

namespace MetarSharp.Benchmarks;

public class BenchMarks
{
    private static List<string> Metars { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var largeList =
            Enumerable.Repeat(
                "KSKX 091200Z AUTO 29015G23KT 10SM CLR 00/M16 A2994 RMK AO2 PK WND 30028/2211 SLP149 T00001161 FZRANO BLU",
                10000).ToList();
        //var lines = File.ReadAllLines("../Metars.txt");
        Metars = largeList;
    }

    [Benchmark]
    public void ParseMetarsEach()
    {
        var parse = Metars.Select(ParseMetar.FromString).ToList();
    }

    [Benchmark]
    public void ParseMetarsAll()
    {
        _ = ParseMetar.FromList(Metars);
    }

    [Benchmark]
    public void ParseMetarsForEach()
    {
        List<Metar> metarList = new();

        Metars.ForEach(x => metarList.Add(ParseMetar.FromString(x)));
    }

    [Benchmark]
    public void ParseSingleMetar()
    {
        var rand = new Random(42069).Next(0, Metars.Count);
            
        _ = ParseMetar.FromString(Metars[rand]);
    }

    [Benchmark]
    public void ConvertDistance()
    {
        _ = ConvertFromKilometer.ToMeter(1000);
    }

    [Benchmark]
    public void ConvertPressure()
    {
        _ = ConvertFromHectopascals.ToInchesMercury(1035);
    }

    [Benchmark]
    public void ConvertSpeed()
    {
        _ = ConvertFromMetersPerSecond.ToKilometersPerHour(500);
    }

    [Benchmark]
    public void ConvertTemperature()
    {
        _ = ConvertFromFahrenheit.ToCelsius(46);
    }

    [Benchmark]
    public void ConvertTime()
    {
        _ = ConvertFromSeconds.ToWeeks(10000);
    }

    [Benchmark]
    public void DownloadFromVatsimSingle()
    {
       _ = DownloadMetar.FromVatsimSingle("eddf");
    }

    [Benchmark]
    public void DownloadFromVatsimMultiple()
    {
        _ = DownloadMetar.FromVatsimMultiple("e");
    }

    [Benchmark]
    public void DownloadFromAvWeatherWithHours()
    {
        _ = DownloadMetar.FromAviationWeather("eddf");
    }

    [Benchmark]
    public void DownloadFromAvWeatherWithoutHours()
    {
        _ = DownloadMetar.FromAviationWeather("eddf", 10);
    }

}

public class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchMarks>();

        Console.WriteLine(summary);
    }
}
