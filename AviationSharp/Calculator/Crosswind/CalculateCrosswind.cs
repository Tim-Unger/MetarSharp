using AviationSharp.Metar;

namespace AviationSharp.Calculator
{
    public partial class Crosswind
    {
        //TODO gust

        public static Crosswind Calculate(int runway, int windDirection, int windSpeed) =>
            CalculateCrosswind.Calculate(runway, windDirection, windSpeed);

        public static Crosswind Calculate(Runway runway, int windDirection, int windSpeed) =>
            CalculateCrosswind.Calculate(
                runway.TrueHeading ?? throw new Exception(),
                windDirection,
                windSpeed
            );

        public static Crosswind Calculate(int runway, Wind wind) =>
            CalculateCrosswind.Calculate(
                runway,
                wind.WindDirection ?? throw new Exception(),
                wind.WindStrength ?? throw new Exception()
            );
    }
}
