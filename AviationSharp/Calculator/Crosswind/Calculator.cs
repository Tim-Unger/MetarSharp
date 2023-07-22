using AviationSharp.Metar;

namespace AviationSharp.Calculator
{
    internal class CalculateCrosswind
    {
        internal static Crosswind Calculate(double runwayHeading, int windDirection, double windStrength)
        {

            if(runwayHeading < 0 || runwayHeading > 360)
            {
                throw new Exception("Runway heading can't be greater than 360 or smaller than 0");
            }

            //TODO
            var runway = runwayHeading < 37 ? (int)Math.Round(runwayHeading, 2) : RoundOff(runwayHeading);


            //var runwaySinCos = Math.SinCos(runwayHeading);
            //var windSinCos = Math.SinCos(windDirection);

            var angleDifference = windDirection - runwayHeading;

            var headWind = Math.Round(windStrength * Math.Cos(angleDifference), 2);
            var crossWind = Math.Round(windStrength * Math.Sin(angleDifference), 2);

            return new Crosswind()
            {
                Runway = runway,
                RunwayHeading = (int)Math.Round(runwayHeading, 0),
                WindDirection = windDirection,
                WindSpeed = windStrength,
                HeadwindComponent = headWind,
                //TODO
                CrosswindDirection = CardinalDirection.North,
                CrosswindComponent = crossWind,
            };
        }

        //Rounds the give value to the nearest of 10 (39 => 40, 34 => 30)
        private static int RoundOff(double value) => (int)Math.Round(((double)value / 10) * 10);

    }
}
