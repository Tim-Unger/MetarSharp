namespace AviationSharp.Airports
{
    public enum IcaoRegion
    {
        WesternSouthPacific,
        GreenlandIcelandKosovo,
        Canada,
        EasternAfrica,
        NorthernCentralEurope,
        CentralSouthernAfrica,
        WesternAfrica,
        NorthEasternAfrica,
        USA,
        SouthEurope,
        CentralAmerica,
        SouthPacific,
        SouthWesternAsia,
        NorthPacific,
        JapanKoreaPhilippines,
        SouthAmerica,
        Caribbean,
        FormerUSSR,
        SouthAsia,
        SouthEastAsia,
        Australia,
        ChinaNorthKoreaMongolia,
        Unknown
    }

    public class Region
    {
        public IcaoRegion IcaoRegion { get; set; }
        public char Letter { get; set; }
        public string Name { get; set; }
        public List<IcaoCountry> Countries { get; set; }
    }

    public class AirportRegion
    {
        public static readonly List<char> RegionLetters = new()
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'Y',
            'Z'
        };
    }
}
