using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class NYFC36X7 : LotteryBase
    {
        public const string Code = "NYFC36X7";
        public const int ID = 0x10;
        public const double MaxMoney = 245157.0;
        public const string Name = "南粤风采36选7";
        public const int PlayType_D = 0x641;
        public const int PlayType_F = 0x642;
        public const int PlayType_HC1_D = 0x643;
        public const int PlayType_HC1_F = 0x644;
        public const int PlayType_HC2_D = 0x645;
        public const int PlayType_HC2_F = 0x650;
        public const int PlayType_HC3_D = 0x647;
        public const int PlayType_HC3_F = 0x648;
        public const string sID = "16";

        public NYFC36X7()
        {
            base.id = 0x10;
            base.name = "南粤风采36选7";
            base.code = "NYFC36X7";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x641) || (PlayType == 0x642))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if ((PlayType == 0x643) || (PlayType == 0x644))
            {
                return this.AnalyseScheme_HC1(Content, PlayType);
            }
            if ((PlayType == 0x645) || (PlayType == 0x650))
            {
                return this.AnalyseScheme_HC2(Content, PlayType);
            }
            if ((PlayType != 0x647) && (PlayType != 0x648))
            {
                return "";
            }
            return this.AnalyseScheme_HC3(Content, PlayType);
        }

        private string AnalyseScheme_HC1(string Content, int PlayType)
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
            if (PlayType == 0x643)
            {
                str2 = @"(\d\d)";
            }
            else
            {
                str2 = @"((\d\d\s){1,35}\d\d)|(\d\d)";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HC1(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x643) ? 1 : 2))) && (strArray2.Length <= 122578.5))
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

        private string AnalyseScheme_HC2(string Content, int PlayType)
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
            if (PlayType == 0x645)
            {
                str2 = @"(\d\d\s\d\d)";
            }
            else
            {
                str2 = @"(\d\d\s){1,35}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HC2(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x645) ? 1 : 2))) && (strArray2.Length <= 122578.5))
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

        private string AnalyseScheme_HC3(string Content, int PlayType)
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
            if (PlayType == 0x647)
            {
                str2 = @"(\d\d\s){2}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){2,35}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HC3(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x647) ? 1 : 2))) && (strArray2.Length <= 122578.5))
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
            if (PlayType == 0x641)
            {
                str2 = @"(\d\d\s){6}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){6,35}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zhi(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x641) ? 1 : 2))) && (strArray2.Length <= 122578.5))
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
            Regex regex = new Regex(@"(\d\d\s){6}[+]\s\d\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_Zhi(Number.Replace("+ ", ""), ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();
            for (int i = 0; i < Num; i++)
            {
                al.Clear();
                for (int j = 0; j < 7; j++)
                {
                    int ball = 0;
                    while ((ball == 0) || base.isExistBall(al, ball))
                    {
                        ball = random.Next(1, 0x25);
                    }
                    al.Add(ball.ToString().PadLeft(2, '0'));
                }
                LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
                al.Sort(comparer);
                string str = "";
                for (int k = 0; k < al.Count; k++)
                {
                    str = str + al[k].ToString() + " ";
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x641) && (play_type <= 0x648));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 0x12))
            {
                return -3.0;
            }
            if ((PlayType == 0x641) || (PlayType == 0x642))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11]);
            }
            if ((PlayType == 0x643) || (PlayType == 0x644))
            {
                return this.ComputeWin_HC1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13]);
            }
            if ((PlayType == 0x645) || (PlayType == 0x650))
            {
                return this.ComputeWin_HC2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[14], WinMoneyList[15]);
            }
            if ((PlayType != 0x647) && (PlayType != 0x648))
            {
                return -4.0;
            }
            return this.ComputeWin_HC3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0x10], WinMoneyList[0x11]);
        }

        private double ComputeWin_HC1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x16)
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
            string str = WinNumber.Substring(20, 2);
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_HC1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 2) && (strArray2[j] == str))
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
                Description = "好彩一奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_HC2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x16)
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
            string str = WinNumber.Substring(0, 0x12);
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_HC2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 5)
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
                                if (str.IndexOf(strArray3[k]) >= 0)
                                {
                                    num5++;
                                }
                            }
                            if (flag && (num5 == 2))
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "好彩二奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_HC3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x16)
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
            string str = WinNumber.Substring(0, 0x12);
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_HC3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 8)
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
                                if (str.IndexOf(strArray3[k]) >= 0)
                                {
                                    num5++;
                                }
                            }
                            if (flag && (num5 == 3))
                            {
                                num++;
                                num2 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "好彩三奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x16)
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
            string str = WinNumber.Substring(20, 2);
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            double num7 = 0.0;
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
                        if (strArray2[j].Length >= 20)
                        {
                            string[] strArray3 = new string[7];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num10 = 0;
                            bool flag = false;
                            bool flag2 = true;
                            for (int k = 0; k < 7; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag2 = false;
                                    break;
                                }
                                if (WinNumber.IndexOf(strArray3[k] + " ") >= 0)
                                {
                                    num10++;
                                }
                                if (str == strArray3[k])
                                {
                                    flag = true;
                                }
                            }
                            if (flag2)
                            {
                                if ((num10 == 6) && flag)
                                {
                                    num++;
                                    num7 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                                else if (num10 == 6)
                                {
                                    num2++;
                                    num7 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                                else if ((num10 == 5) && flag)
                                {
                                    num3++;
                                    num7 += WinMoney3;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                                }
                                else if (num10 == 5)
                                {
                                    num4++;
                                    num7 += WinMoney4;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                                }
                                else if ((num10 == 4) && flag)
                                {
                                    num5++;
                                    num7 += WinMoney5;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax5;
                                }
                                else if ((num10 == 4) || ((num10 == 3) && flag))
                                {
                                    num6++;
                                    num7 += WinMoney6;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax6;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "一等奖" + num.ToString() + "注";
            }
            if (num2 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "二等奖" + num2.ToString() + "注";
            }
            if (num3 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "三等奖" + num3.ToString() + "注";
            }
            if (num4 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "四等奖" + num4.ToString() + "注";
            }
            if (num5 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "五等奖" + num5.ToString() + "注";
            }
            if (num6 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "六等奖" + num6.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num7;
        }

        private string[] FilterRepeated(string[] NumberPart)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= 0x24)) && !base.isExistBall(al, ball))
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
            return new PlayType[] { new PlayType(0x641, "单式"), new PlayType(0x642, "复式"), new PlayType(0x643, "好彩一单式"), new PlayType(0x644, "好彩一复式"), new PlayType(0x645, "好彩二单式"), new PlayType(0x650, "好彩二复式"), new PlayType(0x647, "好彩三单式"), new PlayType(0x648, "好彩三复式") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if ((PlayType == 0x641) || (PlayType == 0x642))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x643) || (PlayType == 0x644))
            {
                return this.ToSingle_HC1(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x645) || (PlayType == 0x650))
            {
                return this.ToSingle_HC2(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x647) && (PlayType != 0x648))
            {
                return null;
            }
            return this.ToSingle_HC3(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_HC1(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
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
            return strArray;
        }

        private string[] ToSingle_HC2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
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

        private string[] ToSingle_HC3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
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

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
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
    }
}
