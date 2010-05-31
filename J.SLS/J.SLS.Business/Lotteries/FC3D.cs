using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class FC3D : LotteryBase
    {
        public const string Code = "FC3D";
        public const int ID = 6;
        public const double MaxMoney = 20000.0;
        public const string Name = "福彩3D";
        public const int PlayType_ZhiB = 0x25e;
        public const int PlayType_ZhiD = 0x259;
        public const int PlayType_ZhiF = 0x25a;
        public const int PlayType_Zu3F = 0x25d;
        public const int PlayType_Zu6F = 0x25c;
        public const int PlayType_ZuB = 0x25f;
        public const int PlayType_ZuD = 0x25b;
        public const string sID = "6";

        public FC3D()
        {
            base.id = 6;
            base.name = "福彩3D";
            base.code = "FC3D";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x259) || (PlayType == 0x25a))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if ((PlayType == 0x25b) || (PlayType == 0x25c))
            {
                return this.AnalyseScheme_Zu3D_Zu6(Content, PlayType);
            }
            if (PlayType == 0x25d)
            {
                return this.AnalyseScheme_Zu3F(Content, PlayType);
            }
            if (PlayType == 0x25e)
            {
                return this.AnalyseScheme_ZhiB(Content, PlayType);
            }
            if (PlayType == 0x25f)
            {
                return this.AnalyseScheme_ZuB(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_Zhi(string Content, int PlayType)
        {
            string str2;
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
            if (PlayType == 0x259)
            {
                str2 = @"([\d]){3}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){3}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zhi(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x259) ? 1 : 2)))
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

        private string AnalyseScheme_ZhiB(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiB(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str3 = str;
                        string[] strArray3 = new string[] { str3, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
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

        private string AnalyseScheme_Zu3D_Zu6(string Content, int PlayType)
        {
            string str2;
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
            if (PlayType == 0x25b)
            {
                str2 = @"([\d]){3}";
            }
            else
            {
                str2 = @"([\d]){3,10}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3D_Zu6(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x25b) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x25c)
                            {
                                str = str + match.Value + "|1\n";
                            }
                        }
                        else
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_Zu3F(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3F(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 2))
                    {
                        string str3 = str;
                        string[] strArray3 = new string[] { str3, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
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

        private string AnalyseScheme_ZuB(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuB(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        string str3 = str;
                        string[] strArray3 = new string[] { str3, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
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

        private string AnalyseSchemeToElectronicTicket_DYJ_Zu3D_Zu6(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"([\d]){3,10}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3D_Zu6(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        if (PlayType == 0x25b)
                        {
                            str = str + canonicalNumber + "|1\n";
                        }
                        else
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseSchemeToElectronicTicket_DYJ_Zu3F(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            Regex regex = new Regex(@"([\d]){2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3F(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        string str3 = str;
                        string[] strArray3 = new string[] { str3, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
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

        private string AnalyseSchemeToElectronicTicket_DYJ_ZuB(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuB(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            str = str + strArray2[j] + "|1\n";
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseSchemeToElectronicTicket_Zu3D_Zu6(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"([\d]){3,10}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3D_Zu6(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        if (PlayType == 0x25b)
                        {
                            str = str + canonicalNumber + "|1\n";
                        }
                        else if (strArray2.Length >= 1)
                        {
                            for (int j = 0; j < strArray2.Length; j++)
                            {
                                str = str + strArray2[j] + "|1\n";
                            }
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseSchemeToElectronicTicket_Zu3F(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            Regex regex = new Regex(@"([\d]){2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3F(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            str = str + strArray2[j] + "|1\n";
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseSchemeToElectronicTicket_ZuB(string Content, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Content).Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuB(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            str = str + strArray2[j] + "|1\n";
                        }
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
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_Zhi(Number, ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 3; j++)
                {
                    str = str + random.Next(0, 10).ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x259) && (play_type <= 0x25f));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 6))
            {
                return -3.0;
            }
            if ((PlayType == 0x259) || (PlayType == 0x25a))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if ((PlayType == 0x25b) || (PlayType == 0x25c))
            {
                return this.ComputeWin_Zu3D_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x25d)
            {
                return this.ComputeWin_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x25e)
            {
                return this.ComputeWin_ZhiB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x25f)
            {
                return this.ComputeWin_ZuB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            return -4.0;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
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
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zhi(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
                        {
                            num++;
                            num2 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "单选奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiB(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
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
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiB(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
                        {
                            num++;
                            num2 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "单选奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu3D_Zu6(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            int num = 0;
            int num2 = 0;
            double num3 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                if (strArray[i].Length >= 3)
                {
                    if (this.FilterRepeated(base.Sort(strArray[i])).Length == 2)
                    {
                        if (base.Sort(strArray[i]) == base.Sort(WinNumber))
                        {
                            num++;
                            num3 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                    else
                    {
                        string[] strArray2 = this.ToSingle_Zu3D_Zu6(strArray[i], ref canonicalNumber);
                        if ((strArray2 != null) && (strArray2.Length >= 1))
                        {
                            for (int j = 0; j < strArray2.Length; j++)
                            {
                                if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                                {
                                    num2++;
                                    num3 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选3奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            return num3;
        }

        private double ComputeWin_Zu3F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
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
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu3F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            num++;
                            num2 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选3奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuB(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            int num = 0;
            int num2 = 0;
            double num3 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuB(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (this.FilterRepeated(strArray2[j]).Length == 2)
                            {
                                num++;
                                num3 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                num2++;
                                num3 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选3奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            return num3;
        }

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (((PlayTypeID == 0x259) || (PlayTypeID == 0x25b)) || (PlayTypeID == 0x25f))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (PlayTypeID == 0x259)
                    {
                        str = str + "1|";
                    }
                    else if (PlayTypeID == 0x25b)
                    {
                        str = str + "6|";
                    }
                    else if (PlayTypeID == 0x25f)
                    {
                        str = str + "6|";
                    }
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + ";\n";
                }
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else if (PlayTypeID == 0x25e)
            {
                str = "S1|" + Number + ";";
            }
            else if (PlayTypeID == 0x25c)
            {
                str = str + "F6|" + Number + ";";
            }
            else if (PlayTypeID == 0x25d)
            {
                str = str + "F3|" + Number + ";";
            }
            else if (PlayTypeID == 0x25a)
            {
                str = str + "1|";
                string[] strArray2 = new string[3];
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int k = 0; k < 3; k++)
                {
                    strArray2[k] = match.Groups["L" + k.ToString()].ToString().Trim();
                    if (strArray2[k] == "")
                    {
                        return "";
                    }
                    if (strArray2[k].Length > 1)
                    {
                        strArray2[k] = strArray2[k].Substring(1, strArray2[k].Length - 2);
                        if (strArray2[k].Length > 1)
                        {
                            strArray2[k] = this.FilterRepeated(strArray2[k]);
                        }
                        if (strArray2[k] == "")
                        {
                            return "";
                        }
                    }
                    str = str + strArray2[k] + ",";
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                str = str + ";";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string ConvertFormatToElectronTicket_HPSH(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (((PlayTypeID == 0x259) || (PlayTypeID == 0x25b)) || (((PlayTypeID == 0x25c) || (PlayTypeID == 0x25d)) || (PlayTypeID == 0x25f)))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else if (PlayTypeID == 0x25e)
            {
                str = Number;
            }
            else if (PlayTypeID == 0x25a)
            {
                string[] strArray2 = new string[3];
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int k = 0; k < 3; k++)
                {
                    strArray2[k] = match.Groups["L" + k.ToString()].ToString().Trim();
                    if (strArray2[k] == "")
                    {
                        return "";
                    }
                    if (strArray2[k].Length > 1)
                    {
                        strArray2[k] = strArray2[k].Substring(1, strArray2[k].Length - 2);
                        if (strArray2[k].Length > 1)
                        {
                            strArray2[k] = this.FilterRepeated(strArray2[k]);
                        }
                        if (strArray2[k] == "")
                        {
                            return "";
                        }
                    }
                    str = str + strArray2[k] + ",";
                }
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string FilterRepeated(string NumberPart)
        {
            string str = "";
            for (int i = 0; i < NumberPart.Length; i++)
            {
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("0123456789".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return base.Sort(str);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x259, "直选单式"), new PlayType(0x25a, "直选复式"), new PlayType(0x25b, "组选单式"), new PlayType(0x25c, "组选6复式"), new PlayType(0x25d, "组选3复式"), new PlayType(0x25e, "直选包点"), new PlayType(0x25f, "组选包点") };
        }

        public override string GetPrintKeyList(string Number, int PlayTypeID, string LotteryMachine)
        {
            Number = Number.Trim();
            if (Number != "")
            {
                string[] numbers = Number.Split(new char[] { '\n' });
                if ((numbers == null) || (numbers.Length < 1))
                {
                    return "";
                }
                switch (LotteryMachine)
                {
                    case "福彩投注系统2.2":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_FCTZST2_2_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_FCTZST2_2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_FCTZST2_2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_FCTZST2_2_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_FCTZST2_2_B(numbers);
                        }
                        return this.GetPrintKeyList_FCTZST2_2_ZhiD(numbers);

                    case "FCR8000":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_FCR8000_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_FCR8000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_FCR8000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_FCR8000_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_FCR8000_B(numbers);
                        }
                        return this.GetPrintKeyList_FCR8000_ZhiD(numbers);

                    case "LT-E":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_LT_E_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_LT_E_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_LT_E_ZuF(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_LT_E_ZuF(numbers);
                            }
                            if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_LT_E_B(numbers);
                        }
                        return this.GetPrintKeyList_LT_E_ZhiD(numbers);

                    case "LT-E02":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_LT_E02_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_LT_E02_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_LT_E02_ZuF(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_LT_E02_ZuF(numbers);
                            }
                            if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_LT_E02_B(numbers);
                        }
                        return this.GetPrintKeyList_LT_E02_ZhiD(numbers);

                    case "SN-3000CQA":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_SN_3000CQA_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_SN_3000CQA_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_SN_3000CQA_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_SN_3000CQA_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_SN_3000CQA_B(numbers);
                        }
                        return this.GetPrintKeyList_SN_3000CQA_ZhiD(numbers);

                    case "SN-2000":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID != 0x25a)
                            {
                                if (PlayTypeID == 0x25b)
                                {
                                    return this.GetPrintKeyList_SN_2000_ZhiD(numbers);
                                }
                                if (PlayTypeID == 0x25c)
                                {
                                    return this.GetPrintKeyList_SN_2000_ZhiD(numbers);
                                }
                                if (PlayTypeID == 0x25d)
                                {
                                    return this.GetPrintKeyList_SN_2000_ZhiD(numbers);
                                }
                                if ((PlayTypeID != 0x25e) && (PlayTypeID != 0x25f))
                                {
                                    break;
                                }
                            }
                            return this.GetPrintKeyList_SN_2000_ZhiD(numbers);
                        }
                        return this.GetPrintKeyList_SN_2000_ZhiD(numbers);

                    case "SN_3000CG":
                        if (PlayTypeID != 0x259)
                        {
                            if (PlayTypeID == 0x25a)
                            {
                                return this.GetPrintKeyList_SN_3000CG_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x25b)
                            {
                                return this.GetPrintKeyList_SN_3000CG_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x25c)
                            {
                                return this.GetPrintKeyList_SN_3000CG_Zu6F(numbers);
                            }
                            if (PlayTypeID == 0x25d)
                            {
                                return this.GetPrintKeyList_SN_3000CG_Zu6F(numbers);
                            }
                            if ((PlayTypeID == 0x25e) || (PlayTypeID == 0x25f))
                            {
                                return this.GetPrintKeyList_SN_3000CG_Zu6F(numbers);
                            }
                            break;
                        }
                        return this.GetPrintKeyList_SN_3000CG_ZhiD(numbers);
                }
            }
            return "";
        }

        private string GetPrintKeyList_FCR8000_B(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").PadLeft(2, '0'))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCR8000_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCR8000_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    if (i < 2)
                    {
                        str = str + "[ENTER]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCTZST2_2_B(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").PadLeft(2, '0'))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCTZST2_2_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCTZST2_2_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    if (i < 2)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_B(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").PadLeft(2, '0').Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7"))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
        }

        private string GetPrintKeyList_LT_E_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2).Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7"))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    if (i < 2)
                    {
                        str = str + "[8]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_ZuF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                str = (str + "[" + Convert.ToString(str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").Length) + "]") + "[ENTER]";
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
        }

        private string GetPrintKeyList_LT_E02_B(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").PadLeft(2, '0').Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F"))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E02_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F");
        }

        private string GetPrintKeyList_LT_E02_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2).Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F"))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    if (i < 2)
                    {
                        str = str + "[8]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E02_ZuF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                str = (str + "[" + Convert.ToString(str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").Length) + "]") + "[ENTER]";
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F");
        }

        private string GetPrintKeyList_SN_2000_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CG_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CG_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    str = str + "[Enter]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CG_Zu6F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return (str + "[Enter]");
        }

        private string GetPrintKeyList_SN_3000CQA_B(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").PadLeft(2, '0'))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CQA_ZhiD(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CQA_ZhiF(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 3; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3.Length == 1)
                    {
                        str = str + "[" + str3 + "]";
                    }
                    else
                    {
                        foreach (char ch in str3.Substring(1, str3.Length - 2))
                        {
                            str = str + "[" + ch.ToString() + "]";
                        }
                    }
                    if (i < 2)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string HPSH_ConvertFormatToElectronTicket_D(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            return Number.Replace(",", " ");
        }

        private string HPSH_ConvertFormatToElectronTicket_F(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            foreach (string str2 in Number.Split(new char[] { ',' }))
            {
                if (str2.Length > 1)
                {
                    str = "(" + str2 + ")";
                }
            }
            return str;
        }

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            if (PlayTypeID == 0x259)
            {
                return this.HPSH_ToElectronicTicket_D(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x25a)
            {
                return this.HPSH_ToElectronicTicket_F(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if ((PlayTypeID == 0x25b) || (PlayTypeID == 0x25c))
            {
                return this.HPSH_ToElectronicTicket_Zu(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x25e)
            {
                return this.HPSH_ToElectronicTicket_ZhiB(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x25d)
            {
                return this.HPSH_ToElectronicTicket_Zu3F(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x25f)
            {
                return this.HPSH_ToElectronicTicket_ZuB(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            return "";
        }

        private string HPSH_ToElectronicTicket_D(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket_D(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0x259;
            return "";
        }

        private string HPSH_ToElectronicTicket_F(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket_F(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPSH_ToElectronicTicket_ZhiB(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str in Number.Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str + "\n";
            }
            NewPlayTypeID = 0x25e;
            return "";
        }

        private string HPSH_ToElectronicTicket_Zu(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket_D(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0x25b;
            return "";
        }

        private string HPSH_ToElectronicTicket_Zu3F(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket_D(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0x25b;
            return "";
        }

        private string HPSH_ToElectronicTicket_ZuB(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str in Number.Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str + "\n";
            }
            NewPlayTypeID = 0x25b;
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override JTicket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x259)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25a)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25b)
            {
                return this.ToElectronicTicket_DYJ_Zu(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25e)
            {
                return this.ToElectronicTicket_DYJ_ZhiB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25c)
            {
                return this.ToElectronicTicket_DYJ_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25d)
            {
                return this.ToElectronicTicket_DYJ_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25f)
            {
                return this.ToElectronicTicket_DYJ_ZuB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_DYJ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xd0, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_ZhiB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xcc, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zu(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_Zu3D_Zu6(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_Zu3F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_Zu3D_Zu6(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_ZuB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_ZuB(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override JTicket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x259)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25a)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0x25b) || (PlayTypeID == 0x25c))
            {
                return this.ToElectronicTicket_HPSH_Zu(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25e)
            {
                return this.ToElectronicTicket_HPSH_ZhiB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25d)
            {
                return this.ToElectronicTicket_HPSH_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x25f)
            {
                return this.ToElectronicTicket_HPSH_ZuB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPSH_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xd0, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_ZhiB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme(Number, PlayTypeID).Split(new char[] { '\n' });
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
                for (int k = 0; k < strArray.Length; k++)
                {
                    string number = "";
                    num3 = 0.0;
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xcc, number, multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_Zu(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_Zu3D_Zu6(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_Zu3F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_ZuB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_ZuB(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
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
            if ((PlayType == 0x259) || (PlayType == 0x25a))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x25b) || (PlayType == 0x25c))
            {
                return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x25d)
            {
                return this.ToSingle_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x25e)
            {
                return this.ToSingle_ZhiB(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x25f)
            {
                return this.ToSingle_ZuB(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[3];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (strArray[i].Length > 1)
                {
                    strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                    if (strArray[i].Length > 1)
                    {
                        strArray[i] = this.FilterRepeated(strArray[i]);
                    }
                    if (strArray[i] == "")
                    {
                        CanonicalNumber = "";
                        return null;
                    }
                }
                if (strArray[i].Length > 1)
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray[i] + ")";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray[i];
                }
            }
            ArrayList list = new ArrayList();
            for (int j = 0; j < strArray[0].Length; j++)
            {
                string str = strArray[0][j].ToString();
                for (int m = 0; m < strArray[1].Length; m++)
                {
                    string str2 = str + strArray[1][m].ToString();
                    for (int n = 0; n < strArray[2].Length; n++)
                    {
                        string str3 = str2 + strArray[2][n].ToString();
                        list.Add(str3);
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

        private string[] ToSingle_ZhiB(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 0) || (num > 0x1b))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i <= 9; i++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    for (int m = 0; m <= 9; m++)
                    {
                        if (((i + k) + m) == num)
                        {
                            list.Add(i.ToString() + k.ToString() + m.ToString());
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu3D_Zu6(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            if (length == 2)
            {
                for (int j = 0; j < (length - 1); j++)
                {
                    for (int k = j + 1; k < length; k++)
                    {
                        list.Add(chArray[j].ToString() + chArray[j].ToString() + chArray[k].ToString());
                        list.Add(chArray[j].ToString() + chArray[k].ToString() + chArray[k].ToString());
                    }
                }
            }
            else
            {
                for (int m = 0; m < (length - 2); m++)
                {
                    for (int n = m + 1; n < (length - 1); n++)
                    {
                        for (int num6 = n + 1; num6 < length; num6++)
                        {
                            list.Add(chArray[m].ToString() + chArray[n].ToString() + chArray[num6].ToString());
                        }
                    }
                }
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu3F(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < (length - 1); i++)
            {
                for (int k = i + 1; k < length; k++)
                {
                    list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString());
                    list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_ZuB(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            ArrayList list = new ArrayList();
            if ((num < 1) || (num > 0x1a))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i <= 9; i++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    if ((i != k) && (((i + i) + k) == num))
                    {
                        list.Add(i.ToString() + i.ToString() + k.ToString());
                    }
                }
            }
            if ((num >= 3) && (num <= 0x18))
            {
                for (int m = 0; m <= 7; m++)
                {
                    for (int n = m + 1; n <= 8; n++)
                    {
                        for (int num6 = n + 1; num6 <= 9; num6++)
                        {
                            if (((m + n) + num6) == num)
                            {
                                list.Add(m.ToString() + n.ToString() + num6.ToString());
                            }
                        }
                    }
                }
            }
            CanonicalNumber = num.ToString();
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }
    }
}
