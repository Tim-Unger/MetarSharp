using AviationSharp.Metar.Exceptions;

namespace AviationSharp.Metar.Tests.Pressure
{
    public class PressureTests
    {
        [Test]
        public void CheckThatConversionIsCorrect_ReturnsTrue()
        {
            foreach (Metar metar in Setup.MetarsParsed.Where(x => x.Pressure.IsPressureMeasurable))
            {
                switch (metar.Pressure.PressureType)
                {
                    case PressureType.Hectopascal:
                    {
                        var convertToAltimeter = Math.Round(
                            metar.Pressure.PressureOnly / 33.8569518716,
                            2
                        );
                        Assert.That(metar.Pressure.PressureAsAltimeter, Is.EqualTo(convertToAltimeter), $"Failed for {metar.Airport}");
                        break;
                    }
                    case PressureType.InchesMercury:
                    {
                        var convertToHectopascal = (int)Math.Round(
                            metar.Pressure.PressureOnly * 33.8569518716,
                            0
                        );

                        Assert.That(metar.Pressure.PressureAsQnh, Is.EqualTo(convertToHectopascal), $"Failed for {metar.Airport}");
                        break;
                    }
                    default:
                        throw new ParseException();
                }
            }
        }
    }
}
