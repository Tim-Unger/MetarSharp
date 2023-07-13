namespace MetarSharp.Parse.ReadableReport
{
    internal class Temperature
    {
        internal static string Append(Metar metar)
        {
            if(!metar.Temperature.IsTemperatureMeasurable)
            {
                return "Temperature not measurable";
            }

            return $"Temperature: {metar.Temperature.TemperatureCelsius}°C ({metar.Temperature.TemperatureFahrenheit}°F)";
        }
    }
}