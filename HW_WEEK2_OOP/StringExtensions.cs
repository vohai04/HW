using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_oop
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if (source == null || value == null)
                return false;
            return source.Contains(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
