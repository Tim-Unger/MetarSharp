using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MetarSharp.Tests.Tests.BasicTests
{
    internal class Wind
    {
        //TODO Currently broken
        [Test]
        public void CheckWind_ReturnsTrue()
        {
            //int index = MetarsParsed.FindIndex(x => x.Wind.WindRaw == null);
            if (MetarsParsed.Any(x => x.Wind.WindRaw == null)) 
            {
                Assert.Fail();
                return; 
            }

            //foreach (var metar in MetarsParsed)
            //{
                
            //    if (metar.Wind.WindRaw == null)
            //    {
            //        string unit = metar.Wind.WindRaw;
            //        Assert.Fail($"Failed with: {unit}");
            //        return;
            //    }

            //    Assert.Pass();

            //    //Assert.NotNull(metar.Wind.WindRaw);
            //    //Assert.Fail($"failed for: {metar.Airport} value was {metar.Wind.WindRaw}");

            //}
            ////Assert.That(MetarsParsed.All(x => x.Wind.WindRaw != null));
        }

        
    }
}
