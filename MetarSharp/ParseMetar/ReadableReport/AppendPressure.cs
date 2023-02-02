namespace MetarSharp.Parse.ReadableReport
{
    internal class Pressure
    {
        internal static string Append(Metar metar)
        {
            if (metar.Pressure.PressureType == PressureType.Hectopascal)
            {
                return $"Pressure: {metar.Pressure.PressureAsQnh}hPa ({metar.Pressure.PressureAsAltimeter}inHg)";
            }

            return $"Pressure: {metar.Pressure.PressureAsAltimeter}inHg ({metar.Pressure.PressureAsQnh}hPa)";
        }
    }
}
