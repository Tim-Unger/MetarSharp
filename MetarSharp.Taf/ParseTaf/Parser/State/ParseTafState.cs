using static MetarSharp.Taf.State;

namespace MetarSharp.Taf.Parse
{
    internal class ParseTafState
    {
        internal static TafState? ReturnTafState(string raw) =>
            new Regex("COR|AMD|NIL|CNL").Match(raw).Value switch
            {
                "COR" => TafState.Corrected,
                "AMD" => TafState.Amended,
                "NIL" => TafState.Nil,
                "CNL" => TafState.Cancelled,
                _ => null
            };
    }
}
