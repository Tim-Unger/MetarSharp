namespace AviationSharp.Airports.Reader
{
    public class Country
    {
        public static string Get(string isoCode) => isoCode switch
        {
            "AG" => "Solomon Islands",
            "AN" => "Nauru",
            "AY" => "Papua New Guinea",
            "BG" => "Greenland",
            "BI" => "Iceland",
            "BK" => "Kosovo",
            "C" => "Canada",
            "DA" => "Algeria",
            "DB" => "Benin",
            "DF" => "Burkina Faso",
            "DG" => "Ghana",
            "DI" => "Ivory Coast",
            "DN" => "Nigeria",
            "DR" => "Niger",
            "DT" => "Tunisia",
            "DX" => "Togo",
            "EB" => "Belgium",
            "ED" => "Germany",
            "EE" => "Estonia",
            "EF" => "Finland",
            "EG" => "United Kingdom",
            "EH" => "Netherlands",
            _ => ""
        };
    }
}
