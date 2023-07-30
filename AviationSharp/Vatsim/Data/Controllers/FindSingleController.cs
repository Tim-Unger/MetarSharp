namespace AviationSharp.Vatsim.Data
{
    public class SingleController
    {
        internal static Controller? Get(string search)
        {
            var feed =
                VatsimData.GetEntireDatafeed().Controllers
                ?? throw new Exception("No controllers found");

            //Search is CID
            if (int.TryParse(search, out var cid))
            {
                return feed.Where(x => x.Cid == cid).FirstOrDefault();
            }

            //Search is frequency
            if (search.Contains('.'))
            {
                return feed.Where(x => x.Frequency == search).FirstOrDefault();
            }

            //Search is callsign
            if (search.Contains('_'))
            {
                return feed.Where(x => x.Callsign.Contains(search.ToUpper())).FirstOrDefault();
            }

            //Search is an airport
            if (search.Length == 4 && search.All(char.IsLetter))
            {
                return feed.Where(x => x.Callsign.StartsWith(search.ToUpper())).FirstOrDefault();
            }

            //Search is name or part of the controller info
            return feed.Where(
                        x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    )
                    .FirstOrDefault()
                ?? feed.Where(
                        x =>
                            x.TextAtis!.Contains(
                                search,
                                StringComparison.InvariantCultureIgnoreCase
                            )
                    )
                    .FirstOrDefault();
        }

        internal static Controller? Get(int cid)
        {
            if (!Vatsim.DoesCIDExist(cid))
            {
                throw new ArgumentException("Please provide a valid CID");
            }

            return VatsimData
                .GetEntireDatafeed()
                .Controllers?.Where(x => x.Cid == cid)
                .FirstOrDefault();
        }
    }
}
