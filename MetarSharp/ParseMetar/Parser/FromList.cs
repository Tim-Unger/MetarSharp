namespace MetarSharp.Parser
{
    internal class FromList
    {
        /// <summary>
        /// This parses the input from a list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        internal static List<Metar> Parse (List<string> input)
        {
            List<Metar> metars = new List<Metar>();

            foreach (var listMetar in input)
            {
                if (listMetar.StartsWith("http"))
                {
                    metars.Add(FromLink.Parse(listMetar));
                    continue;
                }

                metars.Add(FromString.Parse(listMetar));
            }
            return metars;
        }
    }
}
