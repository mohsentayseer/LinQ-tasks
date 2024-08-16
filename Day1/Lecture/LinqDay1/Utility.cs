using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDay1
{
    internal static class Utility
    {
        public static string YaRoka(this string str, string Appended)
        {
            return str + $" {Appended}";
        }
    }
}
