namespace AviationSharp.Airports
{
    public partial class Regions
    {
        public readonly Region WesternSouthPacific = new Region()
        {
            IcaoRegion = IcaoRegion.WesternSouthPacific,
            Letter = 'A',
            Name = "Western South Pacific",
            Countries = ACountries
        };

        internal static readonly List<IcaoCountry> ACountries = new()
        {
            new IcaoCountry()
            {
                Region = IcaoRegion.WesternSouthPacific,
                Identifier = "AG",
                Name = "Solomon Islands"
            },
            new IcaoCountry()
            {
                Region = IcaoRegion.WesternSouthPacific,
                Identifier = "AN",
                Name = "Nauru"
            },
            new IcaoCountry()
            {
                Region = IcaoRegion.WesternSouthPacific,
                Identifier = "AY",
                Name = "Papua New Guinea"
            }
        };
    }
}
