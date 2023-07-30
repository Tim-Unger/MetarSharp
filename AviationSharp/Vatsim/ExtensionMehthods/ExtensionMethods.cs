namespace AviationSharp.Vatsim
{
    public static class ExtensionMethods
    {
        public static bool IsValidCID(this int cid) => Vatsim.DoesCIDExist(cid);

        public static bool IsBetween(this int value, int lowRange, int highRange) =>
            value >= lowRange && value <= highRange;
    }
}
