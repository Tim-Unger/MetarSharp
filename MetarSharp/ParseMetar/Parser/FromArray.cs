namespace MetarSharp.Parser
{
    internal class FromArray
    {
        /// <summary>
        /// This parses the metar from an array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static Metar[] Parse(string[] input)
        {
            List<Metar> returnList = new();

            foreach(var metar in input)
            {
                returnList.Add(FromString.Parse(metar));
            }

            return returnList.ToArray();
        }
    }
}