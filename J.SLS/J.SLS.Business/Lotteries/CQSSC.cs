using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class CQSSC : LotteryBase
    {
        public const string Code = "SHSSL";
        public const int ID = 0x1c;
        public const double MaxMoney = 200000.0;
        public const string Name = "重庆时时彩";
        public const int PlayType_2X_ZuB = 0xafa;
        public const int PlayType_2X_ZuBD = 0xafb;
        public const int PlayType_2X_ZuD = 0xaf7;
        public const int PlayType_2X_ZuF = 0xaf8;
        public const int PlayType_2X_ZuFW = 0xaf9;
        public const int PlayType_3X_B = 0xafc;
        public const int PlayType_3X_ZHFS = 0xb01;
        public const int PlayType_3X_Zu3D = 0xafd;
        public const int PlayType_3X_Zu3F = 0xafe;
        public const int PlayType_3X_Zu6D = 0xaff;
        public const int PlayType_3X_Zu6F = 0xb00;
        public const int PlayType_3X_ZuB = 0xb02;
        public const int PlayType_3X_ZuBD = 0xb03;
        public const int PlayType_5X_TXD = 0xaf5;
        public const int PlayType_5X_TXF = 0xaf6;
        public const int PlayType_D = 0xaf1;
        public const int PlayType_DX = 0xaf4;
        public const int PlayType_F = 0xaf2;
        public const int PlayType_Mixed = 0xaf0;
        public const int PlayType_ZH = 0xaf3;
        public const string sID = "28";

        public CQSSC()
        {
            base.id = 0x1c;
            base.name = "重庆时时彩";
            base.code = "CQSSC";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0xaf0)
            {
                return this.AnalyseScheme_Mixed(Content, PlayType);
            }
            if (PlayType == 0xaf1)
            {
                return this.AnalyseScheme_D(Content, PlayType);
            }
            if (PlayType == 0xaf2)
            {
                return this.AnalyseScheme_F(Content, PlayType);
            }
            if (PlayType == 0xaf3)
            {
                return this.AnalyseScheme_ZH(Content, PlayType);
            }
            if (PlayType == 0xaf4)
            {
                return this.AnalyseScheme_DX(Content, PlayType);
            }
            if ((PlayType == 0xaf5) || (PlayType == 0xaf6))
            {
                return this.AnalyseScheme_5X_TX(Content, PlayType);
            }
            if ((PlayType == 0xaf7) || (PlayType == 0xaf8))
            {
                return this.AnalyseScheme_2X_ZuD_ZuF(Content, PlayType);
            }
            if (PlayType == 0xaf9)
            {
                return this.AnalyseScheme_2X_ZuFW(Content, PlayType);
            }
            if (PlayType == 0xafa)
            {
                return this.AnalyseScheme_2X_ZuB(Content, PlayType);
            }
            if (PlayType == 0xafb)
            {
                return this.AnalyseScheme_2X_ZuBD(Content, PlayType);
            }
            if (PlayType == 0xafc)
            {
                return this.AnalyseScheme_3X_B(Content, PlayType);
            }
            if (PlayType == 0xafd)
            {
                return this.AnalyseScheme_3X_Zu3D(Content, PlayType);
            }
            if (PlayType == 0xafe)
            {
                return this.AnalyseScheme_3X_Zu3F(Content, PlayType);
            }
            if (PlayType == 0xaff)
            {
                return this.AnalyseScheme_3X_Zu6D(Content, PlayType);
            }
            if (PlayType == 0xb00)
            {
                return this.AnalyseScheme_3X_Zu6F(Content, PlayType);
            }
            if (PlayType == 0xb01)
            {
                return this.AnalyseScheme_3X_ZHFS(Content, PlayType);
            }
            if (PlayType == 0xb02)
            {
                return this.AnalyseScheme_3X_ZuB(Content, PlayType);
            }
            if (PlayType == 0xb03)
            {
                return this.AnalyseScheme_3X_ZuBD(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_2X_ZuB(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_2X_ZuB(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_2X_ZuBD(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_2X_ZuBD(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_2X_ZuD_ZuF(string Content, int PlayType)
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
            if (PlayType == 0xaf7)
            {
                str2 = @"(\d){2}";
            }
            else
            {
                str2 = @"(\d){3,10}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2X_ZuD_ZuF(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xaf7) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0xaf8)
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

        private string AnalyseScheme_2X_ZuFW(string Content, int PlayType)
        {
            string[] strArray = Content.Trim().Split(new char[] { '\n' });
            if (strArray == null)
            {
                return "";
            }
            if (strArray.Length == 0)
            {
                return "";
            }
            string str = "";
            string pattern = @"([(](\d){2,10}[)][(](\d){2,10}[)])|([\d][(](\d){2,10}[)])|([(](\d){2,10}[)][\d])";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = base.FilterPreFix(strArray[i]);
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_2X_ZuFW(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_B(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_3X_B(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_ZHFS(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){3,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_ZHFS(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_Zu3D(string Content, int PlayType)
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
            string pattern = @"[\d]{3}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu3D(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_Zu3F(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_3X_Zu3F(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_Zu6D(string Content, int PlayType)
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
            string pattern = @"[\d]{3}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu6D(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_Zu6F(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){3,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu6F(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_ZuB(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_3X_ZuB(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_3X_ZuBD(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_3X_ZuBD(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_5X_TX(string Content, int PlayType)
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
            if (PlayType == 0xaf5)
            {
                str2 = @"([\d]){5}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){5}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_5X_TX(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xaf5) ? 1 : 2))) && (strArray2.Length <= 100000.0))
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

        private string AnalyseScheme_D(string Content, int PlayType)
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
            string pattern = @"(([\d])|([-])){4}[\d]";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_D(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_DX(string Content, int PlayType)
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
            string pattern = "([[]猜大小[]])*?([大小单双]){2}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_DX(match.Value.Replace("[猜大小]", ""), ref canonicalNumber);
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

        private string AnalyseScheme_F(string Content, int PlayType)
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
            string pattern = @"(([\d])|([-])){4}[\d]";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_F(match.Value, ref canonicalNumber);
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
                if (strArray[i].StartsWith("[单式]"))
                {
                    str3 = str3 + this.AnalyseScheme_D(strArray[i], 0xaf1);
                }
                if (strArray[i].StartsWith("[复式]"))
                {
                    str3 = str3 + this.AnalyseScheme_F(strArray[i], 0xaf2);
                }
                if (strArray[i].StartsWith("[组合玩法]"))
                {
                    str3 = str3 + this.AnalyseScheme_ZH(strArray[i], 0xaf3);
                }
                if (strArray[i].StartsWith("[猜大小]"))
                {
                    str3 = str3 + this.AnalyseScheme_DX(strArray[i], 0xaf4);
                }
                if (strArray[i].StartsWith("[五星通选单式]"))
                {
                    str3 = str3 + this.AnalyseScheme_5X_TX(strArray[i], 0xaf5);
                }
                if (strArray[i].StartsWith("[五星通选复式]"))
                {
                    str3 = str3 + this.AnalyseScheme_5X_TX(strArray[i], 0xaf6);
                }
                if (strArray[i].StartsWith("[二星组选单式]"))
                {
                    str3 = str3 + this.AnalyseScheme_2X_ZuD_ZuF(strArray[i], 0xaf7);
                }
                if (strArray[i].StartsWith("[二星组选复式]"))
                {
                    str3 = str3 + this.AnalyseScheme_2X_ZuD_ZuF(strArray[i], 0xaf8);
                }
                if (strArray[i].StartsWith("[二星组选分位]"))
                {
                    str3 = str3 + this.AnalyseScheme_2X_ZuFW(strArray[i], 0xaf9);
                }
                if (strArray[i].StartsWith("[二星组选包点]"))
                {
                    str3 = str3 + this.AnalyseScheme_2X_ZuB(strArray[i], 0xafa);
                }
                if (strArray[i].StartsWith("[二星组选包胆]"))
                {
                    str3 = str3 + this.AnalyseScheme_2X_ZuBD(strArray[i], 0xafb);
                }
                if (strArray[i].StartsWith("[三星包点]"))
                {
                    str3 = str3 + this.AnalyseScheme_3X_B(strArray[i], 0xafc);
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

        private string AnalyseScheme_ZH(string Content, int PlayType)
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
            string pattern = @"(([\d-])|([(][\d]+?[)])){4}(([\d])|([(][\d]+?[)]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 2))
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
            Regex regex = new Regex(@"([\d]){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(Number);
        }

        public override string BuildNumber(int Num, int Type)
        {
            if ((((Type != 5) && (Type != 3)) && ((Type != 2) && (Type != 1))) && (Type != -1))
            {
                Type = 5;
            }
            if (Type == -1)
            {
                return this.BuildNumber_DX(Num);
            }
            return this.BuildNumber_5321(Num, Type);
        }

        private string BuildNumber_5321(int Num, int Type)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = Type; j < 5; j++)
                {
                    str = str + "-";
                }
                for (int k = 0; k < Type; k++)
                {
                    str = str + random.Next(0, 10).ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        private string BuildNumber_DX(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 2; j++)
                {
                    str = str + "大小单双".Substring(random.Next(0, 4), 1);
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0xaf0) && (play_type <= 0xb03));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 20))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int winCountDX = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            if (PlayType == 0xaf0)
            {
                return this.ComputeWin_Mixed(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13], WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x16], WinMoneyList[0x17], WinMoneyList[0x18], WinMoneyList[0x19]);
            }
            if (PlayType == 0xaf1)
            {
                return this.ComputeWin_D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], ref num, ref num2, ref num3, ref num4);
            }
            if (PlayType == 0xaf2)
            {
                return this.ComputeWin_F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], ref num, ref num2, ref num3, ref num4);
            }
            if (PlayType == 0xaf3)
            {
                return this.ComputeWin_ZH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], ref num, ref num2, ref num3, ref num4);
            }
            if (PlayType == 0xaf4)
            {
                return this.ComputeWin_DX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9], ref winCountDX);
            }
            if ((PlayType == 0xaf5) || (PlayType == 0xaf6))
            {
                return this.ComputeWin_5X_TX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[14], WinMoneyList[15], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13], ref num8, ref num9, ref num10);
            }
            if ((PlayType == 0xaf7) || (PlayType == 0xaf8))
            {
                return this.ComputeWin_2X_ZuD_ZuF(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], ref num6);
            }
            if (PlayType == 0xaf9)
            {
                return this.ComputeWin_2X_ZuFW(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], ref num6, ref num7);
            }
            if (PlayType == 0xafa)
            {
                return this.ComputeWin_2X_ZuB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], ref num6, ref num7);
            }
            if (PlayType == 0xafb)
            {
                return this.ComputeWin_2X_ZuBD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], ref num6, ref num7);
            }
            if (PlayType == 0xafc)
            {
                return this.ComputeWin_3X_B(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], ref num2);
            }
            if (PlayType == 0xafd)
            {
                return this.ComputeWin_3X_Zu3D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x16], WinMoneyList[0x17], ref num11);
            }
            if (PlayType == 0xafe)
            {
                return this.ComputeWin_3X_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x16], WinMoneyList[0x17], ref num12);
            }
            if (PlayType == 0xaff)
            {
                return this.ComputeWin_3X_Zu6D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x18], WinMoneyList[0x19], ref num13);
            }
            if (PlayType == 0xb00)
            {
                return this.ComputeWin_3X_Zu6F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x18], WinMoneyList[0x19], ref num14);
            }
            if (PlayType == 0xb01)
            {
                return this.ComputeWin_3X_ZHFS(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[20], WinMoneyList[0x15], ref num15);
            }
            if (PlayType == 0xb02)
            {
                return this.ComputeWin_3X_ZuB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x16], WinMoneyList[0x17], WinMoneyList[0x18], WinMoneyList[0x19], ref num16, ref num11, ref num13);
            }
            if (PlayType == 0xb03)
            {
                return this.ComputeWin_3X_ZuBD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x16], WinMoneyList[0x17], WinMoneyList[0x18], WinMoneyList[0x19], ref num16, ref num11, ref num13);
            }
            return -4.0;
        }

        private double ComputeWin_2X_ZuB(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_2X_Zu, ref int WinCount_2X_Zu_DZH)
        {
            WinCount_2X_Zu = 0;
            WinCount_2X_Zu_DZH = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(3, 2);
            bool flag = WinNumber[0] == WinNumber[1];
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_2X_ZuB(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (!flag)
                            {
                                WinCount_2X_Zu++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                WinCount_2X_Zu_DZH++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_2X_Zu > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖" + ((int)WinCount_2X_Zu).ToString() + "注");
            }
            if (WinCount_2X_Zu_DZH > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖(对子号)" + ((int)WinCount_2X_Zu_DZH).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_2X_ZuBD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_2X_Zu, ref int WinCount_2X_Zu_DZH)
        {
            WinCount_2X_Zu = 0;
            WinCount_2X_Zu_DZH = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(3, 2);
            bool flag = WinNumber[0] == WinNumber[1];
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_2X_ZuBD(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (!flag)
                            {
                                WinCount_2X_Zu++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                WinCount_2X_Zu_DZH++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_2X_Zu > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖" + ((int)WinCount_2X_Zu).ToString() + "注");
            }
            if (WinCount_2X_Zu_DZH > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖(对子号)" + ((int)WinCount_2X_Zu_DZH).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_2X_ZuD_ZuF(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_2X_Zu)
        {
            WinCount_2X_Zu = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(3, 2);
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_2X_ZuD_ZuF(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_2X_Zu++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_2X_Zu > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖" + ((int)WinCount_2X_Zu).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_2X_ZuFW(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_2X_Zu, ref int WinCount_2X_Zu_DZH)
        {
            WinCount_2X_Zu = 0;
            WinCount_2X_Zu_DZH = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(3, 2);
            bool flag = WinNumber[0] == WinNumber[1];
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_2X_ZuFW(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (!flag)
                            {
                                WinCount_2X_Zu++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                WinCount_2X_Zu_DZH++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_2X_Zu > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖" + ((int)WinCount_2X_Zu).ToString() + "注");
            }
            if (WinCount_2X_Zu_DZH > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖(对子号)" + ((int)WinCount_2X_Zu_DZH).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_B(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_5XTX_2)
        {
            WinCount_5XTX_2 = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
                string[] strArray2 = this.ToSingle_3X_B(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber.Substring(2, 3)))
                        {
                            WinCount_5XTX_2++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_5XTX_2 > 0)
            {
                base.MergeWinDescription(ref Description, "三星奖" + ((int)WinCount_5XTX_2).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_ZHFS(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_ZHFS)
        {
            WinCount_3X_ZHFS = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_ZHFS(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
                        {
                            WinCount_3X_ZHFS++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_ZHFS > 0)
            {
                base.MergeWinDescription(ref Description, "三星直选奖" + ((int)WinCount_3X_ZHFS).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu3D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu3D)
        {
            WinCount_3X_Zu3D = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu3D(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu3D++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu3D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组3奖" + ((int)WinCount_3X_Zu3D).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu3F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu3F)
        {
            WinCount_3X_Zu3F = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu3F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu3F++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu3F > 0)
            {
                base.MergeWinDescription(ref Description, "三星组3奖" + ((int)WinCount_3X_Zu3F).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu6D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu6D)
        {
            WinCount_3X_Zu6D = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu6D(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6D++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu6D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组6奖" + ((int)WinCount_3X_Zu6D).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu6F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu6F)
        {
            WinCount_3X_Zu6F = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu6F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6F++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu6F > 0)
            {
                base.MergeWinDescription(ref Description, "三星组6奖" + ((int)WinCount_3X_Zu6F).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_ZuB(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, ref int WinCount_3X_ZX, ref int WinCount_3X_Zu3D, ref int WinCount_3X_Zu6D)
        {
            WinCount_3X_ZX = 0;
            WinCount_3X_Zu3D = 0;
            WinCount_3X_Zu6D = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_ZuB(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 1)
                        {
                            if (base.Sort(strArray2[j]) == base.Sort(WinNumber))
                            {
                                WinCount_3X_ZX++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                        else if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 2)
                        {
                            if (base.Sort(strArray2[j]) == base.Sort(WinNumber))
                            {
                                WinCount_3X_Zu3D++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                        else if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6D++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_ZX > 0)
            {
                base.MergeWinDescription(ref Description, "三星直选奖" + ((int)WinCount_3X_ZX).ToString() + "注");
            }
            if (WinCount_3X_Zu3D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组3奖" + ((int)WinCount_3X_Zu3D).ToString() + "注");
            }
            if (WinCount_3X_Zu6D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组6奖" + ((int)WinCount_3X_Zu6D).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_ZuBD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, ref int WinCount_3X_ZX, ref int WinCount_3X_Zu3D, ref int WinCount_3X_Zu6D)
        {
            WinCount_3X_ZX = 0;
            WinCount_3X_Zu3D = 0;
            WinCount_3X_Zu6D = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            WinNumber = WinNumber.Substring(2, 3);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_ZuBD(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 1)
                        {
                            if (base.Sort(strArray2[j]) == base.Sort(WinNumber))
                            {
                                WinCount_3X_ZX++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                        else if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 2)
                        {
                            if (base.Sort(strArray2[j]) == base.Sort(WinNumber))
                            {
                                WinCount_3X_Zu3D++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                        else if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6D++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_ZX > 0)
            {
                base.MergeWinDescription(ref Description, "三星直选奖" + ((int)WinCount_3X_ZX).ToString() + "注");
            }
            if (WinCount_3X_Zu3D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组3奖" + ((int)WinCount_3X_Zu3D).ToString() + "注");
            }
            if (WinCount_3X_Zu6D > 0)
            {
                base.MergeWinDescription(ref Description, "三星组6奖" + ((int)WinCount_3X_Zu6D).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_5X_TX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, ref int WinCount_5XTX_1, ref int WinCount_5XTX_2, ref int WinCount_5XTX_3)
        {
            WinCount_5XTX_1 = 0;
            WinCount_5XTX_2 = 0;
            WinCount_5XTX_3 = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
                string[] strArray2 = this.ToSingle_5X_TX(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 5)
                        {
                            if (strArray2[j] == WinNumber)
                            {
                                WinCount_5XTX_1++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            if ((strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)) || (strArray2[j].Substring(0, 3) == WinNumber.Substring(0, 3)))
                            {
                                WinCount_5XTX_2++;
                                num += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                            if ((strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)) || (strArray2[j].Substring(0, 2) == WinNumber.Substring(0, 2)))
                            {
                                WinCount_5XTX_3++;
                                num += WinMoney3;
                                WinMoneyNoWithTax += WinMoneyNoWithTax3;
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_5XTX_1 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选一等奖" + ((int)WinCount_5XTX_1).ToString() + "注");
            }
            if (WinCount_5XTX_2 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选二等奖" + ((int)WinCount_5XTX_2).ToString() + "注");
            }
            if (WinCount_5XTX_3 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选三等奖" + ((int)WinCount_5XTX_3).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, ref int WinCount5X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount3X = 0;
            WinCount2X = 0;
            WinCount1X = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
                string[] strArray2 = this.ToSingle_D(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount3X > 0)
            {
                base.MergeWinDescription(ref Description, "三星奖" + ((int)WinCount3X).ToString() + "注");
            }
            if (WinCount2X > 0)
            {
                base.MergeWinDescription(ref Description, "二星奖" + ((int)WinCount2X).ToString() + "注");
            }
            if (WinCount1X > 0)
            {
                base.MergeWinDescription(ref Description, "一星奖" + ((int)WinCount1X).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_DX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCountDX)
        {
            WinCountDX = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
            string str = "";
            string str2 = "";
            int num = _Convert.StrToInt(WinNumber.Substring(3, 1), 0);
            str = str + ((num <= 4) ? "小" : "大") + (((num % 2) == 0) ? "双" : "单");
            num = _Convert.StrToInt(WinNumber.Substring(4, 1), 0);
            str2 = str2 + ((num <= 4) ? "小" : "大") + (((num % 2) == 0) ? "双" : "单");
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_DX(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (((strArray2[j].Length >= 2) && (str.IndexOf(strArray2[j][0]) >= 0)) && (str2.IndexOf(strArray2[j][1]) >= 0))
                        {
                            WinCountDX++;
                            num2 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCountDX > 0)
            {
                base.MergeWinDescription(ref Description, "猜大小奖" + ((int)WinCountDX).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, ref int WinCount5X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount3X = 0;
            WinCount2X = 0;
            WinCount1X = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
                string[] strArray2 = this.ToSingle_F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount3X > 0)
            {
                base.MergeWinDescription(ref Description, "三星奖" + ((int)WinCount3X).ToString() + "注");
            }
            if (WinCount2X > 0)
            {
                base.MergeWinDescription(ref Description, "二星奖" + ((int)WinCount2X).ToString() + "注");
            }
            if (WinCount1X > 0)
            {
                base.MergeWinDescription(ref Description, "一星奖" + ((int)WinCount1X).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_Mixed(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7, double WinMoney8, double WinMoneyNoWithTax8, double WinMoney9, double WinMoneyNoWithTax9, double WinMoney10, double WinMoneyNoWithTax10, double WinMoney11, double WinMoneyNoWithTax11, double WinMoney12, double WinMoneyNoWithTax12, double WinMoney13, double WinMoneyNoWithTax13)
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
                int num13 = 0;
                int num14 = 0;
                int num15 = 0;
                int num16 = 0;
                int winCountDX = 0;
                int num18 = 0;
                int num19 = 0;
                int num20 = 0;
                int num21 = 0;
                int num22 = 0;
                double winMoneyNoWithTax = 0.0;
                if (strArray[i].StartsWith("[单式]"))
                {
                    num += this.ComputeWin_D(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, WinMoney2, WinMoneyNoWithTax2, WinMoney3, WinMoneyNoWithTax3, WinMoney4, WinMoneyNoWithTax4, ref num13, ref num14, ref num15, ref num16);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += num13;
                    num3 += num14;
                    num4 += num15;
                    num5 += num16;
                }
                else if (strArray[i].StartsWith("[复式]"))
                {
                    num += this.ComputeWin_F(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, WinMoney2, WinMoneyNoWithTax2, WinMoney3, WinMoneyNoWithTax3, WinMoney4, WinMoneyNoWithTax4, ref num13, ref num14, ref num15, ref num16);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += num13;
                    num3 += num14;
                    num4 += num15;
                    num5 += num16;
                }
                else if (strArray[i].StartsWith("[组合玩法]"))
                {
                    num += this.ComputeWin_ZH(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney1, WinMoneyNoWithTax1, WinMoney2, WinMoneyNoWithTax2, WinMoney3, WinMoneyNoWithTax3, WinMoney4, WinMoneyNoWithTax4, ref num13, ref num14, ref num15, ref num16);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num2 += num13;
                    num3 += num14;
                    num4 += num15;
                    num5 += num16;
                }
                else if (strArray[i].StartsWith("[猜大小]"))
                {
                    num += this.ComputeWin_DX(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney5, WinMoneyNoWithTax5, ref winCountDX);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num6 += winCountDX;
                }
                else if (strArray[i].StartsWith("[五星通选单式]") || strArray[i].StartsWith("[五星通选复式]"))
                {
                    num += this.ComputeWin_5X_TX(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney8, WinMoneyNoWithTax8, WinMoney9, WinMoneyNoWithTax9, WinMoney10, WinMoneyNoWithTax10, ref num20, ref num21, ref num22);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num9 += num20;
                    num10 += num21;
                    num11 += num22;
                }
                else if (strArray[i].StartsWith("[二星组选单式]") || strArray[i].StartsWith("[二星组选复式]"))
                {
                    num += this.ComputeWin_2X_ZuD_ZuF(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney6, WinMoneyNoWithTax6, ref num18);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num7 += num18;
                }
                else if (strArray[i].StartsWith("[二星组选分位]"))
                {
                    num += this.ComputeWin_2X_ZuFW(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney6, WinMoneyNoWithTax6, WinMoney7, WinMoneyNoWithTax7, ref num18, ref num19);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num7 += num18;
                    num8 += num19;
                }
                else if (strArray[i].StartsWith("[二星组选包点]"))
                {
                    num += this.ComputeWin_2X_ZuB(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney6, WinMoneyNoWithTax6, WinMoney7, WinMoneyNoWithTax7, ref num18, ref num19);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num7 += num18;
                    num8 += num19;
                }
                else if (strArray[i].StartsWith("[二星组选包胆]"))
                {
                    num += this.ComputeWin_2X_ZuBD(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney6, WinMoneyNoWithTax6, WinMoney7, WinMoneyNoWithTax7, ref num18, ref num19);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num7 += num18;
                    num8 += num19;
                }
                else if (strArray[i].StartsWith("[三星包点]"))
                {
                    num += this.ComputeWin_3X_B(base.FilterPreFix(strArray[i]), WinNumber, ref Description, ref winMoneyNoWithTax, WinMoney2, WinMoneyNoWithTax2, ref num21);
                    WinMoneyNoWithTax += winMoneyNoWithTax;
                    num3 += num21;
                }
            }
            Description = "";
            if (num2 > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + num2.ToString() + "注");
            }
            if (num3 > 0)
            {
                base.MergeWinDescription(ref Description, "三星奖" + num3.ToString() + "注");
            }
            if (num4 > 0)
            {
                base.MergeWinDescription(ref Description, "二星奖" + num4.ToString() + "注");
            }
            if (num5 > 0)
            {
                base.MergeWinDescription(ref Description, "一星奖" + num5.ToString() + "注");
            }
            if (num6 > 0)
            {
                base.MergeWinDescription(ref Description, "猜大小奖" + num6.ToString() + "注");
            }
            if (num7 > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖" + num7.ToString() + "注");
            }
            if (num8 > 0)
            {
                base.MergeWinDescription(ref Description, "二星组选奖(对子号)" + num8.ToString() + "注");
            }
            if (num9 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选一等奖" + num9.ToString() + "注");
            }
            if (num10 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选二等奖" + num10.ToString() + "注");
            }
            if (num11 > 0)
            {
                base.MergeWinDescription(ref Description, "五星通选三等奖" + num11.ToString() + "注");
            }
            return num;
        }

        private double ComputeWin_ZH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, ref int WinCount5X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount3X = 0;
            WinCount2X = 0;
            WinCount1X = 0;
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 5)
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
                string[] strArray2 = this.ToSingle_ZH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount3X > 0)
            {
                base.MergeWinDescription(ref Description, "三星奖" + ((int)WinCount3X).ToString() + "注");
            }
            if (WinCount2X > 0)
            {
                base.MergeWinDescription(ref Description, "二星奖" + ((int)WinCount2X).ToString() + "注");
            }
            if (WinCount1X > 0)
            {
                base.MergeWinDescription(ref Description, "一星奖" + ((int)WinCount1X).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private string ConvertFormatToElectronTicket_HPCQ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID == 0xaf1) || (PlayTypeID == 0xaf2)) || ((PlayTypeID == 0xaf5) || (PlayTypeID == 0xaf6))) || ((PlayTypeID == 0xafd) || (PlayTypeID == 0xaff)))
            {
                for (int i = 0; i < Number.Length; i++)
                {
                    if (((i % 5) == 0) && (i > 0))
                    {
                        str = str.Substring(0, str.Length - 1) + "\n" + Number.Substring(i, 1) + ",";
                    }
                    else
                    {
                        str = str + Number.Substring(i, 1) + ",";
                    }
                }
            }
            if (PlayTypeID == 0xaf3)
            {
                string[] strArray = new string[5];
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int j = 0; j < 5; j++)
                {
                    strArray[j] = match.Groups["L" + j.ToString()].ToString().Trim();
                    if (strArray[j].Length > 1)
                    {
                        strArray[j] = strArray[j].Substring(1, strArray[j].Length - 2);
                    }
                    str = str + strArray[j].ToString() + ",";
                }
            }
            if (PlayTypeID == 0xaf4)
            {
                Number = Number.Replace("大", "2").Replace("小", "1").Replace("单", "5").Replace("双", "4");
                for (int k = 0; k < Number.Length; k++)
                {
                    if (((k % 2) == 0) && (k > 0))
                    {
                        str = str.Substring(0, str.Length - 1) + "\n" + Number.Substring(k, 1) + ",";
                    }
                    else
                    {
                        str = str + Number.Substring(k, 1) + ",";
                    }
                }
            }
            if (PlayTypeID == 0xaf7)
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int m = 0; m < strArray2.Length; m++)
                {
                    str = str + "_,_,_,";
                    for (int n = 0; n < strArray2[m].Length; n++)
                    {
                        str = str + strArray2[m].Substring(n, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            if (((PlayTypeID == 0xaf8) || (PlayTypeID == 0xafe)) || (((PlayTypeID == 0xb00) || (PlayTypeID == 0xb01)) || (PlayTypeID == 0xb02)))
            {
                for (int num6 = 0; num6 < Number.Length; num6++)
                {
                    str = str + Number.Substring(num6, 1) + ",";
                }
            }
            if (PlayTypeID == 0xaf9)
            {
                str = str + "_,_,_,";
                string[] strArray3 = new string[2];
                Match match2 = new Regex(@"(?<L0>([\d])|([(][\d]+?[)]))(?<L1>([\d])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int num7 = 0; num7 < 2; num7++)
                {
                    strArray3[num7] = match2.Groups["L" + num7.ToString()].ToString().Trim();
                    if (strArray3[num7].Length > 1)
                    {
                        strArray3[num7] = strArray3[num7].Substring(1, strArray3[num7].Length - 2);
                    }
                    str = str + strArray3[num7].ToString() + ",";
                }
            }
            if (PlayTypeID == 0xafa)
            {
                str = str + Number + ",";
            }
            if ((PlayTypeID == 0xafb) || (PlayTypeID == 0xb03))
            {
                str = str + Number + ",";
            }
            if (PlayTypeID == 0xafc)
            {
                str = str + Number + ",";
            }
            return str.Substring(0, str.Length - 1).Replace("-", "_");
        }

        private string FilterRepeated(string NumberPart)
        {
            string str = "";
            for (int i = 0; i < NumberPart.Length; i++)
            {
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("0123456789-".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return base.Sort(str);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { 
                    new PlayType(0xaf0, "混合投注"), new PlayType(0xaf1, "单式"), new PlayType(0xaf2, "复式"), new PlayType(0xaf3, "组合玩法"), new PlayType(0xaf4, "猜大小"), new PlayType(0xaf5, "五星通选单式"), new PlayType(0xaf6, "五星通选复式"), new PlayType(0xaf7, "二星组选单式"), new PlayType(0xaf8, "二星组选复式"), new PlayType(0xaf9, "二星组选分位"), new PlayType(0xafa, "二星组选包点"), new PlayType(0xafb, "二星组选包胆"), new PlayType(0xafc, "三星包点"), new PlayType(0xafd, "三星组3单式"), new PlayType(0xafe, "三星组3复式"), new PlayType(0xaff, "三星组6单式"), 
                    new PlayType(0xb00, "三星组6复式"), new PlayType(0xb01, "三星直选组合复式"), new PlayType(0xb02, "三星组选包胆"), new PlayType(0xb03, "三星组选包点")
                 };
        }

        public override string GetPrintKeyList(string Number, int PlayTypeID, string LotteryMachine)
        {
            Number = Number.Trim();
            if (Number != "")
            {
                string str;
                string[] numbers = Number.Split(new char[] { '\n' });
                if ((numbers == null) || (numbers.Length < 1))
                {
                    return "";
                }
                if (((str = LotteryMachine) != null) && (str == "LT-E"))
                {
                    if (PlayTypeID == 0xaf1)
                    {
                        return this.GetPrintKeyList_LT_E_D(numbers);
                    }
                    if (PlayTypeID == 0xaf2)
                    {
                        return this.GetPrintKeyList_LT_E_F(numbers);
                    }
                    if (PlayTypeID == 0xaf3)
                    {
                        return this.GetPrintKeyList_LT_E_Zu(numbers);
                    }
                    if (PlayTypeID == 0xaf4)
                    {
                        return this.GetPrintKeyList_LT_E_DX(numbers);
                    }
                }
            }
            return "";
        }

        private string GetPrintKeyList_LT_E_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("-", "").Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
                if (str3.Length == 1)
                {
                    str = str + "[Q]";
                }
                if (str3.Length == 2)
                {
                    str = str + "[R]";
                }
                if (str3.Length == 3)
                {
                    str = str + "[3]";
                }
                if (str3.Length == 5)
                {
                    str = str + "[1]";
                }
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_DX(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2)
                {
                    if (ch.ToString() == "小")
                    {
                        str = str + "[Q]";
                    }
                    if (ch.ToString() == "大")
                    {
                        str = str + "[R]";
                    }
                    if (ch.ToString() == "单")
                    {
                        str = str + "[S]";
                    }
                    if (ch.ToString() == "双")
                    {
                        str = str + "[双]";
                    }
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7").Replace("双", "1");
        }

        private string GetPrintKeyList_LT_E_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("-", "").Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
                if (str3.Length == 2)
                {
                    str = str + "[Q]";
                }
                if (str3.Length == 3)
                {
                    str = str + "[R]";
                }
                if (str3.Length == 5)
                {
                    str = str + "[1]";
                }
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_Zu(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                int num = 0;
                for (int i = 0; i < str2.Length; i++)
                {
                    if (str2.Substring(i, 1) == "-")
                    {
                        num++;
                    }
                }
                switch (num)
                {
                    case 0:
                        str = str + "[X]";
                        break;

                    case 2:
                        str = str + "[T]";
                        break;

                    case 3:
                        str = str + "[S]";
                        break;
                }
                str = str + num.ToString();
                foreach (char ch in str2)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7").Replace("X", "4");
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override Ticket[] ToElectronicTicket_HPCQ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0xaf0)
            {
                return this.ToElectronicTicket_HPCQ_Mixed(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf1)
            {
                return this.ToElectronicTicket_HPCQ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf2)
            {
                return this.ToElectronicTicket_HPCQ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf3)
            {
                return this.ToElectronicTicket_HPCQ_ZH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf4)
            {
                return this.ToElectronicTicket_HPCQ_DX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf5)
            {
                return this.ToElectronicTicket_HPCQ_5X_TXD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf6)
            {
                return this.ToElectronicTicket_HPCQ_5X_TXF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf7)
            {
                return this.ToElectronicTicket_HPCQ_2X_ZuD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf8)
            {
                return this.ToElectronicTicket_HPCQ_2X_ZuF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaf9)
            {
                return this.ToElectronicTicket_HPCQ_2X_ZuFW(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xafa)
            {
                return this.ToElectronicTicket_HPCQ_2X_ZuB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xafb)
            {
                return this.ToElectronicTicket_HPCQ_2X_ZuBD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xafc)
            {
                return this.ToElectronicTicket_HPCQ_3X_B(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xafd)
            {
                return this.ToElectronicTicket_HPCQ_3X_Zu3D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xafe)
            {
                return this.ToElectronicTicket_HPCQ_3X_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xaff)
            {
                return this.ToElectronicTicket_HPCQ_3X_Zu6D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb00)
            {
                return this.ToElectronicTicket_HPCQ_3X_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb01)
            {
                return this.ToElectronicTicket_HPCQ_3X_ZHFS(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb02)
            {
                return this.ToElectronicTicket_HPCQ_3X_ZuB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xb03)
            {
                return this.ToElectronicTicket_HPCQ_3X_ZuBD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private Ticket[] ToElectronicTicket_HPCQ_2X_ZuB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuB(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(310, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_2X_ZuBD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuBD(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x137, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_2X_ZuD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuD_ZuF(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x133, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_2X_ZuF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuD_ZuF(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x134, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_2X_ZuFW(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuFW(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x135, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_B(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_B(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x130, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_ZHFS(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_ZHFS(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x13f, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_Zu3D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_Zu3D(Number, PlayTypeID).Split(new char[] { '\n' });
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
                            number = number + "--" + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x139, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_Zu3F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x13b, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_Zu6D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_Zu6D(Number, PlayTypeID).Split(new char[] { '\n' });
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
                            number = number + "--" + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x13a, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_Zu6F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x13c, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_ZuB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_ZuB(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x13d, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_3X_ZuBD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_3X_ZuBD(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x13e, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_5X_TXD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_5X_TX(Number, PlayTypeID).Split(new char[] { '\n' });
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x138, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_5X_TXF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            ArrayList list = new ArrayList();
            string content = "";
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_5X_TX(Number, ref canonicalNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                content = content + strArray[i] + "\n";
            }
            string[] strArray2 = this.AnalyseScheme_5X_TX(content, 0xaf5).Split(new char[] { '\n' });
            if (strArray2 == null)
            {
                return null;
            }
            if (strArray2.Length == 0)
            {
                return null;
            }
            Money = 0.0;
            int num2 = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num2 = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num2 = Multiple / MaxMultiple;
            }
            int multiple = 1;
            double num4 = 0.0;
            for (int j = 1; j < (num2 + 1); j++)
            {
                if ((j * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((j - 1) * MaxMultiple);
                }
                for (int m = 0; m < strArray2.Length; m += 5)
                {
                    string number = "";
                    num4 = 0.0;
                    for (int n = 0; n < 5; n++)
                    {
                        if ((m + n) < strArray2.Length)
                        {
                            number = number + strArray2[m + n].ToString().Split(new char[] { '|' })[0];
                            num4 += 2.0 * double.Parse(strArray2[m + n].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num4 * multiple;
                    list.Add(new Ticket(0x138, this.ConvertFormatToElectronTicket_HPCQ(0xaf5, number), multiple, num4 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int k = 0; k < ticketArray.Length; k++)
            {
                ticketArray[k] = (Ticket)list[k];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_D(Number, PlayTypeID).Split(new char[] { '\n' });
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x12d, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_DX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_DX(Number, PlayTypeID).Split(new char[] { '\n' });
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x132, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x12e, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPCQ_Mixed(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            Ticket[] ticketArray;
            string[] strArray = base.SplitLotteryNumber(Number);
            if (strArray == null)
            {
                return null;
            }
            if (strArray.Length < 1)
            {
                return null;
            }
            Money = 0.0;
            string[] strArray2 = new string[] { "", "", "", "", "", "", "", "", "", "", "", "" };
            foreach (string str in strArray)
            {
                if (str.StartsWith("[单式]"))
                {
                    string[] strArray5;
                    (strArray5 = strArray2)[0] = strArray5[0] + str + "\n";
                }
                else if (str.StartsWith("[复式]"))
                {
                    string[] strArray6;
                    (strArray6 = strArray2)[1] = strArray6[1] + str + "\n";
                }
                else if (str.StartsWith("[组合玩法]"))
                {
                    string[] strArray7;
                    (strArray7 = strArray2)[2] = strArray7[2] + str + "\n";
                }
                else if (str.StartsWith("[猜大小]"))
                {
                    string[] strArray8;
                    (strArray8 = strArray2)[3] = strArray8[3] + str + "\n";
                }
                else if (str.StartsWith("[五星通选单式]"))
                {
                    string[] strArray9;
                    (strArray9 = strArray2)[4] = strArray9[4] + str + "\n";
                }
                else if (str.StartsWith("[五星通选复式]"))
                {
                    string[] strArray10;
                    (strArray10 = strArray2)[5] = strArray10[5] + str + "\n";
                }
                else if (str.StartsWith("[二星组选单式]"))
                {
                    string[] strArray11;
                    (strArray11 = strArray2)[6] = strArray11[6] + str + "\n";
                }
                else if (str.StartsWith("[二星组选复式]"))
                {
                    string[] strArray12;
                    (strArray12 = strArray2)[7] = strArray12[7] + str + "\n";
                }
                else if (str.StartsWith("[二星组选分位]"))
                {
                    string[] strArray13;
                    (strArray13 = strArray2)[8] = strArray13[8] + str + "\n";
                }
                else if (str.StartsWith("[二星组选包点]"))
                {
                    string[] strArray14;
                    (strArray14 = strArray2)[9] = strArray14[9] + str + "\n";
                }
                else if (str.StartsWith("[二星组选包胆]"))
                {
                    string[] strArray15;
                    (strArray15 = strArray2)[10] = strArray15[10] + str + "\n";
                }
                else if (str.StartsWith("[三星包点]"))
                {
                    string[] strArray16;
                    (strArray16 = strArray2)[11] = strArray16[11] + str + "\n";
                }
            }
            ArrayList list = new ArrayList();
            if (strArray2[0].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_D(0xaf1, strArray2[0].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket in ticketArray)
                    {
                        list.Add(ticket);
                    }
                }
            }
            if (strArray2[1].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_F(0xaf2, strArray2[1].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket2 in ticketArray)
                    {
                        list.Add(ticket2);
                    }
                }
            }
            if (strArray2[2].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_ZH(0xaf3, strArray2[2].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket3 in ticketArray)
                    {
                        list.Add(ticket3);
                    }
                }
            }
            if (strArray2[3].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_DX(0xaf4, strArray2[3].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket4 in ticketArray)
                    {
                        list.Add(ticket4);
                    }
                }
            }
            if (strArray2[4].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_5X_TXD(0xaf5, strArray2[4].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket5 in ticketArray)
                    {
                        list.Add(ticket5);
                    }
                }
            }
            if (strArray2[5].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_5X_TXF(0xaf6, strArray2[5].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket6 in ticketArray)
                    {
                        list.Add(ticket6);
                    }
                }
            }
            if (strArray2[6].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_2X_ZuD(0xaf7, strArray2[6].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket7 in ticketArray)
                    {
                        list.Add(ticket7);
                    }
                }
            }
            if (strArray2[7].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_2X_ZuF(0xaf8, strArray2[7].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket8 in ticketArray)
                    {
                        list.Add(ticket8);
                    }
                }
            }
            if (strArray2[8].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_2X_ZuFW(0xaf9, strArray2[8].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket9 in ticketArray)
                    {
                        list.Add(ticket9);
                    }
                }
            }
            if (strArray2[9].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_2X_ZuB(0xafa, strArray2[9].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket10 in ticketArray)
                    {
                        list.Add(ticket10);
                    }
                }
            }
            if (strArray2[10].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_2X_ZuBD(0xafb, strArray2[10].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket11 in ticketArray)
                    {
                        list.Add(ticket11);
                    }
                }
            }
            if (strArray2[11].Length > 0)
            {
                ticketArray = this.ToElectronicTicket_HPCQ_3X_B(0xafc, strArray2[11].ToString(), Multiple, MaxMultiple, ref Money);
                if (ticketArray != null)
                {
                    foreach (Ticket ticket12 in ticketArray)
                    {
                        list.Add(ticket12);
                    }
                }
            }
            Ticket[] ticketArray2 = new Ticket[list.Count];
            for (int i = 0; i < ticketArray2.Length; i++)
            {
                ticketArray2[i] = (Ticket)list[i];
            }
            return ticketArray2;
        }

        private Ticket[] ToElectronicTicket_HPCQ_ZH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_ZH(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0x12f, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
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
            if (PlayType == 0xaf0)
            {
                return this.ToSingle_Mixed(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaf1)
            {
                return this.ToSingle_D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaf2)
            {
                return this.ToSingle_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaf3)
            {
                return this.ToSingle_ZH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaf4)
            {
                return this.ToSingle_DX(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0xaf5) || (PlayType == 0xaf6))
            {
                return this.ToSingle_5X_TX(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0xaf7) || (PlayType == 0xaf8))
            {
                return this.ToSingle_2X_ZuD_ZuF(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaf9)
            {
                return this.ToSingle_2X_ZuFW(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xafa)
            {
                return this.ToSingle_2X_ZuB(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xafb)
            {
                return this.ToSingle_2X_ZuBD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xafc)
            {
                return this.ToSingle_3X_B(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xafd)
            {
                return this.ToSingle_3X_Zu3D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xafe)
            {
                return this.ToSingle_3X_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xaff)
            {
                return this.ToSingle_3X_Zu6D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb00)
            {
                return this.ToSingle_3X_Zu6F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb01)
            {
                return this.ToSingle_3X_ZHFS(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb02)
            {
                return this.ToSingle_3X_ZuB(Number, ref CanonicalNumber);
            }
            if (PlayType == 0xb03)
            {
                return this.ToSingle_3X_ZuBD(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_2X_ZuB(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            ArrayList list = new ArrayList();
            if ((num < 0) || (num > 0x12))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i <= 9; i++)
            {
                for (int k = i; k <= 9; k++)
                {
                    if ((i + k) == num)
                    {
                        list.Add(i.ToString() + k.ToString());
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

        private string[] ToSingle_2X_ZuBD(string sBill, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(sBill.Trim());
            if (CanonicalNumber.Length < 1)
            {
                CanonicalNumber = "";
                return null;
            }
            if (CanonicalNumber.Length > 2)
            {
                CanonicalNumber = CanonicalNumber.Substring(0, 2);
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < length; i++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    list.Add(chArray[i].ToString() + k.ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_2X_ZuD_ZuF(string Number, ref string CanonicalNumber)
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
                    list.Add(chArray[i].ToString() + chArray[k].ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_2X_ZuFW(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]{2,10}[)]))(?<L1>(\d)|([(][\d]{2,10}[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if ((this.FilterRepeated(match.Groups["L0"].ToString()).Length < 2) && (this.FilterRepeated(match.Groups["L1"].ToString()).Length < 2))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i].StartsWith("("))
                {
                    strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                    strArray[i] = this.FilterRepeated(strArray[i]);
                }
                if (strArray[i].Length < 1)
                {
                    CanonicalNumber = "";
                    return null;
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

        private string[] ToSingle_3X_B(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            ArrayList list = new ArrayList();
            if ((num < 0) || (num > 0x1b))
            {
                CanonicalNumber = "";
                return null;
            }
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

        private string[] ToSingle_3X_ZHFS(string Number, ref string CanonicalNumber)
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
            for (int i = 0; i < chArray.Length; i++)
            {
                for (int k = 0; k < chArray.Length; k++)
                {
                    for (int m = 0; m < chArray.Length; m++)
                    {
                        if (((i != k) && (k != m)) && ((i != m) && !list.Contains(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString())))
                        {
                            list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString());
                        }
                    }
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_3X_Zu3D(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            if (this.FilterRepeated(Number.Trim()).Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_3X_Zu3F(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_3X_Zu6D(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            if (this.FilterRepeated(Number.Trim()).Length != 3)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_3X_Zu6F(string Number, ref string CanonicalNumber)
        {
            return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_3X_ZuB(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = Number;
            if ((CanonicalNumber.Length < 1) || (CanonicalNumber.Length > 2))
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            if (length == 1)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int k = 0; k <= 9; k++)
                    {
                        for (int m = 0; m <= 9; m++)
                        {
                            if ((chArray[j].ToString() == k.ToString()) && !list.Contains(chArray[j].ToString() + k.ToString() + m.ToString()))
                            {
                                list.Add(chArray[j].ToString() + k.ToString() + m.ToString());
                            }
                            if ((k.ToString() == m.ToString()) && !list.Contains(chArray[j].ToString() + k.ToString() + m.ToString()))
                            {
                                list.Add(chArray[j].ToString() + k.ToString() + m.ToString());
                            }
                            if (((chArray[j].ToString() != k.ToString()) && (chArray[j].ToString() != m.ToString())) && ((k.ToString() != m.ToString()) && !list.Contains(base.Sort(chArray[j].ToString() + k.ToString() + m.ToString()))))
                            {
                                list.Add(base.Sort(chArray[j].ToString() + k.ToString() + m.ToString()));
                            }
                        }
                    }
                }
            }
            else
            {
                for (int n = 0; n <= 9; n++)
                {
                    list.Add(Number + n.ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_3X_ZuBD(string Number, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(Number, -1);
            CanonicalNumber = "";
            ArrayList list = new ArrayList();
            for (int i = 0; i <= 9; i++)
            {
                for (int m = 0; m <= 9; m++)
                {
                    for (int n = 0; n <= 9; n++)
                    {
                        if (((((i + m) + n) == num) && (i == m)) && (m == n))
                        {
                            list.Add(i.ToString() + m.ToString() + n.ToString());
                        }
                    }
                }
            }
            if ((num < 1) || (num > 0x1a))
            {
                if (list.Count > 0)
                {
                    string[] strArray = new string[list.Count];
                    for (int num5 = 0; num5 < list.Count; num5++)
                    {
                        strArray[num5] = list[num5].ToString();
                    }
                    CanonicalNumber = num.ToString();
                    return strArray;
                }
                CanonicalNumber = "";
                return null;
            }
            for (int j = 0; j <= 9; j++)
            {
                for (int num7 = 0; num7 <= 9; num7++)
                {
                    if ((j != num7) && (((j + j) + num7) == num))
                    {
                        list.Add(j.ToString() + j.ToString() + num7.ToString());
                    }
                }
            }
            if ((num >= 3) && (num <= 0x18))
            {
                for (int num8 = 0; num8 <= 7; num8++)
                {
                    for (int num9 = num8 + 1; num9 <= 8; num9++)
                    {
                        for (int num10 = num9 + 1; num10 <= 9; num10++)
                        {
                            if (((num8 + num9) + num10) == num)
                            {
                                list.Add(num8.ToString() + num9.ToString() + num10.ToString());
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
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_5X_TX(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[5];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 5; i++)
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
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string str4 = str3 + strArray[3][num5].ToString();
                            for (int num6 = 0; num6 < strArray[4].Length; num6++)
                            {
                                string str5 = str4 + strArray[4][num6].ToString();
                                list.Add(str5);
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

        private string[] ToSingle_D(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|(-))(?<L1>(\d)|(-))(?<L2>(\d)|(-))(?<L3>(\d)|(-))(?<L4>(\d))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 5; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str;
            }
            Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
            bool flag = false;
            for (int j = 0; j < 4; j++)
            {
                if (regexArray[j].IsMatch(CanonicalNumber))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                return null;
            }
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_DX(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>([大小单双]))(?<L1>([大小单双]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str;
            }
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_F(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.ToSingle_D(Number, ref CanonicalNumber);
            if ((strArray == null) || (strArray.Length != 1))
            {
                return null;
            }
            Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
            string[] strArray2 = null;
            if (regexArray[0].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("--" + CanonicalNumber.Substring(2, 3)), ("---" + CanonicalNumber.Substring(3, 2)), ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[1].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("---" + CanonicalNumber.Substring(3, 2)), ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[2].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[3].IsMatch(CanonicalNumber))
            {
                strArray2 = new string[] { CanonicalNumber };
            }
            return strArray2;
        }

        private string[] ToSingle_Mixed(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            string lotteryNumberPreFix = base.GetLotteryNumberPreFix(Number);
            if (Number.StartsWith("[单式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_D(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_F(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[组合玩法]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_ZH(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[猜大小]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_DX(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[五星通选单式]") || Number.StartsWith("[五星通选复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_5X_TX(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[二星组选单式]") || Number.StartsWith("[二星组选复式]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_2X_ZuD_ZuF(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[二星组选分位]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_2X_ZuFW(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[二星组选包点]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_2X_ZuB(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[二星组选包胆]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_2X_ZuBD(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            if (Number.StartsWith("[三星包点]"))
            {
                return base.MergeLotteryNumberPreFix(this.ToSingle_3X_B(base.FilterPreFix(Number), ref CanonicalNumber), lotteryNumberPreFix);
            }
            return null;
        }

        private string[] ToSingle_ZH(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[5];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 5; i++)
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
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string str4 = str3 + strArray[3][num5].ToString();
                            for (int num6 = 0; num6 < strArray[4].Length; num6++)
                            {
                                string number = str4 + strArray[4][num6].ToString();
                                string canonicalNumber = "";
                                string[] strArray2 = this.ToSingle_D(number, ref canonicalNumber);
                                if ((strArray2 != null) && (strArray2.Length >= 1))
                                {
                                    list.Add(number);
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray3 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray3[k] = list[k].ToString();
            }
            return strArray3;
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
    }
}
