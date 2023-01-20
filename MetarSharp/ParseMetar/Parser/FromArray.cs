namespace MetarSharp.Parser
{
    internal class FromArray
    {
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