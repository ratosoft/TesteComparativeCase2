using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteComparativeCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "CACAO";
            var s2 = "cação";

            var result = string.Compare(s1.ToUpper(), s2.ToUpper(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace);
        }
    }
}
