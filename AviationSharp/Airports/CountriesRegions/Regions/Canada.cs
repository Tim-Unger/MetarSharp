namespace AviationSharp.Airports
{
    public partial class Regions
    {
        public readonly Region Canada = new()
        {
            IcaoRegion = IcaoRegion.Canada,
            Letter = 'C',
            Name = "Canada",
            Countries = CCountries
        };

        internal static readonly List<IcaoCountry> CCountries = new()
        {
            new IcaoCountry
            {
                Region = IcaoRegion.Canada,
                Identifier = "C",
                Name = "Canada"
            }
        };
    }
}
