namespace MetarSharp.Tests.Clouds
{
    internal class Clouds
    {
        [Test]
        public void CheckClouds_ReturnsTrue()
        {
            foreach (var metar in Setup.MetarsParsed)
            {
                Assert.That(metar.Clouds.All(cloud => cloud.CloudRaw != null));
            }
        }
    }
}
