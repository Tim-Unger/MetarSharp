namespace MetarSharp.Parse.ReadableReport
{
    internal class Dewpoint
    {
        internal static string Append(Metar metar) => $"Dewpoint: {metar.Temperature.DewpointCelsius}°C ({metar.Temperature.DewpointFahrenheit}°F)";
    }
}
