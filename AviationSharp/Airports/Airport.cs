using AviationSharp.Airports;

namespace AviationSharp
{
    public class Airport
    {
        public string Icao { get; set; }
        public string Iata { get; set; }
        public string Name { get; set; }
        public List<decimal> Coordinates { get; set; } = new List<decimal>(2);
        public long Elevation { get; set; }
        public IcaoRegion IcaoRegion { get; set; } 

        //TODO change to IcaoCountry
        public string Country { get; set; }
        public string City { get; set; }
        public bool HasScheduledService { get; set; }
        public List<Runway> Runways { get; set; }
        public List<Frequency> Frequencies { get; set; }
    }

    public class Runway
    {
        public double LengthFeet { get; set; }
        public double LengthMeter { get; set; }
        public string Identifier { get; set; }
        public double? Elevation { get; set; }
        public double? TrueHeading { get; set; }
    }

    public class Frequency
    {
        public double FrequencyMhz { get; set; }
        public string FrequencyMhzString { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class AirportDTO
    {
        public string id { get; set; }
        public string ident { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string latitude_deg { get; set; }
        public string longitude_deg { get; set; }
        public string elevation_ft { get; set; }
        public string continent { get; set; }
        public string iso_country { get; set; }
        public string iso_region { get; set; }
        public string municipality { get; set; }
        public string scheduled_service { get; set; }
        public string gps_code { get; set; }
        public string iata_code { get; set; }
        public string local_code { get; set; }
        public string home_link { get; set; }
        public string wikipedia_link { get; set; }
        public string keywords { get; set; }
        public List<RunwayDTO> Runways { get; set; } = Enumerable.Empty<RunwayDTO>().ToList();
        public List<FrequencyDTO> Frequencies { get; set; } = Enumerable.Empty<FrequencyDTO>().ToList();
    }

    public class RunwayDTO
    {
        public string id { get; set; }
        public string airport_ref { get; set; }
        public string airport_ident { get; set; }
        public string length_ft { get; set; }
        public string width_ft { get; set; }
        public string surface { get; set; }
        public string lighted { get; set; }
        public string closed { get; set; }
        public string le_ident { get; set; }
        public string le_latitude_deg { get; set; }
        public string le_longitude_deg { get; set; }
        public string le_elevation_ft { get; set; }
        public string le_heading_degT { get; set; }
        public string le_displaced_threshold_ft { get; set; }
        public string he_ident { get; set; }
        public string he_latitude_deg { get; set; }
        public string he_longitude_deg { get; set; }
        public string he_elevation_ft { get; set; }
        public string he_heading_degT { get; set; }
        public string he_displaced_threshold_ft { get; set; }
    }

    public class FrequencyDTO
    {
        public string id { get; set; }
        public string airport_ref { get;set; }
        public string airport_ident { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string frequency_mhz { get; set; }
    }
}
