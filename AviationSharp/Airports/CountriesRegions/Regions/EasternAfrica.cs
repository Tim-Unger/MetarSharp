namespace AviationSharp.Airports
{
    public partial class Regions
    {
        public readonly Region EasternAfrica = new()
        {
            IcaoRegion = IcaoRegion.EasternAfrica,
            Letter = 'D',
            Name = "Eastern Part of West Africa",
            Countries = DCountries
        };

        internal static readonly List<IcaoCountry> DCountries = new()
        {
            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DA",
                Name = "Algeria"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DB",
                Name = "Benin"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DF",
                Name = "Burkina Faso"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DG",
                Name = "Ghana"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DI",
                Name = "Cote d' Ivoire"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DN",
                Name = "Nigeria"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DR",
                Name = "Niger"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DT",
                Name = "Tunisia"
            },

            new IcaoCountry()
            {
                Region = IcaoRegion.WesternAfrica,
                Identifier = "DX",
                Name = "Togo"
            }
        };
    }
}
