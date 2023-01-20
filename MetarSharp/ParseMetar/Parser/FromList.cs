namespace MetarSharp.Parser
{
    internal class FromList
    {
        internal static List<Metar> Parse (List<string> input)
        {
            List<Metar> metars = new List<Metar>();

            foreach (var listMetar in input)
            {
                if (listMetar.StartsWith("http"))
                {
                    Metar addNewMetar = new Metar();

                    addNewMetar = FromLink.Parse(listMetar);

                    metars.Add(addNewMetar);
                    continue;
                }

                Metar addMetar = new Metar();

                addMetar = FromString.Parse(listMetar);

                metars.Add(addMetar);
            }
            return metars;
        }
    }
}
