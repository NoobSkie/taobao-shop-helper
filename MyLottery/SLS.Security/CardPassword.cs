namespace SLS.Security
{
    using Shove;
    using System;
    using System.Text.RegularExpressions;

    public class CardPassword
    {
        public static string GenNumber(string CallCert, int AgentID, long CardPasswordID)
        {
            if (CallCert != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                throw new Exception("Call the CardPassword.GenNumber is request a CallCert.");
            }
            string str = AgentID.ToString() + CardPasswordID.ToString().PadLeft(12, '0');
            double a = 1.0;
            int num2 = 0;
            for (int i = 0; i < str.Length; i++)
            {
                num2 = int.Parse(str.Substring(i, 1));
                if (str.Substring(i, 1) == "0")
                {
                    num2 = i + 1;
                }
                a *= num2;
            }
            string str2 = Math.Sin(a).ToString();
            string str3 = "";
            for (int j = 0; j < str2.Length; j++)
            {
                if (("123456789".IndexOf(str2.Substring(j, 1)) >= 0) && (str3.Length < 4))
                {
                    str3 = str3 + str2.Substring(j, 1);
                }
            }
            int[,] numArray = new int[10, 4];
            numArray[0, 0] = 1;
            numArray[1, 0] = 2;
            numArray[2, 0] = 1;
            numArray[3, 0] = 1;
            numArray[4, 0] = 0;
            numArray[5, 0] = 1;
            numArray[6, 0] = 1;
            numArray[7, 0] = 0;
            numArray[8, 0] = 0;
            numArray[9, 0] = 1;
            numArray[0, 1] = 4;
            numArray[1, 1] = 3;
            numArray[2, 1] = 2;
            numArray[3, 1] = 3;
            numArray[4, 1] = 6;
            numArray[5, 1] = 5;
            numArray[6, 1] = 4;
            numArray[7, 1] = 1;
            numArray[8, 1] = 5;
            numArray[9, 1] = 5;
            numArray[0, 2] = 10;
            numArray[1, 2] = 6;
            numArray[2, 2] = 5;
            numArray[3, 2] = 8;
            numArray[4, 2] = 7;
            numArray[5, 2] = 8;
            numArray[6, 2] = 5;
            numArray[7, 2] = 4;
            numArray[8, 2] = 8;
            numArray[9, 2] = 8;
            numArray[0, 3] = 11;
            numArray[1, 3] = 9;
            numArray[2, 3] = 11;
            numArray[3, 3] = 10;
            numArray[4, 3] = 11;
            numArray[5, 3] = 10;
            numArray[6, 3] = 9;
            numArray[7, 3] = 5;
            numArray[8, 3] = 9;
            numArray[9, 3] = 11;
            string str4 = str;
            int num5 = _Convert.StrToInt(str4.Substring(str4.Length - 1, 1), 1);
            return str4.Insert(numArray[num5, 3] + 4, str3.Substring(0, 1)).Insert(numArray[num5, 2] + 4, str3.Substring(1, 1)).Insert(numArray[num5, 1] + 4, str3.Substring(2, 1)).Insert(numArray[num5, 0] + 4, str3.Substring(3, 1));
        }

        public static long GetCardPasswordID(string CallCert, string Number, ref int AgentID)
        {
            if (CallCert != "ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安")
            {
                throw new Exception("Call the CardPassword.GenNumber is request a CallCert.");
            }
            AgentID = -1;
            if (string.IsNullOrEmpty(Number) || !Regex.IsMatch(Number, @"^[\d]{20}$"))
            {
                return -1L;
            }
            AgentID = _Convert.StrToInt(Number.Substring(0, 4), -1);
            if (AgentID < 0)
            {
                return -2L;
            }
            long num = -4L;
            try
            {
                int num2 = _Convert.StrToInt(Number.Substring(Number.Length - 1, 1), 1);
                int[,] numArray = new int[10, 4];
                numArray[0, 0] = 1;
                numArray[1, 0] = 2;
                numArray[2, 0] = 1;
                numArray[3, 0] = 1;
                numArray[4, 0] = 0;
                numArray[5, 0] = 1;
                numArray[6, 0] = 1;
                numArray[7, 0] = 0;
                numArray[8, 0] = 0;
                numArray[9, 0] = 1;
                numArray[0, 1] = 4;
                numArray[1, 1] = 3;
                numArray[2, 1] = 2;
                numArray[3, 1] = 3;
                numArray[4, 1] = 6;
                numArray[5, 1] = 5;
                numArray[6, 1] = 4;
                numArray[7, 1] = 1;
                numArray[8, 1] = 5;
                numArray[9, 1] = 5;
                numArray[0, 2] = 10;
                numArray[1, 2] = 6;
                numArray[2, 2] = 5;
                numArray[3, 2] = 8;
                numArray[4, 2] = 7;
                numArray[5, 2] = 8;
                numArray[6, 2] = 5;
                numArray[7, 2] = 4;
                numArray[8, 2] = 8;
                numArray[9, 2] = 8;
                numArray[0, 3] = 11;
                numArray[1, 3] = 9;
                numArray[2, 3] = 11;
                numArray[3, 3] = 10;
                numArray[4, 3] = 11;
                numArray[5, 3] = 10;
                numArray[6, 3] = 9;
                numArray[7, 3] = 5;
                numArray[8, 3] = 9;
                numArray[9, 3] = 11;
                string str = "";
                str = Number.Substring(numArray[num2, 0] + 4, 1);
                Number = Number.Remove(numArray[num2, 0] + 4, 1);
                string str2 = str;
                str = Number.Substring(numArray[num2, 1] + 4, 1);
                Number = Number.Remove(numArray[num2, 1] + 4, 1);
                str2 = str + str2;
                str = Number.Substring(numArray[num2, 2] + 4, 1);
                Number = Number.Remove(numArray[num2, 2] + 4, 1);
                str2 = str + str2;
                str = Number.Substring(numArray[num2, 3] + 4, 1);
                Number = Number.Remove(numArray[num2, 3] + 4, 1);
                str2 = str + str2;
                string str3 = Number;
                double a = 1.0;
                int num4 = 0;
                for (int i = 0; i < str3.Length; i++)
                {
                    num4 = int.Parse(str3.Substring(i, 1));
                    if (str3.Substring(i, 1) == "0")
                    {
                        num4 = i + 1;
                    }
                    a *= num4;
                }
                string str4 = Math.Sin(a).ToString();
                string str5 = "";
                for (int j = 0; j < str4.Length; j++)
                {
                    if (("123456789".IndexOf(str4.Substring(j, 1)) >= 0) && (str5.Length < 4))
                    {
                        str5 = str5 + str4.Substring(j, 1);
                    }
                }
                if (str5 == str2)
                {
                    num = long.Parse(str3.Substring(4));
                }
            }
            catch
            {
                return -3L;
            }
            return num;
        }

        private static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + _String.Reverse("圳深 ") + _String.Reverse("安宝"));
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }
    }
}

