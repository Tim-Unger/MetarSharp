namespace MetarSharp
{
    public enum Color
    {
        NIL,
        BLUPLUS,
        BLU,
        WHT,
        GRN,
        YLO,
        AMB,
        RED,
        BLACK,
    }
    public class ColorCode
    {
        public Color Color { get; set; }
        public string ColorCodeShort { get; set; }
        public string ColorCodeLong { get; set; }
    }
}
