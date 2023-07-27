namespace AviationSharp.Aircraft
{
    public class SpecialDesignator
    {
        public string Model { get; set; }
        public string Designator { get; set; }
    }

    public partial class Aircraft
    {
        public static List<SpecialDesignator> GetSpecialDesignators()
        {
            return new List<SpecialDesignator>()
            {
                new SpecialDesignator
                {
                    Model = "Aircraft Without Designator",
                    Designator = "ZZZZ"
                },
                new SpecialDesignator
                {
                    Model = "Airship",
                    Designator = "SHIP"
                },
                new SpecialDesignator
                {
                    Model = "Balloon",
                    Designator = "BALL"
                },
                new SpecialDesignator
                {
                    Model = "Glider",
                    Designator = "GLID"
                },
                new SpecialDesignator
                {
                    Model = "Microlight/Ultralight Aircraft",
                    Designator = "ULAC"
                },
                new SpecialDesignator
                {
                    Model = "Microlight/Ultralight Autogyro",
                    Designator = "GYRO"
                },
                new SpecialDesignator
                {
                    Model = "Microlight/Ultralight Helicopter",
                    Designator = "UHEL"
                },
                new SpecialDesignator
                {
                    Model = "Powered Parachute/Paraplane",
                    Designator = "PARA"
                },
                new SpecialDesignator
                {
                    Model = "Sailplane",
                    Designator = "GLID"
                },
            };
        }
    }
}
