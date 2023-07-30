namespace AviationSharp.Vatsim.Data
{
    public class MultipleControllers
    {
        public static List<Controller>? Get(string search)
        {
            var feed =
                VatsimData.GetEntireDatafeed() ?? throw new Exception("No controllers found");

            var controllers = feed.Controllers ?? throw new Exception();

            //Search is a rating
            if (feed.Ratings.Any(x => x.ShortName == search.ToUpper()))
            {
                var index = feed.Ratings.Where(x => x.ShortName == search.ToUpper()).First().Id;

                return controllers.Where(x => x.RatingIndex == index).ToList();
            }

            //Search is a facility-type
            if (feed.Facilities.Any(x => x.ShortName == search.ToUpper()))
            {
                var index = feed.Facilities.Where(x => x.ShortName == search.ToUpper()).First().Id;

                return controllers.Where(x => x.FacilityTypeIndex == index).ToList();
            }
            
            //Search is a server
            if(feed.Servers.Any(x => x.Name == search.ToUpper()))
            {
                return controllers.Where(x => x.Server ==  search.ToUpper()).ToList();
            }

            
            //Search is frequency
            if (search.Contains('.'))
            {
                return controllers.Where(x => x.Frequency == search).ToList();
            }

            //Search is callsign
            if (search.Contains('_'))
            {
                return controllers.Where(x => x.Callsign.Contains(search.ToUpper())).ToList();
            }

            //Search is an airport or FIR or region or country
            if (search.Length <= 4 && search.All(char.IsLetter))
            {
                return controllers.Where(x => x.Callsign.StartsWith(search.ToUpper())).ToList();
            }

            //Search is name or part of the controller info
            return controllers.Where(
                        x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    )
                    .ToList()
                ?? controllers.Where(
                        x =>
                            x.TextAtis!.Contains(
                                search,
                                StringComparison.InvariantCultureIgnoreCase
                            )
                    )
                    .ToList();
        }
    }
}
