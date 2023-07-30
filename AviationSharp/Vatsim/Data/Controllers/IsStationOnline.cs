namespace AviationSharp.Vatsim.Data
{
    internal class Station
    {
        internal static bool IsOnline(string callsign)
        {
            if (!callsign.ToCharArray().Where(x => x == '_').Count().IsBetween(1, 2))
            {
                throw new Exception("The search input is not a full valid callsign ");
            }

            var feed = VatsimData.GetEntireDatafeed().Controllers;

            return feed!.Where(x => x.Callsign == callsign.ToUpper()).Count() == 1;
        }

        internal static bool IsOnline(int cid) =>
            VatsimData.GetAllPilots().Any(x => x.Cid == cid)
            || VatsimData.GetAllControllers().Any(x => x.Cid == cid);
    }
}
