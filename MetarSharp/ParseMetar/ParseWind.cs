using System;
using System.Collections.Generic;
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
                GroupCollection Groups = WindMatches[0].Groups;
                wind.WindRaw = WindMatches[0].ToString();

                //Wind is not variable and not gusting
                if (Groups[7].Success == true)
                {
                    if (string.Concat(Groups[8].Value, Groups[9].Value) == "00000")
                    {
                        wind.IsWindCalm = true;
                        wind.IsWindGusting = false;
                        wind.IsWindVariable = false;

                        return wind;
                    }
                    
                    wind.IsWindCalm = false;
                    wind.IsWindGusting = false;
                    wind.IsWindVariable = false;

                    if (int.TryParse(Groups[8].Value, out int windDirection))
                    {
                        wind.WindDirection = windDirection;
                    }
                    if (int.TryParse(Groups[9].Value, out int windStrength))
                    {
                        wind.WindStrength = windStrength;
                    }

                    wind.WindUnitRaw = Groups[10].Value;

                    string windUnitDecoded = null;
                    windUnitDecoded = Groups[10].Value switch
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

                if (int.TryParse(Groups[3].Value, out int WindDirection))
                {
                    wind.WindDirection = WindDirection;
                }
                if (int.TryParse(Groups[3].Value, out int WindStrength))
                {
                    wind.WindStrength = WindStrength;
                }

                wind.WindUnitRaw = Groups[6].Value;

                string WindUnitDecoded = null;
                switch (Groups[6].Value)
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

                if (int.TryParse(Groups[5].Value, out int WindGusts))
                {
                    wind.WindGusts = WindGusts;
                }

                //Wind is variable
                wind.IsWindCalm = false;
                wind.IsWindVariable = true;
                //and gusting
                wind.IsWindGusting = Groups[14].Success;

                if (int.TryParse(Groups[13].Value, out int windStrength))
                {
                    wind.WindStrength = windStrength;
                }

                if (Groups[14].Success == true)
                {
                    wind.WindDirection = null;

                    if (int.TryParse(Groups[13].Value, out int windStrength))
                    {
                        wind.WindStrength = WindStrength;
                    }

                    wind.WindUnitRaw = Groups[16].Value;

                    string windUnitDecoded = null;
                    switch (Groups[16].Value)
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

                    if (int.TryParse(Groups[15].Value, out int WindGusts))
                    {
                        wind.WindGusts = WindGusts;
                    }
                }
                //and not gusting
                else
                {
                    wind.IsWindGusting = false;

                    wind.WindDirection = null;

                    if (int.TryParse(Groups[13].Value, out int WindStrenght))
                    {
                        wind.WindStrength = WindStrenght;
                    }

                    wind.WindUnitRaw = Groups[16].Value;

                    string windUnitDecoded = null;
                    switch (Groups[16].Value)
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

                    wind.WindUnitRaw = Groups[16].Value;

                }
                }

                //wind has variations
                if (Groups[17].Success == true)
                {
                    wind.isWindDirectionVarying = true;

                    wind.WindDirectionVariationRaw = Groups[17].Value;

                    if (int.TryParse(Groups[18].Value, out int WindVarLow))
                    {
                        wind.WindVariationLow = WindVarLow;
                    }
                    if (int.TryParse(Groups[19].Value, out int WindVarHigh))
                    {
                        wind.WindVariationHigh = WindVarHigh;
                    }
                }
                else
                {
                    //wind has no variations
                    wind.isWindDirectionVarying = false;
                }
            
            return wind;
        }
    }
}
