namespace AviationSharp.Metar.Tests.Visibility
{
    internal class Visibility
    {
        [Test]
        public void CheckVisibilityIsNotNull_ReturnsTrue()
        {

            //TODO
            //Assert.That(MetarsParsed.Where(x => x.Visibility.IsVisibilityMeasurable).ToList().All(x => new[] {"SM", "M"}.Any(y => x.Visibility.VisibilityUnitRaw == y)));
            foreach (Metar metar in Setup.MetarsParsed)
            {
                if (metar.Visibility.IsVisibilityMeasurable == false)
                {
                    return;
                }

                var isPass = new[] { "SM", "M" }.Any(x => metar.Visibility.VisibilityUnitRaw == x);
                Assert.That(isPass);
            }
        }
    }
}
