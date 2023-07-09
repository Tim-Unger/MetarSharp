namespace MetarSharp.Tests.Tests.ColorCode
{
    public class ColorCodeTests
    {
        [Test]
        //TODO
        public void CheckColorCodeMatchesMetarValues_ReturnsTrue()
        {
            
            var metarsWithColorCode = MetarsParsed.Where(x => x.AdditionalInformation.ColorCode.Color != Color.NIL).ToList();
            
            foreach (var colorCode in metarsWithColorCode)
            {
                var isColorCodeCorrect = AreColorCodeValuesCorrect(colorCode.AdditionalInformation.ColorCode.Color, colorCode);
                Assert.That(isColorCodeCorrect, Is.True);
            }
            Assert.That(metarsWithColorCode.All(x => AreColorCodeValuesCorrect(x.AdditionalInformation.ColorCode.Color, x)));
        }

        private static bool AreColorCodeValuesCorrect(Color colorCode, Metar metar) => colorCode switch
        {
            Color.NIL => true,
            Color.BLUPLUS => IsBluePlusCorrect(metar),
            Color.BLU => IsBlueCorrect(metar),
            Color.WHT => IsWhiteCorrect(metar),
            Color.GRN => IsGreenCorrect(metar),
            Color.YLO => IsYellowCorrect(metar),
            Color.AMB => IsAmberCorrect(metar),
            Color.RED => IsRedCorrect(metar),
            Color.BLACK => true, //You are fucked anyways if you are here
            _ => throw new ArgumentOutOfRangeException()
        };

        private static bool IsBluePlusCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            return orderedCloudList.CloudCeiling >= 2000 && metar.Visibility.ReportedVisibility >= 8000;
        }

        private static bool IsBlueCorrect(Metar metar)
        {
            //if(metar.Clouds.Any(x => x.IsCAVOK))
            //{
            //    Assert.Pass();
            //}

            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            var vis = metar.Visibility.ReportedVisibility;

            if(metar.Visibility.VisibilityUnit == VisibilityUnit.Miles || metar.Visibility.VisibilityUnit == VisibilityUnit.Kilometers)
            {
                vis *= 1000;
            }

            return orderedCloudList.CloudCeiling >= 2500 && vis >= 8000;
        }

        private static bool IsWhiteCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            var vis = metar.Visibility.ReportedVisibility;

            if (metar.Visibility.VisibilityUnit == VisibilityUnit.Miles || metar.Visibility.VisibilityUnit == VisibilityUnit.Kilometers)
            {
                vis *= 1000;
            }

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

            var vis = metar.Visibility.ReportedVisibility;

            if (metar.Visibility.VisibilityUnit == VisibilityUnit.Miles || metar.Visibility.VisibilityUnit == VisibilityUnit.Kilometers)
            {
                vis *= 1000;
            }

            return orderedCloudList.CloudCeiling >= 300 && metar.Visibility.ReportedVisibility >= 1600;
        }

        private static bool IsAmberCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            var vis = metar.Visibility.ReportedVisibility;

            if (metar.Visibility.VisibilityUnit == VisibilityUnit.Miles || metar.Visibility.VisibilityUnit == VisibilityUnit.Kilometers)
            {
                vis *= 1000;
            }

            return orderedCloudList.CloudCeiling >= 200 && metar.Visibility.ReportedVisibility >= 800;
        }

        private static bool IsRedCorrect(Metar metar)
        {
            var orderedCloudList = metar.Clouds.OrderByDescending(x => x.CloudCeiling).ToList().First();

            var vis = metar.Visibility.ReportedVisibility;

            if (metar.Visibility.VisibilityUnit == VisibilityUnit.Miles || metar.Visibility.VisibilityUnit == VisibilityUnit.Kilometers)
            {
                vis *= 1000;
            }

            //This should technically be less than 200 and 800 although most metars report red with either at 200 or 800
            return orderedCloudList.CloudCeiling <= 200 && metar.Visibility.ReportedVisibility <= 800;
        }
    }
}