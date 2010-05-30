using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class TCCJDLT : LotteryBase
    {
        public const string Code = "TCCJDLT";
        public const int ID = 0x27;
        public const double MaxMoney = 30000.0;
        public const string Name = "体彩超级大乐透";
        public const int PlayType_2_D = 0xf41;
        public const int PlayType_2_F = 0xf42;
        public const int PlayType_D = 0xf3d;
        public const int PlayType_F = 0xf3e;
        public const int PlayType_ZJ_D = 0xf3f;
        public const int PlayType_ZJ_F = 0xf40;
        public const string sID = "39";

        public TCCJDLT()
        {
            base.id = 0x27;
            base.name = "体彩超级大乐透";
            base.code = "TCCJDLT";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0xf3d) || (PlayType == 0xf3e))
            {
                return this.AnalyseScheme_0(Content, PlayType);
            }
            if ((PlayType == 0xf3f) || (PlayType == 0xf40))
            {
                return this.AnalyseScheme_ZJ(Content, PlayType);
            }
            if ((PlayType != 0xf41) && (PlayType != 0xf42))
            {
                return null;
            }
            return this.AnalyseScheme_12X2(Content, PlayType);
        }

        private string AnalyseScheme_0(string Content, int PlayType)
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
            if (PlayType == 0xf3d)
            {
                str2 = @"(\d\d\s){5}[+](\s\d\d){2}";
            }
            else
            {
                str2 = @"(\d\d\s){5,35}[+](\s\d\d){2,12}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_0(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xf3d) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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

        private string AnalyseScheme_12X2(string Content, int PlayType)
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
            if (PlayType == 0xf41)
            {
                str2 = @"\d\d\s\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){2,11}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_12X2(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xf41) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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

        private string AnalyseScheme_ZJ(string Content, int PlayType)
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
            if (PlayType == 0xf3f)
            {
                str2 = @"(\d\d\s){5}[+](\s\d\d){2}";
            }
            else
            {
                str2 = @"(\d\d\s){5,35}[+](\s\d\d){2,12}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_0(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0xf3f) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            Regex regex = new Regex(@"(\d\d\s){5}[+](\s\d\d){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0xf3d);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Red, int Blue, int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();
            ArrayList list2 = new ArrayList();
            for (int i = 0; i < Num; i++)
            {
                al.Clear();
                list2.Clear();
                for (int j = 0; j < Red; j++)
                {
                    int ball = 0;
                    while ((ball == 0) || base.isExistBall(al, ball))
                    {
                        ball = random.Next(1, 0x24);
                    }
                    al.Add(ball.ToString().PadLeft(2, '0'));
                }
                for (int k = 0; k < Blue; k++)
                {
                    int num5 = 0;
                    while ((num5 == 0) || base.isExistBall(list2, num5))
                    {
                        num5 = random.Next(1, 13);
                    }
                    list2.Add(num5.ToString().PadLeft(2, '0'));
                }
                LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
                al.Sort(comparer);
                list2.Sort(comparer);
                string str = "";
                for (int m = 0; m < al.Count; m++)
                {
                    str = str + al[m].ToString() + " ";
                }
                if (str != "")
                {
                    str = str + "+ ";
                }
                for (int n = 0; n < list2.Count; n++)
                {
                    str = str + list2[n].ToString() + " ";
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0xf3d) && (play_type <= 0xf42));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 30))
            {
                return -3.0;
            }
            if ((PlayType == 0xf3d) || (PlayType == 0xf3e))
            {
                return this.ComputeWin_0(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[4], WinMoneyList[5], WinMoneyList[8], WinMoneyList[9], WinMoneyList[12], WinMoneyList[13], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x18], WinMoneyList[0x19], WinMoneyList[0x1c], WinMoneyList[0x1d]);
            }
            if ((PlayType == 0xf3f) || (PlayType == 0xf40))
            {
                return this.ComputeWin_ZJ(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13], WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x16], WinMoneyList[0x17], WinMoneyList[0x18], WinMoneyList[0x19], WinMoneyList[0x1a], WinMoneyList[0x1b], WinMoneyList[0x1c], WinMoneyList[0x1d]);
            }
            if ((PlayType != 0xf41) && (PlayType != 0xf42))
            {
                return -4.0;
            }
            return this.ComputeWin_12X2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[30], WinMoneyList[0x1f]);
        }

        private double ComputeWin_0(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7, double WinMoney8, double WinMoneyNoWithTax8)
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
            string str = WinNumber.Substring(0, 15);
            string str2 = WinNumber.Substring(0x11, 5).Trim();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            double num9 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_0(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 0x16)
                        {
                            string[] strArray3 = new string[5];
                            string[] strArray4 = new string[2];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)[+]\s(?<B0>\d\d\s)(?<B1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num12 = 0;
                            int num13 = 0;
                            bool flag = true;
                            for (int k = 0; k < 5; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (str.IndexOf(strArray3[k] + " ") >= 0)
                                {
                                    num12++;
                                }
                            }
                            for (int m = 0; m < 2; m++)
                            {
                                strArray4[m] = match.Groups["B" + m.ToString()].ToString().Trim();
                                if (strArray4[m] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (str2.IndexOf(strArray4[m]) >= 0)
                                {
                                    num13++;
                                }
                            }
                            if (flag)
                            {
                                if ((num12 == 5) && (num13 == 2))
                                {
                                    num++;
                                    num9 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                                else if ((num12 == 5) && (num13 == 1))
                                {
                                    num2++;
                                    num9 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                                else if (num12 == 5)
                                {
                                    num3++;
                                    num9 += WinMoney3;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                                }
                                else if ((num12 == 4) && (num13 == 2))
                                {
                                    num4++;
                                    num9 += WinMoney4;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                                }
                                else if ((num12 == 4) && (num13 == 1))
                                {
                                    num5++;
                                    num9 += WinMoney5;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax5;
                                }
                                else if ((num12 == 4) || ((num12 == 3) && (num13 == 2)))
                                {
                                    num6++;
                                    num9 += WinMoney6;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax6;
                                }
                                else if (((num12 == 3) && (num13 == 1)) || ((num12 == 2) && (num13 == 2)))
                                {
                                    num7++;
                                    num9 += WinMoney7;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax7;
                                }
                                else if ((((num12 == 3) || ((num12 == 2) && (num13 == 1))) || ((num12 == 1) && (num13 == 2))) || (num13 == 2))
                                {
                                    num8++;
                                    num9 += WinMoney8;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax8;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
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
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "七等奖" + num7.ToString() + "注";
            }
            if (num8 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "八等奖" + num8.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num9;
        }

        private double ComputeWin_12X2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            string str = WinNumber.Substring(0x11, 5).Trim();
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_12X2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 2)
                        {
                            string[] strArray3 = new string[2];
                            Match match = new Regex(@"(?<B0>\d\d\s)(?<B1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num5 = 0;
                            bool flag = true;
                            for (int k = 0; k < 2; k++)
                            {
                                strArray3[k] = match.Groups["B" + k.ToString()].ToString().Trim();
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
                Description = "12选2" + num.ToString() + "注";
            }
            return num2;
        }

        private double ComputeWin_ZJ(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double ZJ_WinMoney1, double ZJ_WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double ZJ_WinMoney2, double ZJ_WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double ZJ_WinMoney3, double ZJ_WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double ZJ_WinMoney4, double ZJ_WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double ZJ_WinMoney5, double ZJ_WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double ZJ_WinMoney6, double ZJ_WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7, double ZJ_WinMoney7, double ZJ_WinMoneyNoWithTax7, double WinMoney8, double WinMoneyNoWithTax8)
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
            string str = WinNumber.Substring(0, 15);
            string str2 = WinNumber.Substring(0x11, 5).Trim();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            double num9 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_0(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 0x16)
                        {
                            string[] strArray3 = new string[5];
                            string[] strArray4 = new string[2];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)[+]\s(?<B0>\d\d\s)(?<B1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num12 = 0;
                            int num13 = 0;
                            bool flag = true;
                            for (int k = 0; k < 5; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (str.IndexOf(strArray3[k] + " ") >= 0)
                                {
                                    num12++;
                                }
                            }
                            for (int m = 0; m < 2; m++)
                            {
                                strArray4[m] = match.Groups["B" + m.ToString()].ToString().Trim();
                                if (strArray4[m] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (str2.IndexOf(strArray4[m]) >= 0)
                                {
                                    num13++;
                                }
                            }
                            if (flag)
                            {
                                if ((num12 == 5) && (num13 == 2))
                                {
                                    num++;
                                    num9 += WinMoney1 + ZJ_WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1 + ZJ_WinMoneyNoWithTax1;
                                }
                                else if ((num12 == 5) && (num13 == 1))
                                {
                                    num2++;
                                    num9 += WinMoney2 + ZJ_WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2 + ZJ_WinMoneyNoWithTax2;
                                }
                                else if (num12 == 5)
                                {
                                    num3++;
                                    num9 += WinMoney3 + ZJ_WinMoney3;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax3 + ZJ_WinMoneyNoWithTax3;
                                }
                                else if ((num12 == 4) && (num13 == 2))
                                {
                                    num4++;
                                    num9 += WinMoney4 + ZJ_WinMoney4;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax4 + ZJ_WinMoneyNoWithTax4;
                                }
                                else if ((num12 == 4) && (num13 == 1))
                                {
                                    num5++;
                                    num9 += WinMoney5 + ZJ_WinMoney5;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax5 + ZJ_WinMoneyNoWithTax5;
                                }
                                else if ((num12 == 4) || ((num12 == 3) && (num13 == 2)))
                                {
                                    num6++;
                                    num9 += WinMoney6 + ZJ_WinMoney6;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax6 + ZJ_WinMoneyNoWithTax6;
                                }
                                else if (((num12 == 3) && (num13 == 1)) || ((num12 == 2) && (num13 == 2)))
                                {
                                    num7++;
                                    num9 += WinMoney7 + ZJ_WinMoney7;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax7 + ZJ_WinMoneyNoWithTax7;
                                }
                                else if ((((num12 == 3) || ((num12 == 2) && (num13 == 1))) || ((num12 == 1) && (num13 == 2))) || (num13 == 2))
                                {
                                    num8++;
                                    num9 += WinMoney8;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax8;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = "追加一等奖" + num.ToString() + "注";
            }
            if (num2 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加二等奖" + num2.ToString() + "注";
            }
            if (num3 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加三等奖" + num3.ToString() + "注";
            }
            if (num4 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加四等奖" + num4.ToString() + "注";
            }
            if (num5 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加五等奖" + num5.ToString() + "注";
            }
            if (num6 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加六等奖" + num6.ToString() + "注";
            }
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "追加七等奖" + num7.ToString() + "注";
            }
            if (num8 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "八等奖" + num8.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num9;
        }

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3e)) && ((PlayTypeID != 0xf3f) && (PlayTypeID != 0xf40))) && ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42)))
            {
                return str;
            }
            return Number.Replace(" + ", "-");
        }

        private string ConvertFormatToElectronTicket_HPSD(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3e)) && ((PlayTypeID != 0xf3f) && (PlayTypeID != 0xf40))) && ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42)))
            {
                return str;
            }
            return Number.Replace(" ", ",").Replace(",+,", "|");
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
            return new PlayType[] { new PlayType(0xf3d, "单式"), new PlayType(0xf3e, "复式"), new PlayType(0xf3f, "追加单式"), new PlayType(0xf40, "追加复式"), new PlayType(0xf41, "12选2单式"), new PlayType(0xf42, "12选2复式") };
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
                    case "CR_YTCII2":
                        if ((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3f))
                        {
                            if ((PlayTypeID == 0xf3e) || (PlayTypeID == 0xf40))
                            {
                                return this.GetPrintKeyList_CR_YTCII2_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_12X2(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_D(numbers);

                    case "TGAMPOS4000":
                        if (PlayTypeID != 0xf3d)
                        {
                            if (PlayTypeID == 0xf3f)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZJ_D(numbers);
                            }
                            if (PlayTypeID == 0xf3e)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_F(numbers);
                            }
                            if (PlayTypeID == 0xf40)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZJ_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_12X2(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_D(numbers);

                    case "CP86":
                        if ((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3f))
                        {
                            if ((PlayTypeID == 0xf3e) || (PlayTypeID == 0xf40))
                            {
                                return this.GetPrintKeyList_CP86_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_12X2(numbers);
                        }
                        return this.GetPrintKeyList_CP86_D(numbers);

                    case "MODEL_4000":
                        if (PlayTypeID != 0xf3d)
                        {
                            if (PlayTypeID == 0xf3f)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZJ_D(numbers);
                            }
                            if (PlayTypeID == 0xf3e)
                            {
                                return this.GetPrintKeyList_MODEL_4000_F(numbers);
                            }
                            if (PlayTypeID == 0xf40)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZJ_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_12X2(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_D(numbers);

                    case "CORONISTPT":
                        if (PlayTypeID != 0xf3d)
                        {
                            if (PlayTypeID == 0xf3f)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZJ_D(numbers);
                            }
                            if (PlayTypeID == 0xf3e)
                            {
                                return this.GetPrintKeyList_CORONISTPT_F(numbers);
                            }
                            if (PlayTypeID == 0xf40)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZJ_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_12X2(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_D(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0xf3d)
                        {
                            if (PlayTypeID == 0xf3f)
                            {
                                return this.GetPrintKeyList_RS6500_ZJ_D(numbers);
                            }
                            if (PlayTypeID == 0xf3e)
                            {
                                return this.GetPrintKeyList_RS6500_F(numbers);
                            }
                            if (PlayTypeID != 0xf40)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_ZJ_F(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_D(numbers);

                    case "ks230":
                        if ((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3f))
                        {
                            if ((PlayTypeID == 0xf3e) || (PlayTypeID == 0xf40))
                            {
                                return this.GetPrintKeyList_ks230_F(numbers);
                            }
                            if ((PlayTypeID != 0xf41) && (PlayTypeID != 0xf42))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_12X2(numbers);
                        }
                        return this.GetPrintKeyList_ks230_D(numbers);

                    case "LA-600A":
                        if ((PlayTypeID != 0xf3d) && (PlayTypeID != 0xf3f))
                        {
                            if ((PlayTypeID == 0xf3e) || (PlayTypeID == 0xf40))
                            {
                                return this.GetPrintKeyList_LA_600A_F(numbers);
                            }
                            if ((PlayTypeID == 0xf41) || (PlayTypeID == 0xf42))
                            {
                                return this.GetPrintKeyList_LA_600A_12X2(numbers);
                            }
                            break;
                        }
                        return this.GetPrintKeyList_LA_600A_D(numbers);
                }
            }
            return "";
        }

        private string GetPrintKeyList_CORONISTPT_12X2(string[] Numbers)
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

        private string GetPrintKeyList_CORONISTPT_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CORONISTPT_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_CORONISTPT_ZJ_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return (str + "[A]");
        }

        private string GetPrintKeyList_CORONISTPT_ZJ_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return (str + "[A]");
        }

        private string GetPrintKeyList_CP86_12X2(string[] Numbers)
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

        private string GetPrintKeyList_CP86_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CP86_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_CR_YTCII2_12X2(string[] Numbers)
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

        private string GetPrintKeyList_CR_YTCII2_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CR_YTCII2_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_ks230_12X2(string[] Numbers)
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

        private string GetPrintKeyList_ks230_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_ks230_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LA_600A_12X2(string[] Numbers)
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

        private string GetPrintKeyList_LA_600A_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LA_600A_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                str = str + "[↓]";
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓][↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_MODEL_4000_12X2(string[] Numbers)
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

        private string GetPrintKeyList_MODEL_4000_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_MODEL_4000_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓][↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_MODEL_4000_ZJ_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return (str + "[+]");
        }

        private string GetPrintKeyList_MODEL_4000_ZJ_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓][↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return (str + "[+]");
        }

        private string GetPrintKeyList_RS6500_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_ZJ_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return (str + "[A]");
        }

        private string GetPrintKeyList_RS6500_ZJ_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return (str + "[A]");
        }

        private string GetPrintKeyList_TGAMPOS4000_12X2(string[] Numbers)
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

        private string GetPrintKeyList_TGAMPOS4000_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TGAMPOS4000_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓][↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_TGAMPOS4000_ZJ_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch != '+')
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return (str + "[+]");
        }

        private string GetPrintKeyList_TGAMPOS4000_ZJ_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string[] strArray = str2.Split(new char[] { '+' });
                if (strArray.Length != 2)
                {
                    return "";
                }
                string str3 = strArray[0].Replace(" ", "");
                string str4 = strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", "");
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[↓][↓]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return (str + "[+]");
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override Ticket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0xf3d)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf3e)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf3f)
            {
                return this.ToElectronicTicket_DYJ_ZJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf40)
            {
                return this.ToElectronicTicket_DYJ_ZJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf41)
            {
                return this.ToElectronicTicket_DYJ_2_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf42)
            {
                return this.ToElectronicTicket_DYJ_2_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private Ticket[] ToElectronicTicket_DYJ_2_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + ";\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x69, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_2_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0] + ";";
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x69, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + ";\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x65, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0] + ";";
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_DYJ_ZJ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + ";\n";
                            num3 += 3.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x67, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_DYJ_ZJ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0] + ";";
                        num3 += 3.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x68, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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

        public override Ticket[] ToElectronicTicket_HPSD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0xf3d)
            {
                return this.ToElectronicTicket_HPSD_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf3e)
            {
                return this.ToElectronicTicket_HPSD_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf3f)
            {
                return this.ToElectronicTicket_HPSD_ZJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf40)
            {
                return this.ToElectronicTicket_HPSD_ZJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf41)
            {
                return this.ToElectronicTicket_HPSD_2_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0xf42)
            {
                return this.ToElectronicTicket_HPSD_2_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private Ticket[] ToElectronicTicket_HPSD_2_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0x69, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSD_2_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    ArrayList list2 = new ArrayList();
                    string[] strArray2 = strArray[k].Split(new char[] { ' ' });
                    int length = strArray2.Length;
                    for (int m = 0; m < (length - 1); m++)
                    {
                        for (int num8 = m + 1; num8 < length; num8++)
                        {
                            list2.Add(strArray2[m] + " " + strArray2[num8]);
                        }
                    }
                    for (int n = 0; n < list2.Count; n++)
                    {
                        number = number + list2[n].ToString().Split(new char[] { '|' })[0] + "\n";
                        num3 = 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x69, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSD_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0x65, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSD_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
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

        private Ticket[] ToElectronicTicket_HPSD_ZJ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                            num3 += 3.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x67, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSD_ZJ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 3.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x68, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
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
            if (((PlayType == 0xf3d) || (PlayType == 0xf3e)) || ((PlayType == 0xf3f) || (PlayType == 0xf40)))
            {
                return this.ToSingle_0(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0xf41) && (PlayType != 0xf42))
            {
                return null;
            }
            return this.ToSingle_12X2(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_0(string Number, ref string CanonicalNumber)
        {
            string[] strArray = Number.Split(new char[] { '+' });
            CanonicalNumber = "";
            if (strArray.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray2 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ' ' }), 0x23);
            string[] strArray3 = this.FilterRepeated(strArray[1].Trim().Split(new char[] { ' ' }), 12);
            if ((strArray2.Length < 5) || (strArray3.Length < 2))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray2.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray2[i] + " ";
            }
            CanonicalNumber = CanonicalNumber + "+ ";
            for (int j = 0; j < strArray3.Length; j++)
            {
                CanonicalNumber = CanonicalNumber + strArray3[j] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray2.Length;
            int num4 = strArray3.Length;
            for (int k = 0; k < (length - 4); k++)
            {
                for (int n = k + 1; n < (length - 3); n++)
                {
                    for (int num7 = n + 1; num7 < (length - 2); num7++)
                    {
                        for (int num8 = num7 + 1; num8 < (length - 1); num8++)
                        {
                            for (int num9 = num8 + 1; num9 < length; num9++)
                            {
                                for (int num10 = 0; num10 < (num4 - 1); num10++)
                                {
                                    for (int num11 = num10 + 1; num11 < num4; num11++)
                                    {
                                        list.Add(strArray2[k] + " " + strArray2[n] + " " + strArray2[num7] + " " + strArray2[num8] + " " + strArray2[num9] + " + " + strArray3[num10] + " " + strArray3[num11]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray4 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray4[m] = list[m].ToString();
            }
            return strArray4;
        }

        private string[] ToSingle_12X2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }), 12);
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
    }
}
