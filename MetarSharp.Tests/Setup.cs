namespace MetarSharp.Tests
{
    [SetUpFixture]
    internal class Setup
    {
        public static List<string> Metars { get; set; }
        public static List<Metar> MetarsParsed { get; set; }

        [OneTimeSetUp]
        public void SetupClass()
        {
            using (StreamReader streamReader = new StreamReader("../Metars.txt"))
            {
                string metarListRaw = streamReader.ReadToEnd();
                Metars = metarListRaw.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                MetarsParsed = Metars.Select(x => ParseMetar.FromString(x)).ToList();
            };
        }

        //[OneTimeTearDown]
        //public void TearDownClass() 
        //{
        //    Metars.Clear();
        //    MetarsParsed.Clear();
        //}
    }
}
