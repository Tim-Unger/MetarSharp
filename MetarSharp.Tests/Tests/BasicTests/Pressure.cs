namespace MetarSharp.Tests.Pressure
{
    internal class Pressure
    {
        [Test]
        public void CheckMetarHasPressure_ReturnsTrue()
        {
            Assert.That(MetarsParsed.Where(x => x.Pressure.IsPressureMeasurable).ToList().All(y => y.Pressure.PressureRaw != null));
            //foreach (var metar in MetarsParsed.Where(x => x.Pressure.IsPressureMeasurable))
            //{
            //    Assert.That(metar.Pressure.PressureRaw, Is.Not.EqualTo(null), $"Failed for {metar.MetarRaw}");
            //}
        }
    }
}
