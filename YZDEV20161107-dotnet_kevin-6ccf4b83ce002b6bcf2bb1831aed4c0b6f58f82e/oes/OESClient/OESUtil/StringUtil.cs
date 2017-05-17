using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESUtil
{
    public class StringUtil
    {
        public static string FilterSearchString(string content)
        {
            content = content.Replace("%", "\\\\%").Replace("_", "\\\\_");
            return content;
        }
    }
}
