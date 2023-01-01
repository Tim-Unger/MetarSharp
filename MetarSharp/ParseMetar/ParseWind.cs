using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetarSharp.Parse
{
    public class ParseWind
    {
        public static Wind ReturnWind(string raw)
        {
            Wind wind = new Wind();

            Regex WindRegex = new Regex(
                @"((([0-9]{3})([0-9]{1,3})G([0-9]{1,3})(KT|MPH|MPS))|(([0-9]{3})([0-9]{1,3})(KT|MPH|MPS))|((VRB)([0-9]{1,3})(G([0-9]{1,3}))?(KT|MPH|MPS)))(\s([0-9]{3})V([0-9]{3}))?",
                RegexOptions.None
            );

            MatchCollection WindMatches = WindRegex.Matches(raw);

            if (WindMatches.Count == 1)
            {
                GroupCollection groups = WindMatches[0].Groups;
                wind.WindRaw = WindMatches[0].ToString();

                //Wind is not variable and not gusting
                if (groups[7].Success == true)
                {
                    if (string.Concat(groups[8].Value, groups[9].Value) == "00000")
                    {
                        wind.IsWindCalm = true;
                        wind.IsWindGusting = false;
                        wind.IsWindVariable = false;

                        return wind;
                    }

                    wind.IsWindCalm = false;
                    wind.IsWindGusting = false;
                    wind.IsWindVariable = false;

                    if (int.TryParse(groups[8].Value, out int windDirection))
                    {
                        wind.WindDirection = windDirection;
                    }
                    if (int.TryParse(groups[9].Value, out int windStrengthout))
                    {
                        wind.WindStrength = windStrengthout;
                    }

                    wind.WindUnitRaw = groups[10].Value;

                    string windUnitDecoded = null;
                    windUnitDecoded = groups[10].Value switch
                    {
                        "KT" => "Knots",
                        "MPH" => "Miles per Hour",
                        "MPS" => "Meters per Second",
                        _ => "Other",
                    };
                    wind.WindUnitDecoded = windUnitDecoded;

                    return wind;
                }

                //Wind is not variable and gusting
                wind.IsWindCalm = false;
                wind.IsWindGusting = true;
                wind.IsWindVariable = false;

                if (int.TryParse(groups[3].Value, out int WindDirection))
                {
                    wind.WindDirection = WindDirection;
                }
                if (int.TryParse(groups[3].Value, out int WindStrength))
                {
                    wind.WindStrength = WindStrength;
                }

                wind.WindUnitRaw = groups[6].Value;

                string WindUnitDecoded = null;
                switch (groups[6].Value)
                {
                    case "KT":
                        WindUnitDecoded = "Knots";
                        break;
                    case "MPH":
                        WindUnitDecoded = "Miles per Hour";
                        break;
                    case "MPS":
                        WindUnitDecoded = "Meters per Second";
                        break;
                }
                wind.WindUnitDecoded = WindUnitDecoded;

                if (int.TryParse(groups[5].Value, out int WindGusts))
                {
                    wind.WindGusts = WindGusts;
                }

                //Wind is variable
                wind.IsWindCalm = false;
                wind.IsWindVariable = true;
                //and gusting
                wind.IsWindGusting = groups[14].Success;

                if (int.TryParse(groups[13].Value, out int windStrength))
                {
                    wind.WindStrength = windStrength;
                }

                if (groups[14].Success == true)
                {
                    wind.WindDirection = null;

                    if (int.TryParse(groups[13].Value, out int windStrength2))
                    {
                        wind.WindStrength = windStrength2;
                    }

                    wind.WindUnitRaw = groups[16].Value;

                    string windUnitDecoded = null;
                    switch (groups[16].Value)
                    {
                        case "KT":
                            WindUnitDecoded = "Knots";
                            break;
                        case "MPH":
                            WindUnitDecoded = "Miles per Hour";
                            break;
                        case "MPS":
                            WindUnitDecoded = "Meters per Second";
                            break;
                    }
                    wind.WindUnitDecoded = WindUnitDecoded;

                    if (int.TryParse(groups[15].Value, out int WindGusts2))
                    {
                        wind.WindGusts = WindGusts2;
                    }
                }
                //and not gusting
                else
                {
                    wind.IsWindGusting = false;

                    wind.WindDirection = null;

                    if (int.TryParse(groups[13].Value, out int WindStrength2))
                    {
                        wind.WindStrength = WindStrength2;
                    }

                    wind.WindUnitRaw = groups[16].Value;

                    string windUnitDecoded = null;
                    switch (groups[16].Value)
                    {
                        case "KT":
                            windUnitDecoded = "Knots";
                            break;
                        case "MPH":
                            windUnitDecoded = "Miles per Hour";
                            break;
                        case "MPS":
                            windUnitDecoded = "Meters per Second";
                            break;
                    }
                    wind.WindUnitDecoded = windUnitDecoded;

                    wind.WindUnitRaw = groups[16].Value;
                }

                //wind has variations
                if (groups[17].Success == true)
                {
                    wind.isWindDirectionVarying = true;

                    wind.WindDirectionVariationRaw = groups[17].Value;

                    if (int.TryParse(groups[18].Value, out int WindVarLow))
                    {
                        wind.WindVariationLow = WindVarLow;
                    }
                    if (int.TryParse(groups[19].Value, out int WindVarHigh))
                    {
                        wind.WindVariationHigh = WindVarHigh;
                    }
                }
                else
                {
                    //wind has no variations
                    wind.isWindDirectionVarying = false;
                }
            }
            return wind;
        }

        //TODO Tests
        public static Wind ParseWindTemp(string raw)
        {
            Wind wind = new Wind();

            Regex windRegex = new Regex(
                @"((([0-9]{3})([0-9]{1,3})G([0-9]{1,3})(KT|MPH|MPS))|(([0-9]{3})([0-9]{1,3})(KT|MPH|MPS))|((VRB)([0-9]{1,3})(G([0-9]{1,3}))?(KT|MPH|MPS)))(\s([0-9]{3})V([0-9]{3}))?",
                RegexOptions.None
            );

            MatchCollection windMatches = windRegex.Matches(raw);

            if (windMatches.Count == 0)
            {
                throw new Exception("Wind value could not be found");
            }

            GroupCollection groups = windMatches[0].Groups;
            
            #region STANDARD
            //These always need to be set

            wind.WindRaw = groups[0].Value;

            wind.WindDirection = TryParseWithThrow(groups[3].Value);

            int windStrength = TryParseWithThrow(groups[4].Value);
            wind.WindStrength = windStrength;

            wind.IsWindCalm = windStrength == 0;

            wind.IsWindGusting = groups[5].Success;

            string windUnitRaw = groups[6].Value;

            wind.WindUnitRaw = windUnitRaw;

            (wind.WindUnitDecoded, wind.WindUnit) = GetUnit(windUnitRaw);

            #endregion


            wind.WindGusts = groups[5].Success ? TryParseWithThrow(groups[5].Value) : null;

            wind.IsWindVariable = groups[12].Success;


            if (groups[17].Success)
            {
                wind.isWindDirectionVarying = groups[17].Success;
                wind.WindDirectionVariationRaw = groups[17].Value;
                wind.WindVariationLow = TryParseWithThrow(groups[18].Value);
                wind.WindVariationHigh = TryParseWithThrow(groups[19].Value);
            }

            return wind;
        }

        private static Tuple<string, WindUnit> GetUnit(string raw) => raw switch
        {
            "KT" => new Tuple<string, WindUnit>("Knots", WindUnit.Knots),
            "MPH" => new Tuple<string, WindUnit>("Miles Per Hour", WindUnit.MilesPerHour),
            "MPS" => new Tuple<string, WindUnit>("Meters per Second", WindUnit.MetersPerSecond),
            _ => throw new Exception("Could not convert Wind Unit")
        };

        private static int TryParseWithThrow(string value)
        {
            return int.TryParse(value, out int converted) ? converted : throw new Exception($"Could not convert value {value} to number");
        }
    }
}
