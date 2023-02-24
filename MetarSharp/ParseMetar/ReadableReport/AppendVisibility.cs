﻿using MetarSharp.Exceptions;
using static MetarSharp.Extensions.Extensions;

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

            if (metar.Visibility.IsVisibilityMeasurable == false)
            {
                return "Visibility not measurable";
            }

            if(metar.Clouds.Any(x => x.IsCAVOK))
            {
                return "Ceiling and Visibility okay";
            }

            string visibilityUnit = DistanceValueSingularOrPlural(metar.Visibility.ReportedVisibility, metar.Visibility.VisibilityUnit);

            visibility =
                "Visibility: "
                + metar.Visibility.ReportedVisibility
                + " "
                + visibilityUnit
                + " ";


            if (metar.Visibility.HasVisibilityLowestValue)
            {
                string lowestVisibility =
                    "Lowest Visibility: "
                    + metar.Visibility.LowestVisibility
                    + " "
                    + visibilityUnit
                    + " in the"
                    + metar.Visibility.LowestVisibilityDirectionDecoded
                    + " ";

                return visibility + lowestVisibility;
            }

            return visibility ?? throw new ParseException();
        }

    }
}
