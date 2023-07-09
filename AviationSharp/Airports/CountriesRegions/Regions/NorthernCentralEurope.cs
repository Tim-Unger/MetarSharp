namespace AviationSharp.Airports
{
    public partial class Regions
    {
        public readonly Region NorthernCentralEurope = new()
        {
            IcaoRegion = IcaoRegion.NorthernCentralEurope,
            Letter = 'E',
            Name = "Northern and Central Europe",
            Countries = ECountries
        };

        internal static readonly List<IcaoCountry> ECountries = new()
        {
            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EB",
                Name = "Belgium"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "ED",
                Name = "Germany"
            },
             
            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EE",
                Name = "Estonia"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EF",
                Name = "Finland"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EG",
                Name = "United Kingdom"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EH",
                Name = "Netherlands"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EI",
                Name = "Ireland"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EK",
                Name = "Denmark"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EL",
                Name = "Luxembourg"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EN",
                Name = "Norway"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EP",
                Name = "Poland"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "ES",
                Name = "Sweden"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "ET",
                Name = "Germany (military)"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EV",
                Name = "Latvia"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.NorthernCentralEurope,
                Identifier = "EY",
                Name = "Lithuania"
            }
        };
    }
}
