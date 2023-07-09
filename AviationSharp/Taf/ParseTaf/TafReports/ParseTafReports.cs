using static AviationSharp.Metar.Extensions.TryParseExtensions;
using AviationSharp.Metar.Parse;

namespace AviationSharp.Taf.Parse
{
    internal class ParseTafReports
    {
        private static readonly Regex _reportsRegex = new("(PROB(?>[0-9]{1,3}))|(FM(?>[0-9]{2}[0-9]{4})|BCMG|TEMPO)(.*)(?!)(PROB(?>[0-9]{1,3}))|(FM(?>[0-9]{2}[0-9]{4})|BCMG|TEMPO|RMK)");

        internal static List<TafReport> ReturnTafReports(string raw)
        {
            var splits = CombineSplits(_reportsRegex.Split(raw).ToList());

            return splits.Skip(1).Select(x => ParseReport(x)).ToList();
        }

        private static List<string> CombineSplits(List<string> splits)
        {
            var combinedSplits = new List<string>
            {
                splits.First()
            };

            splits.Remove(splits.First());

            for (var i = 0; i < splits.Count - 1; i += 2)
            {
                combinedSplits.Add(string.Concat(splits[i], splits[i+1]));
            }

            if(combinedSplits.Last().StartsWith("RMK"))
            {
                combinedSplits.Remove(combinedSplits.Last());
            }

            return combinedSplits;
        }

        private static TafReport ParseReport(string raw)
        {
            var report = new TafReport();

            report.HasProbability = false;

            var probabilityRegex = new Regex("PROB([0-9]{1,3})");
            if (probabilityRegex.IsMatch(raw))
            {
                var probability = IntTryParseWithThrow(probabilityRegex.Match(raw).Groups[1].Value);

                if(probability > 100)
                {
                    //Just to be sure
                    throw new ArgumentOutOfRangeException();
                }

                report.HasProbability = true;
                report.TafProbability = probability;
            }

            report.TafTimeSpan = TafTimeSpan.Parse(raw) ?? null;

            report.Wind = ParseWindOnly.FromString(raw) ?? null;

            report.Visibility = ParseVisibilityOnly.FromString(raw) ?? null;

            report.Weather = ParseWeatherOnly.FromString(raw) ?? null;

            report.Clouds = ParseCloudsOnly.FromString(raw) ?? null;

            report.Temperature = ParseTemperatureOnly.FromString(raw) ?? null;

            report.Pressure = ParsePressureOnly.FromString(raw) ?? null;

            return report;
        }
    }
}
