namespace AviationSharp.Calculator
{
    public partial class Crosswind
    {
       public int Runway { get; set; }
        public int RunwayHeading { get; set; }
        public int WindDirection { get; set; }
        public int WindSpeed { get; set;}
        public int HeadwindComponent { get; set; }
        public string CrosswindDirection { get; set; }
        public int CrosswindComponent { get; set; }
    }
}
