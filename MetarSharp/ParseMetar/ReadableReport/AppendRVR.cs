using System.Text;

namespace MetarSharp.Parse.ReadableReport
{
    internal class RVR
    {
        /// <summary>
        /// Appends the RVR to the readable report
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        internal static string Append(Metar metar)
        {
            var stringBuilder = new StringBuilder();
            //Null check on RunwayVisibilities is done one level further up
            foreach (var RVR in metar.RunwayVisibilities!)
            {
                var visibility = new StringBuilder();

                visibility.Append($"Runway-Visibility for Runway {RVR.Runway} ");

                if (RVR.IsRVRValueMoreOrLess == true)
                {
                    visibility.Append($"Runway Visual Range: {RVR.RVRMoreOrLessDecoded} than {RVR.RunwayVisualRange} Meter ");
                    continue;
                }

                visibility.Append("Runway Visual Range: " + RVR.RunwayVisualRange + " Meter ");

                string variation = null;
                if (RVR.IsRVRVarying == true)
                {
                    if (RVR.IsRVRVariationMoreOrLess == true)
                    {
                        variation = $"Variating up to: {RVR.RVRVariationMoreOrLessDecoded} than {RVR.RVRVariationValue} Meter";
                        continue;
                    }

                    variation = "Variating up to: " + RVR.RVRVariationValue + " Meter";
                }

                var tendency = $" {RVR.RVRTendencyDecoded}";
                
                stringBuilder.AppendLine($"{visibility} {variation} {tendency}");
            }

            return stringBuilder.ToString();
        }
    }
}
