using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SSQ : LotteryBase
    {
        public const string Code = "SSQ";
        public const int ID = 5;
        public const double MaxMoney = 1240320.0;
        public const string Name = "双色球";
        public const int PlayType_D = 0x1f5;
        public const int PlayType_DanT = 0x1f7;
        public const int PlayType_F = 0x1f6;
        public const string sID = "5";

        public SSQ()
        {
            base.id = 5;
            base.name = "双色球";
            base.code = "SSQ";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x1f5) || (PlayType == 0x1f6))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if (PlayType == 0x1f7)
            {
                return this.AnalyseScheme_DanT(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_DanT(string Content, int PlayType)
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
            string pattern = @"(\d\d\s){1,5}[,](\s)(\d\d\s){2,31}[+](\s\d\d){1,16}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_DanT(match.Value, ref canonicalNumber);
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
            if (PlayType == 0x1f5)
            {
                str2 = @"(\d\d\s){6}[+]\s\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){6,20}[+](\s\d\d){1,16}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1f5) ? 1 : 2))) && (strArray2.Length <= 620160.0))
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

        private string AnalyseSchemeToElectronicTicket_DT(string Content, int PlayType)
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
            string pattern = @"(\d\d\s){1,5}[,](\s)(\d\d\s){2,31}[+](\s\d\d){1,16}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_DanT(match.Value, ref canonicalNumber);
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
            Regex regex = new Regex(@"(\d\d\s){6}[+](\s\d\d){1,4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x1f5);
            return (((strArray != null) && (strArray.Length >= 1)) && (strArray.Length <= 4));
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
                        ball = random.Next(1, 0x22);
                    }
                    al.Add(ball.ToString().PadLeft(2, '0'));
                }
                for (int k = 0; k < Blue; k++)
                {
                    int num5 = 0;
                    while ((num5 == 0) || base.isExistBall(list2, num5))
                    {
                        num5 = random.Next(1, 0x11);
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
                str = str + "+ ";
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
            return ((play_type >= 0x1f5) && (play_type <= 0x1f7));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 14))
            {
                return -3.0;
            }
            if ((PlayType == 0x1f5) || (PlayType == 0x1f6))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13]);
            }
            if (PlayType == 0x1f7)
            {
                return this.ComputeWin_DanT(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13]);
            }
            return -4.0;
        }

        private double ComputeWin_DanT(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7)
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
            string str2 = WinNumber.Substring(20, WinNumber.Length - 20).Trim();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            double num8 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_DanT(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 0x16)
                        {
                            string[] strArray3 = new string[6];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)[+]\s(?<B0>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num11 = 0;
                            bool flag = false;
                            bool flag2 = false;
                            bool flag3 = true;
                            for (int k = 0; k < 6; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag3 = false;
                                    break;
                                }
                                if (str.IndexOf(strArray3[k] + " ") >= 0)
                                {
                                    num11++;
                                }
                            }
                            if (flag3)
                            {
                                string str4 = match.Groups["B0"].ToString().Trim();
                                if (str4 != "")
                                {
                                    if (str4 == str2.Substring(0, 2))
                                    {
                                        flag = true;
                                    }
                                    if (str2.IndexOf(" " + str4) >= 0)
                                    {
                                        flag2 = true;
                                    }
                                    if ((num11 == 6) && flag)
                                    {
                                        num++;
                                        num8 += WinMoney1;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                    }
                                    else if (num11 == 6)
                                    {
                                        num2++;
                                        num8 += WinMoney2;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                    }
                                    else if ((num11 == 5) && flag)
                                    {
                                        num3++;
                                        num8 += WinMoney3;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax3;
                                    }
                                    else if ((num11 == 5) || ((num11 == 4) && flag))
                                    {
                                        num4++;
                                        num8 += WinMoney4;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax4;
                                        if ((num11 == 5) && flag2)
                                        {
                                            num7++;
                                            num8 += WinMoney7;
                                            WinMoneyNoWithTax += WinMoneyNoWithTax7;
                                        }
                                    }
                                    else if ((num11 == 4) || ((num11 == 3) && flag))
                                    {
                                        num5++;
                                        num8 += WinMoney5;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax5;
                                    }
                                    else if (flag)
                                    {
                                        num6++;
                                        num8 += WinMoney6;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax6;
                                    }
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
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "快乐星期天特别奖" + num7.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num8;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7)
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
            string str2 = WinNumber.Substring(20, WinNumber.Length - 20).Trim();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            double num8 = 0.0;
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
                        if (strArray2[j].Length >= 0x16)
                        {
                            string[] strArray3 = new string[6];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)[+]\s(?<B0>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num11 = 0;
                            bool flag = false;
                            bool flag2 = false;
                            bool flag3 = true;
                            for (int k = 0; k < 6; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag3 = false;
                                    break;
                                }
                                if (str.IndexOf(strArray3[k] + " ") >= 0)
                                {
                                    num11++;
                                }
                            }
                            if (flag3)
                            {
                                string str4 = match.Groups["B0"].ToString().Trim();
                                if (str4 != "")
                                {
                                    if (str4 == str2.Substring(0, 2))
                                    {
                                        flag = true;
                                    }
                                    if (str2.IndexOf(" " + str4) >= 0)
                                    {
                                        flag2 = true;
                                    }
                                    if ((num11 == 6) && flag)
                                    {
                                        num++;
                                        num8 += WinMoney1;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                    }
                                    else if (num11 == 6)
                                    {
                                        num2++;
                                        num8 += WinMoney2;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                    }
                                    else if ((num11 == 5) && flag)
                                    {
                                        num3++;
                                        num8 += WinMoney3;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax3;
                                    }
                                    else if ((num11 == 5) || ((num11 == 4) && flag))
                                    {
                                        num4++;
                                        num8 += WinMoney4;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax4;
                                        if ((num11 == 5) && flag2)
                                        {
                                            num7++;
                                            num8 += WinMoney7;
                                            WinMoneyNoWithTax += WinMoneyNoWithTax7;
                                        }
                                    }
                                    else if ((num11 == 4) || ((num11 == 3) && flag))
                                    {
                                        num5++;
                                        num8 += WinMoney5;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax5;
                                    }
                                    else if (flag)
                                    {
                                        num6++;
                                        num8 += WinMoney6;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax6;
                                    }
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
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "快乐星期天特别奖" + num7.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num8;
        }

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID != 0x1f5) && (PlayTypeID != 0x1f6))
            {
                return str;
            }
            return Number.Replace(" + ", "-");
        }

        private string ConvertFormatToElectronTicket_HPCQ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (((PlayTypeID != 0x1f5) && (PlayTypeID != 0x1f6)) && (PlayTypeID != 0x1f7))
            {
                return str;
            }
            return Number.Replace(" ", ",").Replace(",+,", "#");
        }

        private string ConvertFormatToElectronTicket_HPJX(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID != 0x1f5) && (PlayTypeID != 0x1f6))
            {
                return str;
            }
            return Number.Replace(" ", ",").Replace(",+,", "#");
        }

        private string ConvertFormatToElectronTicket_HPSH(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID != 0x1f5) && (PlayTypeID != 0x1f6))
            {
                return str;
            }
            return Number.Replace(" ", ",").Replace(",+,", "#");
        }

        private string[] FilterRepeated(string[] NumberPart1, string[] NumberPart2)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart2.Length; i++)
            {
                al.Add(NumberPart2[i]);
            }
            ArrayList list2 = new ArrayList();
            for (int j = 0; j < NumberPart1.Length; j++)
            {
                int ball = _Convert.StrToInt(NumberPart1[j], -1);
                if (!base.isExistBall(al, ball))
                {
                    list2.Add(NumberPart1[j]);
                }
            }
            LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
            list2.Sort(comparer);
            string[] strArray = new string[list2.Count];
            for (int k = 0; k < list2.Count; k++)
            {
                strArray[k] = list2[k].ToString().PadLeft(2, '0');
            }
            return strArray;
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
            return new PlayType[] { new PlayType(0x1f5, "单式"), new PlayType(0x1f6, "复式"), new PlayType(0x1f7, "胆拖") };
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
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_FCTZST2_2_F(numbers);
                        }
                        return this.GetPrintKeyList_FCTZST2_2_D(numbers);

                    case "FCR8000":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_FCR8000_F(numbers);
                        }
                        return this.GetPrintKeyList_FCR8000_D(numbers);

                    case "LT-E":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_LT_E_F(numbers);
                        }
                        return this.GetPrintKeyList_LT_E_D(numbers);

                    case "LT-E02":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_LT_E02_F(numbers);
                        }
                        return this.GetPrintKeyList_LT_E02_D(numbers);

                    case "SN-3000CQA":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_SN_3000CQA_F(numbers);
                        }
                        return this.GetPrintKeyList_SN_3000CQA_D(numbers);

                    case "SN-2000":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID != 0x1f6)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_SN_2000_F(numbers);
                        }
                        return this.GetPrintKeyList_SN_2000_D(numbers);

                    case "SN_3000CG":
                        if (PlayTypeID != 0x1f5)
                        {
                            if (PlayTypeID == 0x1f6)
                            {
                                return this.GetPrintKeyList_SN_3000CG_F(numbers);
                            }
                            break;
                        }
                        return this.GetPrintKeyList_SN_3000CG_D(numbers);
                }
            }
            return "";
        }

        private string GetPrintKeyList_FCR8000_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCR8000_F(string[] Numbers)
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
                foreach (char ch in strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str3)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCTZST2_2_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_FCTZST2_2_F(string[] Numbers)
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
                foreach (char ch in strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str3)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E_F(string[] Numbers)
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
                str = (((str + "[" + Convert.ToString((int)(str3.Length / 2)) + "]") + "[" + _Convert.Chr(0x15).ToString() + "]") + "[" + Convert.ToString((int)(str4.Length / 2)) + "]") + "[" + _Convert.Chr(0x15).ToString() + "]";
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[" + _Convert.Chr(0x15).ToString() + "]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "Q").Replace("2", "R").Replace("3", "1").Replace("4", "S").Replace("5", "T").Replace("6", "4").Replace("7", "U").Replace("8", "V").Replace("9", "7");
        }

        private string GetPrintKeyList_LT_E02_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LT_E02_F(string[] Numbers)
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
                str = (((str + "[" + Convert.ToString((int)(str3.Length / 2)) + "]") + "[" + _Convert.Chr(0x15).ToString() + "]") + "[" + Convert.ToString((int)(str4.Length / 2)) + "]") + "[" + _Convert.Chr(0x15).ToString() + "]";
                foreach (char ch in str3)
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[" + _Convert.Chr(0x15).ToString() + "]";
                foreach (char ch2 in str4)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str.Replace("0", "O").Replace("1", "3").Replace("2", "A").Replace("3", "B").Replace("4", "6").Replace("5", "C").Replace("6", "D").Replace("7", "9").Replace("8", "E").Replace("9", "F");
        }

        private string GetPrintKeyList_SN_2000_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_2000_F(string[] Numbers)
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

        private string GetPrintKeyList_SN_3000CG_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CG_F(string[] Numbers)
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
                str = str + "[ENTER]";
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CQA_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                string str3 = str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", "");
                if (str3.Length == 14)
                {
                    foreach (char ch in str3)
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_3000CQA_F(string[] Numbers)
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
                foreach (char ch in strArray[1].Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
                str = str + "[ENTER]";
                foreach (char ch2 in str3)
                {
                    str = str + "[" + ch2.ToString() + "]";
                }
            }
            return str;
        }

        private string HPSH_ConvertFormatToElectronTicket(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            return Number.Replace(",", " ").Replace("#", " + ");
        }

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override JTicket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1f5)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f6)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f7)
            {
                return this.ToElectronicTicket_DYJ_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
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
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + ";\n";
                            num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DT(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if (((k + m) < strArray.Length) && (strArray[k + m] != ""))
                        {
                            try
                            {
                                number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + ";\n";
                                num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
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
                    number = strArray[k].ToString().Split(new char[] { '|' })[0] + ";";
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override JTicket[] ToElectronicTicket_HPCQ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1f5)
            {
                return this.ToElectronicTicket_HPCQ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f6)
            {
                return this.ToElectronicTicket_HPCQ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f7)
            {
                return this.ToElectronicTicket_HPCQ_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPCQ_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    Money = num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPCQ_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DT(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    Money = num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPCQ_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    Money = num3 * multiple;
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override JTicket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1f5)
            {
                return this.ToElectronicTicket_HPJX_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f6)
            {
                return this.ToElectronicTicket_HPJX_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f7)
            {
                return this.ToElectronicTicket_HPJX_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPJX_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DT(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if (((k + m) < strArray.Length) && (strArray[k + m] != ""))
                        {
                            try
                            {
                                number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                                num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
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
            if (PlayTypeID == 0x1f5)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f6)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1f7)
            {
                return this.ToElectronicTicket_HPSH_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
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
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_DT(Number, PlayTypeID).Split(new char[] { '\n' });
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
                        if (((k + m) < strArray.Length) && (strArray[k + m] != ""))
                        {
                            try
                            {
                                number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
                                num3 += 2.0 * double.Parse(strArray[k + m].ToString().Split(new char[] { '|' })[1]);
                            }
                            catch
                            {
                            }
                        }
                    }
                    Money += num3 * multiple;
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPCQ(PlayTypeID, number), multiple, num3 * multiple));
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
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
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
            if ((PlayType == 0x1f5) || (PlayType == 0x1f6))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1f7)
            {
                return this.ToSingle_DanT(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_DanT(string Number, ref string CanonicalNumber)
        {
            string[] strArray = Number.Split(new char[] { '+' });
            CanonicalNumber = "";
            if (strArray.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray2 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ',' })[0].Trim().Split(new char[] { ' ' }), 0x21);
            string[] strArray3 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ',' })[1].Trim().Split(new char[] { ' ' }), 0x21);
            string[] strArray4 = this.FilterRepeated(strArray[1].Trim().Split(new char[] { ' ' }), 0x10);
            string[] strArray5 = this.FilterRepeated(strArray2, strArray3);
            if ((((strArray5.Length + strArray3.Length) < 7) || (strArray4.Length < 1)) || (strArray5.Length > 5))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray5.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray5[i] + " ";
            }
            CanonicalNumber = CanonicalNumber + ", ";
            for (int j = 0; j < strArray3.Length; j++)
            {
                CanonicalNumber = CanonicalNumber + strArray3[j] + " ";
            }
            CanonicalNumber = CanonicalNumber + "+ ";
            for (int k = 0; k < strArray4.Length; k++)
            {
                CanonicalNumber = CanonicalNumber + strArray4[k] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            string[] strArray6 = new string[strArray5.Length + strArray3.Length];
            string str = "";
            for (int m = 0; m < strArray5.Length; m++)
            {
                strArray6[m] = strArray5[m];
                str = str + strArray5[m] + " ";
            }
            for (int n = strArray5.Length; n < (strArray5.Length + strArray3.Length); n++)
            {
                strArray6[n] = strArray3[n - strArray5.Length];
            }
            ArrayList list = new ArrayList();
            int length = strArray5.Length;
            int num7 = strArray6.Length;
            switch (length)
            {
                case 1:
                    for (int num8 = length; num8 < (num7 - 4); num8++)
                    {
                        for (int num9 = num8 + 1; num9 < (num7 - 3); num9++)
                        {
                            for (int num10 = num9 + 1; num10 < (num7 - 2); num10++)
                            {
                                for (int num11 = num10 + 1; num11 < (num7 - 1); num11++)
                                {
                                    for (int num12 = num11 + 1; num12 < num7; num12++)
                                    {
                                        for (int num13 = 0; num13 < strArray4.Length; num13++)
                                        {
                                            list.Add(str + strArray6[num8] + " " + strArray6[num9] + " " + strArray6[num10] + " " + strArray6[num11] + " " + strArray6[num12] + " + " + strArray4[num13]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case 2:
                    for (int num14 = length; num14 < (num7 - 3); num14++)
                    {
                        for (int num15 = num14 + 1; num15 < (num7 - 2); num15++)
                        {
                            for (int num16 = num15 + 1; num16 < (num7 - 1); num16++)
                            {
                                for (int num17 = num16 + 1; num17 < num7; num17++)
                                {
                                    for (int num18 = 0; num18 < strArray4.Length; num18++)
                                    {
                                        list.Add(str + strArray6[num14] + " " + strArray6[num15] + " " + strArray6[num16] + " " + strArray6[num17] + " + " + strArray4[num18]);
                                    }
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    for (int num19 = length; num19 < (num7 - 2); num19++)
                    {
                        for (int num20 = num19 + 1; num20 < (num7 - 1); num20++)
                        {
                            for (int num21 = num20 + 1; num21 < num7; num21++)
                            {
                                for (int num22 = 0; num22 < strArray4.Length; num22++)
                                {
                                    list.Add(str + strArray6[num19] + " " + strArray6[num20] + " " + strArray6[num21] + " + " + strArray4[num22]);
                                }
                            }
                        }
                    }
                    break;

                case 4:
                    for (int num23 = length; num23 < (num7 - 1); num23++)
                    {
                        for (int num24 = num23 + 1; num24 < num7; num24++)
                        {
                            for (int num25 = 0; num25 < strArray4.Length; num25++)
                            {
                                list.Add(str + strArray6[num23] + " " + strArray6[num24] + " + " + strArray4[num25]);
                            }
                        }
                    }
                    break;

                case 5:
                    for (int num26 = length; num26 < num7; num26++)
                    {
                        for (int num27 = 0; num27 < strArray4.Length; num27++)
                        {
                            list.Add(str + strArray6[num26] + " + " + strArray4[num27]);
                        }
                    }
                    break;
            }
            string[] strArray7 = new string[list.Count];
            for (int num28 = 0; num28 < list.Count; num28++)
            {
                strArray7[num28] = list[num28].ToString();
            }
            return strArray7;
        }

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = Number.Split(new char[] { '+' });
            CanonicalNumber = "";
            if (strArray.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray2 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ' ' }), 0x21);
            string[] strArray3 = this.FilterRepeated(strArray[1].Trim().Split(new char[] { ' ' }), 0x10);
            if (((strArray2.Length < 6) || (strArray3.Length < 1)) || (strArray2.Length > 20))
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
            for (int k = 0; k < (length - 5); k++)
            {
                for (int n = k + 1; n < (length - 4); n++)
                {
                    for (int num6 = n + 1; num6 < (length - 3); num6++)
                    {
                        for (int num7 = num6 + 1; num7 < (length - 2); num7++)
                        {
                            for (int num8 = num7 + 1; num8 < (length - 1); num8++)
                            {
                                for (int num9 = num8 + 1; num9 < length; num9++)
                                {
                                    for (int num10 = 0; num10 < strArray3.Length; num10++)
                                    {
                                        list.Add(strArray2[k] + " " + strArray2[n] + " " + strArray2[num6] + " " + strArray2[num7] + " " + strArray2[num8] + " " + strArray2[num9] + " + " + strArray3[num10]);
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
    }
}
