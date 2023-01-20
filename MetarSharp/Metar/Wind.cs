namespace MetarSharp
{
    public enum WindUnit
    {
        Knots,
        MilesPerHour,
        MetersPerSecond
    }
    public class Wind
    {
        //The Wind as String (23008KT)
        public string WindRaw { get; set; }
        public bool IsWindMeasurable { get; set; }
        public bool IsWindDirectionMeasurable { get; set; }
        public bool IsWindStrengthMeasurable { get; set; }
        public bool IsWindCalm { get; set; }
        //The Wind Direction (230)
        public int? WindDirection { get; set; }
        //The Wind Strength (3)
        public int? WindStrength { get; set; }
        //The Wind Unit (KT)
        public string WindUnitRaw { get; set; }
        public string WindUnitDecoded { get; set; }
        public WindUnit WindUnit { get; set; }
        //Whether there are Wind Gusts
        public bool IsWindGusting { get; set; }
        //Strength of the Wind Gusts (10)
        public int? WindGusts { get; set; }
        //Whether the Wind is VRB (true)
        public bool IsWindVariable { get; set; }
        public bool IsWindDirectionVarying { get; set; }
        public string? WindDirectionVariationRaw { get; set; }
        //The lowest direction of the Wind
        public int? WindVariationLow { get; set; }
        //The highest direction of the Wind
        public int? WindVariationHigh { get; set; }
    }
}
