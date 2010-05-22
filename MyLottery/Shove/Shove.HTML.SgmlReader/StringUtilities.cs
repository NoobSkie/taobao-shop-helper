using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Shove.HTML.SgmlReader
{
    class StringUtilities
    {
        public static bool EqualsIgnoreCase(string a, string b)
        {
            return string.Compare(a, b, true, CultureInfo.InvariantCulture) == 0;
        }
    }
}
