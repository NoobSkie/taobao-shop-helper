using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.StringTool
{
    public static class EncodeHelper
    {
        public static string GB2312ToUTF8(string str)
        {
            try
            {
                Encoding uft8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] temp = gb2312.GetBytes(str);
                byte[] temp1 = Encoding.Convert(gb2312, uft8, temp);
                return uft8.GetString(temp1);
            }
            catch
            {
                return str;
            }
        }
    }
}
