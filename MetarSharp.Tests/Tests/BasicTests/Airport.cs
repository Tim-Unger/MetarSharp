
namespace MetarSharp.Tests.Tests.BasicTests
{
    internal class Airport
    {

        [Test]
        public void CheckAirport_ReturnsTrue()
        {
            Assert.That(MetarsParsed.All(x => x.Airport != null));
        }
    }
}
