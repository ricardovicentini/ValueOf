using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueOf.Demo
{
    public static class StringExtensions
    {
        public static string RemoverNaoNumericos(this string input)
        {
            return string.Concat(input.Where(c => char.IsDigit(c)).Select(c => c));
        }
    }
}
