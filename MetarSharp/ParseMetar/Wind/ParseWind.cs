using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Parse
{
    internal class ParseWind
    {

        private static readonly Regex _windRegex = new(@"(?<!(?>RMK|TEMPO|BECMG).*)((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\s(([0-9]{3})V([0-9]{3})))?");

        internal static Wind ReturnWind(string raw)
        {
            var wind = new Wind();

            MatchCollection windMatches = _windRegex.Matches(raw);

            if (windMatches.Count == 0)
            {
                wind.IsWindMeasurable = false;
                return wind;
            }

            GroupCollection groups = windMatches[0].Groups;

            #region STANDARD
            //These always need to be set

            wind.WindRaw = groups[0].Value;

            wind.IsWindMeasurable = groups[6].Success == false;
            wind.IsWindDirectionMeasurable = groups[6].Success == false;
            wind.IsWindStrengthMeasurable = groups[7].Success == false;

            var isWindVRB = groups[2].Value.Contains("VRB");
            wind.IsWindVariable = isWindVRB;

            var windStrength = groups[4].Success ? IntTryParseWithThrow(groups[4].Value) : 0;
            wind.WindStrength = windStrength;

            var isWindCalm = windStrength == 0;
            wind.IsWindCalm = isWindCalm;

            wind.WindDirection = isWindCalm ? null : IntTryParseWithThrow(groups[3].Value);

            wind.IsWindGusting = groups[8].Success;

            var windUnitRaw = groups[10].Value;

            wind.WindUnitRaw = windUnitRaw;

            (wind.WindUnitDecoded, wind.WindUnit) = GetUnit(windUnitRaw);

            #endregion

            wind.WindGusts = groups[9].Success ? IntTryParseWithThrow(groups[9].Value) : null;

            if (isWindVRB)
            {
                wind.WindStrength = IntTryParseWithThrow(groups[5].Value);
            }

            if (groups[12].Success)
            {
                wind.IsWindDirectionVarying = true;
                wind.WindDirectionVariationRaw = groups[12].Value;
                wind.WindVariationLow = IntTryParseWithThrow(groups[13].Value);
                wind.WindVariationHigh = IntTryParseWithThrow(groups[14].Value);
            }
            return wind;
        }

        private static (string, WindUnit) GetUnit(string raw) => raw switch
        {
            "KT" => (WindDefinitions.KnotsLong, WindUnit.Knots),
            "MPH" => (WindDefinitions.MilesPerHourLong, WindUnit.MilesPerHour),
            "MPS" => (WindDefinitions.MetersPerSecondLong, WindUnit.MetersPerSecond),
            _ => throw new ParseException("Could not convert Wind Unit")
        };
    }
}
