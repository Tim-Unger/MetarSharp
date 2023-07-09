namespace AviationSharp.Metar.Tests.Wind
{
    internal class Wind
    {
        [Test]
        public void CheckWind_ReturnsTrue()
        {
            //int index = MetarsParsed.FindIndex(x => x.Wind.WindRaw == null);
            if (MetarsParsed.Any(x => x.Wind.WindRaw == null && x.IsAutomatedReport == false))
            {
                Assert.Fail();
                return;
            }
        }
    }
}
