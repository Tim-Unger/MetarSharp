using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MetarSharp.Tests.Wind
{
    internal class Wind
    {
        [Test]
        public void CheckWind_ReturnsTrue()
        {
            //int index = MetarsParsed.FindIndex(x => x.Wind.WindRaw == null);
            if (MetarsParsed.Any(x => x.Wind.WindRaw == null && x.IsAutomatedReport == false))
            {
                Assert.Fail();
                return;
            }
        }
    }
}
