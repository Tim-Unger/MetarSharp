namespace MetarSharp.Parse.ReadableReport
{
    internal class Visibility
    {
        /// <summary>
        /// This appends the visibility as a readable string
        /// </summary>
        /// <param name="metar"></param>
        /// <returns></returns>
        internal static string Append(Metar metar)
        {
            string visibility = null;
            //TODO CAVOK
            if (metar.Visibility.IsVisibilityMeasurable == false)
            {
                return "Visibility not measurable";
            }

            if(metar.Clouds.Any(x => x.IsCAVOK))
            {
                return "Ceiling and Visibility okay";
            }

            visibility =
                "Visibility: "
                + metar.Visibility.ReportedVisibility
                + " "
                + metar.Visibility.VisibilityUnitDecoded
                + " ";


            if (metar.Visibility.HasVisibilityLowestValue)
            {
                string lowestVisibility =
                    "Lowest Visibility: "
                    + metar.Visibility.LowestVisibility
                    + " "
                    + metar.Visibility.VisibilityUnitDecoded
                    + " in the"
                    + metar.Visibility.LowestVisibilityDirectionDecoded
                    + " ";

                return visibility + lowestVisibility;
            }

            return visibility;
        }
    }
}
