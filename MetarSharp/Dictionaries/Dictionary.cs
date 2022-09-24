using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Dictionaries
{
    public class Dictionary
    {
        public static Dictionary<string, string> MainDictionary = new Dictionary<string, string>
        {
            //Sped Units
            { "KT", "Knots" },
            { "MPH", "Miles per Hour" },
            { "MPS", "Meters per Second" },
            //Pressure Units
            { "QNH", "Hectopascals" },
            { "A", "Inches Mercury" },
            //Cloud Descriptions
            { "FEW", "Few Clouds" },
            { "SCT", "Scattered Clouds" },
            { "BKN", "Broken Clouds" },
            { "OVC", "Overcast Clouds" },
            { "NSC", "No Significant Clouds" },
            { "NCD", "No Clouds Detected" },
            //Cloud Descriptions
            { "CB", "Cumulonimbus Clouds" },
            { "TCU", "Towering Cumulonimbus Clouds" },
            //Runway Designators
            { "L", "Left" },
            { "C", "Center" },
            { "R", "Right" },
            //RVR Distance Indicators
            { "M", "Less" },
            { "P", "More" },
            //RVR Tendency
            { "U", "Upward" },
            { "N", "Stagnant" },
            { "D", "Downward" },
            //Cardinal Directions
            { "N", "North" },
            { "NE", "North-East" },
            { "E", "East" },
            { "SE", "South-East" },
            { "S", "South" },
            { "SW", "South-West" },
            { "W", "West" },
            { "NW", "North-West" },
            //Distance Directions
            { "SM", "Statute Miles" },
            { "M", "Meters" },
            //Weather Strenght
            { "-", "Light" },
            { "\\+", "Strong" },
            { "VC", "In The Vicinity" },
            //Weather Events
            { "MI", "Shallow" },
            { "BC", "Patches" },
            { "PR", "Partial" },
            { "DR", "Low Drifting" },
            { "BL", "Blowing" },
            { "SH", "Shower" },
            { "TS", "Thunderstorm" },
            { "FZ", "Freezing" },
            { "DZ", "Drizzle" },
            { "RA", "Rain" },
            { "SN", "Snow" },
            { "SG", "Snow Grains" },
            { "PL", "Ice Pellets" },
            { "GR", "Hail" },
            { "GS", "Small Hail" },
            { "UP", "Unknown" },
            {"BR", "Mist"},
            {"FG", "Fog" },
            {"FU", "Smoke" },
            {"VA", "Volcanic Ash" },
            {"DU", "Widespread Dust" },
            {"SA", "Sand" },
            {"HZ", "Haze" },
            {"PO", "Dust Whirls" },
            {"SQ", "Squall" },
            {"FC", "Tornado" },
            {"SS", "Sandstorm" },
            {"DS", "Duststorm" }
        };
    }
}
