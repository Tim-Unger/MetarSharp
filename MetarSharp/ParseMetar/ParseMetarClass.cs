using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MetarSharp.Parse;

namespace MetarSharp
{
    internal class ParseMetar
    {
        public class RawMetarString
        {
            public static string RawMetar { get; set; }

            public static string RestOfMetar { get; set; }
        }

        public Metar ParseFromString(in string Metar, out Metar ParsedMetar)
        {
            RawMetarString.RawMetar = Metar;
            Metar Parsed = new Metar();

            Parsed.ReportingTime = ParseReportingTime.ReturnReportingTime(RawMetarString.RawMetar);

            Parsed.Wind = ParseWind.ReturnWind(RawMetarString.RawMetar);

            Parsed.IsAutomatedReport = ParseAuto.ReturnIsAutomated(RawMetarString.RawMetar);

            ParsedMetar = Parsed;
            return ParsedMetar;
        }

        public Metar ParseFromLink()
        {
            return null;
        }

        //public Metar Parse()
        //{

        //}
    }
}
