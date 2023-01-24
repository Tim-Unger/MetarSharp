using MetarSharp.Exceptions;

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
                        double convertToAltimeter = Math.Round(
                            metar.Pressure.PressureOnly / 33.8569518716,
                            2
                        );
                        Assert.That(metar.Pressure.PressureAsAltimeter, Is.EqualTo(convertToAltimeter));
                        break;
                    }
                    case PressureType.InchesMercury:
                    {
                        int convertToHectopascal = (int)Math.Round(
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

        [Test]
        public void CheckThatAltimeterSeparatorIsSet_ReturnsTrue()
        {
            foreach (
                var metar in MetarsParsed.Where(
                    x => x.Pressure.PressureType == PressureType.InchesMercury
                )
            )
            {
                var convertHectospascals = (int)Math.Round(
                    metar.Pressure.PressureAsQnh / 33.8569518716 ?? throw new ParseException(),
                    0
                );

                var convertHectopascalsOne = String.Join(
                    String.Empty,
                    convertHectospascals.ToString().Take(2)
                );
                var convertHectopascalsTwo = String.Join(
                    String.Empty,
                    convertHectospascals.ToString().Skip(2).Take(2)
                );

                var convertHectopascalsAndCheck =
                    convertHectopascalsOne + "." + convertHectopascalsTwo;

                var takeMetarPartOne = String.Join(
                    String.Empty,
                    metar.Pressure.PressureRaw.ToString().Skip(1).Take(2)
                );
                var takeMetarPartTwo = String.Join(
                    String.Empty,
                    metar.Pressure.PressureRaw.ToString().Skip(3).Take(2)
                );

                var hectopascalsAndCheck = takeMetarPartOne + "." + takeMetarPartTwo;

                var checkConverted = metar.Pressure.PressureAsAltimeter.ToString();

                var allTheSame =
                    convertHectopascalsAndCheck == hectopascalsAndCheck
                    && convertHectopascalsAndCheck == checkConverted;
                Assert.That(
                    allTheSame,
                    Is.True,
                    $"Failed for {convertHectopascalsAndCheck}, {hectopascalsAndCheck}, {checkConverted}"
                );
            }
        }
    }
}
