using System.Security.Cryptography;
using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Dewpoint
    {
        internal static string Append(Metar metar)
        {
            return $"Dewpoint: {metar.Temperature.DewpointCelsius}°C ({ metar.Temperature.DewpointFahrenheit}°F)";
        } 
    }
}
