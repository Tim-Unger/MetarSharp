namespace AviationSharp.Metar.Extensions
{
    public class DistanceExtensions
    {
        /// <summary>
        /// returns distance in either singular or plural depending on the value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="visibilityUnit"></param>
        /// <returns>the distance as a string either singular or plural</returns>
        /// <exception cref="ParseException"></exception>
        public static string DistanceValueSingularOrPlural(double value, VisibilityUnit visibilityUnit) => visibilityUnit switch
        {
            VisibilityUnit.Meters => value > 1 ? "Meters" : "Meter",
            VisibilityUnit.Kilometers => value > 1 ? "Kilometer" : "Kilometers",
            VisibilityUnit.Miles => value > 1 ? "Miles" : "Mile",
            _ => throw new ParseException()
        };
    }
}
