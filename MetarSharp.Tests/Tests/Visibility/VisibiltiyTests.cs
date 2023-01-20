using System.Text.RegularExpressions;

namespace MetarSharp.Tests.Visibility
{
    internal class VisibiltiyTests
    {
        [Test]
        public void CheckLowestVisibilityCount_ReturnsTrue()
        {
            Regex lowestVisRegex = new(@"([0-9]{4}(N|NE|E|SE|S|SW|W|NW))(?<!R[0-9]{1,2}(L|R|C)?/[0-9]{4}(N|NE|E|SE|S|SW|W|NW))\s", RegexOptions.Multiline);
            MatchCollection matches = lowestVisRegex.Matches(String.Join("\n", Metars));

            var listCount = MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).ToList().ConvertAll(y => y.Visibility.VisibilityRaw);
            Assert.That(matches, Has.Count.EqualTo(MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).Count()));
        }

        [Test]
        public void CheckThatLowestVisibilityIsLowerThanVisibility_ReturnsTrue()
        {
            var metarsWithLowestVis = MetarsParsed.Where(x => x.Visibility.HasVisibilityLowestValue).ToList();

            foreach (var metar in metarsWithLowestVis)
            {
                Assert.That(metar.Visibility.ReportedVisibility, Is.GreaterThan(metar.Visibility.LowestVisibility));
            }
        }
    }
}
