namespace MetarSharp.Tests.Visibility
{
    internal class Visibility
    {
        [Test]
        public void CheckVisibilityIsNotNull_ReturnsTrue()
        {

            //TODO
            //Assert.That(MetarsParsed.Where(x => x.Visibility.IsVisibilityMeasurable).ToList().All(x => new[] {"SM", "M"}.Any(y => x.Visibility.VisibilityUnitRaw == y)));
            foreach (var metar in MetarsParsed)
            {
                if (metar.Visibility.IsVisibilityMeasurable == false)
                {
                    return;
                }

                bool isPass = new[] { "SM", "M" }.Any(x => metar.Visibility.VisibilityUnitRaw == x);
                Assert.That(isPass);
            }
        }
    }
}
