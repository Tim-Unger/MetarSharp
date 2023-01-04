using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Tests.Clouds
{
    internal class Clouds
    {
        [Test]
        public void CheckClouds_ReturnsTrue()
        {
            foreach (var metar in Setup.MetarsParsed)
            {
                Assert.That(metar.Clouds.All(cloud => cloud.CloudRaw != null));
            }
        }
    }
}
