using MetarSharp.Definitions;
using MetarSharp.Exceptions;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    internal class ParseRVR
    {
        internal static List<RunwayVisibility> ReturnRVR(string raw)
        {
            var runwayVisibilities = new List<RunwayVisibility>();

            var RVRRegex = new Regex(
                "R(([0-9]{2})(L|R|C)?)/(P|M)?([0-9]{4})(?:(V?(P|M)?([0-9]{4})?))(U|D|N)",
                RegexOptions.None
            );

            foreach (Match match in RVRRegex.Matches(raw).Cast<Match>())
            {
                var runwayVisibility = new RunwayVisibility();

                runwayVisibility.RunwayVisibilityRaw = match.ToString();

                GroupCollection groups = match.Groups;

                runwayVisibility.Runway = groups[1].Value;

                runwayVisibility.ParallelRunwayDesignatorDecoded = groups[3].Value switch
                {
                    "L" => RunwayDefinition.LeftRunwayLong,
                    "C" => RunwayDefinition.CenterRunwayLong,
                    "R" => RunwayDefinition.RightRunwayLong,
                    null or "" => null,
                    _
                      => throw new ParseException(
                          $"Could not read Runway Designator of RVR runway {groups[1].Value}"
                      )
                };

                runwayVisibility.RunwayVisualRange = int.TryParse(groups[5].Value, out var rvr)
                  ? rvr
                  : throw new ParseException(
                        $"Could not Convert Runway Visual Range of Runway {groups[1].Value} to Number"
                    );

                runwayVisibility.IsRVRValueMoreOrLess = groups[4].Success ? true : null;

                runwayVisibility.RVRMoreOrLessDecoded = groups[4].Value switch
                {
                    "M" => "Less",
                    "P" => "More",
                    null or "" => "",
                    _
                      => throw new ParseException(
                          $"Could not read RVR-More or Less Value of Runway {groups[1].Value}"
                      )
                };

                (
                    runwayVisibility.RVRTendencyRaw,
                    runwayVisibility.RVRTendencyDecoded
                ) = groups[9].Value switch
                {
                    "U" => (RVRDefinitions.TendencyDownwardShort, RVRDefinitions.TendencyUpwardLong),
                    "N" => (RVRDefinitions.TendencyStagnantShort, RVRDefinitions.TendencyStagnantLong),
                    "D" => (RVRDefinitions.TendencyDownwardShort, RVRDefinitions.TendencyDownwardLong),
                    _
                      => throw new ParseException(
                          $"Could not read RVR-Tendency for Runway {groups[1].Value}"
                      )
                };

                runwayVisibility.IsRVRVarying = groups[6].Value != "";
                runwayVisibility.IsRVRVariationMoreOrLess = groups[7].Success ? true : null;

                runwayVisibility.RVRVariationMoreOrLessDecoded = groups[7].Value switch
                {
                    "M" => RVRDefinitions.ValueLessThanLong,
                    "P" => RVRDefinitions.ValueMoreThanLong,
                    null or "" => null,
                    _ => ""
                };

                runwayVisibility.RVRVariationValue = int.TryParse(groups[8].Value, out var rvrVar)
                  ? rvrVar
                  : null;

                runwayVisibilities.Add(runwayVisibility);
            }

            return runwayVisibilities;
        }
    }
}
