

namespace AviationSharp.Metar.Tests.Visibility
{
    internal class VisibiltiyTests
    {
        [Test]
        public void CheckLowestVisibilityCount_ReturnsTrue()
        {
            var lowestVisRegex = new Regex(@"([0-9]{4}(N|NE|E|SE|S|SW|W|NW))(?<!R[0-9]{1,2}(L|R|C)?/[0-9]{4}(N|NE|E|SE|S|SW|W|NW))\s", RegexOptions.Multiline);
            MatchCollection matches = lowestVisRegex.Matches(String.Join("\n", Setup.Metars));

            var listCount = Setup.MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).ToList().ConvertAll(y => y.Visibility.VisibilityRaw);
            Assert.That(matches, Has.Count.EqualTo(Setup.MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).Count()));
        }

        [Test]
        public void CheckThatLowestVisibilityIsLowerThanVisibility_ReturnsTrue()
        {
            var metarsWithLowestVis = Setup.MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).ToList();

            foreach (Metar metar in metarsWithLowestVis)
            {
                Assert.That(metar.Visibility.ReportedVisibility, Is.GreaterThan(metar.Visibility.LowestVisibility));
            }
        }
    }
}
