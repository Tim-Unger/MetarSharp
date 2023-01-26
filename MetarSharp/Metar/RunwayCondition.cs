namespace MetarSharp
{
    public enum Condition
    {
        ClearAndDry,
        Damp,
        Wet,
        Frost,
        DrySnow,
        WetSnow,
        Slush,
        Ice,
        CompactedSnow,
        FrozenRidges,
        Unknown
    }
    public class RunwayCondition
    {
        public string? RunwayConditionRaw { get; set; }
        public Condition Condition { get; set; } = Condition.ClearAndDry;
    }
}
