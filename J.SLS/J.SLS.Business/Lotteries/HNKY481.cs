using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class HNKY481 : LotteryBase
    {
        public const string Code = "HNKY481";
        public const int ID = 0x44;
        public const double MaxMoney = 20000.0;
        public const string Name = "快赢481";
        public const int PlayType_RX1 = 0x1a91;
        public const int PlayType_RX2 = 0x1a92;
        public const int PlayType_RX3 = 0x1a93;
        public const int PlayType_X4ZX12 = 0x1a98;
        public const int PlayType_X4ZX12_F = 0x1a99;
        public const int PlayType_X4ZX24 = 0x1a96;
        public const int PlayType_X4ZX24_F = 0x1a97;
        public const int PlayType_X4ZX4 = 0x1a9c;
        public const int PlayType_X4ZX4_F = 0x1a9d;
        public const int PlayType_X4ZX6 = 0x1a9a;
        public const int PlayType_X4ZX6_F = 0x1a9b;
        public const int PlayType_X4ZXD = 0x1a94;
        public const int PlayType_X4ZXF = 0x1a95;
        public const string sID = "68";

        public HNKY481()
        {
            base.id = 0x44;
            base.name = "快赢481";
            base.code = "HNKY481";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if (PlayType == 0x1a91)
            {
                return this.AnalyseScheme_RX1(Content, PlayType);
            }
            if (PlayType == 0x1a92)
            {
                return this.AnalyseScheme_RX2(Content, PlayType);
            }
            if (PlayType == 0x1a93)
            {
                return this.AnalyseScheme_RX3(Content, PlayType);
            }
            if ((PlayType == 0x1a94) || (PlayType == 0x1a95))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if (((PlayType == 0x1a96) || (PlayType == 0x1a98)) || ((PlayType == 0x1a9a) || (PlayType == 0x1a9c)))
            {
                return this.AnalyseScheme_Zu(Content, PlayType);
            }
            if (((PlayType != 0x1a97) && (PlayType != 0x1a99)) && ((PlayType != 0x1a9b) && (PlayType != 0x1a9d)))
            {
                return "";
            }
            return this.AnalyseScheme_ZuF(Content, PlayType);
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
            string pattern = @"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = strArray[i];
                    string[] strArray2 = this.ToSingle_RX1(match.Value, ref canonicalNumber);
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
            string pattern = @"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = strArray[i];
                    string[] strArray2 = this.ToSingle_RX2(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        object obj2 = str;
                        str = string.Concat(new object[] { obj2, canonicalNumber, "|", strArray2.Length, "\n" });
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
            string pattern = @"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = strArray[i];
                    string[] strArray2 = this.ToSingle_RX3(match.Value, ref canonicalNumber);
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
            if (PlayType == 0x1a94)
            {
                str2 = @"([\d]){4}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,8}[)])){4}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zhi(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1a94) ? 1 : 2)))
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

        private string AnalyseScheme_Zu(string Content, int PlayType)
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
            string pattern = @"(([\d])|([(][\d]{1,8}[)])){4}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = strArray[i];
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
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

        private string AnalyseScheme_ZuF(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
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
                for (int j = 0; j < 4; j++)
                {
                    str = str + random.Next(1, 8).ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x1a91) && (play_type <= 0x1a9d));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            Description = "";
            WinMoneyNoWithTax = 0.0;
            if ((WinMoneyList == null) || (WinMoneyList.Length < 0x10))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (PlayType == 0x1a91)
            {
                return this.ComputeWin_RX1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], ref num);
            }
            if (PlayType == 0x1a92)
            {
                return this.ComputeWin_RX2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], ref num2);
            }
            if (PlayType == 0x1a93)
            {
                return this.ComputeWin_RX3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5], ref num3);
            }
            if ((PlayType == 0x1a94) || (PlayType == 0x1a95))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7]);
            }
            if ((((PlayType != 0x1a96) && (PlayType != 0x1a98)) && ((PlayType != 0x1a9a) && (PlayType != 0x1a9c))) && (((PlayType != 0x1a97) && (PlayType != 0x1a99)) && ((PlayType != 0x1a9b) && (PlayType != 0x1a9d))))
            {
                return -4.0;
            }
            return this.ComputeWin_Zu(PlayType, Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], WinMoneyList[14], WinMoneyList[15]);
        }

        private double ComputeWin_RX1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int WinCountRX1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
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
            WinCountRX1 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX1(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (WinNumber.Substring(k, 1) == strArray2[j].Substring(k, 1))
                            {
                                WinCountRX1++;
                                num += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                        }
                    }
                }
            }
            if (WinCountRX1 > 0)
            {
                Description = "任选一奖" + ((int)WinCountRX1).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney2, double WinMoneyNoWithTax2, ref int WinCountRX2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
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
            WinCountRX2 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX2(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        num2 = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            if (WinNumber.Substring(k, 1) == strArray2[j].Substring(k, 1))
                            {
                                num2++;
                            }
                        }
                        if (num2 == 2)
                        {
                            WinCountRX2++;
                            num += WinMoney2;
                            WinMoneyNoWithTax += WinMoneyNoWithTax2;
                        }
                    }
                }
            }
            if (WinCountRX2 > 0)
            {
                Description = "任选二奖" + ((int)WinCountRX2).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_RX3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney3, double WinMoneyNoWithTax3, ref int WinCountRX3)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
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
            WinCountRX3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_RX3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        num2 = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            if (WinNumber.Substring(k, 1) == strArray2[j].Substring(k, 1))
                            {
                                num2++;
                            }
                        }
                        if (num2 == 3)
                        {
                            WinCountRX3++;
                            num += WinMoney3;
                            WinMoneyNoWithTax += WinMoneyNoWithTax3;
                        }
                    }
                }
            }
            if (WinCountRX3 > 0)
            {
                Description = "任选三奖" + ((int)WinCountRX3).ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
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
                        if ((strArray2[j].Length >= 4) && (strArray2[j] == WinNumber))
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

        private double ComputeWin_Zu(int PlayType, string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 4);
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
            int num3 = 0;
            int num4 = 0;
            double num5 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_Zu(strArray[i], ref canonicalNumber, PlayType);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (((base.Sort(strArray2[j]) == base.Sort(WinNumber)) || base.Sort(strArray2[j]).Equals(base.Sort(WinNumber))) && (strArray2[j].Length >= 4))
                        {
                            if (this.FilterRepeated(strArray2[j]).Length == 4)
                            {
                                num4++;
                                num5 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            if (this.FilterRepeated(strArray2[j]).Length == 3)
                            {
                                num3++;
                                num5 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                            if ((this.FilterRepeated(strArray2[j]).Length == 2) && (base.Sort(strArray2[j]).Substring(1, 1) != base.Sort(strArray2[j]).Substring(2, 1)))
                            {
                                num2++;
                                num5 += WinMoney3;
                                WinMoneyNoWithTax += WinMoneyNoWithTax3;
                            }
                            if ((this.FilterRepeated(base.Sort(strArray2[j])).Length == 2) && (base.Sort(strArray2[j]).Substring(1, 1) == base.Sort(strArray2[j]).Substring(2, 1)))
                            {
                                num++;
                                num5 += WinMoney4;
                                WinMoneyNoWithTax += WinMoneyNoWithTax4;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选4奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            if (num3 > 0)
            {
                Description = "组选12奖" + num3.ToString() + "注。";
            }
            if (num4 > 0)
            {
                Description = "组选24奖" + num4.ToString() + "注。";
            }
            return num5;
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
                strArray[j] = al[j].ToString();
            }
            return strArray;
        }

        private int getCount(ArrayList list, string value)
        {
            int num = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToString() == value)
                {
                    num++;
                }
            }
            return num;
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x1a91, "任选一"), new PlayType(0x1a92, "任选二"), new PlayType(0x1a93, "任选三"), new PlayType(0x1a94, "直选单式"), new PlayType(0x1a95, "直选复式"), new PlayType(0x1a96, "组选24单式"), new PlayType(0x1a97, "组选24复式"), new PlayType(0x1a98, "组选12单式"), new PlayType(0x1a99, "组选12复式"), new PlayType(0x1a9a, "组选6单式"), new PlayType(0x1a9b, "组选6复式"), new PlayType(0x1a9c, "组选4单式"), new PlayType(0x1a9d, "组选4复式") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0x1a91)
            {
                return this.ToSingle_RX1(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a92)
            {
                return this.ToSingle_RX2(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a93)
            {
                return this.ToSingle_RX3(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x1a94) || (PlayType == 0x1a95))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a96)
            {
                return this.ToSingle_Zu24(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a98)
            {
                return this.ToSingle_Zu12(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9a)
            {
                return this.ToSingle_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9c)
            {
                return this.ToSingle_Zu4(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a97)
            {
                return this.ToSingle_Zu24_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a99)
            {
                return this.ToSingle_Zu12_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9b)
            {
                return this.ToSingle_Zu6_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9d)
            {
                return this.ToSingle_Zu4_F(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_RX1(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                char ch2 = strArray[0][j];
                if (_Convert.StrToInt(ch2.ToString(), 0) > 0)
                {
                    list.Add(str + "___");
                }
            }
            for (int k = 0; k < strArray[1].Length; k++)
            {
                string str2 = strArray[1][k].ToString();
                char ch4 = strArray[1][k];
                if (_Convert.StrToInt(ch4.ToString(), 0) > 0)
                {
                    list.Add("_" + str2 + "__");
                }
            }
            for (int m = 0; m < strArray[2].Length; m++)
            {
                string str3 = strArray[2][m].ToString();
                char ch6 = strArray[2][m];
                if (_Convert.StrToInt(ch6.ToString(), 0) > 0)
                {
                    list.Add("__" + str3 + "_");
                }
            }
            for (int n = 0; n < strArray[3].Length; n++)
            {
                string str4 = strArray[3][n].ToString();
                char ch8 = strArray[3][n];
                if (_Convert.StrToInt(ch8.ToString(), 0) > 0)
                {
                    list.Add("___" + str4);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int num6 = 0; num6 < list.Count; num6++)
            {
                strArray2[num6] = list[num6].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX2(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                string str = strArray[0].Substring(j, 1);
                if (str != "_")
                {
                    for (int num3 = 0; num3 < strArray[1].Length; num3++)
                    {
                        string str2 = strArray[1].Substring(num3, 1);
                        if (str2 != "_")
                        {
                            list.Add(str + str2 + "__");
                        }
                    }
                }
            }
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str3 = strArray[0].Substring(k, 1);
                if (str3 != "_")
                {
                    for (int num5 = 0; num5 < strArray[2].Length; num5++)
                    {
                        string str4 = strArray[2].Substring(num5, 1);
                        if (str4 != "_")
                        {
                            list.Add(str3 + "_" + str4 + "_");
                        }
                    }
                }
            }
            for (int m = 0; m < strArray[0].Length; m++)
            {
                string str5 = strArray[0].Substring(m, 1);
                if (str5 != "_")
                {
                    for (int num7 = 0; num7 < strArray[3].Length; num7++)
                    {
                        string str6 = strArray[3].Substring(num7, 1);
                        if (str6 != "_")
                        {
                            list.Add(str5 + "__" + str6);
                        }
                    }
                }
            }
            for (int n = 0; n < strArray[1].Length; n++)
            {
                string str7 = strArray[1].Substring(n, 1);
                if (str7 != "_")
                {
                    for (int num9 = 0; num9 < strArray[2].Length; num9++)
                    {
                        string str8 = strArray[2].Substring(num9, 1);
                        if (str8 != "_")
                        {
                            list.Add("_" + str7 + str8 + "_");
                        }
                    }
                }
            }
            for (int num10 = 0; num10 < strArray[1].Length; num10++)
            {
                string str9 = strArray[1].Substring(num10, 1);
                if (str9 != "_")
                {
                    for (int num11 = 0; num11 < strArray[3].Length; num11++)
                    {
                        string str10 = strArray[3].Substring(num11, 1);
                        if (str10 != "_")
                        {
                            list.Add("_" + str9 + "_" + str10);
                        }
                    }
                }
            }
            for (int num12 = 0; num12 < strArray[2].Length; num12++)
            {
                string str11 = strArray[2].Substring(num12, 1);
                if (str11 != "_")
                {
                    for (int num13 = 0; num13 < strArray[3].Length; num13++)
                    {
                        string str12 = strArray[3].Substring(num13, 1);
                        if (str12 != "_")
                        {
                            list.Add("__" + str11 + str12);
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int num14 = 0; num14 < list.Count; num14++)
            {
                strArray2[num14] = list[num14].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_RX3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|(_)|([(][\d]+?[)]))(?<L1>(\d)|(_)|([(][\d]+?[)]))(?<L2>(\d)|(_)|([(][\d]+?[)]))(?<L3>(\d)|(_)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                string str = strArray[0].Substring(j, 1);
                if (str != "_")
                {
                    for (int num3 = 0; num3 < strArray[1].Length; num3++)
                    {
                        string str2 = strArray[1].Substring(num3, 1);
                        if (str2 != "_")
                        {
                            for (int num4 = 0; num4 < strArray[2].Length; num4++)
                            {
                                string str3 = strArray[2].Substring(num4, 1);
                                if (str3 != "_")
                                {
                                    list.Add(str + str2 + str3 + "_");
                                }
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < strArray[0].Length; k++)
            {
                string str4 = strArray[0].Substring(k, 1);
                if (str4 != "_")
                {
                    for (int num6 = 0; num6 < strArray[1].Length; num6++)
                    {
                        string str5 = strArray[1].Substring(num6, 1);
                        if (str5 != "_")
                        {
                            for (int num7 = 0; num7 < strArray[3].Length; num7++)
                            {
                                string str6 = strArray[3].Substring(num7, 1);
                                if (str6 != "_")
                                {
                                    list.Add(str4 + str5 + "_" + str6);
                                }
                            }
                        }
                    }
                }
            }
            for (int m = 0; m < strArray[0].Length; m++)
            {
                string str7 = strArray[0].Substring(m, 1);
                if (str7 != "_")
                {
                    for (int num9 = 0; num9 < strArray[2].Length; num9++)
                    {
                        string str8 = strArray[2].Substring(num9, 1);
                        if (str8 != "_")
                        {
                            for (int num10 = 0; num10 < strArray[3].Length; num10++)
                            {
                                string str9 = strArray[3].Substring(num10, 1);
                                if (str9 != "_")
                                {
                                    list.Add(str7 + "_" + str8 + str9);
                                }
                            }
                        }
                    }
                }
            }
            for (int n = 0; n < strArray[1].Length; n++)
            {
                string str10 = strArray[1].Substring(n, 1);
                if (str10 != "_")
                {
                    for (int num12 = 0; num12 < strArray[2].Length; num12++)
                    {
                        string str11 = strArray[2].Substring(num12, 1);
                        if (str11 != "_")
                        {
                            for (int num13 = 0; num13 < strArray[3].Length; num13++)
                            {
                                string str12 = strArray[3].Substring(num13, 1);
                                if (str12 != "_")
                                {
                                    list.Add("_" + str10 + str11 + str12);
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int num14 = 0; num14 < list.Count; num14++)
            {
                strArray2[num14] = list[num14].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                            list.Add(str4);
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

        private string[] ToSingle_Zu(string Number, ref string CanonicalNumber, int PlayType)
        {
            if (PlayType == 0x1a96)
            {
                return this.ToSingle_Zu24(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a98)
            {
                return this.ToSingle_Zu12(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9a)
            {
                return this.ToSingle_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9c)
            {
                return this.ToSingle_Zu4(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a97)
            {
                return this.ToSingle_Zu24_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a99)
            {
                return this.ToSingle_Zu12_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9b)
            {
                return this.ToSingle_Zu6_F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1a9d)
            {
                return this.ToSingle_Zu4_F(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_Zu12(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + strArray[1][n].ToString();
                    for (int num4 = 0; num4 < strArray[2].Length; num4++)
                    {
                        string str3 = str2 + strArray[2][num4].ToString();
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string numberPart = str3 + strArray[3][num5].ToString();
                            if ((numberPart.Length >= 4) && (this.FilterRepeated(numberPart).Length == 3))
                            {
                                list.Add(numberPart);
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < list.Count; k++)
            {
                if (this.FilterRepeated(base.Sort(list[k].ToString())).Length == 1)
                {
                    list.Remove(list[k]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu12_F(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 3)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < (length - 2); i++)
            {
                for (int k = i + 1; k < (length - 1); k++)
                {
                    for (int m = k + 1; m < length; m++)
                    {
                        list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString() + chArray[m].ToString());
                        list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString() + chArray[m].ToString());
                        list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString());
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

        private string[] ToSingle_Zu24(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + strArray[1][n].ToString();
                    for (int num4 = 0; num4 < strArray[2].Length; num4++)
                    {
                        string str3 = str2 + strArray[2][num4].ToString();
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string numberPart = str3 + strArray[3][num5].ToString();
                            if ((numberPart.Length >= 4) && (this.FilterRepeated(numberPart).Length == 4))
                            {
                                list.Add(numberPart);
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < list.Count; k++)
            {
                if (this.FilterRepeated(base.Sort(list[k].ToString())).Length == 1)
                {
                    list.Remove(list[k]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu24_F(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 5)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            for (int i = 0; i < (length - 3); i++)
            {
                for (int k = i + 1; k < (length - 2); k++)
                {
                    for (int m = k + 1; m < (length - 1); m++)
                    {
                        for (int n = m + 1; n < length; n++)
                        {
                            list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[m].ToString() + chArray[n].ToString());
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

        private string[] ToSingle_Zu4(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + strArray[1][n].ToString();
                    for (int num4 = 0; num4 < strArray[2].Length; num4++)
                    {
                        string str3 = str2 + strArray[2][num4].ToString();
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string str4 = str3 + strArray[3][num5].ToString();
                            if (((str4.Length >= 4) && (this.FilterRepeated(base.Sort(str4)).Length == 2)) && (base.Sort(str4).Substring(1, 1) == base.Sort(str4).Substring(2, 1)))
                            {
                                list.Add(str4);
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < list.Count; k++)
            {
                if (this.FilterRepeated(base.Sort(list[k].ToString())).Length == 1)
                {
                    list.Remove(list[k]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu4_F(string Number, ref string CanonicalNumber)
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
                    list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString());
                    list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString() + chArray[k].ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu6(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[4];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 4; i++)
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
                for (int n = 0; n < strArray[1].Length; n++)
                {
                    string str2 = str + strArray[1][n].ToString();
                    for (int num4 = 0; num4 < strArray[2].Length; num4++)
                    {
                        string str3 = str2 + strArray[2][num4].ToString();
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string numberPart = str3 + strArray[3][num5].ToString();
                            if (((numberPart.Length >= 4) && (this.FilterRepeated(numberPart).Length == 2)) && (base.Sort(numberPart).Substring(1, 1) != base.Sort(numberPart).Substring(2, 1)))
                            {
                                list.Add(numberPart);
                            }
                        }
                    }
                }
            }
            for (int k = 0; k < list.Count; k++)
            {
                if (this.FilterRepeated(base.Sort(list[k].ToString())).Length == 1)
                {
                    list.Remove(list[k]);
                }
            }
            string[] strArray2 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray2[m] = list[m].ToString();
            }
            return strArray2;
        }

        private string[] ToSingle_Zu6_F(string Number, ref string CanonicalNumber)
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
            for (int i = 0; i < (length - 1); i++)
            {
                for (int k = i + 1; k < length; k++)
                {
                    list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString());
                }
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
