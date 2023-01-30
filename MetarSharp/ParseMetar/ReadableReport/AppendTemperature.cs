using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class Temperature
    {
        internal static string Append(Metar metar)
        {
            return $"Temperature: {metar.Temperature.TemperatureCelsius}°C ({metar.Temperature.TemperatureFahrenheit}°F)";
        }
    }
}