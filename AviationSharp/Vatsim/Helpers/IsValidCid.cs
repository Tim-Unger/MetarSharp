namespace AviationSharp.Vatsim
{
    public partial class Vatsim
    {
        public static bool DoesCIDExist(int cid)
        {
            if(cid < 800000)
            {
                return false;
            }

            if (new[] { 8, 9 }.Any(x => x == int.Parse(cid.ToString()[0].ToString())))
            {
                if (cid.ToString().Length != 6)
                {
                    return false;
                }

                return IsCIDActive(cid);
            }

            if(cid.ToString().Length != 7)
            {
                return false;
            }

            return IsCIDActive(cid);
        }

        private static bool IsCIDActive(int cid) => !new HttpClient().GetStringAsync($"https://api.vatsim.net/api/ratings/{cid}/").Result.Contains("Not found");
    }
}
