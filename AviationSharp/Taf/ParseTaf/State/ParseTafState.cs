using static AviationSharp.Taf.State;

namespace AviationSharp.Taf.Parse
{
    internal class ParseTafState
    {
        private static readonly Regex _stateRegex = new("COR|AMD|NIL|CNL");

        internal static TafState? ReturnTafState(string raw) =>
            _stateRegex.Match(raw).Value switch
            {
                "COR" => TafState.Corrected,
                "AMD" => TafState.Amended,
                "NIL" => TafState.Nil,
                "CNL" => TafState.Cancelled,
                _ => null
            };
    }
}
