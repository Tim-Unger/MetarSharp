using System.Text.RegularExpressions;

namespace MetarSharp.Tests.Wind
{
    internal class WindTests
    {

        [Test]
        public void CheckWindVariationCount_ReturnsTrue()
        {
            Regex windVarRegex = new(@"(?<!RMK.*)[0-9]{3}[0-9]{2,3}(G[0-9]{2})?(KT|MPS|MPH)\s[0-9]{3}V[0-9]{3}\s", RegexOptions.Multiline);
            MatchCollection matches = windVarRegex.Matches(String.Join("\n", Metars));

            int windVarCount = MetarsParsed.Where(x => x.Wind.IsWindDirectionVarying).Count();
            var windVarList = MetarsParsed.Where(x => x.Wind.IsWindDirectionVarying).ToList();

            Assert.That(matches, Has.Count.EqualTo(windVarCount), $"Metars with Wind Var: {windVarCount} Matches: {matches.Count}");
        }

        [Test]
        public void CheckGustCount_ReturnsTrue()
        {
            Regex gustVarRegex = new(@"(?<!(TEMPO|BECMG|RMK).*)G[0-9]{1,3}(KT|MPH|MPS)", RegexOptions.Multiline);
            MatchCollection matches = gustVarRegex.Matches(String.Join("\n", Metars));

            int gustCount = MetarsParsed.Where(x => x.Wind.IsWindGusting).Count();
            Assert.That(gustCount, Is.EqualTo(matches.Count), $"Metars with gust: {gustCount}, matches: {matches.Count}");
        }
    }
}
