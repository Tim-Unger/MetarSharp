using System.Text.RegularExpressions;
using static MetarSharp.Extensions.TryParseExtensions;

namespace MetarSharp.Taf.Parse
{
    internal class ParseValidity
    {
        internal static Validity ReturnValidity(string raw)
        {
            var validity = new Validity();

            var validityRegex = new Regex("([0-9]{2})([0-9]{2})/([0-9]{2})([0-9]{2})");

            var tafValidityGroups = validityRegex.Matches(raw)[0].Groups;

            validity.ValidityRaw = tafValidityGroups[0].Value;

            var startDay = IntTryParseWithThrow(tafValidityGroups[1].Value);
            var startHour = IntTryParseWithThrow(tafValidityGroups[2].Value);

            validity.StartWindowRaw = $"{startDay}{startHour}";

            validity.StartDay = startDay;

            validity.StartHour = startHour;

            //TODO
            //validity.StartDateTime 

            var endDay = IntTryParseWithThrow(tafValidityGroups[3].Value);
            var endHour = IntTryParseWithThrow(tafValidityGroups[4].Value);

            validity.EndWindowRaw = $"{endDay}{endHour}";

            validity.EndDay = endDay;

            validity.EndHour = endHour;

            //TODO
            //validity.EndDateTime

            //TODO
            //validity.ValidityDuration

            return validity;
        }
    }
}
