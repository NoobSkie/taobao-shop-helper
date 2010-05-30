using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SXKLPK : LotteryBase
    {
        public const string Code = "SXKLPK";
        public const int ID = 0x36;
        public const double MaxMoney = 200000.0;
        public const string Name = "陕西快乐扑克";
        public const int PlayType_Mixed = 0x1518;
        public const int PlayType_RX1_D = 0x1519;
        public const int PlayType_RX1_F = 0x151a;
        public const int PlayType_RX2_D = 0x151b;
        public const int PlayType_RX2_F = 0x151c;
        public const int PlayType_RX3_D = 0x151d;
        public const int PlayType_RX3_F = 0x151e;
        public const int PlayType_X4_ZhiD = 0x1523;
        public const int PlayType_X4_ZhiF = 0x1524;
        public const int PlayType_X4_Zu12 = 0x1520;
        public const int PlayType_X4_Zu24 = 0x151f;
        public const int PlayType_X4_Zu4 = 0x1522;
        public const int PlayType_X4_Zu6 = 0x1521;
        public const string sID = "54";

        public SXKLPK()
        {
            base.id = 0x36;
            base.name = "陕西快乐扑克";
            base.code = "SXKLPK";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0x1518)
            {
                return this.AnalyseScheme_Mixed(Content, PlayType);
            }
            if ((PlayType == 0x1519) || (PlayType == 0x151a))
            {
                return this.AnalyseScheme_RX1(Content, PlayType);
            }
            if ((PlayType == 0x151b) || (PlayType == 0x151c))
            {
                return this.AnalyseScheme_RX2(Content, PlayType);
            }
            if ((PlayType == 0x151d) || (PlayType == 0x151e))
            {
                return this.AnalyseScheme_RX3(Content, PlayType);
            }
            if (PlayType == 0x151f)
            {
                return this.AnalyseScheme_X4_Zu24(Content, PlayType);
            }
            if (PlayType == 0x1520)
            {
                return this.AnalyseScheme_X4_Zu12(Content, PlayType);
            }
            if (PlayType == 0x1521)
            {
                return this.AnalyseScheme_X4_Zu6(Content, PlayType);
            }
            if (PlayType == 0x1522)
            {
                return this.AnalyseScheme_X4_Zu4(Content, PlayType);
            }
            if ((PlayType != 0x1523) && (PlayType != 0x1524))
            {
                return "";
            }
            return this.AnalyseScheme_X4_Zhi(Content, PlayType);
        }

        private string AnalyseScheme_Mixed(string Content, int PlayType)
        {
            string[] strArray = base.SplitLotteryNumber(Content);
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length < 1)
            {
                return "";
            }
            string str = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string lotteryNumberPreFix = base.GetLotteryNumberPreFix(strArray[i]);
                string str3 = "";
                if (strArray[i].StartsWith("[任选一单式]"))
                {
                    str3 = this.AnalyseScheme_RX1(base.FilterPreFix(strArray[i]), 0x1519);
                }
                if (strArray[i].StartsWith("[任选一复式]"))
                {
                    str3 = this.AnalyseScheme_RX1(base.FilterPreFix(strArray[i]), 0x151a);
                }
                if (strArray[i].StartsWith("[任选二单式]"))
                {
                    str3 = this.AnalyseScheme_RX2(base.FilterPreFix(strArray[i]), 0x151b);
                }
                if (strArray[i].StartsWith("[任选二复式]"))
                {
                    str3 = this.AnalyseScheme_RX2(base.FilterPreFix(strArray[i]), 0x151c);
                }
                if (strArray[i].StartsWith("[任选三单式]"))
                {
                    str3 = this.AnalyseScheme_RX3(base.FilterPreFix(strArray[i]), 0x151d);
                }
                if (strArray[i].StartsWith("[任选三复式]"))
                {
                    str3 = this.AnalyseScheme_RX3(base.FilterPreFix(strArray[i]), 0x151e);
                }
                if (strArray[i].StartsWith("[选四组选24]"))
                {
                    str3 = this.AnalyseScheme_X4_Zu24(base.FilterPreFix(strArray[i]), 0x151f);
                }
                if (strArray[i].StartsWith("[选四组选12]"))
                {
                    str3 = this.AnalyseScheme_X4_Zu12(base.FilterPreFix(strArray[i]), 0x1520);
                }
                if (strArray[i].StartsWith("[选四组选6]"))
                {
                    str3 = this.AnalyseScheme_X4_Zu6(base.FilterPreFix(strArray[i]), 0x1521);
                }
                if (strArray[i].StartsWith("[选四组选4]"))
                {
                    str3 = this.AnalyseScheme_X4_Zu4(base.FilterPreFix(strArray[i]), 0x1522);
                }
                if (str3 != "")
                {
                    str = str + lotteryNumberPreFix + str3 + "\n";
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_RX1(string Content, int PlayType)
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
            if (PlayType == 0x1519)
            {
                str2 = "((([2-9])|(10)|([AJQK_]))[,]){3}(([2-9])|(10)|([AJQK_]))";
            }
            else
            {
                str2 = "(((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))[,]){3}((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (regex.Match(strArray[i].ToString()).Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        if ((strArray2.Length > 1) && (PlayType == 0x151a))
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                        if ((strArray2.Length == 1) && (PlayType == 0x1519))
                        {
                            str = str + canonicalNumber + "|1\n";
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

        private string AnalyseScheme_RX2(string Content, int PlayType)
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
            if (PlayType == 0x151b)
            {
                str2 = "((([2-9])|(10)|([AJQK_]))[,]){3}(([2-9])|(10)|([AJQK_]))";
            }
            else
            {
                str2 = "(((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))[,]){3}((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (regex.Match(strArray[i].ToString()).Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        if ((strArray2.Length > 1) && (PlayType == 0x151c))
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                        if ((strArray2.Length == 1) && (PlayType == 0x151b))
                        {
                            str = str + canonicalNumber + "|1\n";
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

        private string AnalyseScheme_RX3(string Content, int PlayType)
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
            if (PlayType == 0x151d)
            {
                str2 = "((([2-9])|(10)|([AJQK_]))[,]){3}(([2-9])|(10)|([AJQK_]))";
            }
            else
            {
                str2 = "(((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))[,]){3}((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (regex.Match(strArray[i].ToString()).Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX3(strArray[i], ref canonicalNumber);
                    if (strArray2 != null)
                    {
                        if ((strArray2.Length > 1) && (PlayType == 0x151e))
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                        if ((strArray2.Length == 1) && (PlayType == 0x151d))
                        {
                            str = str + canonicalNumber + "|1\n";
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

        private string AnalyseScheme_X4_Zhi(string Content, int PlayType)
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
            if (PlayType == 0x1523)
            {
                str2 = "((([2-9])|(10)|([AJQK]))[,]){3}(([2-9])|(10)|([AJQK]))";
            }
            else
            {
                str2 = "(((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))[,]){3}((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i].ToString());
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_X4_Zhi(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1523) ? 1 : 2)))
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

        private string AnalyseScheme_X4_Zu12(string Content, int PlayType)
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
            string pattern = "((([2-9])|(10)|([AJQK]))[,]){3}(([2-9])|(10)|([AJQK]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_X4_Zu12(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
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

        private string AnalyseScheme_X4_Zu24(string Content, int PlayType)
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
            string pattern = "((([2-9])|(10)|([AJQK]))[,]){3,12}(([2-9])|(10)|([AJQK]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_X4_Zu24(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
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

        private string AnalyseScheme_X4_Zu4(string Content, int PlayType)
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
            string pattern = "((([2-9])|(10)|([AJQK]))[,]){3}(([2-9])|(10)|([AJQK]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_X4_Zu4(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
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

        private string AnalyseScheme_X4_Zu6(string Content, int PlayType)
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
            string pattern = "((([2-9])|(10)|([AJQK]))[,]){3}(([2-9])|(10)|([AJQK]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_X4_Zu6(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
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
            Regex regex = new Regex("((([2-9])|(10)|([AJQK]))[,]){3}(([2-9])|(10)|([AJQK]))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(Number);
        }

        public override string BuildNumber(int Num, int Type)
        {
            return "";
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x1518) && (play_type <= 0x1524));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 20))
            {
                return -3.0;
            }
            if (!this.AnalyseWinNumber(WinNumber))
            {
                return -5.0;
            }
            int winCount = 0;
            int num2 = 0;
            int num3 = 0;
            if (PlayType == 0x1518)
            {
                return this.ComputeWin_Mixed(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13]);
            }
            if ((PlayType == 0x1519) || (PlayType == 0x151a))
            {
                return this.ComputeWin_RX1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], ref winCount);
            }
            if ((PlayType == 0x151b) || (PlayType == 0x151c))
            {
                return this.ComputeWin_RX2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], ref winCount);
            }
            if ((PlayType == 0x151d) || (PlayType == 0x151e))
            {
                return this.ComputeWin_RX3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], ref num2, ref num3);
            }
            if ((PlayType == 0x1523) || (PlayType == 0x1524))
            {
                return this.ComputeWin_X4_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], ref num2, ref num3);
            }
            if (PlayType == 0x151f)
            {
                return this.ComputeWin_X4_Zu24(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], ref winCount);
            }
            if (PlayType == 0x1520)
            {
                return this.ComputeWin_X4_Zu12(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[14], WinMoneyList[15], ref winCount);
            }
            if (PlayType == 0x1521)
            {
                return this.ComputeWin_X4_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x10], WinMoneyList[0x11], ref winCount);
            }
            if (PlayType == 0x1522)
            {
                return this.ComputeWin_X4_Zu4(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x12], WinMoneyList[0x13], ref winCount);
            }
            return -4.0;
        }

        private double ComputeWin_Mixed(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7, double WinMoney8, double WinMoneyNoWithTax8, double WinMoney9, double WinMoneyNoWithTax9, double WinMoney10, double WinMoneyNoWithTax10)
        {
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return -2.0;
            }
            if (strArray.Length < 1)
            {
                return -2.0;
            }
            double num = 0.0;
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
            for (int i = 0; i < strArray.Length; i++)
            {
                int winCount = 0;
                int num14 = 0;
                int num15 = 0;
                double winMoneyNoWithTax = 0.0;
                if (strArray[i].StartsWith("[任选一单式]") || strArray[i].StartsWith("[任选一复式]"))
                {
                    num += this.ComputeWin_RX1(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += winCount;
                }
                else if (strArray[i].StartsWith("[任选二单式]") || strArray[i].StartsWith("[任选二复式]"))
                {
                    num += this.ComputeWin_RX2(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney2, WinMoneyNoWithTax2, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num3 += winCount;
                }
                else if (strArray[i].StartsWith("[任选三单式]") || strArray[i].StartsWith("[任选三复式]"))
                {
                    num += this.ComputeWin_RX3(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney3, WinMoneyNoWithTax3, WinMoney4, WinMoneyNoWithTax4, ref num14, ref num15);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num4 += num14;
                    num5 += num15;
                }
                else if (strArray[i].StartsWith("[选四直选单式]") || strArray[i].StartsWith("[选四直选复式]"))
                {
                    num += this.ComputeWin_X4_Zhi(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney5, WinMoneyNoWithTax5, WinMoney6, WinMoneyNoWithTax6, ref num14, ref num15);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num6 += num14;
                    num7 += num15;
                }
                else if (strArray[i].StartsWith("[选四组选24]"))
                {
                    num += this.ComputeWin_X4_Zu24(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney7, WinMoneyNoWithTax7, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num8 += winCount;
                }
                else if (strArray[i].StartsWith("[选四组选12]"))
                {
                    num += this.ComputeWin_X4_Zu12(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney8, WinMoneyNoWithTax8, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num9 += winCount;
                }
                else if (strArray[i].StartsWith("[选四组选6]"))
                {
                    num += this.ComputeWin_X4_Zu6(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney9, WinMoneyNoWithTax9, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num10 += winCount;
                }
                else if (strArray[i].StartsWith("[选四组选4]"))
                {
                    num += this.ComputeWin_X4_Zu4(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney10, WinMoneyNoWithTax10, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num11 += winCount;
                }
            }
            Description = "";
            if (num2 > 0)
            {
                base.MergeWinDescription(ref Description, "任选一" + num2.ToString() + "注");
            }
            if (num3 > 0)
            {
                base.MergeWinDescription(ref Description, "任选二" + num3.ToString() + "注");
            }
            if (num4 > 0)
            {
                base.MergeWinDescription(ref Description, "任选三中3 " + num4.ToString() + "注");
            }
            if (num5 > 0)
            {
                base.MergeWinDescription(ref Description, "任选三中2 " + num5.ToString() + "注");
            }
            if (num6 > 0)
            {
                base.MergeWinDescription(ref Description, "选四中4 " + num6.ToString() + "注");
            }
            if (num7 > 0)
            {
                base.MergeWinDescription(ref Description, "选四中3 " + num7.ToString() + "注");
            }
            if (num8 > 0)
            {
                base.MergeWinDescription(ref Description, "选四组选24 " + num8.ToString() + "注");
            }
            if (num9 > 0)
            {
                base.MergeWinDescription(ref Description, "选四组选12 " + num9.ToString() + "注");
            }
            if (num10 > 0)
            {
                base.MergeWinDescription(ref Description, "选四组选6 " + num10.ToString() + "注");
            }
            if (num11 > 0)
            {
                base.MergeWinDescription(ref Description, "选四组选4 " + num11.ToString() + "注");
            }
            return num;
        }

        private double ComputeWin_RX1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Split(new char[] { ',' }).Length >= 4)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (strArray2[j].Split(new char[] { ',' })[k] == WinNumber.Split(new char[] { ',' })[k])
                                {
                                    WinCount++;
                                    num += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                            }
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "任选一" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_RX2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            int num = 0;
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Split(new char[] { ',' }).Length >= 4)
                        {
                            num = 0;
                            for (int k = 0; k < 4; k++)
                            {
                                if (strArray2[j].Split(new char[] { ',' })[k] == WinNumber.Split(new char[] { ',' })[k])
                                {
                                    num++;
                                }
                            }
                            if (num == 2)
                            {
                                WinCount++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "任选二" + ((int)WinCount).ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_RX3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_1, ref int WinCount_2)
        {
            int num = 0;
            WinCount_1 = 0;
            WinCount_2 = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Split(new char[] { ',' }).Length >= 4)
                        {
                            num = 0;
                            for (int k = 0; k < 4; k++)
                            {
                                if (strArray2[j].Split(new char[] { ',' })[k] == WinNumber.Split(new char[] { ',' })[k])
                                {
                                    num++;
                                }
                            }
                            switch (num)
                            {
                                case 3:
                                    WinCount_1++;
                                    num2 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                    break;

                                case 2:
                                    WinCount_2++;
                                    num2 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                    goto Label_014B;
                            }
                        Label_014B: ;
                        }
                    }
                }
            }
            if (WinCount_1 > 0)
            {
                base.MergeWinDescription(ref Description, "任选三中3 " + ((int)WinCount_1).ToString() + "注");
            }
            if (WinCount_2 > 0)
            {
                base.MergeWinDescription(ref Description, "任选三中2 " + ((int)WinCount_2).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_X4_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_1, ref int WinCount_2)
        {
            int num = 0;
            WinCount_1 = 0;
            WinCount_2 = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_X4_Zhi(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Split(new char[] { ',' }).Length >= 4)
                        {
                            num = 0;
                            for (int k = 0; k < 4; k++)
                            {
                                if (strArray2[j].Split(new char[] { ',' })[k] == WinNumber.Split(new char[] { ',' })[k])
                                {
                                    num++;
                                }
                            }
                            switch (num)
                            {
                                case 4:
                                    WinCount_1++;
                                    num2 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                    break;

                                case 3:
                                    WinCount_2++;
                                    num2 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                    goto Label_014B;
                            }
                        Label_014B: ;
                        }
                    }
                }
            }
            if (WinCount_1 > 0)
            {
                base.MergeWinDescription(ref Description, "任选四中4 " + ((int)WinCount_1).ToString() + "注");
            }
            if (WinCount_2 > 0)
            {
                base.MergeWinDescription(ref Description, "任选四中3 " + ((int)WinCount_2).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_X4_Zu12(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_X4_Zu12(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Split(new char[] { ',' }).Length >= 4) && (this.SortKLPK(strArray2[j]) == this.SortKLPK(WinNumber)))
                        {
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "选四组选12 " + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_X4_Zu24(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_X4_Zu24(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Split(new char[] { ',' }).Length >= 4) && (this.SortKLPK(strArray2[j]) == this.SortKLPK(WinNumber)))
                        {
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "选四组选24 " + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_X4_Zu4(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_X4_Zu4(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Split(new char[] { ',' }).Length >= 4) && (this.SortKLPK(strArray2[j]) == this.SortKLPK(WinNumber)))
                        {
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "选四组选4 " + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_X4_Zu6(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Split(new char[] { ',' }).Length != 4)
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_X4_Zu6(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Split(new char[] { ',' }).Length >= 4) && (this.SortKLPK(strArray2[j]) == this.SortKLPK(WinNumber)))
                        {
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "选四组选6 " + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private string FilterRepeated(string NumberPart)
        {
            string number = "";
            string[] strArray = NumberPart.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (("23456789AJQK10".IndexOf(strArray[i]) >= 0) && (number.IndexOf(strArray[i]) == -1))
                {
                    number = number + strArray[i] + ",";
                }
            }
            number = number.Substring(0, number.Length - 1);
            return this.SortKLPK(number);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x1518, "混合投注"), new PlayType(0x1519, "任选一单式"), new PlayType(0x151a, "任选一复式"), new PlayType(0x151b, "任选二单式"), new PlayType(0x151c, "任选二复式"), new PlayType(0x151d, "任选三单式"), new PlayType(0x151e, "任选三复式"), new PlayType(0x151f, "选四组选24"), new PlayType(0x1520, "选四组选12"), new PlayType(0x1521, "选四组选6"), new PlayType(0x1522, "选四组选4"), new PlayType(0x1523, "选四直选单式"), new PlayType(0x1524, "选四组选复式") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        private string SortKLPK(string Number)
        {
            string[] strArray = new string[13];
            string str = "";
            string[] strArray2 = Number.Split(new char[] { ',' });
            for (int i = 0; i < strArray2.Length; i++)
            {
                if ("23456789AJQK10".IndexOf(strArray2[i]) >= 0)
                {
                    if (strArray2[i] == "A")
                    {
                        strArray[0] = "A";
                    }
                    else if (strArray2[i] == "2")
                    {
                        strArray[1] = "2";
                    }
                    else if (strArray2[i] == "3")
                    {
                        strArray[2] = "3";
                    }
                    else if (strArray2[i] == "4")
                    {
                        strArray[3] = "4";
                    }
                    else if (strArray2[i] == "5")
                    {
                        strArray[4] = "5";
                    }
                    else if (strArray2[i] == "6")
                    {
                        strArray[5] = "6";
                    }
                    else if (strArray2[i] == "7")
                    {
                        strArray[6] = "7";
                    }
                    else if (strArray2[i] == "8")
                    {
                        strArray[7] = "8";
                    }
                    else if (strArray2[i] == "9")
                    {
                        strArray[8] = "9";
                    }
                    else if (strArray2[i] == "10")
                    {
                        strArray[9] = "10";
                    }
                    else if (strArray2[i] == "J")
                    {
                        strArray[10] = "J";
                    }
                    else if (strArray2[i] == "Q")
                    {
                        strArray[11] = "Q";
                    }
                    else if (strArray2[i] == "K")
                    {
                        strArray[12] = "K";
                    }
                }
            }
            for (int j = 0; j < 13; j++)
            {
                if (strArray[j] != null)
                {
                    str = str + strArray[j] + ",";
                }
            }
            return str.Substring(0, str.Length - 1);
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0x1518)
            {
                return this.ToSingle_Mixed(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x1519) || (PlayType == 0x151a))
            {
                return this.ToSingle_RX1(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x151b) || (PlayType == 0x151c))
            {
                return this.ToSingle_RX2(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x151d) || (PlayType == 0x151e))
            {
                return this.ToSingle_RX3(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x151f)
            {
                return this.ToSingle_X4_Zu24(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1520)
            {
                return this.ToSingle_X4_Zu12(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1521)
            {
                return this.ToSingle_X4_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1522)
            {
                return this.ToSingle_X4_Zu4(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x1523) && (PlayType != 0x1524))
            {
                return null;
            }
            return this.ToSingle_X4_Zhi(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_Mixed(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            string lotteryNumberPreFix = base.GetLotteryNumberPreFix(Number);
            if (Number.StartsWith("[任选1单式]") || Number.StartsWith("[任选1复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_RX1(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[任选2单式]") || Number.StartsWith("[任选2复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_RX2(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[任选3单式]") || Number.StartsWith("[任选3复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_RX3(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[选4组选24]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_X4_Zu24(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[选4组选12]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_X4_Zu12(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[选4组选6]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_X4_Zu6(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[选4组选4]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_X4_Zu4(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (!Number.StartsWith("[选4直选单式]") && !Number.StartsWith("[选4直选复式]"))
            {
                return null;
            }
            return base.MergeLotteryNumberPreFix(this.ToSingle_X4_Zhi(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
        }

        private string[] ToSingle_RX1(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            int num = 0;
            Match match = new Regex("(?<L0>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L1>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L2>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L3>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
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
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray[i] + "),";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray[i] + ",";
                }
                if (strArray[i] != "_")
                {
                    Regex regex2 = new Regex("((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    if (regex2.IsMatch(strArray[i]))
                    {
                        num++;
                    }
                }
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            for (int j = 0; j < 4; j++)
            {
                strArray[j] = strArray[j].Replace(",", "").Replace("10", "$");
            }
            ArrayList list = new ArrayList();
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str = strArray[0][k].ToString();
                if (str != "_")
                {
                    str = str + ",_,_,_";
                    list.Add(str);
                }
            }
            for (int m = 0; m < strArray[1].Length; m++)
            {
                string str2 = strArray[1][m].ToString();
                if (str2 != "_")
                {
                    str2 = "_," + str2 + ",_,_";
                    list.Add(str2);
                }
            }
            for (int n = 0; n < strArray[2].Length; n++)
            {
                string str3 = strArray[2][n].ToString();
                if (str3 != "_")
                {
                    str3 = "_,_," + str3 + ",_";
                    list.Add(str3);
                }
            }
            for (int num7 = 0; num7 < strArray[3].Length; num7++)
            {
                string str4 = strArray[3][num7].ToString();
                if (str4 != "_")
                {
                    str4 = "_,_,_," + str4;
                    list.Add(str4);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int num8 = 0; num8 < list.Count; num8++)
            {
                strArray2[num8] = list[num8].ToString().Replace("$", "10");
            }
            return strArray2;
        }

        private string[] ToSingle_RX2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L1>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L2>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L3>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
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
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray[i] + "),";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray[i] + ",";
                }
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            for (int j = 0; j < 4; j++)
            {
                strArray[j] = strArray[j].Replace(",", "").Replace("10", "$");
                if (strArray[j] != "_")
                {
                    string[] strArray3;
                    IntPtr ptr;
                    (strArray3 = strArray)[(int)(ptr = (IntPtr)j)] = strArray3[(int)ptr] + "_";
                }
            }
            ArrayList list = new ArrayList();
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str = strArray[0][k].ToString();
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + "," + strArray[1][n].ToString();
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        string str3 = str2 + "," + strArray[2][num5].ToString();
                        for (int num6 = 0; num6 < strArray[3].Length; num6++)
                        {
                            string str4 = str3 + "," + strArray[3][num6].ToString();
                            if (str4.Replace("_", "").Length == 5)
                            {
                                list.Add(str4);
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString().Replace("$", "10");
            }
            return strArray2;
        }

        private string[] ToSingle_RX3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L1>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L2>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L3>((([2-9])|(10)|([AJQK_]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
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
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray[i] + "),";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray[i] + ",";
                }
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            for (int j = 0; j < 4; j++)
            {
                strArray[j] = strArray[j].Replace(",", "").Replace("10", "$");
                if (strArray[j] != "_")
                {
                    strArray[j] = strArray[j] + "_";
                }
            }
            ArrayList list = new ArrayList();
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str = strArray[0][k].ToString();
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + "," + strArray[1][n].ToString();
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        string str3 = str2 + "," + strArray[2][num5].ToString();
                        for (int num6 = 0; num6 < strArray[3].Length; num6++)
                        {
                            string str4 = str3 + "," + strArray[3][num6].ToString();
                            if (str4.Replace("_", "").Length == 6)
                            {
                                list.Add(str4);
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString().Replace("$", "10");
            }
            return strArray2;
        }

        private string[] ToSingle_X4_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L1>((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L2>((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))[,](?<L3>((([2-9])|(10)|([AJQK]))|([(]((([2-9])|(10)|([AJQK]))[,]){1,12}(([2-9])|(10)|([AJQK]))[)])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
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
                if ((strArray[i].Length > 1) && (strArray[i] != "10"))
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray[i] + "),";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray[i] + ",";
                }
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            for (int j = 0; j < 4; j++)
            {
                strArray[j] = strArray[j].Replace(",", "").Replace("10", "$");
            }
            ArrayList list = new ArrayList();
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str = strArray[0][k].ToString();
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + "," + strArray[1][n].ToString();
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        string str3 = str2 + "," + strArray[2][num5].ToString();
                        for (int num6 = 0; num6 < strArray[3].Length; num6++)
                        {
                            string str4 = str3 + "," + strArray[3][num6].ToString();
                            list.Add(str4);
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString().Replace("$", "10");
            }
            return strArray2;
        }

        private string[] ToSingle_X4_Zu12(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            if (this.FilterRepeated(Number).Split(new char[] { ',' }).Length != 3)
            {
                CanonicalNumber = "";
                return null;
            }
            Match match = new Regex("(?<L0>(([2-9])|(10)|([AJQK_])))[,](?<L1>(([2-9])|(10)|([AJQK_])))[,](?<L2>(([2-9])|(10)|([AJQK_])))[,](?<L3>(([2-9])|(10)|([AJQK_])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str + ",";
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_X4_Zu24(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            string[] strArray = CanonicalNumber.Split(new char[] { ',' });
            if (strArray.Length < 4)
            {
                CanonicalNumber = "";
                return null;
            }
            ArrayList list = new ArrayList();
            int length = strArray.Length;
            for (int i = 0; i < (length - 3); i++)
            {
                for (int k = i + 1; k < (length - 2); k++)
                {
                    for (int m = k + 1; m < (length - 1); m++)
                    {
                        for (int n = m + 1; n < length; n++)
                        {
                            list.Add(strArray[i].ToString() + "," + strArray[k].ToString() + "," + strArray[m].ToString() + "," + strArray[n].ToString());
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_X4_Zu4(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            if (this.FilterRepeated(Number).Split(new char[] { ',' }).Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            if ((((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[1]) || (Number.Split(new char[] { ',' })[1] != Number.Split(new char[] { ',' })[2])) && ((Number.Split(new char[] { ',' })[1] != Number.Split(new char[] { ',' })[2]) || (Number.Split(new char[] { ',' })[2] != Number.Split(new char[] { ',' })[3]))) && (((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[2]) || (Number.Split(new char[] { ',' })[2] != Number.Split(new char[] { ',' })[3])) && ((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[1]) || (Number.Split(new char[] { ',' })[1] != Number.Split(new char[] { ',' })[3]))))
            {
                CanonicalNumber = "";
                return null;
            }
            Match match = new Regex("(?<L0>(([2-9])|(10)|([AJQK_])))[,](?<L1>(([2-9])|(10)|([AJQK_])))[,](?<L2>(([2-9])|(10)|([AJQK_])))[,](?<L3>(([2-9])|(10)|([AJQK_])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str + ",";
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_X4_Zu6(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            if (this.FilterRepeated(Number).Split(new char[] { ',' }).Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            if ((((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[1]) || (Number.Split(new char[] { ',' })[2] != Number.Split(new char[] { ',' })[3])) && ((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[3]) || (Number.Split(new char[] { ',' })[1] != Number.Split(new char[] { ',' })[2]))) && ((Number.Split(new char[] { ',' })[0] != Number.Split(new char[] { ',' })[2]) || (Number.Split(new char[] { ',' })[1] != Number.Split(new char[] { ',' })[3])))
            {
                CanonicalNumber = "";
                return null;
            }
            Match match = new Regex("(?<L0>(([2-9])|(10)|([AJQK_])))[,](?<L1>(([2-9])|(10)|([AJQK_])))[,](?<L2>(([2-9])|(10)|([AJQK_])))[,](?<L3>(([2-9])|(10)|([AJQK_])))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str + ",";
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            return new string[] { CanonicalNumber };
        }
    }
}
