namespace MetarSharp.Tests.Temperature
{
    internal class Temperature
    {
        [Test]
        public void CheckTemperatureHasValue_ReturnsTrue()
        {
            foreach (var metar in MetarsParsed.Where(x => x.Temperature.IsTemperatureMeasurable).ToList())
            {
                Assert.That(metar.Temperature.TemperatureOnly, Is.Not.EqualTo(null), $"Metar {metar.MetarRaw} has no temperature");
            }
        }

        [Test]
        public void CheckDewpointHasValue_ReturnsTrue()
        {
            foreach (var metar in MetarsParsed.Where(x => x.Temperature.IsTemperatureMeasurable).ToList())
            {
                Assert.That(metar.Temperature.DewpointOnly, Is.Not.EqualTo(null), $"Metar {metar.MetarRaw} has no dewpoint");
            }
        }
    }
}
