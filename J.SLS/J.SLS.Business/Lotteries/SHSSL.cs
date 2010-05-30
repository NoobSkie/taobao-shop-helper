using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SHSSL : LotteryBase
    {
        public const string Code = "SHSSL";
        public const int ID = 0x1d;
        public const double MaxMoney = 20000.0;
        public const string Name = "上海时时乐";
        public const int PlayType_H1D = 0xb62;
        public const int PlayType_H1F = 0xb63;
        public const int PlayType_H2D = 0xb5e;
        public const int PlayType_H2F = 0xb5f;
        public const int PlayType_Mixed = 0xb54;
        public const int PlayType_Q1D = 0xb60;
        public const int PlayType_Q1F = 0xb61;
        public const int PlayType_Q2D = 0xb5c;
        public const int PlayType_Q2F = 0xb5d;
        public const int PlayType_ZhiD = 0xb55;
        public const int PlayType_ZhiF = 0xb56;
        public const int PlayType_ZhiH = 0xb5a;
        public const int PlayType_Zu3F = 0xb59;
        public const int PlayType_Zu6F = 0xb58;
        public const int PlayType_ZuD = 0xb57;
        public const int PlayType_ZuH = 0xb5b;
        public const string sID = "29";

        public SHSSL()
        {
            base.id = 0x1d;
            base.name = "上海时时乐";
            base.code = "SHSSL";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0xb54)
            {
                return this.AnalyseScheme_Mixed(Content, PlayType);
            }
            if ((PlayType == 0xb55) || (PlayType == 0xb56))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if ((PlayType == 0xb57) || (PlayType == 0xb58))
            {
                return this.AnalyseScheme_Zu3D_Zu6(Content, PlayType);
            }
            if (PlayType == 0xb59)
            {
                return this.AnalyseScheme_Zu3F(Content, PlayType);
            }
            if (PlayType == 0xb5a)
            {
                return this.AnalyseScheme_ZhiH(Content, PlayType);
            }
            if (PlayType == 0xb5b)
            {
                return this.AnalyseScheme_ZuH(Content, PlayType);
            }
            if (((PlayType == 0xb5c) || (PlayType == 0xb5d)) || ((PlayType == 0xb5e) || (PlayType == 0xb5f)))
            {
                return this.AnalyseScheme_2(Content, PlayType);
            }
            if (((PlayType != 0xb60) && (PlayType != 0xb61)) && ((PlayType != 0xb62) && (PlayType != 0xb63)))
            {
                return "";
            }
            return this.AnalyseScheme_1(Content, PlayType);
        }

        private string AnalyseScheme_1(string Content, int PlayType)
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
            if ((PlayType == 0xb60) || (PlayType == 0xb62))
            {
                str2 = @"([\d]){1}";
            }
            else
            {
                str2 = @"([\d]){1,10}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_1(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= (((PlayType == 0xb60) || (PlayType == 0xb62)) ? 1 : 2)))
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

        private string AnalyseScheme_2(string Content, int PlayType)
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
            if ((PlayType == 0xb5c) || (PlayType == 0xb5e))
            {
                str2 = @"([\d]){2}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){2}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= (((PlayType == 0xb5c) || (PlayType == 0xb5e)) ? 1 : 2)))
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
                if (strArray[i].StartsWith("[直选单式]"))
                {
                    str3 = this.AnalyseScheme_Zhi(strArray[i], 0xb55);
                }
                if (strArray[i].StartsWith("[直选复式]"))
                {
                    str3 = this.AnalyseScheme_Zhi(strArray[i], 0xb56);
                }
                if (strArray[i].StartsWith("[组选单式]"))
                {
                    str3 = this.AnalyseScheme_Zu3D_Zu6(strArray[i], 0xb57);
                }
                if (strArray[i].StartsWith("[组选6复式]"))
                {
                    str3 = this.AnalyseScheme_Zu3D_Zu6(strArray[i], 0xb58);
                }
                if (strArray[i].StartsWith("[组选3复式]"))
                {
                    str3 = this.AnalyseScheme_Zu3F(strArray[i], 0xb59);
                }
                if (strArray[i].StartsWith("[直选和值]"))
                {
                    str3 = this.AnalyseScheme_ZhiH(strArray[i], 0xb5a);
                }
                if (strArray[i].StartsWith("[组选和值]"))
                {
                    str3 = this.AnalyseScheme_ZuH(strArray[i], 0xb5b);
                }
                if (strArray[i].StartsWith("[前2单式]"))
                {
                    str3 = this.AnalyseScheme_2(strArray[i], 0xb5c);
                }
                if (strArray[i].StartsWith("[前2复式]"))
                {
                    str3 = this.AnalyseScheme_2(strArray[i], 0xb5d);
                }
                if (strArray[i].StartsWith("[后2单式]"))
                {
                    str3 = this.AnalyseScheme_2(strArray[i], 0xb5e);
                }
                if (strArray[i].StartsWith("[后2复式]"))
                {
                    str3 = this.AnalyseScheme_2(strArray[i], 0xb5f);
                }
                if (strArray[i].StartsWith("[前1单式]"))
                {
                    str3 = this.AnalyseScheme_1(strArray[i], 0xb60);
                }
                if (strArray[i].StartsWith("[前1复式]"))
                {
                    str3 = this.AnalyseScheme_1(strArray[i], 0xb61);
                }
                if (strArray[i].StartsWith("[后1单式]"))
                {
                    str3 = this.AnalyseScheme_1(strArray[i], 0xb62);
                }
                if (strArray[i].StartsWith("[后1复式]"))
                {
                    str3 = this.AnalyseScheme_1(strArray[i], 0xb63);
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
            if (PlayType == 0xb55)
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
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xb55) ? 1 : 2)))
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

        private string AnalyseScheme_ZhiH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiH(match.Value, ref canonicalNumber);
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
            if (PlayType == 0xb57)
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
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xb57) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0xb58)
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

        private string AnalyseScheme_ZuH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZuH(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronicTicket_DYJ_ZhiH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiH(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronicTicket_DYJ_ZuH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZuH(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronicTicket_ZhiH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiH(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronicTicket_ZuH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZuH(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronTicket_2D(string Content, int PlayType)
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
            if ((PlayType == 0xb5c) || (PlayType == 0xb5e))
            {
                str2 = @"([\d]){2}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){2}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2(match.Value, ref canonicalNumber);
                    if (strArray2 != null)
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

        private string AnalyseSchemeToElectronTicket_2F(string Content, int PlayType)
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
            if ((PlayType == 0xb5c) || (PlayType == 0xb5e))
            {
                str2 = @"([\d]){2}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){2}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronTicket_DYJ_2D(string Content, int PlayType)
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
            if ((PlayType == 0xb5c) || (PlayType == 0xb5e))
            {
                str2 = @"([\d]){2}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){2}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronTicket_DYJ_2F(string Content, int PlayType)
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
            if ((PlayType == 0xb5c) || (PlayType == 0xb5e))
            {
                str2 = @"([\d]){2}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){2}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronTicket_DYJ_Zu3F(string Content, int PlayType)
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

        private string AnalyseSchemeToElectronTicket_DYJ_Zu6F(string Content, int PlayType)
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
            if (PlayType == 0xb57)
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
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xb57) ? 1 : 2)))
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

        private string AnalyseSchemeToElectronTicket_Zu3F(string Content, int PlayType)
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

        private string AnalyseSchemeToElectronTicket_Zu6F(string Content, int PlayType)
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
            if (PlayType == 0xb57)
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
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xb57) ? 1 : 2)))
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
            return ((play_type >= 0xb54) && (play_type <= 0xb63));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 14))
            {
                return -3.0;
            }
            int winCount = 0;
            int num2 = 0;
            int num3 = 0;
            if (PlayType == 0xb54)
            {
                return this.ComputeWin_Mixed(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13]);
            }
            if ((PlayType == 0xb55) || (PlayType == 0xb56))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], ref winCount);
            }
            if ((PlayType == 0xb57) || (PlayType == 0xb58))
            {
                return this.ComputeWin_Zu3D_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], ref num2, ref num3);
            }
            if (PlayType == 0xb59)
            {
                return this.ComputeWin_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], ref winCount);
            }
            if (PlayType == 0xb5a)
            {
                return this.ComputeWin_ZhiH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], ref winCount);
            }
            if (PlayType == 0xb5b)
            {
                return this.ComputeWin_ZuH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], ref num2, ref num3);
            }
            if ((PlayType == 0xb5c) || (PlayType == 0xb5d))
            {
                return this.ComputeWin_Q2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7], ref winCount);
            }
            if ((PlayType == 0xb5e) || (PlayType == 0xb5f))
            {
                return this.ComputeWin_H2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9], ref winCount);
            }
            if ((PlayType == 0xb60) || (PlayType == 0xb61))
            {
                return this.ComputeWin_Q1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], ref winCount);
            }
            if ((PlayType != 0xb62) && (PlayType != 0xb63))
            {
                return -4.0;
            }
            return this.ComputeWin_H1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], ref winCount);
        }

        private double ComputeWin_H1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(2, 1);
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
                string[] strArray2 = this.ToSingle_1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 1) && (strArray2[j] == WinNumber))
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
                Description = "后1奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_H2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(1, 2);
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
                string[] strArray2 = this.ToSingle_2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (strArray2[j] == WinNumber))
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
                Description = "后2奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_Mixed(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7)
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
            for (int i = 0; i < strArray.Length; i++)
            {
                int winCount = 0;
                int num11 = 0;
                int num12 = 0;
                double winMoneyNoWithTax = 0.0;
                if (strArray[i].StartsWith("[直选单式]") || strArray[i].StartsWith("[直选复式]"))
                {
                    num += this.ComputeWin_Zhi(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += winCount;
                }
                else if (strArray[i].StartsWith("[组选单式]") || strArray[i].StartsWith("[组选6复式]"))
                {
                    num += this.ComputeWin_Zu3D_Zu6(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney2, WinMoneyNoWithTax2, WinMoney3, WinMoneyNoWithTax3, ref num11, ref num12);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num3 += num11;
                    num4 += num12;
                }
                else if (strArray[i].StartsWith("[组选3复式]"))
                {
                    num += this.ComputeWin_Zu3F(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney2, WinMoneyNoWithTax2, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num3 += winCount;
                }
                else if (strArray[i].StartsWith("[直选和值]"))
                {
                    num += this.ComputeWin_ZhiH(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += winCount;
                }
                else if (strArray[i].StartsWith("[组选和值]"))
                {
                    num += this.ComputeWin_ZuH(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney2, WinMoneyNoWithTax2, WinMoney3, WinMoneyNoWithTax3, ref num11, ref num12);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num3 += num11;
                    num4 += num12;
                }
                else if (strArray[i].StartsWith("[前2单式]") || strArray[i].StartsWith("[前2复式]"))
                {
                    num += this.ComputeWin_Q2(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney4, WinMoneyNoWithTax4, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num5 += winCount;
                }
                else if (strArray[i].StartsWith("[后2单式]") || strArray[i].StartsWith("[后2复式]"))
                {
                    num += this.ComputeWin_H2(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney5, WinMoneyNoWithTax5, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num6 += winCount;
                }
                else if (strArray[i].StartsWith("[前1单式]") || strArray[i].StartsWith("[前1复式]"))
                {
                    num += this.ComputeWin_Q1(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney6, WinMoneyNoWithTax6, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num7 += winCount;
                }
                else if (strArray[i].StartsWith("[后1单式]") || strArray[i].StartsWith("[后1复式]"))
                {
                    num += this.ComputeWin_H1(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney7, WinMoneyNoWithTax7, ref winCount);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num8 += winCount;
                }
            }
            Description = "";
            if (num2 > 0)
            {
                base.MergeWinDescription(ref Description, "单选奖" + num2.ToString() + "注");
            }
            if (num3 > 0)
            {
                base.MergeWinDescription(ref Description, "组3奖" + num3.ToString() + "注");
            }
            if (num4 > 0)
            {
                base.MergeWinDescription(ref Description, "组6奖" + num4.ToString() + "注");
            }
            if (num5 > 0)
            {
                base.MergeWinDescription(ref Description, "前2奖" + num5.ToString() + "注");
            }
            if (num6 > 0)
            {
                base.MergeWinDescription(ref Description, "后2奖" + num6.ToString() + "注");
            }
            if (num7 > 0)
            {
                base.MergeWinDescription(ref Description, "前1奖" + num7.ToString() + "注");
            }
            if (num8 > 0)
            {
                base.MergeWinDescription(ref Description, "后1奖" + num8.ToString() + "注");
            }
            return num;
        }

        private double ComputeWin_Q1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 1);
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
                string[] strArray2 = this.ToSingle_1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 1) && (strArray2[j] == WinNumber))
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
                Description = "前1奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_Q2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 2);
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
                string[] strArray2 = this.ToSingle_2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (strArray2[j] == WinNumber))
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
                Description = "前2奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
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
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "直选奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_ZhiH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
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
                Description = "单选奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_Zu3D_Zu6(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_Zu3, ref int WinCount_Zu6)
        {
            WinCount_Zu3 = 0;
            WinCount_Zu6 = 0;
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                if (strArray[i].Length >= 3)
                {
                    if (this.FilterRepeated(base.Sort(strArray[i])).Length == 2)
                    {
                        if (base.Sort(strArray[i]) == base.Sort(WinNumber))
                        {
                            WinCount_Zu3++;
                            num += WinMoney1;
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
                                    WinCount_Zu6++;
                                    num += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_Zu3 > 0)
            {
                base.MergeWinDescription(ref Description, "组选3奖" + ((int)WinCount_Zu3).ToString() + "注");
            }
            if (WinCount_Zu6 > 0)
            {
                base.MergeWinDescription(ref Description, "组选6奖" + ((int)WinCount_Zu6).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_Zu3F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount)
        {
            WinCount = 0;
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
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
                            WinCount++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            if (WinCount > 0)
            {
                Description = "组选3奖" + ((int)WinCount).ToString() + "注。";
            }
            return num;
        }

        private double ComputeWin_ZuH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_Zu3, ref int WinCount_Zu6)
        {
            WinCount_Zu3 = 0;
            WinCount_Zu6 = 0;
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
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (this.FilterRepeated(strArray2[j]).Length == 2)
                            {
                                WinCount_Zu3++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                WinCount_Zu6++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_Zu3 > 0)
            {
                base.MergeWinDescription(ref Description, "组选3奖" + ((int)WinCount_Zu3).ToString() + "注");
            }
            if (WinCount_Zu6 > 0)
            {
                base.MergeWinDescription(ref Description, "组选6奖" + ((int)WinCount_Zu6).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private string ConvertFormatToElectronTicket_DYJ_1(int PlayTypeID, string Number)
        {
            string str = "";
            if (Number.EndsWith("\n"))
            {
                Number = Number.Substring(0, Number.Length - 1);
            }
            string[] strArray = Number.Split(new char[] { '\n' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "1D|";
                if ((PlayTypeID == 0xb62) || (PlayTypeID == 0xb63))
                {
                    str = str + "-,-,";
                }
                str = str + strArray[i].ToString();
                if ((PlayTypeID == 0xb60) || (PlayTypeID == 0xb61))
                {
                    str = str + ",-,-";
                }
                str = str + ";\n";
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_DYJ_2D(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (PlayTypeID == 0xb5c)
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str = str + "2D|";
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    str = str + "-;\n";
                }
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    str = str + "2D|" + "-,";
                    for (int m = 0; m < strArray2[k].Length; m++)
                    {
                        str = str + strArray2[k].Substring(m, 1) + ",";
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
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_DYJ_2F(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[2];
            string str = "";
            str = str + "2D|";
            if (PlayTypeID == 0xb5f)
            {
                str = str + "-,";
            }
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    return "";
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
                        return "";
                    }
                }
                str = str + strArray[i] + ",";
            }
            if (PlayTypeID == 0xb5d)
            {
                str = str + "-,";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return (str.Replace("-", "_") + ";");
        }

        private string ConvertFormatToElectronTicket_DYJ_D(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (((PlayTypeID == 0xb55) || (PlayTypeID == 0xb58)) || (((PlayTypeID == 0xb59) || (PlayTypeID == 0xb5b)) || (PlayTypeID == 0xb57)))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (PlayTypeID == 0xb55)
                    {
                        str = str + "1|";
                    }
                    else if (PlayTypeID == 0xb58)
                    {
                        str = str + "F6|";
                    }
                    else if (PlayTypeID == 0xb59)
                    {
                        str = str + "F3|";
                    }
                    else if (PlayTypeID == 0xb5b)
                    {
                        str = str + "6|";
                    }
                    else if (PlayTypeID == 0xb57)
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
            else if (PlayTypeID == 0xb5a)
            {
                str = str + "S1|" + Number + ";";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_DYJ_F(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[3];
            string str = "";
            if (PlayTypeID == 0xb56)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                str = str + "1|";
                for (int i = 0; i < 3; i++)
                {
                    strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (strArray[i] == "")
                    {
                        return "";
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
                            return "";
                        }
                    }
                    str = str + strArray[i] + ",";
                }
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return (str.Replace("-", "_") + ";");
        }

        private string ConvertFormatToElectronTicket_HPSH_1(int PlayTypeID, string Number)
        {
            string str = "";
            if (Number.EndsWith("\n"))
            {
                Number = Number.Substring(0, Number.Length - 1);
            }
            string[] strArray = Number.Split(new char[] { '\n' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((PlayTypeID == 0xb62) || (PlayTypeID == 0xb63))
                {
                    str = str + "-,-,";
                }
                str = str + strArray[i].ToString();
                if ((PlayTypeID == 0xb60) || (PlayTypeID == 0xb61))
                {
                    str = str + ",-,-";
                }
                str = str + "\n";
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_HPSH_2D(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (PlayTypeID == 0xb5c)
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    str = str + "-\n";
                }
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    str = str + "-,";
                    for (int m = 0; m < strArray2[k].Length; m++)
                    {
                        str = str + strArray2[k].Substring(m, 1) + ",";
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
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_HPSH_2F(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[2];
            string str = "";
            if (PlayTypeID == 0xb5f)
            {
                str = "-,";
            }
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    return "";
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
                        return "";
                    }
                }
                str = str + strArray[i] + ",";
            }
            if (PlayTypeID == 0xb5d)
            {
                str = str + "-,";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_HPSH_D(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID == 0xb55) || (PlayTypeID == 0xb5a)) || ((PlayTypeID == 0xb58) || (PlayTypeID == 0xb59))) || ((PlayTypeID == 0xb5b) || (PlayTypeID == 0xb57)))
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
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string ConvertFormatToElectronTicket_HPSH_F(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[3];
            string str = "";
            if (PlayTypeID == 0xb56)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int i = 0; i < 3; i++)
                {
                    strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (strArray[i] == "")
                    {
                        return "";
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
                            return "";
                        }
                    }
                    str = str + strArray[i] + ",";
                }
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str.Replace("-", "_");
        }

        private string FilterRepeated(string NumberPart)
        {
            string str = "";
            for (int i = 0; i < NumberPart.Length; i++)
            {
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("-0123456789".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return base.Sort(str);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0xb54, "混合投注"), new PlayType(0xb55, "直选单式"), new PlayType(0xb56, "直选复式"), new PlayType(0xb57, "组选单式"), new PlayType(0xb58, "组选6复式"), new PlayType(0xb59, "组选3复式"), new PlayType(0xb5a, "直选和值"), new PlayType(0xb5b, "组选和值"), new PlayType(0xb5c, "前2单式"), new PlayType(0xb5d, "前2复式"), new PlayType(0xb5e, "后2单式"), new PlayType(0xb5f, "后2复式"), new PlayType(0xb60, "前1单式"), new PlayType(0xb61, "前1复式"), new PlayType(0xb62, "后1单式"), new PlayType(0xb63, "后1复式") };
        }

        private string HPSH_ConvertFormatToElectronTicket(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            foreach (string str2 in Number.Split(new char[] { ',' }))
            {
                if (str2.Length > 1)
                {
                    str = str + "(" + str2 + ")";
                }
                else if (!(str2 == "_"))
                {
                    str = str + str2;
                }
            }
            return str;
        }

        private string HPSH_ConvertFormatToElectronTicket_1F(int PlayTypeID, string Number)
        {
            return Number.Trim();
        }

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            if ((PlayTypeID == 0xb55) || (PlayTypeID == 0xb5a))
            {
                return this.HPSH_ToElectronicTicket_D(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0xb56)
            {
                return this.HPSH_ToElectronicTicket_F(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (((PlayTypeID == 0xb57) || (PlayTypeID == 0xb5b)) || ((PlayTypeID == 0xb58) || (PlayTypeID == 0xb59)))
            {
                return this.HPSH_ToElectronicTicket_ZuD(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if ((((PlayTypeID == 0xb5c) || (PlayTypeID == 0xb5e)) || ((PlayTypeID == 0xb60) || (PlayTypeID == 0xb62))) || ((PlayTypeID == 0xb5d) || (PlayTypeID == 0xb5f)))
            {
                return this.HPSH_ToElectronicTicket_2D(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if ((PlayTypeID != 0xb61) && (PlayTypeID != 0xb63))
            {
                return "";
            }
            return this.HPSH_ToElectronicTicket_1F(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
        }

        private string HPSH_ToElectronicTicket_1F(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket_1F(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPSH_ToElectronicTicket_2D(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPSH_ToElectronicTicket_D(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0xb55;
            return "";
        }

        private string HPSH_ToElectronicTicket_F(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0xb56;
            return "";
        }

        private string HPSH_ToElectronicTicket_ZuD(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = 0xb57;
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override Ticket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0xb55)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb56)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb57)
            {
                return this.ToElectronicTicket_DYJ_ZuD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb5a)
            {
                return this.ToElectronicTicket_DYJ_ZhiH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb5b)
            {
                return this.ToElectronicTicket_DYJ_ZuH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb58)
            {
                return this.ToElectronicTicket_DYJ_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb59)
            {
                return this.ToElectronicTicket_DYJ_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb5c) || (PlayTypeID == 0xb5e))
            {
                return this.ToElectronicTicket_DYJ_2D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb5d) || (PlayTypeID == 0xb5f))
            {
                return this.ToElectronicTicket_DYJ_2F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb60) || (PlayTypeID == 0xb62))
            {
                return this.ToElectronicTicket_DYJ_1D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID != 0xb61) && (PlayTypeID != 0xb63))
            {
                return null;
            }
            return this.ToElectronicTicket_DYJ_1F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
        }

        private Ticket[] ToElectronicTicket_DYJ_1D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_1(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_DYJ_1(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_1F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_1(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    if (strArray[k].ToString().Split(new char[] { '|' })[0].Length > 1)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_DYJ_1(PlayTypeID, number), multiple, num3 * multiple));
                    }
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_2D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_DYJ_2D(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_DYJ_2D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_2F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_DYJ_2F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    if (strArray[k].ToString().Split(new char[] { '|' })[0].Length > 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_DYJ_2F(PlayTypeID, number), multiple, num3 * multiple));
                    }
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_DYJ_F(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_ZhiH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_ZhiH(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_DYJ_Zu3F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_DYJ_Zu6F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_ZuD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_ZuH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DYJ_ZuH(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_DYJ_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        public override Ticket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0xb55)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb56)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb57)
            {
                return this.ToElectronicTicket_HPSH_ZuD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb5a)
            {
                return this.ToElectronicTicket_HPSH_ZhiH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb5b)
            {
                return this.ToElectronicTicket_HPSH_ZuH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb58)
            {
                return this.ToElectronicTicket_HPSH_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb59)
            {
                return this.ToElectronicTicket_HPSH_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb5c) || (PlayTypeID == 0xb5e))
            {
                return this.ToElectronicTicket_HPSH_2D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb5d) || (PlayTypeID == 0xb5f))
            {
                return this.ToElectronicTicket_HPSH_2F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0xb60) || (PlayTypeID == 0xb62))
            {
                return this.ToElectronicTicket_HPSH_1D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID != 0xb61) && (PlayTypeID != 0xb63))
            {
                return null;
            }
            return this.ToElectronicTicket_HPSH_1F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
        }

        private Ticket[] ToElectronicTicket_HPSH_1D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_1(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_HPSH_1(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_1F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_1(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_HPSH_1(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_2D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_2D(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_HPSH_2D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_2F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_2F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_HPSH_2F(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_HPSH_F(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_ZhiH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_ZhiH(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_Zu3F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronTicket_Zu6F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_ZuD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_ZuH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_ZuH(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_HPSH_D(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0xb54)
            {
                return this.ToSingle_Mixed(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0xb55) || (PlayType == 0xb56))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0xb57) || (PlayType == 0xb58))
            {
                return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb59)
            {
                return this.ToSingle_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb5a)
            {
                return this.ToSingle_ZhiH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb5b)
            {
                return this.ToSingle_ZuH(Number, ref CanonicalNumber);
            }
            if (((PlayType == 0xb5c) || (PlayType == 0xb5d)) || ((PlayType == 0xb5e) || (PlayType == 0xb5f)))
            {
                return this.ToSingle_2(Number, ref CanonicalNumber);
            }
            if (((PlayType != 0xb60) && (PlayType != 0xb61)) && ((PlayType != 0xb62) && (PlayType != 0xb63)))
            {
                return null;
            }
            return this.ToSingle_1(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_1(string Number, ref string CanonicalNumber)
        {
            char[] chArray = this.FilterRepeated(Number.Trim()).ToCharArray();
            CanonicalNumber = "";
            if (chArray.Length < 1)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray = new string[chArray.Length];
            for (int i = 0; i < chArray.Length; i++)
            {
                strArray[i] = chArray[i].ToString();
                CanonicalNumber = CanonicalNumber + chArray[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
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
                    list.Add(str2);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Mixed(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            string lotteryNumberPreFix = base.GetLotteryNumberPreFix(Number);
            if (Number.StartsWith("[直选单式]") || Number.StartsWith("[直选复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_Zhi(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[组选单式]") || Number.StartsWith("[组选6复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_Zu3D_Zu6(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[组选3复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_Zu3F(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[直选和值]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_ZhiH(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[组选和值]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_ZuH(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if ((Number.StartsWith("[前2单式]") || Number.StartsWith("[前2复式]")) || (Number.StartsWith("[后2单式]") || Number.StartsWith("[后2复式]")))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_2(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if ((!Number.StartsWith("[前1单式]") && !Number.StartsWith("[前1复式]")) && (!Number.StartsWith("[后1单式]") && !Number.StartsWith("[后1复式]")))
            {
                return null;
            }
            return base.MergeLotteryNumberPreFix(this.ToSingle_1(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
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

        private string[] ToSingle_ZhiH(string sBill, ref string CanonicalNumber)
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

        private string[] ToSingle_ZuH(string sBill, ref string CanonicalNumber)
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
