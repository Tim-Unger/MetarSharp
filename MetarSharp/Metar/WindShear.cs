namespace MetarSharp
{
    public class WindShear
    {
        public string WindShearRaw { get; set; } = "None";

        public bool IsAllRunways { get; set; }

        public int? Runway { get; set; }
    }
}
