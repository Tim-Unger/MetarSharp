namespace MetarSharp.Parse.ReadableReport
{
    internal class Pressure
    {
        internal static string Append(Metar metar)
        {
            if (!metar.Pressure.IsPressureMeasurable)
            {
                return "Pressure not measurable";
            }

            //non-nulls the pressure (0 is fine here as this is only executed if the pressure is measurable)
            var nonNullablePressure = metar.Pressure.PressureAsAltimeter ?? 0;

            //This counts the decimal places of the altimeter pressure value
            var getDecimalPlaces = nonNullablePressure.ToString("R").Split('.');
            
            var decimalPlaces = 0;
            if(getDecimalPlaces.Length > 1)
            {
                decimalPlaces = getDecimalPlaces[1].Length;
            }

            //This adds a zero if the pressure has only one decimal place (30.1) or two zeros if it is a round number (30)
            var correctDecimalPlaces = AddDecimalPlaces(nonNullablePressure.ToString(), decimalPlaces);

            if (metar.Pressure.PressureType == PressureType.Hectopascal)
            {
                return $"Pressure: {metar.Pressure.PressureAsQnh}hPa ({correctDecimalPlaces}inHg)";
            }

            return $"Pressure: {correctDecimalPlaces}inHg ({metar.Pressure.PressureAsQnh}hPa)";
        }

        private static string AddDecimalPlaces(string input, int decimalPlaces) => decimalPlaces switch
        {
            0 => input += ".00",
            1 => input += "0",
            _ => input
        };
    }
}
