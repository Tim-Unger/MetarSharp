namespace AviationSharp.Metar.Parse
{
    internal class ParseAuto
    {
        /// <summary>
        /// this returns whether the metar is automated or not.
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        internal static bool ReturnIsAutomated(string raw) => Regex.IsMatch(raw, "(AUTO)");
    }

    public class ParseAutoOnly
    {
        public static bool FromString(string raw) => ParseAuto.ReturnIsAutomated(raw);
    }
}
