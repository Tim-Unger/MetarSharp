namespace MetarSharp.Parse.ReadableReport
{
    internal class Pressure
    {
        internal static string Append(Metar metar)
        {
            string pressure = "Pressure: " + metar.Pressure.PressureAsQnh + "hPa" + " or " + metar.Pressure.PressureAsAltimeter + "inHg";

            return pressure;
        }
    }
}
