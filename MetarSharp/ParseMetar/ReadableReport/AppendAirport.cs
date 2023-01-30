namespace MetarSharp.Parse.ReadableReport
{
    internal class Airport
    {
        internal static string Append(Metar metar)
        {
            return $"for {metar.Airport}. ";
        }
    }
}
