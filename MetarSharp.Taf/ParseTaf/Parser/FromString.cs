﻿using MetarSharp.Taf.Parse;

namespace MetarSharp.Taf.Parser
{
    internal class FromString
    {
        internal static Taf Parse(string input) 
        {
            var parsed = new Taf();

            parsed.Airport = ParseAirport.ReturnAirport(input);

            parsed.ReportingTime = ParseReportingTime.ReturnReportingTime(input); 

            parsed.Validity = ParseValidity.ReturnValidity(input);
            return parsed;
        }
    }
}
