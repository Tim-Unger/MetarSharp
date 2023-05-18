using MetarSharp.Exceptions;
using System.ComponentModel.Design;

namespace MetarSharp.Tests.Pressure
{
    internal class PressureTests
    {
        [Test]
        public void CheckThatConversionIsCorrect_ReturnsTrue()
        {
            foreach (var metar in MetarsParsed.Where(x => x.Pressure.IsPressureMeasurable))
            {
                switch (metar.Pressure.PressureType)
                {
                    case PressureType.Hectopascal:
                    {
                        var convertToAltimeter = Math.Round(
                            metar.Pressure.PressureOnly / 33.8569518716,
                            2
                        );
                        Assert.That(metar.Pressure.PressureAsAltimeter, Is.EqualTo(convertToAltimeter));
                        break;
                    }
                    case PressureType.InchesMercury:
                    {
                        var convertToHectopascal = (int)Math.Round(
                            metar.Pressure.PressureOnly * 33.8569518716,
                            0
                        );
                        Assert.That(metar.Pressure.PressureAsQnh, Is.EqualTo(convertToHectopascal));
                        break;
                    }
                    default:
                        throw new ParseException();
                }
            }
        }
    }
}
