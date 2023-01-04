using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
