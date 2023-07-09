using AirportDataUploader;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AviationSharp.Airports.Reader
{
    internal class Airac
    {
        public int CycleNumberInYear { get; init; }
        public int Ident { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
    }

    internal class AiracDTO
    {
        public int cycleNumberInYear { get; init; }
        public int ident { get; init; }
        public string startDate { get; init; }
        public string endDate { get; init; }
    }

    public class AirportJson
    {
        private static readonly List<RunwayDTO> _runways = Runways
            .Read()
            .OrderBy(x => int.Parse(x.airport_ref))
            .ToList();

        private static readonly List<FrequencyDTO> _frequencies = Frequencies
            .Read()
            .OrderBy(x => int.Parse(x.airport_ref))
            .ToList();

        public static void Write()
        {
            var airports = Airports.ReadToDTO();

            Parallel.ForEach(airports, x => x.Runways = FindRunways(int.Parse(x.id)));
            Parallel.ForEach(airports, x => x.Frequencies = FindFrequencies(int.Parse(x.id)));

            var airportsConverted = airports
                .Select(
                    x =>
                        new Airport()
                        {
                            Icao = x.ident,
                            Iata = x.iata_code ?? "",
                            Name = x.name,
                            Coordinates = new List<decimal>()
                            {
                                decimal.Parse(x.latitude_deg),
                                decimal.Parse(x.longitude_deg)
                            },
                            Elevation = x.elevation_ft != "" ? long.Parse(x.elevation_ft) : 0,
                            IcaoRegion = Region.Get(x.ident),
                            Country = Country.Get(x.iso_country),
                            City = x.municipality,
                            HasScheduledService = x.scheduled_service == "yes",
                            Runways = ConvertRunways(x.Runways),
                            Frequencies = ConvertFrequencies(x.Frequencies)
                        }
                )
                .ToList();

            var currentAirac = new HttpClient()
                .GetStringAsync("https://api.tim-u.me/airacs/current")
                .Result;

            var airacDTO = JsonSerializer.Deserialize<AiracDTO>(currentAirac);

            var airac = new Airac()
            {
                CycleNumberInYear = airacDTO.cycleNumberInYear,
                Ident = airacDTO.ident,
                StartDate = DateOnly.Parse(airacDTO.startDate),
                EndDate = DateOnly.Parse(airacDTO.endDate),
            };

            var json = new AirportDataUploader.AirportJson()
            {
                Airac = airac!.Ident,
                AirportCount = airportsConverted.Count,
                Airports = airportsConverted
            };

            var jsonString = JsonSerializer.Serialize(
                json,
                new JsonSerializerOptions() { WriteIndented = true }
            );

            File.WriteAllText(
                $"{Environment.CurrentDirectory}/DataFiles/Airports.json",
                jsonString
            );
        }

        private static List<Runway> ConvertRunways(List<RunwayDTO> runways)
        {
            var convertedRunways = new List<Runway>();

            foreach (RunwayDTO runway in runways)
            {
                var length = runway.length_ft;

                var convertLength = length != "" ? double.Parse(length) : 0;

                var lengthMeter = Math.Round(double.Parse(convertLength.ToString()) / 3.281, 2);

                var firstRunway = new Runway()
                {
                    LengthFeet = convertLength,
                    LengthMeter = lengthMeter,
                    Identifier = runway.le_ident,
                    Elevation =
                        runway.le_elevation_ft != "" ? double.Parse(runway.le_elevation_ft) : null,
                    TrueHeading =
                        runway.le_heading_degT != "" ? double.Parse(runway.le_heading_degT) : null
                };

                var secondRunway = new Runway()
                {
                    LengthFeet = convertLength,
                    LengthMeter = lengthMeter,
                    Identifier = runway.he_ident,
                    Elevation =
                        runway.he_elevation_ft != "" ? double.Parse(runway.he_elevation_ft) : null,
                    TrueHeading =
                        runway.he_heading_degT != "" ? double.Parse(runway.he_heading_degT) : null
                };

                convertedRunways.Add(firstRunway);
                convertedRunways.Add(secondRunway);
            }

            return convertedRunways;
        }

        private static List<RunwayDTO> FindRunways(int id)
        {
            if (_runways.Count == 0)
            {
                return Enumerable.Empty<RunwayDTO>().ToList();
            }

            var runways = new List<RunwayDTO>();
            foreach (RunwayDTO runway in _runways)
            {
                if (int.Parse(runway.airport_ref) == id)
                {
                    runways.Add(runway);
                }
            }

            if (runways.Count == 0)
            {
                return Enumerable.Empty<RunwayDTO>().ToList();
            }

            return runways;
        }

        private static List<Frequency> ConvertFrequencies(List<FrequencyDTO> frequencies) =>
            frequencies
                .Select(
                    x =>
                        new Frequency()
                        {
                            FrequencyMhz = double.Parse(x.frequency_mhz),
                            FrequencyMhzString = x.frequency_mhz,
                            Type = x.type,
                            Description = x.description
                        }
                )
                .ToList();

        private static List<FrequencyDTO> FindFrequencies(int id)
        {
            if (_frequencies.Count == 0)
            {
                return Enumerable.Empty<FrequencyDTO>().ToList();
            }

            var frequencies = new List<FrequencyDTO>();
            foreach (FrequencyDTO frequency in _frequencies)
            {
                if (int.Parse(frequency.airport_ref) == id)
                {
                    frequencies.Add(frequency);
                }
            }

            if (frequencies.Count == 0)
            {
                return Enumerable.Empty<FrequencyDTO>().ToList();
            }

            return frequencies;
        }
    }
}
