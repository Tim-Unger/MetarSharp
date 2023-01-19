using MetarSharp;
using MetarSharp.Definitions;
using ColorCode = MetarSharp.ColorCode;

namespace MetarSharp.Tests.Tests.ColorCode
{
    public class ColorCodeTests
    {
        [Test]
        //TODO
        public void CheckColorCodeMatchesMetarValues_ReturnsTrue()
        {
            
            var metarsWithColorCode = MetarsParsed.Where(x => x.AdditionalInformation.ColorCode != null).ToList();
            
            foreach (var colorCode in metarsWithColorCode)
            {
                bool isColorCodeCorrect = AreColorCodeValuesCorrect(colorCode.AdditionalInformation.ColorCode.Color, colorCode);
                Assert.That(isColorCodeCorrect, Is.True);
            }
            Assert.That(metarsWithColorCode.All(x => AreColorCodeValuesCorrect(x.AdditionalInformation.ColorCode.Color, x)));
        }

        private bool AreColorCodeValuesCorrect(Color colorCode, Metar metar) => colorCode switch
        {
            Color.BLUPLUS => IsBluePlusCorrect(metar),
            Color.BLU => IsBlueCorrect(metar),
            Color.WHT => IsWhiteCorrect(metar),
            Color.GRN => IsGreenCorrect(metar),
            Color.AMB => IsAmberCorrect(metar),
            Color.RED => IsRedCorrect(metar),
            Color.BLACK => true, //You are fucked anyways if you are here
        };

        private static bool IsBluePlusCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 2000 && metar.Visibility.ReportedVisibility >= 8000;
        }

        private static bool IsBlueCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 2500 && metar.Visibility.ReportedVisibility >= 8000;
        }

        private static bool IsWhiteCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 1500 && metar.Visibility.ReportedVisibility >= 5000;
        }

        private static bool IsGreenCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 700 && metar.Visibility.ReportedVisibility >= 3700;
        }
        private static bool IsYellowCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 300 && metar.Visibility.ReportedVisibility >= 1600;
        }

        private static bool IsAmberCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 200 && metar.Visibility.ReportedVisibility >= 800;
        }

        private static bool IsRedCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling < 200 && metar.Visibility.ReportedVisibility >= 800;
        }
    }
}