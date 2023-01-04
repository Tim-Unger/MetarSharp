using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Tests.Pressure
{
    internal class PressureTests
    {
        [Test]
        public void CheckThatConversionIsCorrect_ReturnsTrue()
        {
            foreach (var metar in MetarsParsed.Where(x => x.Pressure.IsPressureMeasurable))
            {
                if (metar.Pressure.PressureType == PressureType.Hectopascal)
                {
                    double convertToAltimeter = Math.Round(
                        metar.Pressure.PressureOnly / 33.8569518716,
                        2
                    );
                    Assert.That(metar.Pressure.PressureAsAltimeter, Is.EqualTo(convertToAltimeter));
                }

                if (metar.Pressure.PressureType == PressureType.InchesMercury)
                {
                    int convertToHectopascal = (int)Math.Round(
                        metar.Pressure.PressureOnly * 33.8569518716,
                        0
                    );
                    Assert.That(metar.Pressure.PressureAsQnh, Is.EqualTo(convertToHectopascal));
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
                int convertHectospascals = (int)Math.Round(
                    metar.Pressure.PressureAsQnh / 33.8569518716 ?? throw new Exception(),
                    0
                );

                string convertHectopascalsOne = String.Join(
                    String.Empty,
                    convertHectospascals.ToString().Take(2)
                );
                string convertHectopascalsTwo = String.Join(
                    String.Empty,
                    convertHectospascals.ToString().Skip(2).Take(2)
                );

                string convertHectopascalsAndCheck =
                    convertHectopascalsOne + "." + convertHectopascalsTwo;

                string takeMetarPartOne = String.Join(
                    String.Empty,
                    metar.Pressure.PressureRaw.ToString().Skip(1).Take(2)
                );
                string takeMetarPartTwo = String.Join(
                    String.Empty,
                    metar.Pressure.PressureRaw.ToString().Skip(3).Take(2)
                );

                string hectopascalsAndCheck = takeMetarPartOne + "." + takeMetarPartTwo;

                string checkConverted = metar.Pressure.PressureWithSeperator;

                bool allTheSame =
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
