using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MetarSharp.Methods;
using MetarSharp.Methods.Convert.Distance;
using MetarSharp.Methods.Convert.Pressure;
using MetarSharp.Methods.Convert.Speed;
using MetarSharp.Methods.Convert.Temperature;
using MetarSharp.Methods.Convert.Time;
using MetarSharp.Methods.Download;

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

    [Benchmark]
    public void ConvertDistance()
    {
        var distance = ConvertFromKilometer.ToMeter(1000);
    }

    [Benchmark]
    public void ConvertPressure()
    {
        var pressure = ConvertFromHectopascals.ToInchesMercury(1035);
    }

    [Benchmark]
    public void ConvertSpeed()
    {
        var speed = ConvertFromMetersPerSecond.ToKilometersPerHour(500);
    }

    [Benchmark]
    public void ConvertTemperature()
    {
        var temperature = ConvertFromFahrenheit.ToCelsius(46);
    }

    [Benchmark]
    public void ConvertTime()
    {
        var time = ConvertFromSeconds.ToWeeks(10000);
    }

    [Benchmark]
    public void DownloadFromVatsimSingle()
    {
        var download = DownloadMetar.FromVatsimSingle("eddf");
    }

    [Benchmark]
    public void DownloadFromVatsimMultiple()
    {
        var download = DownloadMetar.FromVatsimMultiple("e");
    }

    [Benchmark]
    public void DownloadFromAvWeatherWithHours()
    {
        var download = DownloadMetar.FromAviationWeather("eddf");
    }

    [Benchmark]
    public void DownloadFromAvWeatherWithoutHours()
    {
        var download = DownloadMetar.FromAviationWeather("eddf", 10);
    }

}

public class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchMarks>();
    }
}
