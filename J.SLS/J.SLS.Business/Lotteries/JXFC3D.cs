using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class JXFC3D : LotteryBase
    {
        public const string Code = " JXFC3D";
        public const int ID = 0x43;
        public const double MaxMoney = 20000.0;
        public const string Name = "江西福彩3D";
        public const int PlayType_ZhiBC = 0x1a39;
        public const int PlayType_ZhiBW = 0x1a34;
        public const int PlayType_ZhiD = 0x1a2d;
        public const int PlayType_ZhiDT = 0x1a3b;
        public const int PlayType_ZhiDX = 0x1a46;
        public const int PlayType_ZhiECH = 0x1a3a;
        public const int PlayType_ZhiF = 0x1a35;
        public const int PlayType_ZhiH = 0x1a30;
        public const int PlayType_ZhiJO = 0x1a42;
        public const int PlayType_ZhiKD = 0x1a3d;
        public const int PlayType_Zu3D = 0x1a2e;
        public const int PlayType_Zu3DX = 0x1a47;
        public const int PlayType_Zu3F = 0x1a36;
        public const int PlayType_Zu3H = 0x1a31;
        public const int PlayType_Zu3JO = 0x1a43;
        public const int PlayType_Zu3KD = 0x1a3e;
        public const int PlayType_Zu6D = 0x1a2f;
        public const int PlayType_Zu6DX = 0x1a48;
        public const int PlayType_Zu6F = 0x1a37;
        public const int PlayType_Zu6H = 0x1a32;
        public const int PlayType_Zu6JO = 0x1a44;
        public const int PlayType_Zu6KD = 0x1a3f;
        public const int PlayType_ZuheDT = 0x1a3c;
        public const int PlayType_ZuheDX = 0x1a49;
        public const int PlayType_ZuheF = 0x1a38;
        public const int PlayType_ZuheH = 0x1a33;
        public const int PlayType_ZuheHSW = 0x1a41;
        public const int PlayType_ZuheJO = 0x1a45;
        public const int PlayType_ZuheKD = 0x1a40;
        public const string sID = "67";

        public JXFC3D()
        {
            base.id = 0x43;
            base.name = "江西福彩3D";
            base.code = "JXFC3D";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x1a2d) || (PlayType == 0x1a34))
            {
                return this.AnalyseScheme_ZhiD_BW(Content, PlayType);
            }
            if (((PlayType == 0x1a2e) || (PlayType == 0x1a2f)) || (PlayType == 0x1a37))
            {
                return this.AnalyseScheme_Zu3D_Zu6(Content, PlayType);
            }
            if (PlayType == 0x1a30)
            {
                return this.AnalyseScheme_ZhiH(Content, PlayType);
            }
            if (PlayType == 0x1a31)
            {
                return this.AnalyseScheme_Zu3H(Content, PlayType);
            }
            if (PlayType == 0x1a32)
            {
                return this.AnalyseScheme_Zu6H(Content, PlayType);
            }
            if (PlayType == 0x1a33)
            {
                return this.AnalyseScheme_ZuheH(Content, PlayType);
            }
            if (PlayType == 0x1a35)
            {
                return this.AnalyseScheme_ZhiF(Content, PlayType);
            }
            if (PlayType == 0x1a36)
            {
                return this.AnalyseScheme_Zu3F(Content, PlayType);
            }
            if (PlayType == 0x1a38)
            {
                return this.AnalyseScheme_ZuheF(Content, PlayType);
            }
            if (PlayType == 0x1a39)
            {
                return this.AnalyseScheme_ZhiBC(Content, PlayType);
            }
            if (PlayType == 0x1a3a)
            {
                return this.AnalyseScheme_ZhiECH(Content, PlayType);
            }
            if (PlayType == 0x1a3b)
            {
                return this.AnalyseScheme_ZhiDT(Content, PlayType);
            }
            if (PlayType == 0x1a3c)
            {
                return this.AnalyseScheme_ZuheDT(Content, PlayType);
            }
            if (PlayType == 0x1a3d)
            {
                return this.AnalyseScheme_ZhiKD(Content, PlayType);
            }
            if (PlayType == 0x1a3e)
            {
                return this.AnalyseScheme_Zu3KD(Content, PlayType);
            }
            if (PlayType == 0x1a3f)
            {
                return this.AnalyseScheme_Zu6KD(Content, PlayType);
            }
            if (PlayType == 0x1a40)
            {
                return this.AnalyseScheme_ZuheKD(Content, PlayType);
            }
            if (PlayType == 0x1a41)
            {
                return this.AnalyseScheme_ZuheHSW(Content, PlayType);
            }
            if (PlayType == 0x1a42)
            {
                Content = Content.Replace("偶", "0").Replace("奇", "1");
                return this.AnalyseScheme_ZhiJO(Content, PlayType);
            }
            if (PlayType == 0x1a43)
            {
                Content = Content.Replace("偶", "0").Replace("奇", "1");
                return this.AnalyseScheme_Zu3JO(Content, PlayType);
            }
            if (PlayType == 0x1a44)
            {
                Content = Content.Replace("偶", "0").Replace("奇", "1");
                return this.AnalyseScheme_Zu6JO(Content, PlayType);
            }
            if (PlayType == 0x1a45)
            {
                Content = Content.Replace("偶", "0").Replace("奇", "1");
                return this.AnalyseScheme_ZuheJO(Content, PlayType);
            }
            if (PlayType == 0x1a46)
            {
                Content = Content.Replace("小", "0").Replace("大", "1");
                return this.AnalyseScheme_ZhiDX(Content, PlayType);
            }
            if (PlayType == 0x1a47)
            {
                Content = Content.Replace("小", "0").Replace("大", "1");
                return this.AnalyseScheme_Zu3DX(Content, PlayType);
            }
            if (PlayType == 0x1a48)
            {
                Content = Content.Replace("小", "0").Replace("大", "1");
                return this.AnalyseScheme_Zu6DX(Content, PlayType);
            }
            if (PlayType == 0x1a49)
            {
                Content = Content.Replace("小", "0").Replace("大", "1");
                return this.AnalyseScheme_ZuheDX(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_ZhiBC(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiBC(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiD_BW(string Content, int PlayType)
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
            if (PlayType == 0x1a2d)
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
                    string[] strArray2 = this.ToSingle_ZhiD_BW(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1a2d) ? 1 : 2)))
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

        private string AnalyseScheme_ZhiDT(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}[,]([\d]){2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiDT(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiDX(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]{3})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiDX(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiECH(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiECH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiF(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZhiF(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 0))
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
            Regex regex = new Regex(@"([2][0-7]{1})|([1][\d]{1})|([\d]{1})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiJO(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiJO(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZhiKD(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiKD(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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
            if ((PlayType == 0x1a2e) || (PlayType == 0x1a2f))
            {
                str2 = @"([\d]){3}";
            }
            else
            {
                str2 = @"([\d]){4,10}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3D_Zu6(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= (((PlayType == 0x1a2e) || (PlayType == 0x1a2f)) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x1a37)
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

        private string AnalyseScheme_Zu3DX(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]{3})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3DX(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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
            Regex regex = new Regex(@"([\d]){2,10}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3F(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 0))
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

        private string AnalyseScheme_Zu3H(string Content, int PlayType)
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
            Regex regex = new Regex(@"([2][0-7]{1})|([1][\d]{1})|([\d]{1})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3H(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu3JO(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3JO(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu3KD(string Content, int PlayType)
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
            Regex regex = new Regex("([1-9]){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3KD(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu6DX(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]{3})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu6DX(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu6H(string Content, int PlayType)
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
            Regex regex = new Regex(@"([2][0-7]{1})|([1][\d]{1})|([\d]{1})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu6H(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu6JO(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu6JO(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_Zu6KD(string Content, int PlayType)
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
            Regex regex = new Regex("([2-9]){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu6KD(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheDT(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}[,]([\d]){2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheDT(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheDX(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]{3})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheDX(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheF(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_ZuheF(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 0))
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

        private string AnalyseScheme_ZuheH(string Content, int PlayType)
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
            Regex regex = new Regex(@"([2][0-7]{1})|([1][\d]{1})|([\d]{1})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheHSW(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheHSW(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheJO(string Content, int PlayType)
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
            Regex regex = new Regex("([0-1]){3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheJO(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        private string AnalyseScheme_ZuheKD(string Content, int PlayType)
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
            Regex regex = new Regex("([1-9]){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuheKD(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length > 0))
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

        public override bool AnalyseWinNumber(string Number)
        {
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_ZhiD_BW(Number, ref canonicalNumber);
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
            return ((play_type >= 0x1a2d) && (play_type <= 0x1a49));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 6))
            {
                return -3.0;
            }
            if ((PlayType == 0x1a2d) || (PlayType == 0x1a34))
            {
                return this.ComputeWin_ZhiD_BW(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (((PlayType == 0x1a2e) || (PlayType == 0x1a2f)) || (PlayType == 0x1a37))
            {
                return this.ComputeWin_Zu3D_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a30)
            {
                return this.ComputeWin_ZhiH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a31)
            {
                return this.ComputeWin_Zu3H(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x1a32)
            {
                return this.ComputeWin_Zu6H(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a33)
            {
                return this.ComputeWin_ZuheH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a35)
            {
                return this.ComputeWin_ZhiF(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a36)
            {
                return this.ComputeWin_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x1a38)
            {
                return this.ComputeWin_ZuheF(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a39)
            {
                return this.ComputeWin_ZhiBC(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a3a)
            {
                return this.ComputeWin_ZhiECH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a3b)
            {
                return this.ComputeWin_ZhiDT(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a3c)
            {
                return this.ComputeWin_ZuheDT(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a3d)
            {
                return this.ComputeWin_ZhiKD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a3e)
            {
                return this.ComputeWin_Zu3KD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x1a3f)
            {
                return this.ComputeWin_Zu6KD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a40)
            {
                return this.ComputeWin_ZuheKD(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a41)
            {
                return this.ComputeWin_ZuheHSW(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a42)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ComputeWin_ZhiJO(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a43)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ComputeWin_Zu3JO(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x1a44)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ComputeWin_Zu6JO(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a45)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ComputeWin_ZuheJO(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a46)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ComputeWin_ZhiDX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1a47)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ComputeWin_Zu3DX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x1a48)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ComputeWin_Zu6DX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x1a49)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ComputeWin_ZuheDX(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            return -4.0;
        }

        private double ComputeWin_ZhiBC(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_ZhiBC(strArray[i], ref canonicalNumber);
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
                Description = "直选包串奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiD_BW(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_ZhiD_BW(strArray[i], ref canonicalNumber);
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
                Description = "直选奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiDT(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_ZhiDT(strArray[i], ref canonicalNumber);
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
                Description = "直选胆拖奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiDX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiDX(strArray[i], ref canonicalNumber);
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
                Description = "直选大小奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiECH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiECH(strArray[i], ref canonicalNumber);
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
                Description = "直选二重号奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiF(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_ZhiF(strArray[i], ref canonicalNumber);
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
                Description = "直选复式奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_ZhiH(strArray[i], ref canonicalNumber);
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
                Description = "直选和值奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiJO(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiJO(strArray[i], ref canonicalNumber);
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
                Description = "直选奇偶奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZhiKD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZhiKD(strArray[i], ref canonicalNumber);
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
                Description = "直选跨度奖" + num.ToString() + "注。";
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

        private double ComputeWin_Zu3DX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_Zu3DX(strArray[i], ref canonicalNumber);
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
                Description = "组3大小奖" + num.ToString() + "注。";
            }
            return num2;
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
                Description = "组3复式奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu3H(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_Zu3H(strArray[i], ref canonicalNumber);
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
                Description = "组选3和值奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu3JO(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu3JO(strArray[i], ref canonicalNumber);
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
                Description = "组3奇偶奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu3KD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_Zu3KD(strArray[i], ref canonicalNumber);
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
                Description = "组3跨度奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu6DX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu6DX(strArray[i], ref canonicalNumber);
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
                Description = "组6大小奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu6H(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu6H(strArray[i], ref canonicalNumber);
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
                Description = "组选6和值奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu6JO(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_Zu6JO(strArray[i], ref canonicalNumber);
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
                Description = "组6奇偶奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_Zu6KD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu6KD(strArray[i], ref canonicalNumber);
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
                Description = "组6跨度奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheDT(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheDT(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (str.Length == 1)
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 2)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney3;
                                WinMoneyNoWithTax += WinMoneyNoWithTax3;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合胆拖奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheDX(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheDX(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if ((str.Length == 1) || (str.Length == 2))
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合大小奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheF(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3)
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
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheF(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
                        {
                            if (str.Length == 1)
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 2)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney3;
                                WinMoneyNoWithTax += WinMoneyNoWithTax3;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合复式奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (str.Length == 1)
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 2)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney3;
                                WinMoneyNoWithTax += WinMoneyNoWithTax3;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合和值奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheHSW(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheHSW(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if ((str.Length == 1) || (str.Length == 2))
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "和数尾组合奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheJO(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheJO(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if ((str.Length == 1) || (str.Length == 2))
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合奇偶奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuheKD(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
            string str = this.FilterRepeated(WinNumber);
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_ZuheKD(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (str.Length == 2)
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else if (str.Length == 3)
                            {
                                num++;
                                num2 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组合跨度奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private string ConvertFormatToElectronTicket_HPJX(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID == 0x1a30) || (PlayTypeID == 0x1a31)) || ((PlayTypeID == 0x1a32) || (PlayTypeID == 0x1a33))) || (((PlayTypeID == 0x1a3d) || (PlayTypeID == 0x1a3e)) || ((PlayTypeID == 0x1a3f) || (PlayTypeID == 0x1a40))))
            {
                return Number;
            }
            if ((PlayTypeID == 0x1a3b) || (PlayTypeID == 0x1a3c))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int j = 0; j < strArray.Length; j++)
                {
                    for (int k = 0; k < strArray[j].Length; k++)
                    {
                        str = str + strArray[j].Substring(k, 1) + ",";
                    }
                    str = str.Substring(0, str.Length - 1).Replace(",,,", "#0#") + "\n";
                }
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                return str;
            }
            if (PlayTypeID == 0x1a34)
            {
                string[] strArray2 = new string[3];
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
                for (int m = 0; m < 3; m++)
                {
                    strArray2[m] = match.Groups["L" + m.ToString()].ToString().Trim();
                    if (strArray2[m] == "")
                    {
                        return "";
                    }
                    if (strArray2[m].Length > 1)
                    {
                        strArray2[m] = strArray2[m].Substring(1, strArray2[m].Length - 2);
                        if (strArray2[m].Length > 1)
                        {
                            strArray2[m] = this.FilterRepeated(strArray2[m]);
                        }
                        if (strArray2[m] == "")
                        {
                            return "";
                        }
                    }
                    str = str + strArray2[m] + ",";
                }
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                return str;
            }
            string[] strArray3 = Number.Split(new char[] { '\n' });
            for (int i = 0; i < strArray3.Length; i++)
            {
                for (int n = 0; n < strArray3[i].Length; n++)
                {
                    str = str + strArray3[i].Substring(n, 1) + ",";
                }
                str = str.Substring(0, str.Length - 1) + "\n";
            }
            if (str.EndsWith("\n"))
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
            return new PlayType[] { 
                    new PlayType(0x1a2d, "直选单式"), new PlayType(0x1a2e, "组选3单式"), new PlayType(0x1a2f, "组选6单式"), new PlayType(0x1a30, "直选和值"), new PlayType(0x1a31, "组选3和值"), new PlayType(0x1a32, "组选6和值"), new PlayType(0x1a33, "组合和值"), new PlayType(0x1a34, "直选按位包号"), new PlayType(0x1a35, "直选复式"), new PlayType(0x1a36, "组选3复式"), new PlayType(0x1a37, "组选6复式"), new PlayType(0x1a38, "组合复式"), new PlayType(0x1a39, "直选包串"), new PlayType(0x1a3a, "直选二重号"), new PlayType(0x1a3b, "直选胆拖"), new PlayType(0x1a3c, "组合胆拖"), 
                    new PlayType(0x1a3d, "直选跨度"), new PlayType(0x1a3e, "组选3跨度"), new PlayType(0x1a3f, "组选6跨度"), new PlayType(0x1a40, "组合跨度"), new PlayType(0x1a41, "和数尾组合"), new PlayType(0x1a42, "直选奇偶"), new PlayType(0x1a43, "组选3奇偶"), new PlayType(0x1a44, "组选6奇偶"), new PlayType(0x1a45, "组合奇偶"), new PlayType(0x1a46, "直选大小"), new PlayType(0x1a47, "组选3大小"), new PlayType(0x1a48, "组选6大小"), new PlayType(0x1a49, "组合大小")
                 };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override JTicket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1a2d)
            {
                return this.ToElectronicTicket_HPJX_ZhiD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a2e)
            {
                return this.ToElectronicTicket_HPJX_Zu3D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a2f)
            {
                return this.ToElectronicTicket_HPJX_Zu6D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a30)
            {
                return this.ToElectronicTicket_HPJX_ZhiH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a31)
            {
                return this.ToElectronicTicket_HPJX_Zu3H(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a32)
            {
                return this.ToElectronicTicket_HPJX_Zu6H(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a33)
            {
                return this.ToElectronicTicket_HPJX_ZuheH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a34)
            {
                return this.ToElectronicTicket_HPJX_ZhiBW(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a35)
            {
                return this.ToElectronicTicket_HPJX_ZhiF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a36)
            {
                return this.ToElectronicTicket_HPJX_Zu3F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a37)
            {
                return this.ToElectronicTicket_HPJX_Zu6F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a38)
            {
                return this.ToElectronicTicket_HPJX_ZuheF(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a39)
            {
                return this.ToElectronicTicket_HPJX_ZhiBC(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3a)
            {
                return this.ToElectronicTicket_HPJX_ZhiECH(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3b)
            {
                return this.ToElectronicTicket_HPJX_ZhiDT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3c)
            {
                return this.ToElectronicTicket_HPJX_ZuheDT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3d)
            {
                return this.ToElectronicTicket_HPJX_ZhiKD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3e)
            {
                return this.ToElectronicTicket_HPJX_Zu3KD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a3f)
            {
                return this.ToElectronicTicket_HPJX_Zu6KD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a40)
            {
                return this.ToElectronicTicket_HPJX_ZuheKD(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a41)
            {
                return this.ToElectronicTicket_HPJX_ZuheHSW(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a42)
            {
                return this.ToElectronicTicket_HPJX_ZhiJO(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a43)
            {
                return this.ToElectronicTicket_HPJX_Zu3JO(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a44)
            {
                return this.ToElectronicTicket_HPJX_Zu6JO(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a45)
            {
                return this.ToElectronicTicket_HPJX_ZuheJO(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a46)
            {
                return this.ToElectronicTicket_HPJX_ZhiDX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a47)
            {
                return this.ToElectronicTicket_HPJX_Zu3DX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a48)
            {
                return this.ToElectronicTicket_HPJX_Zu6DX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1a49)
            {
                return this.ToElectronicTicket_HPJX_ZuheDX(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiBC(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd5, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiBW(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd0, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiDT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd7, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiDX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe2, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiECH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd6, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd1, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xcc, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiJO(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xde, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZhiKD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd9, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3DX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe3, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(210, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3H(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xcd, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3JO(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xdf, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu3KD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xda, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0xcb, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6DX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe4, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd3, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6H(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xce, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6JO(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe0, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_Zu6KD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xdb, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheDT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd8, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheDX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe5, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheF(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xd4, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xcf, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheHSW(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xdd, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheJO(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xe1, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_ZuheKD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(220, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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
            if ((PlayType == 0x1a2d) || (PlayType == 0x1a34))
            {
                return this.ToSingle_ZhiD_BW(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a35)
            {
                return this.ToSingle_ZhiF(Number, ref CanonicalNumber);
            }
            if (((PlayType == 0x1a2e) || (PlayType == 0x1a2f)) || (PlayType == 0x1a37))
            {
                return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a36)
            {
                return this.ToSingle_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a38)
            {
                return this.ToSingle_ZuheF(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a30)
            {
                return this.ToSingle_ZhiH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a31)
            {
                return this.ToSingle_Zu3H(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a32)
            {
                return this.ToSingle_Zu6H(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a33)
            {
                return this.ToSingle_ZuheH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a39)
            {
                return this.ToSingle_ZhiBC(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3a)
            {
                return this.ToSingle_ZhiECH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3b)
            {
                return this.ToSingle_ZhiDT(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3c)
            {
                return this.ToSingle_ZuheDT(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3d)
            {
                return this.ToSingle_ZhiKD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3e)
            {
                return this.ToSingle_Zu3KD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a3f)
            {
                return this.ToSingle_Zu6KD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a40)
            {
                return this.ToSingle_ZuheKD(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a41)
            {
                return this.ToSingle_ZuheHSW(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a42)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ToSingle_ZhiJO(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a43)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ToSingle_Zu3JO(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a44)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ToSingle_Zu6JO(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a45)
            {
                Number = Number.Replace("偶", "0").Replace("奇", "1");
                return this.ToSingle_ZuheJO(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a46)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ToSingle_ZhiDX(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a47)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ToSingle_Zu3DX(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a48)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ToSingle_Zu6DX(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a49)
            {
                Number = Number.Replace("小", "0").Replace("大", "1");
                return this.ToSingle_ZuheDX(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_ZhiBC(string Number, ref string CanonicalNumber)
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
                for (int k = 0; k < length; k++)
                {
                    for (int m = 0; m < length; m++)
                    {
                        list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString());
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

        private string[] ToSingle_ZhiD_BW(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_ZhiDT(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d){1,2})[,](?<L1>(\d){2,})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            char[] chArray = strArray[0].ToCharArray();
            char[] chArray2 = this.FilterRepeated(strArray[1]).ToCharArray();
            for (int j = 0; j < chArray2.Length; j++)
            {
                if (strArray[0].IndexOf(chArray2[j]) >= 0)
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            CanonicalNumber = strArray[0] + "," + this.FilterRepeated(strArray[1]);
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            int num4 = chArray2.Length;
            switch (length)
            {
                case 1:
                    list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray[0].ToString());
                    for (int m = 0; m < num4; m++)
                    {
                        list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray2[m].ToString());
                        list.Add(chArray[0].ToString() + chArray2[m].ToString() + chArray[0].ToString());
                        list.Add(chArray2[m].ToString() + chArray[0].ToString() + chArray[0].ToString());
                        for (int n = 0; n < num4; n++)
                        {
                            list.Add(chArray[0].ToString() + chArray2[m].ToString() + chArray2[n].ToString());
                            list.Add(chArray2[m].ToString() + chArray[0].ToString() + chArray2[n].ToString());
                            list.Add(chArray2[m].ToString() + chArray2[n].ToString() + chArray[0].ToString());
                        }
                    }
                    break;

                case 2:
                    if (chArray[0] != chArray[1])
                    {
                        for (int num7 = 0; num7 < length; num7++)
                        {
                            for (int num8 = 0; num8 < length; num8++)
                            {
                                if (num7 != num8)
                                {
                                    list.Add(chArray[num7].ToString() + chArray[num7].ToString() + chArray[num8].ToString());
                                    list.Add(chArray[num7].ToString() + chArray[num8].ToString() + chArray[num7].ToString());
                                    list.Add(chArray[num8].ToString() + chArray[num7].ToString() + chArray[num7].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray[0].ToString());
                    }
                    if (chArray[0] != chArray[1])
                    {
                        for (int num9 = 0; num9 < length; num9++)
                        {
                            for (int num10 = 0; num10 < length; num10++)
                            {
                                for (int num11 = 0; num11 < num4; num11++)
                                {
                                    if (num9 != num10)
                                    {
                                        list.Add(chArray[num9].ToString() + chArray[num10].ToString() + chArray2[num11].ToString());
                                        list.Add(chArray[num9].ToString() + chArray2[num11].ToString() + chArray[num10].ToString());
                                        list.Add(chArray2[num11].ToString() + chArray[num9].ToString() + chArray[num10].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int num12 = 0; num12 < num4; num12++)
                        {
                            list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray2[num12].ToString());
                            list.Add(chArray[0].ToString() + chArray2[num12].ToString() + chArray[0].ToString());
                            list.Add(chArray2[num12].ToString() + chArray[0].ToString() + chArray[0].ToString());
                        }
                    }
                    break;
            }
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

        private string[] ToSingle_ZhiDX(string Number, ref string CanonicalNumber)
        {
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            Number = Number.Replace("1", "(56789)").Replace("0", "(01234)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
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
                        return null;
                    }
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

        private string[] ToSingle_ZhiECH(string Number, ref string CanonicalNumber)
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
                for (int k = 0; k < length; k++)
                {
                    if (i != k)
                    {
                        list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString());
                        list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[i].ToString());
                        list.Add(chArray[k].ToString() + chArray[i].ToString() + chArray[i].ToString());
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

        private string[] ToSingle_ZhiF(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 3)
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < length; i++)
            {
                for (int k = 0; k < length; k++)
                {
                    for (int m = 0; m < length; m++)
                    {
                        if (((i != k) && (i != m)) && (k != m))
                        {
                            list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString());
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

        private string[] ToSingle_ZhiJO(string Number, ref string CanonicalNumber)
        {
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            Number = Number.Replace("1", "(13579)").Replace("0", "(02468)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
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
                        return null;
                    }
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

        private string[] ToSingle_ZhiKD(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 0) || (num > 9))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                for (int n = i + 1; n < (int.Parse(CanonicalNumber) + i); n++)
                {
                    list.Add(i.ToString() + n.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
                }
            }
            ArrayList list2 = new ArrayList();
            for (int j = 0; j < 3; j++)
            {
                for (int num5 = 0; num5 < 3; num5++)
                {
                    for (int num6 = 0; num6 < 3; num6++)
                    {
                        for (int num7 = 0; num7 < list.Count; num7++)
                        {
                            if (((j != num5) && (num5 != num6)) && (num6 != j))
                            {
                                char[] chArray = list[num7].ToString().ToCharArray();
                                list2.Add(chArray[j].ToString() + chArray[num5].ToString() + chArray[num6].ToString());
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < (10 - int.Parse(CanonicalNumber)); k++)
            {
                if (int.Parse(CanonicalNumber) == 0)
                {
                    list2.Add(k.ToString() + k.ToString() + k.ToString());
                }
                else
                {
                    list2.Add(k.ToString() + ((int.Parse(CanonicalNumber) + k)).ToString() + ((int.Parse(CanonicalNumber) + k)).ToString());
                    list2.Add(k.ToString() + k.ToString() + ((int.Parse(CanonicalNumber) + k)).ToString());
                    list2.Add(((int.Parse(CanonicalNumber) + k)).ToString() + ((int.Parse(CanonicalNumber) + k)).ToString() + k.ToString());
                    list2.Add(((int.Parse(CanonicalNumber) + k)).ToString() + k.ToString() + k.ToString());
                    list2.Add(((int.Parse(CanonicalNumber) + k)).ToString() + k.ToString() + ((int.Parse(CanonicalNumber) + k)).ToString());
                    list2.Add(k.ToString() + ((int.Parse(CanonicalNumber) + k)).ToString() + k.ToString());
                }
            }
            if (list2.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list2.Count];
            for (int m = 0; m < list2.Count; m++)
            {
                strArray[m] = list2[m].ToString();
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
            CanonicalNumber = Number.Trim();
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
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu3DX(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            char[] chArray = Number.ToCharArray();
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                if ((((chArray[0] != chArray[1]) || (chArray[0] != chArray[2])) || (chArray[1] != chArray[2])) && ((chArray[0] == '1') || (chArray[2] == '0')))
                {
                    CanonicalNumber = "";
                    return null;
                }
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            Number = Number.Replace("1", "(56789)").Replace("0", "(01234)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < strArray[0].Length; k++)
                {
                    for (int m = 0; m < strArray[1].Length; m++)
                    {
                        if (k != m)
                        {
                            list.Add(strArray[0][k].ToString() + strArray[0][k].ToString() + strArray[1][m].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int n = 0; n < strArray[0].Length; n++)
                {
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        list.Add(strArray[0][n].ToString() + strArray[0][n].ToString() + strArray[2][num5].ToString());
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num6 = 0; num6 < strArray[1].Length; num6++)
                {
                    for (int num7 = 0; num7 < strArray[0].Length; num7++)
                    {
                        list.Add(strArray[0][num7].ToString() + strArray[1][num6].ToString() + strArray[1][num6].ToString());
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
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

        private string[] ToSingle_Zu3H(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 1) || (num > 0x1a))
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
                    if ((i != k) && (((i + i) + k) == num))
                    {
                        list.Add(i.ToString() + i.ToString() + k.ToString());
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

        private string[] ToSingle_Zu3JO(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = Number.ToCharArray();
            Number = Number.Replace("1", "(13579)").Replace("0", "(02468)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < strArray[0].Length; k++)
                {
                    for (int m = 0; m < strArray[1].Length; m++)
                    {
                        if (k != m)
                        {
                            list.Add(strArray[0][k].ToString() + strArray[0][k].ToString() + strArray[1][m].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int n = 0; n < strArray[0].Length; n++)
                {
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        list.Add(strArray[0][n].ToString() + strArray[0][n].ToString() + strArray[2][num5].ToString());
                    }
                }
            }
            if ((chArray[0] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num6 = 0; num6 < strArray[0].Length; num6++)
                {
                    for (int num7 = 0; num7 < strArray[1].Length; num7++)
                    {
                        list.Add(strArray[0][num6].ToString() + strArray[0][num6].ToString() + strArray[1][num7].ToString());
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num8 = 0; num8 < strArray[1].Length; num8++)
                {
                    for (int num9 = 0; num9 < strArray[0].Length; num9++)
                    {
                        list.Add(strArray[0][num9].ToString() + strArray[1][num8].ToString() + strArray[1][num8].ToString());
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu3KD(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 1) || (num > 9))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                list.Add(i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
                list.Add(i.ToString() + i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
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

        private string[] ToSingle_Zu6DX(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            char[] chArray = Number.ToCharArray();
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                if ((((chArray[0] != chArray[1]) || (chArray[0] != chArray[2])) || (chArray[1] != chArray[2])) && ((chArray[0] == '1') || (chArray[2] == '0')))
                {
                    CanonicalNumber = "";
                    return null;
                }
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            Number = Number.Replace("1", "(56789)").Replace("0", "(01234)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < (strArray[0].Length - 2); k++)
                {
                    for (int m = k + 1; m < (strArray[1].Length - 1); m++)
                    {
                        for (int n = m + 1; n < strArray[2].Length; n++)
                        {
                            list.Add(strArray[0][k].ToString() + strArray[1][m].ToString() + strArray[2][n].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int num5 = 0; num5 < (strArray[0].Length - 1); num5++)
                {
                    for (int num6 = num5 + 1; num6 < strArray[1].Length; num6++)
                    {
                        for (int num7 = 0; num7 < strArray[2].Length; num7++)
                        {
                            list.Add(strArray[0][num5].ToString() + strArray[1][num6].ToString() + strArray[2][num7].ToString());
                        }
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num8 = 0; num8 < strArray[0].Length; num8++)
                {
                    for (int num9 = 0; num9 < (strArray[1].Length - 1); num9++)
                    {
                        for (int num10 = num9 + 1; num10 < strArray[2].Length; num10++)
                        {
                            list.Add(strArray[0][num8].ToString() + strArray[1][num9].ToString() + strArray[2][num10].ToString());
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu6H(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 3) || (num > 0x18))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i <= 7; i++)
            {
                for (int k = i + 1; k <= 8; k++)
                {
                    for (int m = k + 1; m <= 9; m++)
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

        private string[] ToSingle_Zu6JO(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = Number.ToCharArray();
            Number = Number.Replace("1", "(13579)").Replace("0", "(02468)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < (strArray[0].Length - 2); k++)
                {
                    for (int m = k + 1; m < (strArray[1].Length - 1); m++)
                    {
                        for (int n = m + 1; n < strArray[2].Length; n++)
                        {
                            list.Add(strArray[0][k].ToString() + strArray[1][m].ToString() + strArray[2][n].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int num5 = 0; num5 < (strArray[0].Length - 1); num5++)
                {
                    for (int num6 = num5 + 1; num6 < strArray[1].Length; num6++)
                    {
                        for (int num7 = 0; num7 < strArray[2].Length; num7++)
                        {
                            list.Add(strArray[0][num5].ToString() + strArray[1][num6].ToString() + strArray[2][num7].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num8 = 0; num8 < (strArray[0].Length - 1); num8++)
                {
                    for (int num9 = 0; num9 < strArray[1].Length; num9++)
                    {
                        for (int num10 = num8 + 1; num10 < strArray[2].Length; num10++)
                        {
                            list.Add(strArray[0][num8].ToString() + strArray[1][num9].ToString() + strArray[2][num10].ToString());
                        }
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num11 = 0; num11 < strArray[0].Length; num11++)
                {
                    for (int num12 = 0; num12 < (strArray[1].Length - 1); num12++)
                    {
                        for (int num13 = num12 + 1; num13 < strArray[2].Length; num13++)
                        {
                            list.Add(strArray[0][num11].ToString() + strArray[1][num12].ToString() + strArray[2][num13].ToString());
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu6KD(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 2) || (num > 9))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                for (int k = i + 1; k < (int.Parse(CanonicalNumber) + i); k++)
                {
                    list.Add(i.ToString() + k.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
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

        private string[] ToSingle_ZuheDT(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d){1,2})[,](?<L1>(\d){2,})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            char[] chArray = strArray[0].ToCharArray();
            char[] chArray2 = this.FilterRepeated(strArray[1]).ToCharArray();
            for (int j = 0; j < chArray2.Length; j++)
            {
                if (strArray[0].IndexOf(chArray2[j]) >= 0)
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            CanonicalNumber = strArray[0] + "," + this.FilterRepeated(strArray[1]);
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            int num4 = chArray2.Length;
            switch (length)
            {
                case 1:
                    list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray[0].ToString());
                    for (int m = 0; m < num4; m++)
                    {
                        list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray2[m].ToString());
                        list.Add(chArray[0].ToString() + chArray2[m].ToString() + chArray2[m].ToString());
                    }
                    for (int n = 0; n < (num4 - 1); n++)
                    {
                        for (int num7 = n + 1; num7 < num4; num7++)
                        {
                            list.Add(chArray[0].ToString() + chArray2[n].ToString() + chArray2[num7].ToString());
                        }
                    }
                    break;

                case 2:
                    if (chArray[0] != chArray[1])
                    {
                        list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray[1].ToString());
                        list.Add(chArray[0].ToString() + chArray[1].ToString() + chArray[1].ToString());
                    }
                    else
                    {
                        list.Add(chArray[0].ToString() + chArray[0].ToString() + chArray[0].ToString());
                    }
                    for (int num8 = 0; num8 < num4; num8++)
                    {
                        list.Add(chArray[0].ToString() + chArray[1].ToString() + chArray2[num8].ToString());
                    }
                    break;
            }
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

        private string[] ToSingle_ZuheDX(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            char[] chArray = Number.ToCharArray();
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                if ((((chArray[0] != chArray[1]) || (chArray[0] != chArray[2])) || (chArray[1] != chArray[2])) && ((chArray[0] == '1') || (chArray[2] == '0')))
                {
                    CanonicalNumber = "";
                    return null;
                }
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            Number = Number.Replace("1", "(56789)").Replace("0", "(01234)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < strArray[0].Length; k++)
                {
                    list.Add(strArray[0][k].ToString() + strArray[0][k].ToString() + strArray[0][k].ToString());
                }
                for (int m = 0; m < (strArray[0].Length - 2); m++)
                {
                    for (int num4 = m + 1; num4 < (strArray[1].Length - 1); num4++)
                    {
                        for (int num5 = num4 + 1; num5 < strArray[2].Length; num5++)
                        {
                            list.Add(strArray[0][m].ToString() + strArray[1][num4].ToString() + strArray[2][num5].ToString());
                        }
                    }
                }
                for (int n = 0; n < strArray[0].Length; n++)
                {
                    for (int num7 = 0; num7 < strArray[1].Length; num7++)
                    {
                        if (n != num7)
                        {
                            list.Add(strArray[0][n].ToString() + strArray[0][n].ToString() + strArray[1][num7].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int num8 = 0; num8 < (strArray[0].Length - 1); num8++)
                {
                    for (int num9 = num8 + 1; num9 < strArray[1].Length; num9++)
                    {
                        for (int num10 = 0; num10 < strArray[2].Length; num10++)
                        {
                            list.Add(strArray[0][num8].ToString() + strArray[1][num9].ToString() + strArray[2][num10].ToString());
                        }
                    }
                }
                for (int num11 = 0; num11 < strArray[0].Length; num11++)
                {
                    for (int num12 = 0; num12 < strArray[2].Length; num12++)
                    {
                        list.Add(strArray[0][num11].ToString() + strArray[0][num11].ToString() + strArray[2][num12].ToString());
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num13 = 0; num13 < strArray[0].Length; num13++)
                {
                    for (int num14 = 0; num14 < (strArray[1].Length - 1); num14++)
                    {
                        for (int num15 = num14 + 1; num15 < strArray[2].Length; num15++)
                        {
                            list.Add(strArray[0][num13].ToString() + strArray[1][num14].ToString() + strArray[2][num15].ToString());
                        }
                    }
                }
                for (int num16 = 0; num16 < strArray[1].Length; num16++)
                {
                    for (int num17 = 0; num17 < strArray[0].Length; num17++)
                    {
                        list.Add(strArray[1][num16].ToString() + strArray[1][num16].ToString() + strArray[0][num17].ToString());
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_ZuheF(string Number, ref string CanonicalNumber)
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
                for (int n = i + 1; n < length; n++)
                {
                    list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[n].ToString());
                    list.Add(chArray[i].ToString() + chArray[n].ToString() + chArray[n].ToString());
                }
            }
            for (int j = 0; j < length; j++)
            {
                for (int num5 = 0; num5 < length; num5++)
                {
                    for (int num6 = 0; num6 < length; num6++)
                    {
                        if (((j == num5) && (j == num6)) && (num5 == num6))
                        {
                            list.Add(chArray[j].ToString() + chArray[num5].ToString() + chArray[num6].ToString());
                        }
                    }
                }
            }
            for (int k = 0; k < (length - 2); k++)
            {
                for (int num8 = k + 1; num8 < (length - 1); num8++)
                {
                    for (int num9 = num8 + 1; num9 < length; num9++)
                    {
                        list.Add(chArray[k].ToString() + chArray[num8].ToString() + chArray[num9].ToString());
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray[m] = list[m].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_ZuheH(string sBill, ref string CanonicalNumber)
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
                if (((i + i) + i) == num)
                {
                    list.Add(i.ToString() + i.ToString() + i.ToString());
                }
            }
            for (int j = 0; j <= 9; j++)
            {
                for (int n = 0; n <= 9; n++)
                {
                    if ((j != n) && (((j + j) + n) == num))
                    {
                        list.Add(j.ToString() + j.ToString() + n.ToString());
                    }
                }
            }
            for (int k = 0; k <= 7; k++)
            {
                for (int num6 = k + 1; num6 <= 8; num6++)
                {
                    for (int num7 = num6 + 1; num7 <= 9; num7++)
                    {
                        if (((k + num6) + num7) == num)
                        {
                            list.Add(k.ToString() + num6.ToString() + num7.ToString());
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray[m] = list[m].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_ZuheHSW(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 0) || (num > 9))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                for (int m = 0; m < 10; m++)
                {
                    for (int n = 0; n < 10; n++)
                    {
                        if (((m + n) + n) == int.Parse(((i == 0) ? null : i.ToString()) + ((string)CanonicalNumber)))
                        {
                            list.Add(m.ToString() + n.ToString() + n.ToString());
                        }
                    }
                }
            }
            for (int j = 0; j < 3; j++)
            {
                for (int num6 = 0; num6 < 8; num6++)
                {
                    for (int num7 = num6 + 1; num7 < 9; num7++)
                    {
                        for (int num8 = num7 + 1; num8 < 10; num8++)
                        {
                            if (((num6 + num7) + num8) == int.Parse(((j == 0) ? null : j.ToString()) + ((string)CanonicalNumber)))
                            {
                                list.Add(num6.ToString() + num7.ToString() + num8.ToString());
                            }
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray[k] = list[k].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_ZuheJO(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Regex regex = new Regex("^[0-1][0-1][0-1]{1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (regex.Match(Number).Success)
            {
                Number = Number.Substring(0, 3);
                CanonicalNumber = Number;
            }
            else
            {
                CanonicalNumber = "";
                return null;
            }
            char[] chArray = Number.ToCharArray();
            Number = Number.Replace("1", "(13579)").Replace("0", "(02468)");
            string[] strArray = new string[3];
            Match match2 = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match2.Groups["L" + i.ToString()].ToString().Trim();
                strArray[i] = strArray[i].Substring(1, strArray[i].Length - 2);
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            ArrayList list = new ArrayList();
            if ((chArray[0] == chArray[1]) && (chArray[0] == chArray[2]))
            {
                for (int k = 0; k < strArray[0].Length; k++)
                {
                    list.Add(strArray[0][k].ToString() + strArray[0][k].ToString() + strArray[0][k].ToString());
                }
                for (int m = 0; m < (strArray[0].Length - 2); m++)
                {
                    for (int num4 = m + 1; num4 < (strArray[1].Length - 1); num4++)
                    {
                        for (int num5 = num4 + 1; num5 < strArray[2].Length; num5++)
                        {
                            list.Add(strArray[0][m].ToString() + strArray[1][num4].ToString() + strArray[2][num5].ToString());
                        }
                    }
                }
                for (int n = 0; n < strArray[0].Length; n++)
                {
                    for (int num7 = 0; num7 < strArray[1].Length; num7++)
                    {
                        if (n != num7)
                        {
                            list.Add(strArray[0][n].ToString() + strArray[0][n].ToString() + strArray[1][num7].ToString());
                        }
                    }
                }
            }
            if ((chArray[0] == chArray[1]) && (chArray[0] != chArray[2]))
            {
                for (int num8 = 0; num8 < (strArray[0].Length - 1); num8++)
                {
                    for (int num9 = num8 + 1; num9 < strArray[1].Length; num9++)
                    {
                        for (int num10 = 0; num10 < strArray[2].Length; num10++)
                        {
                            list.Add(strArray[0][num8].ToString() + strArray[1][num9].ToString() + strArray[2][num10].ToString());
                        }
                    }
                }
                for (int num11 = 0; num11 < strArray[0].Length; num11++)
                {
                    for (int num12 = 0; num12 < strArray[2].Length; num12++)
                    {
                        list.Add(strArray[0][num11].ToString() + strArray[0][num11].ToString() + strArray[2][num12].ToString());
                    }
                }
            }
            if ((chArray[0] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num13 = 0; num13 < (strArray[0].Length - 1); num13++)
                {
                    for (int num14 = 0; num14 < strArray[1].Length; num14++)
                    {
                        for (int num15 = num13 + 1; num15 < strArray[2].Length; num15++)
                        {
                            list.Add(strArray[0][num13].ToString() + strArray[1][num14].ToString() + strArray[2][num15].ToString());
                        }
                    }
                }
                for (int num16 = 0; num16 < strArray[0].Length; num16++)
                {
                    for (int num17 = 0; num17 < strArray[1].Length; num17++)
                    {
                        list.Add(strArray[0][num16].ToString() + strArray[0][num16].ToString() + strArray[1][num17].ToString());
                    }
                }
            }
            if ((chArray[1] == chArray[2]) && (chArray[0] != chArray[1]))
            {
                for (int num18 = 0; num18 < strArray[0].Length; num18++)
                {
                    for (int num19 = 0; num19 < (strArray[1].Length - 1); num19++)
                    {
                        for (int num20 = num19 + 1; num20 < strArray[2].Length; num20++)
                        {
                            list.Add(strArray[0][num18].ToString() + strArray[1][num19].ToString() + strArray[2][num20].ToString());
                        }
                    }
                }
                for (int num21 = 0; num21 < strArray[1].Length; num21++)
                {
                    for (int num22 = 0; num22 < strArray[0].Length; num22++)
                    {
                        list.Add(strArray[1][num21].ToString() + strArray[1][num21].ToString() + strArray[0][num22].ToString());
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray2 = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray2[j] = list[j].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_ZuheKD(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 1) || (num > 9))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                list.Add(i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
                list.Add(i.ToString() + i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
            }
            for (int j = 0; j < (10 - int.Parse(CanonicalNumber)); j++)
            {
                for (int m = j + 1; m < (int.Parse(CanonicalNumber) + j); m++)
                {
                    list.Add(j.ToString() + m.ToString() + ((int.Parse(CanonicalNumber) + j)).ToString());
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray[k] = list[k].ToString();
            }
            return strArray;
        }
    }
}
