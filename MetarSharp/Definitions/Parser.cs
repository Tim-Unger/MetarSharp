namespace MetarSharp.ParseOptions
{
    public class Parser
    {
        public static void Edit(string Unit, string Definition)
        {
            if (Dictionaries.Dictionary.MainDictionary.ContainsKey(Unit))
            {
                Dictionaries.Dictionary.MainDictionary[Unit] = Definition;
            }
        }
    }
}
