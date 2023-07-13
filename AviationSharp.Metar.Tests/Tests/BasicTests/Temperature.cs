namespace AviationSharp.Metar.Tests.Temperature
{
    internal class Temperature
    {
        [Test]
        public void CheckTemperatureHasValue_ReturnsTrue()
        {
            foreach (Metar metar in Setup.MetarsParsed.Where(x => x.Temperature.IsTemperatureMeasurable).ToList())
            {
                Assert.That(metar.Temperature.TemperatureCelsius, Is.Not.EqualTo(null), $"Metar {metar.MetarRaw} has no temperature");
            }
        }

        [Test]
        public void CheckDewpointHasValue_ReturnsTrue()
        {
            foreach (Metar metar in Setup.MetarsParsed.Where(x => x.Temperature.IsTemperatureMeasurable).ToList())
            {
                Assert.That(metar.Temperature.DewpointCelsius, Is.Not.EqualTo(null), $"Metar {metar.MetarRaw} has no dewpoint");
            }
        }
    }
}
