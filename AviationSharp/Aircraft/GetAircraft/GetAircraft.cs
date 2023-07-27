using System.Text.Json;

namespace AviationSharp.Aircraft
{
    public partial class Aircraft
    {
        public static List<Aircraft> GetAll()
        {
            var content = File.ReadAllText($"{Environment.CurrentDirectory}/DataFiles/Aircraft.json");
            
            var aircraftRaw = JsonSerializer.Deserialize<List<AircraftDTO>>(content) ?? throw new Exception();

            return aircraftRaw.Select(x => new Aircraft()
            {
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                TypeDesignator = x.TypeDesignator,
                AircraftType = GetAcType(x.AircraftType),
                EngineType = GetEngType(x.EngineType),
                EngineCount = int.TryParse(x.EngineCount, out var count) ? count : null,
                WakeTurbulenceCategory = GetWtc(x.WakeTurbulenceCategory),
                WakeTurbulenceCategoryShort = x.WakeTurbulenceCategory
            })
            .ToList();
        }

        private static AircraftType GetAcType(string raw) => raw switch
        {
            "LandPlane" => AircraftType.LandPlane,
            "Amphibian" => AircraftType.Amphibian,
            "Helicopter" => AircraftType.Helicopter,
            "Gyrocopter" => AircraftType.Gyrocopter,
            "Tiltrotor" => AircraftType.TiltRotor,
            "SeaPlane" => AircraftType.SeaPlane,
            _ => AircraftType.Unknown
        };

        private static EngineType GetEngType(string raw) => raw switch
        {
            "Jet" => EngineType.Jet,
            "Piston" => EngineType.Piston,
            "Turboprop/Turboshaft" => EngineType.Turboprop,
            "Electric" => EngineType.Electric,
            "Rocket" => EngineType.Rocket,
            _ => EngineType.Unknown
        };

        private static WakeTurbulenceCategory GetWtc(string raw) => raw switch
        {
            "L" => WakeTurbulenceCategory.Light,
            "M" => WakeTurbulenceCategory.Medium,
            "H" => WakeTurbulenceCategory.Heavy,
            "J" => WakeTurbulenceCategory.Super,
            "L/M" => WakeTurbulenceCategory.LightMedium,
            "M/H" => WakeTurbulenceCategory.MediumHeavy
        };
    }
}