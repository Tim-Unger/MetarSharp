using MetarSharp.Definitions;
using System.Text.RegularExpressions;

namespace MetarSharp.Parse
{
    public class ParseRVR
    {
        public static List<RunwayVisibility> ReturnRVR(string raw)
        {
            List<RunwayVisibility> runwayVisibilities = new List<RunwayVisibility>();

            Regex RVRRegex = new Regex(
                "R(([0-9]{2})(L|R|C)?)/(P|M)?([0-9]{4})(?:(V?(P|M)?([0-9]{4})?))(U|D|N)",
                RegexOptions.None
            );

            foreach (Match match in RVRRegex.Matches(raw).Cast<Match>())
            {
                RunwayVisibility runwayVisibility = new RunwayVisibility();

                runwayVisibility.RunwayVisibilityRaw = match.ToString();

                GroupCollection groups = match.Groups;

                runwayVisibility.Runway = groups[1].Value;

                //runwayVisibility.ParallelRunwayDesignator = groups[3].Success
                //    ? groups[3].Value
                //    : null;

                runwayVisibility.ParallelRunwayDesignatorDecoded = groups[3].Value switch
                {
                    "L" => RunwayDefinition.LeftRunwayLong,
                    "C" => RunwayDefinition.CenterRunwayLong,
                    "R" => RunwayDefinition.RightRunwayLong,
                    null or "" => null,
                    _
                      => throw new Exception(
                          $"Could not read Runway Designator of RVR runway {groups[1].Value}"
                      )
                };

                runwayVisibility.RunwayVisualRange = int.TryParse(groups[5].Value, out int _rvr)
                  ? _rvr
                  : throw new Exception(
                        $"Could not Convert Runway Visual Range of Runway {groups[1].Value} to Number"
                    );

                runwayVisibility.IsRVRValueMoreOrLess = groups[4].Success ? true : null;

                runwayVisibility.RVRMoreOrLessDecoded = groups[4].Value switch
                {
                    "M" => "Less",
                    "P" => "More",
                    null or "" => "",
                    _
                      => throw new Exception(
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
                      => throw new Exception(
                          $"Could not read RVR-Tendency for Runway {groups[1].Value}"
                      )
                };

                runwayVisibility.IsRVRVarying = groups[6].Success ? true : null;
                runwayVisibility.IsRVRVariationMoreOrLess = groups[7].Success ? true : null;

                runwayVisibility.RVRVariationMoreOrLessDecoded = groups[7].Value switch
                {
                    "M" => RVRDefinitions.ValueLessThanLong,
                    "P" => RVRDefinitions.ValueMoreThanLong,
                    null or "" => null,
                    _ => ""
                };

                runwayVisibility.RVRVariationValue = int.TryParse(groups[8].Value, out int rvrVar)
                  ? rvrVar
                  : null;

                runwayVisibilities.Add(runwayVisibility);
            }

            return runwayVisibilities;
        }
    }
}
