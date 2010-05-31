using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SYYDJ : LotteryBase
    {
        public const string Code = "SYYDJ";
        public const int ID = 0x3e;
        public const double MaxMoney = 200000.0;
        public const string Name = "十一运夺金";
        public const int PlayType_RX1 = 0x1839;
        public const int PlayType_RX2 = 0x183a;
        public const int PlayType_RX3 = 0x183b;
        public const int PlayType_RX4 = 0x183c;
        public const int PlayType_RX5 = 0x183d;
        public const int PlayType_RX6 = 0x183e;
        public const int PlayType_RX7 = 0x183f;
        public const int PlayType_RX8 = 0x1840;
        public const int PlayType_ZhiQ2 = 0x1841;
        public const int PlayType_ZhiQ3 = 0x1842;
        public const int PlayType_ZuQ2 = 0x1843;
        public const int PlayType_ZuQ3 = 0x1844;
        public const string sID = "62";

        public SYYDJ()
        {
            base.id = 0x3e;
            base.name = "十一运夺金";
            base.code = "SYYDJ";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0x1839)
            {
                return this.AnalyseScheme_RX1(Content, PlayType);
            }
            if (PlayType == 0x183a)
            {
                return this.AnalyseScheme_RX2(Content, PlayType);
            }
            if (PlayType == 0x183b)
            {
                return this.AnalyseScheme_RX3(Content, PlayType);
            }
            if (PlayType == 0x183c)
            {
                return this.AnalyseScheme_RX4(Content, PlayType);
            }
            if (PlayType == 0x183d)
            {
                return this.AnalyseScheme_RX5(Content, PlayType);
            }
            if (PlayType == 0x183e)
            {
                return this.AnalyseScheme_RX6(Content, PlayType);
            }
            if (PlayType == 0x183f)
            {
                return this.AnalyseScheme_RX7(Content, PlayType);
            }
            if (PlayType == 0x1840)
            {
                return this.AnalyseScheme_RX8(Content, PlayType);
            }
            if (PlayType == 0x1841)
            {
                return this.AnalyseScheme_ZhiQ2(Content, PlayType);
            }
            if (PlayType == 0x1842)
            {
                return this.AnalyseScheme_ZhiQ3(Content, PlayType);
            }
            if (PlayType == 0x1843)
            {
                return this.AnalyseScheme_ZuQ2(Content, PlayType);
            }
            if (PlayType == 0x1844)
            {
                return this.AnalyseScheme_ZuQ3(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_RX1(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"(\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX1(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX2(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){1,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX2(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX3(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){2,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX3(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX4(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){3,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX4(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX5(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){4,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX5(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX6(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){5,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX6(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX7(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){6,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX7(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX8(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){7,10}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX8(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_ZhiQ2(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){0,8}(\d\d))[|]((\d\d\s){0,9}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiQ2(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_ZhiQ3(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"((\d\d\s){0,8}\d\d)[|]((\d\d\s){0,8}\d\d)[|]((\d\d\s){0,8}\d\d)";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiQ3(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_ZuQ2(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"(\d\d\s){1,10}\d\d";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuQ2(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_ZuQ3(string Content, int PlayType)
        {
            string[] strArray = Content.Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"(\d\d\s){2,10}\d\d";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuQ3(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str4 = str;
                        string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                        str = string.Concat(strArray3);
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public override bool AnalyseWinNumber(string Number)
        {
            Regex regex = new Regex(@"((\d\d\s){4}\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(Number);
        }

        public override string BuildNumber(int Num, int Type)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < Type; j++)
                {
                    str = str + random.Next(1, 11).ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x1839) && (play_type <= 0x1844));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 0x18))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            if (PlayType == 0x1839)
            {
                return this.ComputeWin_RX1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], ref num);
            }
            if (PlayType == 0x183a)
            {
                return this.ComputeWin_RX2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], ref num2);
            }
            if (PlayType == 0x183b)
            {
                return this.ComputeWin_RX3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5], ref num3);
            }
            if (PlayType == 0x183c)
            {
                return this.ComputeWin_RX4(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7], ref num4);
            }
            if (PlayType == 0x183d)
            {
                return this.ComputeWin_RX5(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9], ref num5);
            }
            if (PlayType == 0x183e)
            {
                return this.ComputeWin_RX6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], ref num6);
            }
            if (PlayType == 0x183f)
            {
                return this.ComputeWin_RX7(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], ref num7);
            }
            if (PlayType == 0x1840)
            {
                return this.ComputeWin_RX8(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[14], WinMoneyList[15], ref num8);
            }
            if (PlayType == 0x1841)
            {
                return this.ComputeWin_ZhiQ2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x10], WinMoneyList[0x11], ref num9);
            }
            if (PlayType == 0x1842)
            {
                return this.ComputeWin_ZhiQ3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x12], WinMoneyList[0x13], ref num10);
            }
            if (PlayType == 0x1843)
            {
                return this.ComputeWin_ZuQ2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[20], WinMoneyList[0x15], ref num11);
            }
            if (PlayType == 0x1844)
            {
                return this.ComputeWin_ZuQ3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x16], WinMoneyList[0x17], ref num12);
            }
            return -4.0;
        }

        private double ComputeWin_RX1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCountRX1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX1 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[1];
                        Match match = new Regex(@"(?<R0>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 1; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.Substring(0, 2) == strArray3[k])
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 1))
                        {
                            WinCountRX1++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCountRX1 > 0)
            {
                Description = "任选一奖" + ((int)WinCountRX1).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCountRX2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX2 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[2];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 2; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 2))
                        {
                            WinCountRX2++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                    }
                }
            }
            if (WinCountRX2 > 0)
            {
                Description = "任选二奖" + ((int)WinCountRX2).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney3, double WinMoneyNoWithTax3, ref int WinCountRX3)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[3];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 3; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 3))
                        {
                            WinCountRX3++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                    }
                }
            }
            if (WinCountRX3 > 0)
            {
                Description = "任选三奖" + ((int)WinCountRX3).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX4(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney4, double WinMoneyNoWithTax4, ref int WinCountRX4)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX4 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX4(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[4];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 4; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 4))
                        {
                            WinCountRX4++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                    }
                }
            }
            if (WinCountRX4 > 0)
            {
                Description = "任选四奖" + ((int)WinCountRX4).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX5(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney5, double WinMoneyNoWithTax5, ref int WinCountRX5)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX5 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX5(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[5];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 5; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 5))
                        {
                            WinCountRX5++;
                            num += WinMoney5;
                            WinMoneyNoWithTax += WinMoneyNoWithTax5;
                        }
                    }
                }
            }
            if (WinCountRX5 > 0)
            {
                Description = "任选五奖" + ((int)WinCountRX5).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX6(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney6, double WinMoneyNoWithTax6, ref int WinCountRX6)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX6 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX6(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[6];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 6; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 5))
                        {
                            WinCountRX6++;
                            num += WinMoney6;
                            WinMoneyNoWithTax += WinMoneyNoWithTax6;
                        }
                    }
                }
            }
            if (WinCountRX6 > 0)
            {
                Description = "任选六奖" + ((int)WinCountRX6).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX7(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney7, double WinMoneyNoWithTax7, ref int WinCountRX7)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX7 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX7(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[7];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 7; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 5))
                        {
                            WinCountRX7++;
                            num += WinMoney7;
                            WinMoneyNoWithTax += WinMoneyNoWithTax7;
                        }
                    }
                }
            }
            if (WinCountRX7 > 0)
            {
                Description = "任选七奖" + ((int)WinCountRX7).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX8(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney8, double WinMoneyNoWithTax8, ref int WinCountRX8)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCountRX8 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX8(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string[] strArray3 = new string[8];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d\s)(?<R7>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        int num5 = 0;
                        bool flag = true;
                        for (int k = 0; k < 8; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                flag = false;
                                break;
                            }
                            if (WinNumber.IndexOf(strArray3[k]) >= 0)
                            {
                                num5++;
                            }
                        }
                        if (flag && (num5 == 5))
                        {
                            WinCountRX8++;
                            num += WinMoney8;
                            WinMoneyNoWithTax += WinMoneyNoWithTax8;
                        }
                    }
                }
            }
            if (WinCountRX8 > 0)
            {
                Description = "任选八奖" + ((int)WinCountRX8).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_ZhiQ2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney9, double WinMoneyNoWithTax9, ref int WinCount_ZhiQ2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCount_ZhiQ2 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiQ2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        bool flag = false;
                        Regex regex = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        if (regex.IsMatch(strArray2[j]) && (WinNumber.Substring(0, 5) == strArray2[j]))
                        {
                            flag = true;
                        }
                        if (flag)
                        {
                            WinCount_ZhiQ2++;
                            num += WinMoney9;
                            WinMoneyNoWithTax += WinMoneyNoWithTax9;
                        }
                    }
                }
            }
            if (WinCount_ZhiQ2 > 0)
            {
                Description = "直选前二奖" + ((int)WinCount_ZhiQ2).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_ZhiQ3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney10, double WinMoneyNoWithTax10, ref int WinCount_ZhiQ3)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCount_ZhiQ3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiQ3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        bool flag = false;
                        Regex regex = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        if (regex.IsMatch(strArray2[j]) && (WinNumber.Substring(0, 8) == strArray2[j]))
                        {
                            flag = true;
                        }
                        if (flag)
                        {
                            WinCount_ZhiQ3++;
                            num += WinMoney10;
                            WinMoneyNoWithTax += WinMoneyNoWithTax10;
                        }
                    }
                }
            }
            if (WinCount_ZhiQ3 > 0)
            {
                Description = "直选前三奖" + ((int)WinCount_ZhiQ3).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_ZuQ2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney11, double WinMoneyNoWithTax11, ref int WinCount_ZuQ2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCount_ZuQ2 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuQ2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        int num4 = 0;
                        string[] strArray3 = new string[2];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        for (int k = 0; k < 2; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                break;
                            }
                            if (WinNumber.Substring(0, 5).IndexOf(strArray3[k]) >= 0)
                            {
                                num4++;
                            }
                        }
                        if (num4 == 2)
                        {
                            WinCount_ZuQ2++;
                            num += WinMoney11;
                            WinMoneyNoWithTax += WinMoneyNoWithTax11;
                        }
                    }
                }
            }
            if (WinCount_ZuQ2 > 0)
            {
                Description = "组选前二奖" + ((int)WinCount_ZuQ2).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_ZuQ3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney12, double WinMoneyNoWithTax12, ref int WinCount_ZuQ3)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
            {
                return -1.0;
            }
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            WinCount_ZuQ3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuQ3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        int num4 = 0;
                        string[] strArray3 = new string[3];
                        Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                        for (int k = 0; k < 3; k++)
                        {
                            strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                            if (strArray3[k] == "")
                            {
                                break;
                            }
                            if (WinNumber.Substring(0, 8).IndexOf(strArray3[k]) >= 0)
                            {
                                num4++;
                            }
                        }
                        if (num4 == 3)
                        {
                            WinCount_ZuQ3++;
                            num += WinMoney12;
                            WinMoneyNoWithTax += WinMoneyNoWithTax12;
                        }
                    }
                }
            }
            if (WinCount_ZuQ3 > 0)
            {
                Description = "组选前三奖" + ((int)WinCount_ZuQ3).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private string ConvertFormatToElectronTicket_HPSD(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID == 0x1839) || (PlayTypeID == 0x183a)) || ((PlayTypeID == 0x183b) || (PlayTypeID == 0x183c))) || (((PlayTypeID == 0x183d) || (PlayTypeID == 0x183e)) || ((PlayTypeID == 0x183f) || (PlayTypeID == 0x1840))))
            {
                str = Number.Replace(" ", ",");
            }
            if ((PlayTypeID == 0x1841) || (PlayTypeID == 0x1842))
            {
                str = Number;
            }
            if ((PlayTypeID != 0x1843) && (PlayTypeID != 0x1844))
            {
                return str;
            }
            return Number.Replace(" ", ",").Replace("|", ",");
        }

        private string[] FilterRepeated(string[] NumberPart, int MaxBall)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= MaxBall)) && !base.isExistBall(al, ball))
                {
                    al.Add(NumberPart[i]);
                }
            }
            LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
            al.Sort(comparer);
            string[] strArray = new string[al.Count];
            for (int j = 0; j < al.Count; j++)
            {
                strArray[j] = al[j].ToString().PadLeft(2, '0');
            }
            return strArray;
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x1839, "任选一"), new PlayType(0x183a, "任选二"), new PlayType(0x183b, "任选三"), new PlayType(0x183c, "任选四"), new PlayType(0x183d, "任选五"), new PlayType(0x183e, "任选六"), new PlayType(0x183f, "任选七"), new PlayType(0x1840, "任选八"), new PlayType(0x1841, "直选前二"), new PlayType(0x1842, "直选前三"), new PlayType(0x1843, "组选前二"), new PlayType(0x1844, "组选前三") };
        }

        public override string GetPrintKeyList(string Number, int PlayTypeID, string LotteryMachine)
        {
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override JTicket[] ToElectronicTicket_HPSD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1839)
            {
                return this.ToElectronicTicket_HPSD_RX1(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183a)
            {
                return this.ToElectronicTicket_HPSD_RX2(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183b)
            {
                return this.ToElectronicTicket_HPSD_RX3(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183c)
            {
                return this.ToElectronicTicket_HPSD_RX4(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183d)
            {
                return this.ToElectronicTicket_HPSD_RX5(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183e)
            {
                return this.ToElectronicTicket_HPSD_RX6(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x183f)
            {
                return this.ToElectronicTicket_HPSD_RX7(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1840)
            {
                return this.ToElectronicTicket_HPSD_RX8(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1841)
            {
                return this.ToElectronicTicket_HPSD_ZhiQ2(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1842)
            {
                return this.ToElectronicTicket_HPSD_ZhiQ3(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1843)
            {
                return this.ToElectronicTicket_HPSD_ZuQ2(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1844)
            {
                return this.ToElectronicTicket_HPSD_ZuQ3(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX1(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX1(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                for (int k = 0; k < strArray.Length; k += 5)
                {
                    string number = "";
                    num3 = 0.0;
                    for (int m = 0; m < 5; m++)
                    {
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(1, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX2(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX2(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(2, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(2, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(2, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX3(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX3(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(3, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(3, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(3, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX4(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX4(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(4, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(4, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(4, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX5(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX5(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(5, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(5, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(5, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX6(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX6(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(6, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(6, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(6, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX7(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX7(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(7, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(7, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(7, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_RX8(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX8(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(8, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(8, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(8, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_ZhiQ2(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_ZhiQ2(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (!string.IsNullOrEmpty(strArray[k].ToString()) && (strArray[k].ToString().Split(new char[] { '|' }).Length >= 3))
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[2]) == 1.0)
                        {
                            string str3 = number;
                            number = str3 + strArray[k].ToString().Split(new char[] { '|' })[0] + "|" + strArray[k].ToString().Split(new char[] { '|' })[1] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[2]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(9, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "|" + strArray[k].ToString().Split(new char[] { '|' })[1] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[2]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(9, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2.Replace(" ", ",")), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(9, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_ZhiQ3(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_ZhiQ3(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            string str = "";
            double num4 = 0.0;
            int num5 = 0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (!string.IsNullOrEmpty(strArray[k].ToString()) && (strArray[k].ToString().Split(new char[] { '|' }).Length >= 4))
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[3]) == 1.0)
                        {
                            string str3 = number;
                            number = str3 + strArray[k].ToString().Split(new char[] { '|' })[0] + "|" + strArray[k].ToString().Split(new char[] { '|' })[1] + "|" + strArray[k].ToString().Split(new char[] { '|' })[2] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[3]);
                            num5++;
                            if ((num5 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(10, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num5 = 0;
                            }
                        }
                        else
                        {
                            str = strArray[k].ToString().Split(new char[] { '|' })[0] + "|" + strArray[k].ToString().Split(new char[] { '|' })[1] + "|" + strArray[k].ToString().Split(new char[] { '|' })[2] + "\n";
                            num4 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[3]);
                            Money += num4 * multiple;
                            list.Add(new JTicket(10, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str.Replace(" ", ",")), multiple, num4 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(10, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_ZuQ2(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_ZuQ2(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(11, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(11, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(11, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_ZuQ3(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_ZuQ3(Number, PlayTypeID).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num = Multiple / MaxMultiple;
            }
            ArrayList list = new ArrayList();
            int multiple = 1;
            double num3 = 0.0;
            for (int i = 1; i < (num + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                string number = "";
                num3 = 0.0;
                string str2 = "";
                double num5 = 0.0;
                int num6 = 0;
                for (int k = 0; k < strArray.Length; k++)
                {
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        if (double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]) == 1.0)
                        {
                            number = number + strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            num6++;
                            if ((num6 == 5) || (k == (strArray.Length - 1)))
                            {
                                Money += num3 * multiple;
                                list.Add(new JTicket(12, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                                number = "";
                                num3 = 0.0;
                                num6 = 0;
                            }
                        }
                        else
                        {
                            str2 = strArray[k].ToString().Split(new char[] { '|' })[0] + "\n";
                            num5 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                            Money += num5 * multiple;
                            list.Add(new JTicket(12, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, str2), multiple, num5 * multiple));
                        }
                    }
                }
                if (number != "")
                {
                    Money += num3 * multiple;
                    list.Add(new JTicket(12, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0x1839)
            {
                return this.ToSingle_RX1(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183a)
            {
                return this.ToSingle_RX2(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183b)
            {
                return this.ToSingle_RX3(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183c)
            {
                return this.ToSingle_RX4(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183d)
            {
                return this.ToSingle_RX5(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183e)
            {
                return this.ToSingle_RX6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x183f)
            {
                return this.ToSingle_RX7(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1840)
            {
                return this.ToSingle_RX8(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1841)
            {
                return this.ToSingle_ZhiQ2(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1842)
            {
                return this.ToSingle_ZhiQ3(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1843)
            {
                return this.ToSingle_ZuQ2(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1844)
            {
                return this.ToSingle_ZuQ3(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_RX1(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 1)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < length; j++)
            {
                list.Add(strArray[j]);
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 1); j++)
            {
                for (int m = j + 1; m < length; m++)
                {
                    list.Add(strArray[j] + " " + strArray[m]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 3)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 2); j++)
            {
                for (int m = j + 1; m < (length - 1); m++)
                {
                    for (int n = m + 1; n < length; n++)
                    {
                        list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n]);
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX4(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 4)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 3); j++)
            {
                for (int m = j + 1; m < (length - 2); m++)
                {
                    for (int n = m + 1; n < (length - 1); n++)
                    {
                        for (int num6 = n + 1; num6 < length; num6++)
                        {
                            list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6]);
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX5(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 5)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 4); j++)
            {
                for (int m = j + 1; m < (length - 3); m++)
                {
                    for (int n = m + 1; n < (length - 2); n++)
                    {
                        for (int num6 = n + 1; num6 < (length - 1); num6++)
                        {
                            for (int num7 = num6 + 1; num7 < length; num7++)
                            {
                                list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6] + " " + strArray[num7]);
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX6(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 6)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 5); j++)
            {
                for (int m = j + 1; m < (length - 4); m++)
                {
                    for (int n = m + 1; n < (length - 3); n++)
                    {
                        for (int num6 = n + 1; num6 < (length - 2); num6++)
                        {
                            for (int num7 = num6 + 1; num7 < (length - 1); num7++)
                            {
                                for (int num8 = num7 + 1; num8 < length; num8++)
                                {
                                    list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6] + " " + strArray[num7] + " " + strArray[num8]);
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX7(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 7)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 6); j++)
            {
                for (int m = j + 1; m < (length - 5); m++)
                {
                    for (int n = m + 1; n < (length - 4); n++)
                    {
                        for (int num6 = n + 1; num6 < (length - 3); num6++)
                        {
                            for (int num7 = num6 + 1; num7 < (length - 2); num7++)
                            {
                                for (int num8 = num7 + 1; num8 < (length - 1); num8++)
                                {
                                    for (int num9 = num8 + 1; num9 < length; num9++)
                                    {
                                        list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6] + " " + strArray[num7] + " " + strArray[num8] + " " + strArray[num9]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX8(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 8)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 7); j++)
            {
                for (int m = j + 1; m < (length - 6); m++)
                {
                    for (int n = m + 1; n < (length - 5); n++)
                    {
                        for (int num6 = n + 1; num6 < (length - 4); num6++)
                        {
                            for (int num7 = num6 + 1; num7 < (length - 3); num7++)
                            {
                                for (int num8 = num7 + 1; num8 < (length - 2); num8++)
                                {
                                    for (int num9 = num8 + 1; num9 < (length - 1); num9++)
                                    {
                                        for (int num10 = num9 + 1; num10 < length; num10++)
                                        {
                                            list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6] + " " + strArray[num7] + " " + strArray[num8] + " " + strArray[num9] + " " + strArray[num10]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_ZhiQ2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { '|' })[0].Trim().Split(new char[] { ' ' }), 11);
            string[] strArray2 = this.FilterRepeated(Number.Trim().Split(new char[] { '|' })[1].Trim().Split(new char[] { ' ' }), 11);
            if ((strArray.Length < 1) && (strArray2.Length < 1))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            CanonicalNumber = CanonicalNumber + "|";
            for (int j = 0; j < strArray2.Length; j++)
            {
                CanonicalNumber = CanonicalNumber + strArray2[j] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            int num4 = strArray2.Length;
            for (int k = 0; k < length; k++)
            {
                for (int n = 0; n < num4; n++)
                {
                    if (strArray[k] != strArray2[n])
                    {
                        list.Add(strArray[k] + " " + strArray2[n]);
                    }
                }
            }
            string[] strArray3 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray3[m] = list[m].ToString();
            }
            return strArray3;
        }

        private string[] ToSingle_ZhiQ3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { '|' })[0].Trim().Split(new char[] { ' ' }), 11);
            string[] strArray2 = this.FilterRepeated(Number.Trim().Split(new char[] { '|' })[1].Trim().Split(new char[] { ' ' }), 11);
            string[] strArray3 = this.FilterRepeated(Number.Trim().Split(new char[] { '|' })[2].Trim().Split(new char[] { ' ' }), 11);
            if (((strArray.Length < 1) && (strArray2.Length < 1)) && (strArray3.Length < 1))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            CanonicalNumber = CanonicalNumber + "|";
            for (int j = 0; j < strArray2.Length; j++)
            {
                CanonicalNumber = CanonicalNumber + strArray2[j] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            CanonicalNumber = CanonicalNumber + "|";
            for (int k = 0; k < strArray3.Length; k++)
            {
                CanonicalNumber = CanonicalNumber + strArray3[k] + " ";
            }
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            int num5 = strArray2.Length;
            int num6 = strArray3.Length;
            for (int m = 0; m < length; m++)
            {
                for (int num8 = 0; num8 < num5; num8++)
                {
                    for (int num9 = 0; num9 < num6; num9++)
                    {
                        if (((strArray[m] != strArray2[num8]) && (strArray2[num8] != strArray3[num9])) && (strArray3[num9] != strArray[m]))
                        {
                            list.Add(strArray[m] + " " + strArray2[num8] + " " + strArray3[num9]);
                        }
                    }
                }
            }
            string[] strArray4 = new string[list.Count];
            for (int n = 0; n < list.Count; n++)
            {
                strArray4[n] = list[n].ToString();
            }
            return strArray4;
        }

        private string[] ToSingle_ZuQ2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 1); j++)
            {
                for (int m = j + 1; m < length; m++)
                {
                    list.Add(strArray[j] + " " + strArray[m]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_ZuQ3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 11);
            CanonicalNumber = "";
            if (strArray.Length < 3)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int j = 0; j < (length - 2); j++)
            {
                for (int m = j + 1; m < (length - 1); m++)
                {
                    for (int n = m + 1; n < length; n++)
                    {
                        list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n]);
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }
    }
}
