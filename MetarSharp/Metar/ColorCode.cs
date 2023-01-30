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
        public Color Color { get; set; } = Color.NIL;

        public string ColorCodeShort { get; set; } = "NIL";

        public string ColorCodeLong { get; set; } = "Nil";
    }
}
