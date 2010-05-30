using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class JXSSC : LotteryBase
    {
        public const string Code = "JXSSC";
        public const int ID = 0x3d;
        public const double MaxMoney = 200000.0;
        public const string Name = "江西时时彩";
        public const int PlayType_2X_ZhiB = 0x17e0;
        public const int PlayType_2X_ZuB = 0x17de;
        public const int PlayType_2X_ZuBD = 0x17df;
        public const int PlayType_2X_ZuD = 0x17db;
        public const int PlayType_2X_ZuF = 0x17dc;
        public const int PlayType_2X_ZuFW = 0x17dd;
        public const int PlayType_3X_Zu3D = 0x17e1;
        public const int PlayType_3X_Zu3F = 0x17e2;
        public const int PlayType_3X_Zu6D = 0x17e3;
        public const int PlayType_3X_Zu6F = 0x17e4;
        public const int PlayType_5X_TXD = 0x17d9;
        public const int PlayType_5X_TXF = 0x17da;
        public const int PlayType_D = 0x17d5;
        public const int PlayType_DX = 0x17d8;
        public const int PlayType_F = 0x17d6;
        public const int PlayType_RX1 = 0x17e5;
        public const int PlayType_RX2 = 0x17e6;
        public const int PlayType_ZH = 0x17d7;
        public const string sID = "61";

        public JXSSC()
        {
            base.id = 0x3d;
            base.name = "江西时时彩";
            base.code = "JXSSC";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0x17d5)
            {
                return this.AnalyseScheme_D(Content, PlayType);
            }
            if (PlayType == 0x17d6)
            {
                return this.AnalyseScheme_F(Content, PlayType);
            }
            if (PlayType == 0x17d7)
            {
                return this.AnalyseScheme_ZH(Content, PlayType);
            }
            if (PlayType == 0x17d8)
            {
                return this.AnalyseScheme_DX(Content, PlayType);
            }
            if ((PlayType == 0x17d9) || (PlayType == 0x17da))
            {
                return this.AnalyseScheme_5X_TX(Content, PlayType);
            }
            if (PlayType == 0x17db)
            {
                return this.AnalyseScheme_2X_ZuD(Content, PlayType);
            }
            if (PlayType == 0x17dc)
            {
                return this.AnalyseScheme_2X_ZuF(Content, PlayType);
            }
            if (PlayType == 0x17dd)
            {
                return this.AnalyseScheme_2X_ZuFW(Content, PlayType);
            }
            if (PlayType == 0x17de)
            {
                return this.AnalyseScheme_2X_ZuB(Content, PlayType);
            }
            if (PlayType == 0x17df)
            {
                return this.AnalyseScheme_2X_ZuBD(Content, PlayType);
            }
            if (PlayType == 0x17e0)
            {
                return this.AnalyseScheme_2X_ZhiB(Content, PlayType);
            }
            if (PlayType == 0x17e1)
            {
                return this.AnalyseScheme_3X_Zu3D(Content, PlayType);
            }
            if (PlayType == 0x17e3)
            {
                return this.AnalyseScheme_3X_Zu6D(Content, PlayType);
            }
            if (PlayType == 0x17e2)
            {
                return this.AnalyseScheme_3X_Zu3F(Content, PlayType);
            }
            if (PlayType == 0x17e4)
            {
                return this.AnalyseScheme_3X_Zu6F(Content, PlayType);
            }
            if (PlayType == 0x17e5)
            {
                return this.AnalyseScheme_RX1(Content, PlayType);
            }
            if (PlayType == 0x17e6)
            {
                return this.AnalyseScheme_RX2(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_2X_ZhiB(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_2X_ZhiB(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_2X_ZuD(string Content, int PlayType)
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
            if (PlayType == 0x17db)
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
                    string[] strArray2 = this.ToSingle_2X_ZuD(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x17db) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x17dc)
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

        private string AnalyseScheme_2X_ZuF(string Content, int PlayType)
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
            if (PlayType == 0x17db)
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
                    string[] strArray2 = this.ToSingle_2X_ZuF(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x17db) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x17dc)
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
            Regex regex = new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu3D(match.Value, ref canonicalNumber);
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
            Regex regex = new Regex(@"([\d]){2,10}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu3F(match.Value, ref canonicalNumber);
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
            Regex regex = new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu6D(match.Value, ref canonicalNumber);
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
            Regex regex = new Regex(@"([\d]){3,10}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3X_Zu6F(match.Value, ref canonicalNumber);
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
            if (PlayType == 0x17d9)
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
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x17d9) ? 1 : 2))) && (strArray2.Length <= 100000.0))
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
            Regex regex = new Regex(@"(([-])|(\d)|([(][\d]+?[)])){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX1(match.Value, ref canonicalNumber);
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
            Regex regex = new Regex(@"(([-])|(\d)|([(][\d]+?[)])){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_RX2(match.Value, ref canonicalNumber);
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

        private string AnalyseSchemeToElectronicTicket_F(string Content, int PlayType)
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
            if (PlayType == 0x17d9)
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

        public override bool AnalyseWinNumber(string Number)
        {
            Regex regex = new Regex(@"([\d]){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(Number);
        }

        public override string BuildNumber(int Num, int Type)
        {
            if ((((Type != 5) && (Type != 4)) && ((Type != 3) && (Type != 2))) && ((Type != 1) && (Type != -1)))
            {
                Type = 5;
            }
            if (Type == -1)
            {
                return this.BuildNumber_DX(Num);
            }
            return this.BuildNumber_54321(Num, Type);
        }

        private string BuildNumber_54321(int Num, int Type)
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
            return ((play_type >= 0x17d5) && (play_type <= 0x17e6));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 30))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int winCountDX = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            if (PlayType == 0x17d5)
            {
                return this.ComputeWin_D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], ref num, ref num2, ref num3, ref num4, ref num5);
            }
            if (PlayType == 0x17d6)
            {
                return this.ComputeWin_F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], ref num, ref num2, ref num3, ref num4, ref num5);
            }
            if (PlayType == 0x17d7)
            {
                return this.ComputeWin_ZH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], ref num, ref num2, ref num3, ref num4, ref num5);
            }
            if (PlayType == 0x17d8)
            {
                return this.ComputeWin_DX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11], ref winCountDX);
            }
            if ((PlayType == 0x17d9) || (PlayType == 0x17da))
            {
                return this.ComputeWin_5X_TX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13], WinMoneyList[20], WinMoneyList[0x15], ref num9, ref num10, ref num11);
            }
            if (PlayType == 0x17db)
            {
                return this.ComputeWin_2X_ZuD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], ref num7);
            }
            if (PlayType == 0x17dc)
            {
                return this.ComputeWin_2X_ZuF(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], ref num7, ref num8);
            }
            if (PlayType == 0x17dd)
            {
                return this.ComputeWin_2X_ZuFW(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], ref num7, ref num8);
            }
            if (PlayType == 0x17de)
            {
                return this.ComputeWin_2X_ZuB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], ref num7, ref num8);
            }
            if (PlayType == 0x17df)
            {
                return this.ComputeWin_2X_ZuBD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], ref num7, ref num8);
            }
            if (PlayType == 0x17e0)
            {
                return this.ComputeWin_2X_ZhiB(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7], ref num4);
            }
            if (PlayType == 0x17e1)
            {
                return this.ComputeWin_3X_Zu3D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x16], WinMoneyList[0x17], ref num12);
            }
            if (PlayType == 0x17e3)
            {
                return this.ComputeWin_3X_Zu6D(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x18], WinMoneyList[0x19], ref num13);
            }
            if (PlayType == 0x17e2)
            {
                return this.ComputeWin_3X_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x16], WinMoneyList[0x17], ref num12);
            }
            if (PlayType == 0x17e4)
            {
                return this.ComputeWin_3X_Zu6F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x18], WinMoneyList[0x19], ref num13);
            }
            if (PlayType == 0x17e5)
            {
                return this.ComputeWin_RX1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x1a], WinMoneyList[0x1b], ref num14);
            }
            if (PlayType == 0x17e6)
            {
                return this.ComputeWin_RX2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x1c], WinMoneyList[0x1d], ref num15);
            }
            return -4.0;
        }

        private double ComputeWin_2X_ZhiB(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount2X)
        {
            WinCount2X = 0;
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
                string[] strArray2 = this.ToSingle_2X_ZhiB(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            WinCount2X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount2X > 0)
            {
                base.MergeWinDescription(ref Description, "二星直选奖" + ((int)WinCount2X).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
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

        private double ComputeWin_2X_ZuD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_2X_Zu)
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
                string[] strArray2 = this.ToSingle_2X_ZuD(strArray[i], ref canonicalNumber);
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

        private double ComputeWin_2X_ZuF(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCount_2X_Zu, ref int WinCount_2X_Zu_DZH)
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
                string[] strArray2 = this.ToSingle_2X_ZuF(strArray[i], ref canonicalNumber);
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

        private double ComputeWin_3X_Zu3D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu3)
        {
            WinCount_3X_Zu3 = 0;
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
            WinNumber = WinNumber.Substring(2, 3);
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu3D(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j].Substring(2, 3)) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu3++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu3 > 0)
            {
                base.MergeWinDescription(ref Description, "三星组选三奖" + ((int)WinCount_3X_Zu3).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu3F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu3)
        {
            WinCount_3X_Zu3 = 0;
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
            WinNumber = WinNumber.Substring(2, 3);
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu3F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j].Substring(2, 3)) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu3++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu3 > 0)
            {
                base.MergeWinDescription(ref Description, "三星组选三奖" + ((int)WinCount_3X_Zu3).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu6D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu6)
        {
            WinCount_3X_Zu6 = 0;
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
            WinNumber = WinNumber.Substring(2, 3);
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu6D(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j].Substring(2, 3)) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu6 > 0)
            {
                base.MergeWinDescription(ref Description, "三星组选六奖" + ((int)WinCount_3X_Zu6).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_3X_Zu6F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_3X_Zu6)
        {
            WinCount_3X_Zu6 = 0;
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
            WinNumber = WinNumber.Substring(2, 3);
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_3X_Zu6F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (base.Sort(strArray2[j].Substring(2, 3)) == base.Sort(WinNumber)))
                        {
                            WinCount_3X_Zu6++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_3X_Zu6 > 0)
            {
                base.MergeWinDescription(ref Description, "三星组选六奖" + ((int)WinCount_3X_Zu6).ToString() + "注");
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

        private double ComputeWin_D(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, ref int WinCount5X, ref int WinCount4X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount4X = 0;
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
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"-(\d){4}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(1, 4) == WinNumber.Substring(1, 4)))
                        {
                            WinCount4X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                        else if (regexArray[4].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney5;
                            WinMoneyNoWithTax += WinMoneyNoWithTax5;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount4X > 0)
            {
                base.MergeWinDescription(ref Description, "四星奖" + ((int)WinCount4X).ToString() + "注");
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

        private double ComputeWin_F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, ref int WinCount5X, ref int WinCount4X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount4X = 0;
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
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"-(\d){4}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(1, 4) == WinNumber.Substring(1, 4)))
                        {
                            WinCount4X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                        else if (regexArray[4].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney5;
                            WinMoneyNoWithTax += WinMoneyNoWithTax5;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount4X > 0)
            {
                base.MergeWinDescription(ref Description, "四星奖" + ((int)WinCount5X).ToString() + "注");
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

        private double ComputeWin_RX1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_RX1)
        {
            WinCount_RX1 = 0;
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
                string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 5)
                        {
                            for (int k = 0; k < strArray2[j].Length; k++)
                            {
                                if (strArray2[j].Substring(k, 1) == WinNumber.Substring(k, 1))
                                {
                                    WinCount_RX1++;
                                    num += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_RX1 > 0)
            {
                base.MergeWinDescription(ref Description, "任选一奖" + ((int)WinCount_RX1).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCount_RX2)
        {
            WinCount_RX2 = 0;
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
                string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 5)
                        {
                            int num4 = 0;
                            for (int k = 0; k < strArray2[j].Length; k++)
                            {
                                if (strArray2[j].Substring(k, 1) == WinNumber.Substring(k, 1))
                                {
                                    num4++;
                                }
                                if (num4 == 2)
                                {
                                    WinCount_RX2++;
                                    num += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                            }
                        }
                    }
                }
            }
            Description = "";
            if (WinCount_RX2 > 0)
            {
                base.MergeWinDescription(ref Description, "任选二奖" + ((int)WinCount_RX2).ToString() + "注");
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_ZH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, ref int WinCount5X, ref int WinCount4X, ref int WinCount3X, ref int WinCount2X, ref int WinCount1X)
        {
            WinCount5X = 0;
            WinCount4X = 0;
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
                    Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"-(\d){4}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (regexArray[0].IsMatch(strArray2[j]) && (strArray2[j] == WinNumber))
                        {
                            WinCount5X++;
                            num += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                        else if (regexArray[1].IsMatch(strArray2[j]) && (strArray2[j].Substring(1, 4) == WinNumber.Substring(1, 4)))
                        {
                            WinCount4X++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                        else if (regexArray[2].IsMatch(strArray2[j]) && (strArray2[j].Substring(2, 3) == WinNumber.Substring(2, 3)))
                        {
                            WinCount3X++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                        else if (regexArray[3].IsMatch(strArray2[j]) && (strArray2[j].Substring(3, 2) == WinNumber.Substring(3, 2)))
                        {
                            WinCount2X++;
                            num += WinMoney4;
                            WinMoneyNoWithTax += WinMoneyNoWithTax4;
                        }
                        else if (regexArray[4].IsMatch(strArray2[j]) && (strArray2[j].Substring(4, 1) == WinNumber.Substring(4, 1)))
                        {
                            WinCount1X++;
                            num += WinMoney5;
                            WinMoneyNoWithTax += WinMoneyNoWithTax5;
                        }
                    }
                }
            }
            Description = "";
            if (WinCount5X > 0)
            {
                base.MergeWinDescription(ref Description, "五星奖" + ((int)WinCount5X).ToString() + "注");
            }
            if (WinCount4X > 0)
            {
                base.MergeWinDescription(ref Description, "四星奖" + ((int)WinCount4X).ToString() + "注");
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

        private string ConvertFormatToElectronTicket_HPJX(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID == 0x17d5) || (PlayTypeID == 0x17d6)) || ((PlayTypeID == 0x17d9) || (PlayTypeID == 0x17da))) || (((PlayTypeID == 0x17e1) || (PlayTypeID == 0x17e3)) || ((PlayTypeID == 0x17e5) || (PlayTypeID == 0x17e6))))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        if (((j % 5) == 0) && (j > 0))
                        {
                            str = str.Substring(0, str.Length - 1) + "\n" + strArray[i].Substring(j, 1) + ",";
                        }
                        else
                        {
                            str = str + strArray[i].Substring(j, 1) + ",";
                        }
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
            if (PlayTypeID == 0x17d7)
            {
                string[] strArray2 = new string[5];
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int k = 0; k < 5; k++)
                {
                    strArray2[k] = match.Groups["L" + k.ToString()].ToString().Trim();
                    if (strArray2[k].Length > 1)
                    {
                        strArray2[k] = strArray2[k].Substring(1, strArray2[k].Length - 2);
                    }
                    str = str + strArray2[k].ToString() + ",";
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            if (PlayTypeID == 0x17d8)
            {
                Number = Number.Replace("大", "2").Replace("小", "1").Replace("单", "5").Replace("双", "4");
                string[] strArray3 = Number.Split(new char[] { '\n' });
                for (int m = 0; m < strArray3.Length; m++)
                {
                    for (int n = 0; n < strArray3[m].Length; n++)
                    {
                        if (((n % 2) == 0) && (n > 0))
                        {
                            str = str.Substring(0, str.Length - 1) + "\n" + strArray3[m].Substring(n, 1) + ",";
                        }
                        else
                        {
                            str = str + strArray3[m].Substring(n, 1) + ",";
                        }
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
            if (PlayTypeID == 0x17db)
            {
                string[] strArray4 = Number.Split(new char[] { '\n' });
                for (int num6 = 0; num6 < strArray4.Length; num6++)
                {
                    str = str + "_,_,_,";
                    for (int num7 = 0; num7 < strArray4[num6].Length; num7++)
                    {
                        str = str + strArray4[num6].Substring(num7, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            if (((PlayTypeID == 0x17dc) || (PlayTypeID == 0x17e2)) || (PlayTypeID == 0x17e4))
            {
                string[] strArray5 = Number.Split(new char[] { '\n' });
                for (int num8 = 0; num8 < strArray5.Length; num8++)
                {
                    for (int num9 = 0; num9 < strArray5[num8].Length; num9++)
                    {
                        str = str + strArray5[num8].Substring(num9, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            if (PlayTypeID == 0x17dd)
            {
                string[] strArray6 = Number.Split(new char[] { '\n' });
                for (int num10 = 0; num10 < strArray6.Length; num10++)
                {
                    str = str + "_,_,_,";
                    string[] strArray7 = new string[2];
                    Match match2 = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray6[num10]);
                    for (int num11 = 0; num11 < 2; num11++)
                    {
                        strArray7[num11] = match2.Groups["L" + num11.ToString()].ToString().Trim();
                        if (strArray7[num11].Length > 1)
                        {
                            strArray7[num11] = strArray7[num11].Substring(1, strArray7[num11].Length - 2);
                        }
                        str = str + strArray7[num11].ToString() + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            if (((PlayTypeID == 0x17de) || (PlayTypeID == 0x17df)) || (PlayTypeID == 0x17e0))
            {
                str = Number + ",";
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
                    new PlayType(0x17d5, "单式"), new PlayType(0x17d6, "复式"), new PlayType(0x17d7, "组合玩法"), new PlayType(0x17d8, "猜大小"), new PlayType(0x17d9, "五星通选单式"), new PlayType(0x17da, "五星通选复式"), new PlayType(0x17db, "二星组选单式"), new PlayType(0x17dc, "二星组选复式"), new PlayType(0x17dd, "二星组选分位"), new PlayType(0x17de, "二星组选包点"), new PlayType(0x17df, "二星组选包胆"), new PlayType(0x17e0, "二星直选包点"), new PlayType(0x17e1, "三星组选三单式"), new PlayType(0x17e2, "三星组选三复式"), new PlayType(0x17e3, "三星组选六单式"), new PlayType(0x17e4, "三星组选六复式"), 
                    new PlayType(0x17e5, "任选一"), new PlayType(0x17e6, "任选二")
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
                    if (PlayTypeID == 0x17d5)
                    {
                        return this.GetPrintKeyList_LT_E_D(numbers);
                    }
                    if (PlayTypeID == 0x17d6)
                    {
                        return this.GetPrintKeyList_LT_E_F(numbers);
                    }
                    if (PlayTypeID == 0x17d7)
                    {
                        return this.GetPrintKeyList_LT_E_Zu(numbers);
                    }
                    if (PlayTypeID == 0x17d8)
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

        private string HPJX_ConvertFormatToElectronTicket(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (((PlayTypeID == 0x17d5) || (PlayTypeID == 0x17d6)) || (((PlayTypeID == 0x17d9) || (PlayTypeID == 0x17da)) || (PlayTypeID == 0x17d7)))
            {
                str = str + Number.Replace(",", "");
            }
            if (PlayTypeID == 0x17d8)
            {
                Number = Number.Replace("2", "大").Replace("1", "小").Replace("5", "单").Replace("4", "双");
                str = str + Number.Replace(",", "");
            }
            if (PlayTypeID == 0x17db)
            {
                str = str + Number.Replace(",", "");
            }
            if (PlayTypeID == 0x17dc)
            {
                str = str + Number.Replace(",", "");
            }
            return str.Replace("-", "_");
        }

        public override string HPJX_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            if (PlayTypeID == 0x17d5)
            {
                return this.HPJX_ToElectronicTicket_D(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17d6)
            {
                return this.HPJX_ToElectronicTicket_F(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17d7)
            {
                return this.HPJX_ToElectronicTicket_ZH(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17d8)
            {
                return this.HPJX_ToElectronicTicket_DX(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17d9)
            {
                return this.HPJX_ToElectronicTicket_5X_TXD(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17da)
            {
                return this.HPJX_ToElectronicTicket_5X_TXF(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17db)
            {
                return this.HPJX_ToElectronicTicket_2X_ZuD(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            if (PlayTypeID == 0x17dc)
            {
                return this.HPJX_ToElectronicTicket_2X_ZuF(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
            }
            return "";
        }

        private string HPJX_ToElectronicTicket_2X_ZuD(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_2X_ZuF(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_5X_TXD(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_5X_TXF(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_D(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_DX(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_F(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        private string HPJX_ToElectronicTicket_ZH(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPJX_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override Ticket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x17d5)
            {
                return this.ToElectronicTicket_HPJX_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17d6)
            {
                return this.ToElectronicTicket_HPJX_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17d7)
            {
                return this.ToElectronicTicket_HPJX_ZH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17d8)
            {
                return this.ToElectronicTicket_HPJX_DX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17d9)
            {
                return this.ToElectronicTicket_HPJX_5X_TXD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17da)
            {
                return this.ToElectronicTicket_HPJX_5X_TXF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17db)
            {
                return this.ToElectronicTicket_HPJX_2X_ZuD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17dc)
            {
                return this.ToElectronicTicket_HPJX_2X_ZuF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17dd)
            {
                return this.ToElectronicTicket_HPJX_2X_ZuFW(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17de)
            {
                return this.ToElectronicTicket_HPJX_2X_ZuB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17df)
            {
                return this.ToElectronicTicket_HPJX_2X_ZuBD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e0)
            {
                return this.ToElectronicTicket_HPJX_2X_ZhiB(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e1)
            {
                return this.ToElectronicTicket_HPJX_3X_Zu3D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e2)
            {
                return this.ToElectronicTicket_HPJX_3X_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e3)
            {
                return this.ToElectronicTicket_HPJX_3X_Zu6D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e4)
            {
                return this.ToElectronicTicket_HPJX_3X_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e5)
            {
                return this.ToElectronicTicket_HPJX_RX1(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x17e6)
            {
                return this.ToElectronicTicket_HPJX_RX2(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private Ticket[] ToElectronicTicket_HPJX_2X_ZhiB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZhiB(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x131, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_2X_ZuB(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(310, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_2X_ZuBD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x137, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_2X_ZuD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuD(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x133, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_2X_ZuF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_2X_ZuF(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x134, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_2X_ZuFW(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x135, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_3X_Zu3D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x139, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_3X_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(320, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_3X_Zu6D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x13a, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_3X_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x141, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_5X_TXD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x138, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_5X_TXF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            ArrayList list = new ArrayList();
            string[] strArray = this.AnalyseSchemeToElectronicTicket_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x138, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x12d, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_DX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && !string.IsNullOrEmpty(strArray[k + m].ToString()))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0];
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x132, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPJX_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x12e, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_RX1(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX1(Number, PlayTypeID).Split(new char[] { '\n' });
            ArrayList list = new ArrayList();
            Money = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                if (strArray2 == null)
                {
                    return null;
                }
                if (strArray2.Length == 0)
                {
                    return null;
                }
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
                for (int k = 1; k < (num2 + 1); k++)
                {
                    if ((k * MaxMultiple) < Multiple)
                    {
                        multiple = MaxMultiple;
                    }
                    else
                    {
                        multiple = Multiple - ((k - 1) * MaxMultiple);
                    }
                    for (int m = 0; m < strArray2.Length; m += 5)
                    {
                        string number = "";
                        num4 = 0.0;
                        for (int n = 0; n < 5; n++)
                        {
                            if (((m + n) < strArray2.Length) && !string.IsNullOrEmpty(strArray2[m + n].ToString()))
                            {
                                number = number + strArray2[m + n].ToString();
                                num4 += 2.0;
                            }
                        }
                        Money += num4 * multiple;
                        list.Add(new Ticket(0x13b, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num4 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_RX2(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseScheme_RX1(Number, PlayTypeID).Split(new char[] { '\n' });
            ArrayList list = new ArrayList();
            Money = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                if (strArray2 == null)
                {
                    return null;
                }
                if (strArray2.Length == 0)
                {
                    return null;
                }
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
                for (int k = 1; k < (num2 + 1); k++)
                {
                    if ((k * MaxMultiple) < Multiple)
                    {
                        multiple = MaxMultiple;
                    }
                    else
                    {
                        multiple = Multiple - ((k - 1) * MaxMultiple);
                    }
                    for (int m = 0; m < strArray2.Length; m += 5)
                    {
                        string number = "";
                        num4 = 0.0;
                        for (int n = 0; n < 5; n++)
                        {
                            if (((m + n) < strArray2.Length) && !string.IsNullOrEmpty(strArray2[m + n].ToString()))
                            {
                                number = number + strArray2[m + n].ToString();
                                num4 += 2.0;
                            }
                        }
                        Money += num4 * multiple;
                        list.Add(new Ticket(0x13c, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num4 * multiple));
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

        private Ticket[] ToElectronicTicket_HPJX_ZH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (!string.IsNullOrEmpty(strArray[k].ToString()))
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x13f, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0x17d5)
            {
                return this.ToSingle_D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17d6)
            {
                return this.ToSingle_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17d7)
            {
                return this.ToSingle_ZH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17d8)
            {
                return this.ToSingle_DX(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x17d9) || (PlayType == 0x17da))
            {
                return this.ToSingle_5X_TX(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17db)
            {
                return this.ToSingle_2X_ZuD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17dc)
            {
                return this.ToSingle_2X_ZuF(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17dd)
            {
                return this.ToSingle_2X_ZuFW(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17de)
            {
                return this.ToSingle_2X_ZuB(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17df)
            {
                return this.ToSingle_2X_ZuBD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e0)
            {
                return this.ToSingle_2X_ZhiB(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e1)
            {
                return this.ToSingle_3X_Zu3D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e2)
            {
                return this.ToSingle_3X_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e3)
            {
                return this.ToSingle_3X_Zu6D(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e4)
            {
                return this.ToSingle_3X_Zu6F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e5)
            {
                return this.ToSingle_RX1(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x17e6)
            {
                return this.ToSingle_RX2(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_2X_ZhiB(string sBill, ref string CanonicalNumber)
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
                for (int k = 0; k <= 9; k++)
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

        private string[] ToSingle_2X_ZuD(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_2X_ZuF(string Number, ref string CanonicalNumber)
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
            for (int i = 0; i < length; i++)
            {
                for (int k = i; k < length; k++)
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

        private string[] ToSingle_3X_Zu3D(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Substring(2).Trim());
            if (CanonicalNumber.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber.ToCharArray();
            CanonicalNumber = "--" + Number.Substring(2);
            ArrayList list = new ArrayList();
            list.Add("--" + Number.Substring(2));
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_3X_Zu3F(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Replace("-", "").Trim());
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
                    list.Add("--" + chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString());
                    list.Add("--" + chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString());
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
            CanonicalNumber = this.FilterRepeated(Number.Substring(2).Trim());
            if (CanonicalNumber.Length != 3)
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            CanonicalNumber = "--" + Number.Substring(2);
            ArrayList list = new ArrayList();
            list.Add("--" + chArray[0].ToString() + chArray[1].ToString() + chArray[2].ToString());
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_3X_Zu6F(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Replace("-", "").Trim());
            if (CanonicalNumber.Length < 4)
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < (length - 2); i++)
            {
                for (int k = i + 1; k < (length - 1); k++)
                {
                    for (int m = k + 1; m < length; m++)
                    {
                        list.Add("--" + chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString());
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
            Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"-(\d){4}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
            bool flag = false;
            for (int j = 0; j < 5; j++)
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
            Regex[] regexArray = new Regex[] { new Regex(@"(\d){5}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"-(\d){4}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"--(\d){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"---(\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase), new Regex(@"----\d", RegexOptions.Compiled | RegexOptions.IgnoreCase) };
            string[] strArray2 = null;
            if (regexArray[0].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("-" + CanonicalNumber.Substring(1, 4)), ("--" + CanonicalNumber.Substring(2, 3)), ("---" + CanonicalNumber.Substring(3, 2)), ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[1].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("--" + CanonicalNumber.Substring(2, 3)), ("---" + CanonicalNumber.Substring(3, 2)), ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[2].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("---" + CanonicalNumber.Substring(3, 2)), ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[3].IsMatch(CanonicalNumber))
            {
                return new string[] { CanonicalNumber, ("----" + CanonicalNumber.Substring(4, 1)) };
            }
            if (regexArray[4].IsMatch(CanonicalNumber))
            {
                strArray2 = new string[] { CanonicalNumber };
            }
            return strArray2;
        }

        private string[] ToSingle_RX1(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[5];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(-)|(\d)|([(][\d]+?[)]))(?<L1>(-)|(\d)|([(][\d]+?[)]))(?<L2>(-)|(\d)|([(][\d]+?[)]))(?<L3>(-)|(\d)|([(][\d]+?[)]))(?<L4>(-)|(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
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
                if (strArray[i] != "-")
                {
                    strArray[i] = strArray[i] + "-";
                }
            }
            ArrayList list = new ArrayList();
            for (int j = 0; j < strArray[0].Length; j++)
            {
                string str = strArray[0][j].ToString();
                char ch2 = strArray[0][j];
                if (ch2.ToString() != "-")
                {
                    list.Add(str + "----");
                }
                else
                {
                    for (int m = 0; m < strArray[1].Length; m++)
                    {
                        string str2 = str + strArray[1][m].ToString();
                        char ch4 = strArray[1][m];
                        if (ch4.ToString() != "-")
                        {
                            list.Add(str2 + "---");
                        }
                        else
                        {
                            for (int n = 0; n < strArray[2].Length; n++)
                            {
                                string str3 = str2 + strArray[2][n].ToString();
                                char ch6 = strArray[2][n];
                                if (ch6.ToString() != "-")
                                {
                                    list.Add(str3 + "--");
                                }
                                else
                                {
                                    for (int num5 = 0; num5 < strArray[3].Length; num5++)
                                    {
                                        string str4 = str3 + strArray[3][num5].ToString();
                                        char ch8 = strArray[3][num5];
                                        if (ch8.ToString() != "-")
                                        {
                                            list.Add(str4 + "-");
                                        }
                                        else
                                        {
                                            for (int num6 = 0; num6 < strArray[4].Length; num6++)
                                            {
                                                string number = str4 + strArray[4][num6].ToString();
                                                string canonicalNumber = "";
                                                char ch10 = strArray[4][num6];
                                                if (!(ch10.ToString() == "-"))
                                                {
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

        private string[] ToSingle_RX2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[5];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|(-)|([(][\d]+?[)]))(?<L1>(\d)|(-)|([(][\d]+?[)]))(?<L2>(\d)|(-)|([(][\d]+?[)]))(?<L3>(\d)|(-)|([(][\d]+?[)]))(?<L4>(\d)|(-)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
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
                if (strArray[i] != "-")
                {
                    strArray[i] = strArray[i] + "-";
                }
            }
            int num2 = 0;
            ArrayList list = new ArrayList();
            for (int j = 0; j < strArray[0].Length; j++)
            {
                string str = strArray[0][j].ToString();
                char ch2 = strArray[0][j];
                if (ch2.ToString() != "-")
                {
                    num2++;
                }
                for (int m = 0; m < strArray[1].Length; m++)
                {
                    string str2 = str + strArray[1][m].ToString();
                    if (num2 == 1)
                    {
                        char ch4 = strArray[1][m];
                        if (ch4.ToString() != "-")
                        {
                            list.Add(str2 + "---");
                            num2 = 1;
                            continue;
                        }
                    }
                    char ch5 = strArray[1][m];
                    if (ch5.ToString() != "-")
                    {
                        num2++;
                    }
                    for (int n = 0; n < strArray[2].Length; n++)
                    {
                        string str3 = str2 + strArray[2][n].ToString();
                        if (num2 == 1)
                        {
                            char ch7 = strArray[2][n];
                            if (ch7.ToString() != "-")
                            {
                                list.Add(str3 + "--");
                                num2 = 1;
                                continue;
                            }
                        }
                        char ch8 = strArray[2][n];
                        if (ch8.ToString() != "-")
                        {
                            num2++;
                        }
                        for (int num6 = 0; num6 < strArray[3].Length; num6++)
                        {
                            string str4 = str3 + strArray[3][num6].ToString();
                            if (num2 == 1)
                            {
                                char ch10 = strArray[3][num6];
                                if (ch10.ToString() != "-")
                                {
                                    list.Add(str4 + "-");
                                    num2 = 1;
                                    continue;
                                }
                            }
                            char ch11 = strArray[3][num6];
                            if (ch11.ToString() != "-")
                            {
                                num2++;
                            }
                            for (int num7 = 0; num7 < strArray[4].Length; num7++)
                            {
                                string str5 = str4 + strArray[4][num7].ToString();
                                if (num2 == 1)
                                {
                                    char ch13 = strArray[4][num7];
                                    if (ch13.ToString() != "-")
                                    {
                                        list.Add(str5);
                                        num2 = 1;
                                        continue;
                                    }
                                }
                                num2 = 0;
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
    }
}
