namespace MetarSharp
{
    public enum TrendType
    {
        NoSignificantChange,
        Becoming,
        Tempo,
        NoSignificantWeather
    }
    
    public enum TimeRestrictionType
    {
        From,
        Until,
        At
    }

    public class Trend
    {
        //TODO move NOSIG
        //public bool IsNOSIG { get; set; }
        public string? TrendRaw { get; set; }
        public TrendType? TrendType { get; set; }
        public string? TrendTypeRaw { get; set; }
        public string? TrendTypeDecoded { get; set; }
        public bool IsTimeRestricted { get; set; }
        public string? TimeRestrictionRaw { get; set; }
        public TimeRestrictionType? TimeRestrictionType { get; set; }
        public int? TimeRestriction { get; set; }
        public DateTime? TimeRestrictionDateTime { get; set; }
        public List<object>? TrendList { get; set; }
        public string? TrendDecoded { get; set; }
    }
}
