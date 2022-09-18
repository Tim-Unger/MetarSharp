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

            wind.WindRaw = raw;

            Regex WindRegex = new Regex(
                @"([0-9]{3})([0-9]{1,2})((G)?(?:([0-9]{1,3})))([A-Z]{2,3})(?(\s(?:(([0-9]{3})V([0-9]{3})))))",
                RegexOptions.None
            );

            Regex VariableWindRegex = new Regex(
                @"(VRB)[0-9]{1,2}(G)?(?:([0-9]{1,3}))[A-Z]{2,3}(?(\s(?:(([0-9]{3})V([0-9]{3})))))",
                RegexOptions.None
            );

            MatchCollection WindMatches = WindRegex.Matches(raw);

            if (WindMatches.Count == 1)
            {
                wind.IsWindVariable = false;

                GroupCollection Groups = WindMatches[0].Groups;

                if (Groups[1].Value == "00000")
                {
                    wind.IsWindCalm = true;
                }
                else
                {
                    wind.IsWindCalm = false;
                }

                if (Groups[3].Success == false)
                {
                    if (int.TryParse(Groups[1].Value, out int WindDirection))
                    {
                        wind.WindDirection = WindDirection;
                    }

                    //TODO
                    string WindStrengthString = string.Concat(Groups[2], Groups[4]);
                    if (int.TryParse(WindStrengthString, out int WindStrength))
                    {
                        wind.WindStrength = WindStrength;
                    }
                }
                else
                {
                    wind.IsWindGusting = true;

                    
                    if (int.TryParse(Groups[2].Value, out int WindStrength))
                    {
                        wind.WindStrength = WindStrength;
                    }

                    if (int.TryParse(Groups[1].Value, out int WindDirection))
                    {
                        wind.WindDirection = WindDirection;
                    }

                    if (int.TryParse(Groups[5].Value, out int WindGusts))
                    {
                        wind.WindGusts = WindGusts;
                    }
                }

                if (Groups[7].Success == true)
                {
                    wind.isWindDirectionVarying = true;
                    wind.WindVarRaw = Groups[7].Value;

                    if (int.TryParse(Groups[8].Value, out int WindVarLow))
                    {
                        wind.WindVarLow = WindVarLow;
                    }
                    if (int.TryParse(Groups[9].Value, out int WindVarHigh))
                    {
                        wind.WindVarHigh = WindVarHigh;
                    }
                }

                wind.WindUnit = Groups[6].Value;
            }
            //TODO

            else if (WindMatches.Count == 0)
            {
                MatchCollection VarWindMatches = VariableWindRegex.Matches(raw);

                if (VarWindMatches.Count == 1)
                {
                    wind.IsWindVariable = true;
                    wind.IsWindCalm = false;

                    wind.WindDirection = null;
                }
            }

            return wind;
        }
    }
}
