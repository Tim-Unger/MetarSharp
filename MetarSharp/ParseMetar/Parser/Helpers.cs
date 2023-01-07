using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarSharp.Parser
{
    internal class Helpers
    {
        internal static bool IsStringNullOrEmpty(string input)
        {
            return input == null || input == String.Empty || input == "" || String.IsNullOrWhiteSpace(input)
        }

        internal static bool IsEntireCollectionNullOrEmpty<T>(T input)
        {
            return T == null || T == Enumerable.Empty<T>();
        }

        internal static void RemoveEmptyEntriesFromCollection<T>(T input)
        {
            return T.Where(x => x != IsNullOrWhiteSpace(x));
        }
    }
}
