namespace MetarSharp.Parse.ReadableReport
{
    internal class Airport
    {
        internal static string Append(Metar metar) => $"for {metar.Airport}. ";
    }
}
