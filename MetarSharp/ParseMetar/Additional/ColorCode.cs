using System.Text.RegularExpressions;
using MetarSharp.Definitions;

namespace MetarSharp.Parse.Additional
{
    internal class ColorCode
    {
        //Color Code Enum, Color Code short, Color Code long
        internal static (Color, string, string) GetColorCode(GroupCollection groups) => groups[11].Value switch
        {
            "BLU+" => (Color.BLUPLUS, ColorCodeDefinitions.BluePlusShort, ColorCodeDefinitions.BluePlusLong),
            "BLU" => (Color.BLU, ColorCodeDefinitions.BlueShort, ColorCodeDefinitions.BlueLong),
            "WHT" => (Color.WHT, ColorCodeDefinitions.WhiteShort, ColorCodeDefinitions.WhiteLong),
            "GRN" => (Color.GRN, ColorCodeDefinitions.GreenShort, ColorCodeDefinitions.GreenLong),
            "YLO" => (Color.YLO, ColorCodeDefinitions.YellowShort, ColorCodeDefinitions.YellowLong),
            "AMB" => (Color.AMB, ColorCodeDefinitions.AmberShort, ColorCodeDefinitions.AmberLong),
            "RED" => (Color.RED, ColorCodeDefinitions.RedShort, ColorCodeDefinitions.RedLong),
            "BLACK" => (Color.BLACK, ColorCodeDefinitions.BlackShort, ColorCodeDefinitions.BlackLong)
        };
    }
}