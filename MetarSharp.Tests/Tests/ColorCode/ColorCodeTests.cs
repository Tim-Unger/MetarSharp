using MetarSharp;
using MetarSharp.Definitions;
using ColorCode = MetarSharp.ColorCode;

namespace MetarSharp.Tests.Tests.ColorCode
{
    public class ColorCodeTests
    {
        [Test]
        public void CheckColorCodeMatchesMetarValues_ReturnsTrue()
        {
            var metarsWithColorCode = MetarsParsed.Where(x => x.AdditionalInformation.ColorCode != null).ToList();
            
            Assert.That(metarsWithColorCode.All(x => AreColorCodeValuesCorrect(x.AdditionalInformation.ColorCode.Color, x)));
        }

        private bool AreColorCodeValuesCorrect(Color colorCode, Metar metar) => colorCode switch
        {
            Color.BLUPLUS => IsBluePlusCorrect(metar),
            
        };

        private bool IsBluePlusCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 2000 && metar.Visibility.ReportedVisibility >= 8000;
        }
    }
}