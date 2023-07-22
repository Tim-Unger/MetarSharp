using AviationSharp.Metar;

namespace AviationSharp.Calculator
{
    public partial class Crosswind
    {
        public int Runway { get; set; }
        public int RunwayHeading { get; set; }
        public int WindDirection { get; set; }
        public double WindSpeed { get; set;}
        public double HeadwindComponent { get; set; }
        public CardinalDirection CrosswindDirection { get; set; }
        public double CrosswindComponent { get; set; }
    }
}
