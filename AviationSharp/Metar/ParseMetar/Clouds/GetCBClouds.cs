namespace AviationSharp.Metar.Parse
{
    internal class CBClouds
    {
        internal static (bool, string, string) Get(GroupCollection groups)
        {
            var isCbTypeMesaurable = groups[6].Value != "///";

            var CBCloudTypeRaw = "";
            var CBCloudTypeDecoded = "";

            if (isCbTypeMesaurable)
            {
                CBCloudTypeRaw = groups[6].Value;

                CBCloudTypeDecoded = groups[6].Value switch
                {
                    "CB" => CloudDefintions.CumulonimbusLong,
                    "TC" or "TCU" => CloudDefintions.ToweringCumulonimbusLong,
                    _ => throw new ParseException("Could not read Cumulonimbus Cloud Type")
                };
            }

            return (isCbTypeMesaurable, CBCloudTypeRaw, CBCloudTypeDecoded);
        }
    }
}
