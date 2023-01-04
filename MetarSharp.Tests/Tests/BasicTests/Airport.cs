
namespace MetarSharp.Tests.Tests.Airport
{
    internal class Airport
    {

        [Test]
        public void CheckAirportIsNotNull_ReturnsTrue()
        {
            Assert.That(MetarsParsed.All(x => x.Airport != null));
        }

        [Test]
        public void CheckAirportLength_ReturnsFour()
        {
            Assert.That(MetarsParsed.All(x => x.Airport.Length == 4), "Airport length was: ");
        }
    }
}
