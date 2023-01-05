using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MetarSharp.Definitions;

namespace MetarSharp.Parse
{
    public class ParseWind
    {
        public static Wind ReturnWind(string raw)
        {
            Wind wind = new Wind();

            Regex windRegex = new Regex(
                @"(?<!RMK.*)((([0-9]{3})([0-9]{1,3})|VRB([0-9]{1,3})|(/{3})(/{1,3}))(G([0-9]{1,3}))?)(KT|MPS|MPH)(\s(([0-9]{3})V([0-9]{3})))?",
                RegexOptions.None
            );

            MatchCollection windMatches = windRegex.Matches(raw);

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

            int windStrength = groups[4].Success ? TryParseWithThrow(groups[4].Value) : 0;
            wind.WindStrength = windStrength;

            bool isWindCalm = windStrength == 0;
            wind.IsWindCalm = isWindCalm;

            wind.WindDirection = isWindCalm ? null : TryParseWithThrow(groups[3].Value);

            wind.IsWindGusting = groups[8].Success;

            string windUnitRaw = groups[10].Value;

            wind.WindUnitRaw = windUnitRaw;

            (wind.WindUnitDecoded, wind.WindUnit) = GetUnit(windUnitRaw);

            #endregion


            wind.WindGusts = groups[9].Success ? TryParseWithThrow(groups[9].Value) : null;

            wind.IsWindVariable = groups[2].Value.Contains("VRB");


            if (groups[12].Success)
            {
                wind.IsWindDirectionVarying = true;
                wind.WindDirectionVariationRaw = groups[12].Value;
                wind.WindVariationLow = TryParseWithThrow(groups[13].Value);
                wind.WindVariationHigh = TryParseWithThrow(groups[14].Value);
            }
            return wind;
        }

        private static (string, WindUnit) GetUnit(string raw) => raw switch
        {
            "KT" => (WindDefinitions.KnotsLong, WindUnit.Knots),
            "MPH" => (WindDefinitions.MilesPerHourLong, WindUnit.MilesPerHour),
            "MPS" => (WindDefinitions.MetersPerSecondLong, WindUnit.MetersPerSecond),
            _ => throw new Exception("Could not convert Wind Unit")
        };

        private static int TryParseWithThrow(string value)
        {
            return int.TryParse(value, out int converted) ? converted : throw new Exception($"Could not convert value {value} to number");
        }
    }
}
