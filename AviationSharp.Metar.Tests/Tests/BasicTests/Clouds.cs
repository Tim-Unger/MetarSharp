namespace AviationSharp.Metar.Tests.Clouds
{
    internal class Clouds
    {
        [Test]
        public void CheckClouds_ReturnsTrue()
        {
            foreach (Metar metar in Setup.MetarsParsed)
            {
                Assert.That(metar.Clouds.All(cloud => cloud.CloudRaw != null));
            }
        }
    }
}
