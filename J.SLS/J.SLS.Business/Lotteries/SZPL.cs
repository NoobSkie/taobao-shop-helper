using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SZPL : LotteryBase
    {
        public const string Code = "SZPL";
        public const int ID = 4;
        public const double MaxMoney = 20000.0;
        public const string Name = "数字排列";
        public const int PlayType_3_ZhiD = 0x191;
        public const int PlayType_3_ZhiF = 0x192;
        public const int PlayType_3_ZhiH = 0x196;
        public const int PlayType_3_Zu3F = 0x195;
        public const int PlayType_3_Zu6F = 0x194;
        public const int PlayType_3_ZuD = 0x193;
        public const int PlayType_3_ZuH = 0x197;
        public const int PlayType_5_D = 0x198;
        public const int PlayType_5_F = 0x199;
        public const string sID = "4";

        public SZPL()
        {
            base.id = 4;
            base.name = "数字排列";
            base.code = "SZPL";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x191) || (PlayType == 0x192))
            {
                return this.AnalyseScheme_3(Content, PlayType);
            }
            if ((PlayType == 0x193) || (PlayType == 0x194))
            {
                return this.AnalyseScheme_Zu3D_Zu6(Content, PlayType);
            }
            if (PlayType == 0x195)
            {
                return this.AnalyseScheme_Zu3F(Content, PlayType);
            }
            if (PlayType == 0x196)
            {
                return this.AnalyseScheme_ZhiH(Content, PlayType);
            }
            if (PlayType == 0x197)
            {
                return this.AnalyseScheme_ZuH(Content, PlayType);
            }
            if ((PlayType != 0x198) && (PlayType != 0x199))
            {
                return "";
            }
            return this.AnalyseScheme_5(Content, PlayType);
        }

        private string AnalyseScheme_3(string Content, int PlayType)
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
            if (PlayType == 0x191)
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
                    string[] strArray2 = this.ToSingle_3(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x191) ? 1 : 2)))
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

        private string AnalyseScheme_5(string Content, int PlayType)
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
            if (PlayType == 0x198)
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
                    string[] strArray2 = this.ToSingle_5(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x198) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            if (PlayType == 0x193)
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
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x193) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x194)
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

        public override bool AnalyseWinNumber(string Number)
        {
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_5(Number, ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num, int Type)
        {
            if ((Type != 3) && (Type != 5))
            {
                Type = 5;
            }
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < Type; j++)
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
            return ((play_type >= 0x191) && (play_type <= 0x199));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 8))
            {
                return -3.0;
            }
            if ((PlayType == 0x191) || (PlayType == 0x192))
            {
                return this.ComputeWin_3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if ((PlayType == 0x193) || (PlayType == 0x194))
            {
                return this.ComputeWin_Zu3D_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x195)
            {
                return this.ComputeWin_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x196)
            {
                return this.ComputeWin_ZhiH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x197)
            {
                return this.ComputeWin_ZuH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if ((PlayType != 0x198) && (PlayType != 0x199))
            {
                return -4.0;
            }
            return this.ComputeWin_5(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7]);
        }

        private double ComputeWin_3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_3(strArray[i], ref canonicalNumber);
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

        private double ComputeWin_5(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
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
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_5(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 5) && (strArray2[j] == WinNumber))
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
                Description = "排列5直选奖" + num.ToString() + "注。";
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

        private double ComputeWin_ZuH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
                string[] strArray2 = this.ToSingle_ZuH(strArray[i], ref canonicalNumber);
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
            return new PlayType[] { new PlayType(0x191, "排列3直选单式"), new PlayType(0x192, "排列3直选复式"), new PlayType(0x193, "排列3组选单式"), new PlayType(0x194, "排列3组选6复式"), new PlayType(0x195, "排列3组选3复式"), new PlayType(0x196, "排列3直选和值"), new PlayType(0x197, "排列3组选和值"), new PlayType(0x198, "排列5单式"), new PlayType(0x199, "排列5复式") };
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
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_CR_YTCII2_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);

                    case "TCBJYTD":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_TCBJYTD_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_TCBJYTD_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TCBJYTD_5_F(numbers);
                        }
                        return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);

                    case "TGAMPOS4000":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_5_F(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);

                    case "CP86":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_CP86_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_CP86_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CP86_ZhiD(numbers);

                    case "MODEL_4000":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_MODEL_4000_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_MODEL_4000_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_5_F(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);

                    case "CORONISTPT":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_CORONISTPT_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_CORONISTPT_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_RS6500_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_RS6500_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_5_F(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_ZhiD(numbers);

                    case "ks230":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_ks230_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_ks230_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if (PlayTypeID != 0x199)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_5_F(numbers);
                        }
                        return this.GetPrintKeyList_ks230_ZhiD(numbers);

                    case "LA-600A":
                        if (PlayTypeID != 0x191)
                        {
                            if (PlayTypeID == 0x192)
                            {
                                return this.GetPrintKeyList_LA_600A_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x193)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x195)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x194)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x196) || (PlayTypeID == 0x197))
                            {
                                return this.GetPrintKeyList_LA_600A_H(numbers);
                            }
                            if (PlayTypeID == 0x198)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x199)
                            {
                                return this.GetPrintKeyList_LA_600A_5_F(numbers);
                            }
                            break;
                        }
                        return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                }
            }
            return "";
        }

        private string GetPrintKeyList_CORONISTPT_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_CORONISTPT_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CORONISTPT_H(string[] Numbers)
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

        private string GetPrintKeyList_CORONISTPT_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_CP86_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CP86_H(string[] Numbers)
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

        private string GetPrintKeyList_CP86_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_CP86_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_CR_YTCII2_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_CR_YTCII2_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_CR_YTCII2_H(string[] Numbers)
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

        private string GetPrintKeyList_CR_YTCII2_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_ks230_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_ks230_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_ks230_H(string[] Numbers)
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

        private string GetPrintKeyList_ks230_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_LA_600A_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_LA_600A_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_LA_600A_H(string[] Numbers)
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

        private string GetPrintKeyList_LA_600A_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_MODEL_4000_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_MODEL_4000_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_MODEL_4000_H(string[] Numbers)
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

        private string GetPrintKeyList_MODEL_4000_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_RS6500_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_RS6500_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_H(string[] Numbers)
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

        private string GetPrintKeyList_RS6500_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_TCBJYTD_3_ZhiF(string[] Numbers)
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
                        str = str + "[→]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TCBJYTD_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[→]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TCBJYTD_H(string[] Numbers)
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

        private string GetPrintKeyList_TCBJYTD_ZhiD(string[] Numbers)
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

        private string GetPrintKeyList_TGAMPOS4000_3_ZhiF(string[] Numbers)
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

        private string GetPrintKeyList_TGAMPOS4000_5_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 5; i++)
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
                    if (i < 4)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TGAMPOS4000_H(string[] Numbers)
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

        private string GetPrintKeyList_TGAMPOS4000_ZhiD(string[] Numbers)
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

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if ((PlayType == 0x191) || (PlayType == 0x192))
            {
                return this.ToSingle_3(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x193) || (PlayType == 0x194))
            {
                return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x195)
            {
                return this.ToSingle_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x196)
            {
                return this.ToSingle_ZhiH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x197)
            {
                return this.ToSingle_ZuH(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x198) && (PlayType != 0x199))
            {
                return null;
            }
            return this.ToSingle_5(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_13(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))[-](?<L1>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
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
                if (i == 0)
                {
                    CanonicalNumber = CanonicalNumber + "-";
                }
            }
            ArrayList list = new ArrayList();
            for (int j = 0; j < strArray[0].Length; j++)
            {
                string str = strArray[0][j].ToString();
                for (int m = 0; m < strArray[1].Length; m++)
                {
                    string str2 = str + "-" + strArray[1][m].ToString();
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

        private string[] ToSingle_3(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_3_ZhiDanT(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[2];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d){1,2})[,](?<L1>(\d){1,9})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (strArray[i].Length > 0)
                {
                    CanonicalNumber = CanonicalNumber + strArray[i] + ",";
                }
                strArray[i] = this.FilterRepeated(strArray[i]);
            }
            if ((strArray[0].Length + strArray[1].Length) < 4)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            char[] chArray = strArray[1].ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            if (strArray[0].Length == 1)
            {
                for (int m = 0; m < (length - 1); m++)
                {
                    for (int n = m + 1; n < length; n++)
                    {
                        list.Add(strArray[0] + chArray[m].ToString() + chArray[n].ToString());
                    }
                }
            }
            else
            {
                for (int num5 = 0; num5 < length; num5++)
                {
                    list.Add(strArray[0] + chArray[num5]);
                }
            }
            ArrayList list2 = new ArrayList();
            for (int j = 0; j < 3; j++)
            {
                for (int num7 = 0; num7 < 3; num7++)
                {
                    for (int num8 = 0; num8 < 3; num8++)
                    {
                        for (int num9 = 0; num9 < list.Count; num9++)
                        {
                            if (((j != num7) && (num7 != num8)) && (num8 != j))
                            {
                                char[] chArray2 = list[num9].ToString().ToCharArray();
                                list2.Add(chArray2[j].ToString() + chArray2[num7].ToString() + chArray2[num8].ToString());
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list2.Count];
            for (int k = 0; k < list2.Count; k++)
            {
                strArray2[k] = list2[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_3_Zu3DanT(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"(\d){1,10}", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (!match.Success)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < match.Value.Length; k++)
                {
                    if (i != int.Parse(match.Value.Substring(k, 1)))
                    {
                        list.Add(i.ToString() + i.ToString() + match.Value.Substring(k, 1));
                        list.Add(i.ToString() + match.Value.Substring(k, 1) + match.Value.Substring(k, 1));
                    }
                }
            }
            CanonicalNumber = match.Value;
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_3_Zu6DanT(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"(\d){1,10}", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (!match.Success)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < 9; i++)
            {
                for (int k = i + 1; k < 10; k++)
                {
                    for (int m = 0; m < match.Value.Length; m++)
                    {
                        if ((i != int.Parse(match.Value.Substring(m, 1))) && (k != int.Parse(match.Value.Substring(m, 1))))
                        {
                            list.Add(i.ToString() + k.ToString() + match.Value.Substring(m, 1));
                        }
                    }
                }
            }
            CanonicalNumber = match.Value;
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_5(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_BuDWD(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"((\d){1,10})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (match.Success)
            {
                CanonicalNumber = this.FilterRepeated(match.Value);
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < CanonicalNumber.Length; i++)
            {
                list.Add(CanonicalNumber.Substring(i, 1));
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_DWD(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[3];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>((\d){1,10})|[-])[,](?<L1>((\d){1,10})|[-])[,](?<L2>((\d){1,10})|[-])", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                strArray[i] = this.FilterRepeated(strArray[i]);
                CanonicalNumber = CanonicalNumber + strArray[i] + ",";
            }
            CanonicalNumber = CanonicalNumber.Substring(0, CanonicalNumber.Length - 1);
            if (CanonicalNumber == "-,-,-")
            {
                CanonicalNumber = "";
            }
            ArrayList list = new ArrayList();
            for (int j = 0; j < 3; j++)
            {
                if (strArray[j].Length > 1)
                {
                    if (j == 0)
                    {
                        for (int m = 0; m < strArray[0].Length; m++)
                        {
                            list.Add(strArray[j].Substring(m, 1) + ",-,-");
                        }
                    }
                    if (j == 1)
                    {
                        for (int n = 0; n < strArray[1].Length; n++)
                        {
                            list.Add("-," + strArray[j].Substring(n, 1) + ",-");
                        }
                    }
                    if (j == 2)
                    {
                        for (int num5 = 0; num5 < strArray[2].Length; num5++)
                        {
                            list.Add("-,-," + strArray[j].Substring(num5, 1));
                        }
                    }
                }
                else if (strArray[j] != "-")
                {
                    switch (j)
                    {
                        case 0:
                            list.Add(strArray[0] + ",-,-");
                            break;

                        case 1:
                            list.Add("-," + strArray[1] + ",-");
                            break;

                        case 2:
                            list.Add("-,-," + strArray[2]);
                            goto Label_01EC;
                    }
                Label_01EC: ;
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray2[k] = list[k].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_DX_1WDW(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>([大小单双])|(-))(?<L1>([大小单双])|(-))(?<L2>([大小单双])|(-))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
            {
                string str = match.Groups["L" + i.ToString()].ToString().Trim();
                if (str == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                CanonicalNumber = CanonicalNumber + str;
            }
            if (CanonicalNumber.Replace("-", "").Length != 1)
            {
                CanonicalNumber = "";
                return null;
            }
            return new string[] { CanonicalNumber };
        }

        private string[] ToSingle_DX_H3WDW(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex("(?<L0>([大小单双]))(?<L1>([大小单双]))(?<L2>([大小单双]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
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

        private string[] ToSingle_ZhiKD(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"((\d){1})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (match.Success)
            {
                CanonicalNumber = match.Value;
            }
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
                for (int num4 = 0; num4 < 3; num4++)
                {
                    for (int num5 = 0; num5 < 3; num5++)
                    {
                        for (int num6 = 0; num6 < list.Count; num6++)
                        {
                            if (((j != num4) && (num4 != num5)) && (num5 != j))
                            {
                                char[] chArray = list[num6].ToString().ToCharArray();
                                list2.Add(chArray[j].ToString() + chArray[num4].ToString() + chArray[num5].ToString());
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

        private string[] ToSingle_Zu3KD(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"((\d){1})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (match.Success)
            {
                CanonicalNumber = match.Value;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                list.Add(i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
                list.Add(i.ToString() + i.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu6KD(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = "";
            Match match = new Regex(@"((\d){1})", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            if (match.Success)
            {
                CanonicalNumber = match.Value;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < (10 - int.Parse(CanonicalNumber)); i++)
            {
                for (int k = i + 1; k < (int.Parse(CanonicalNumber) + i); k++)
                {
                    list.Add(i.ToString() + k.ToString() + ((int.Parse(CanonicalNumber) + i)).ToString());
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
