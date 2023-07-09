namespace AviationSharp.Metar
{
    public static class MetarExtensions
    {
        public static string ConvertToJson(this Metar metar) => ParseMetar.ToJson(metar);
    }
}
