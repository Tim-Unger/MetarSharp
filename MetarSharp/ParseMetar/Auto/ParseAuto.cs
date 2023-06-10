namespace MetarSharp.Parse
{
    public class ParseAuto
    {
        /// <summary>
        /// this returns whether the metar is automated or not.
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        internal static bool ReturnIsAutomated(string raw) => Regex.IsMatch(raw, "(AUTO)");
    }
}
