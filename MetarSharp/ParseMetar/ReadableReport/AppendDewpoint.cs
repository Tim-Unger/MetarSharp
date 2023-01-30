using System.Security.Cryptography;
using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Dewpoint
    {
        internal static string Append(Metar metar)
        {
            string dewpoint = metar.Temperature.DewpointCelsius + "°C" + " (" + metar.Temperature.DewpointFahrenheit + "°F)";

            return dewpoint;
        } 
    }
}
