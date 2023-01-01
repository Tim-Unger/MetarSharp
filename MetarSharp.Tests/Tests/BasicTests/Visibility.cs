using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Tests.Tests.BasicTests
{
    internal class Visibility
    {
        [Test]
        public void CheckVisibilityIsNotNull_ReturnsTrue()
        {
            //Assert.That(MetarsParsed.Any(x => x.Visibility.VisibilityUnitRaw == null) == false);
            foreach (var metar in MetarsParsed)
            {
                if(metar.Visibility.IsVisibilityMeasurable == false)
                {
                    return;
                }

                bool isPass = new[] { "SM", "M" }.Any(x => metar.Visibility.VisibilityUnitRaw == x);
                Assert.That(isPass);
            }
        }
    }
}
