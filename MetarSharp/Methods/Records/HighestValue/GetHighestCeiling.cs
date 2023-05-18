using MetarSharp.Exceptions;
using MetarSharp.Extensions;

namespace MetarSharp.Methods.Records.HighestValue
{
    internal class HighestCeiling
    {
        //TODO implement
        internal static dynamic GetReturn(List<Metar> metars, ValueReturnType valueReturnType) => valueReturnType switch
        {
            ValueReturnType.FullMetar => Get(metars),
            ValueReturnType.JustValueClass => GetClass(metars),
            ValueReturnType.OnlyValue => GetJustValue(metars),
        };

        internal static Metar Get(List<Metar> metars)
        {
            var cloudsSorted = metars
                .Where(x => x.Clouds.Any(x => !x.IsCAVOK))
                .OrderByDescending(x =>  x.Clouds.Max(x => x.CloudCeiling))
                .ToList();

            return cloudsSorted.First();
        }

        private static Cloud GetClass(List<Metar> metars)
        {
            return Get(metars)
                .Clouds
                .OrderByDescending(x => x.CloudCeiling)
                .First();
        }

        private static int GetJustValue(List<Metar> metars)
        {
            return Get(metars)
                .Clouds
                .OrderByDescending(x => x.CloudCeiling)
                .First().CloudCeiling 
                ?? throw new ParseException();
        }
        
    }
}
