using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Tests
{
    internal class GetMetars
    {
        public static List<string> Metars()
        {
            var letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            List<string> returnMetars = new List<string>();

            Random rand = new Random();


            List<string> airports = new List<string>();
            for (int x = 0; x < 500; x++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int y = 0; y < 4; y++)
                {
                    int letterIndex = rand.Next(0, 26);
                    stringBuilder.Append(letters[letterIndex]);
                }

                airports.Add(stringBuilder.ToString());
            }
            return returnMetars;
        }
    }
}
