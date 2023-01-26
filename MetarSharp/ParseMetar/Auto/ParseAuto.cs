using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    public class ParseAuto
    {
        /// <summary>
        /// this returns whether the metar is automated or not.
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static bool ReturnIsAutomated(string raw)
        {
            Regex autoRegex = new Regex("(AUTO)", RegexOptions.None);

            //If the regex matches, the metar is automated, if not it isn't
            return autoRegex.IsMatch(raw);
        }
    }
}
