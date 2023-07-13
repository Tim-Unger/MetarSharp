namespace AviationSharp.Airports
{
    public partial class Regions
    {
        public readonly Region GreenlandIcelandKosovo = new()
        {
            IcaoRegion = IcaoRegion.GreenlandIcelandKosovo,
            Letter = 'B',
            Name = "Greenland, Iceland, Kosovo",
            Countries = BCountries
        };

        internal static readonly List<IcaoCountry> BCountries = new()
        {
            new IcaoCountry()
            {
                Region = IcaoRegion.GreenlandIcelandKosovo,
                Identifier = "BG",
                Name = "Greenland"
            },
            new IcaoCountry()
            {
                Region = IcaoRegion.GreenlandIcelandKosovo,
                Identifier = "BI",
                Name = "Iceland"
            },
            new IcaoCountry()
            {
                Region = IcaoRegion.GreenlandIcelandKosovo,
                Identifier = "BK",
                Name = "Kosovo"
            }
        };
    }
}
