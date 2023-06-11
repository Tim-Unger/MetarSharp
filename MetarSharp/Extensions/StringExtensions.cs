namespace MetarSharp
{
    public static class StringExtensions
    {
        public static Metar ParseMetar(this string raw) => MetarSharp.ParseMetar.FromString(raw);

        public static bool TryParse(this string raw, out Metar metar)
        {
            try
            {
                metar = MetarSharp.ParseMetar.FromString(raw);
                return true;
            }
            catch
            {
                metar = new Metar();
                return false;
            }
        }

        public static bool IsValidMetar(this string raw) => MetarValidity.IsValid(raw);
    }
}
