using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class HNFC22X5 : LotteryBase
    {
        public const string Code = "HNFC22X5";
        public const int ID = 0x17;
        public const double MaxMoney = 52668.0;
        public const string Name = "湖南风采22选5";
        public const int PlayType_D = 0x8fd;
        public const int PlayType_F = 0x8fe;
        public const int PlayType_HY1_D = 0x8ff;
        public const int PlayType_HY1_F = 0x900;
        public const int PlayType_HY2_D = 0x901;
        public const int PlayType_HY2_F = 0x902;
        public const int PlayType_HY3_D = 0x903;
        public const int PlayType_HY3_F = 0x904;
        public const int PlayType_HY4_D = 0x905;
        public const int PlayType_HY4_F = 0x906;
        public const string sID = "23";

        public HNFC22X5()
        {
            base.id = 0x17;
            base.name = "湖南风采22选5";
            base.code = "HNFC22X5";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x8fd) || (PlayType == 0x8fe))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if ((PlayType == 0x8ff) || (PlayType == 0x900))
            {
                return this.AnalyseScheme_HY1(Content, PlayType);
            }
            if ((PlayType == 0x901) || (PlayType == 0x902))
            {
                return this.AnalyseScheme_HY2(Content, PlayType);
            }
            if ((PlayType == 0x903) || (PlayType == 0x904))
            {
                return this.AnalyseScheme_HY3(Content, PlayType);
            }
            if ((PlayType != 0x905) && (PlayType != 0x906))
            {
                return "";
            }
            return this.AnalyseScheme_HY4(Content, PlayType);
        }

        private string AnalyseScheme_HY1(string Content, int PlayType)
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
            if (PlayType == 0x8ff)
            {
                str2 = @"(\d\d)";
            }
            else
            {
                str2 = @"((\d\d\s){1,21}\d\d)|(\d\d)";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HY1(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x8ff) ? 1 : 2))) && (strArray2.Length <= 26334.0))
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

        private string AnalyseScheme_HY2(string Content, int PlayType)
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
            if (PlayType == 0x901)
            {
                str2 = @"(\d\d\s\d\d)";
            }
            else
            {
                str2 = @"(\d\d\s){1,25}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HY2(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x901) ? 1 : 2))) && (strArray2.Length <= 26334.0))
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

        private string AnalyseScheme_HY3(string Content, int PlayType)
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
            if (PlayType == 0x903)
            {
                str2 = @"(\d\d\s){2}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){2,25}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HY3(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x903) ? 1 : 2))) && (strArray2.Length <= 26334.0))
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

        private string AnalyseScheme_HY4(string Content, int PlayType)
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
            if (PlayType == 0x905)
            {
                str2 = @"(\d\d\s){3}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){3,21}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_HY4(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x905) ? 1 : 2))) && (strArray2.Length <= 26334.0))
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
            if (PlayType == 0x8fd)
            {
                str2 = @"(\d\d\s){4}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){4,25}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zhi(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x8fd) ? 1 : 2))) && (strArray2.Length <= 26334.0))
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
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_Zhi(Number, ref canonicalNumber);
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
                for (int j = 0; j < 5; j++)
                {
                    int ball = 0;
                    while ((ball == 0) || base.isExistBall(al, ball))
                    {
                        ball = random.Next(1, 0x17);
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
            return ((play_type >= 0x8fd) && (play_type <= 0x906));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 14))
            {
                return -3.0;
            }
            if ((PlayType == 0x8fd) || (PlayType == 0x8fe))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if ((PlayType == 0x8ff) || (PlayType == 0x900))
            {
                return this.ComputeWin_HY1(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7]);
            }
            if ((PlayType == 0x901) || (PlayType == 0x902))
            {
                return this.ComputeWin_HY2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[8], WinMoneyList[9]);
            }
            if ((PlayType == 0x903) || (PlayType == 0x904))
            {
                return this.ComputeWin_HY3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[10], WinMoneyList[11]);
            }
            if ((PlayType != 0x905) && (PlayType != 0x906))
            {
                return -4.0;
            }
            return this.ComputeWin_HY4(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[12], WinMoneyList[13]);
        }

        private double ComputeWin_HY1(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
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
            string str = WinNumber.Substring(0, 2);
            int num = 0;
            double num2 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle_HY1(strArray[i], ref canonicalNumber);
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
                Description = "好运一奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_HY2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
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
                string[] strArray2 = this.ToSingle_HY2(strArray[i], ref canonicalNumber);
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
                                if (WinNumber.IndexOf(strArray3[k]) >= 0)
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
                Description = "好运二奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_HY3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
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
                string[] strArray2 = this.ToSingle_HY3(strArray[i], ref canonicalNumber);
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
                                if (WinNumber.IndexOf(strArray3[k]) >= 0)
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
                Description = "好运三奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_HY4(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
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
                string[] strArray2 = this.ToSingle_HY4(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 11)
                        {
                            string[] strArray3 = new string[4];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num5 = 0;
                            bool flag = true;
                            for (int k = 0; k < 4; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (WinNumber.IndexOf(strArray3[k]) >= 0)
                                {
                                    num5++;
                                }
                            }
                            if (flag && (num5 == 4))
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
                Description = "好运四奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 14)
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
            int num2 = 0;
            double num3 = 0.0;
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
                        if (strArray2[j].Length >= 14)
                        {
                            string[] strArray3 = new string[5];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num7 = 0;
                            bool flag = true;
                            for (int k = 0; k < 5; k++)
                            {
                                strArray3[k] = match.Groups["R" + k.ToString()].ToString().Trim();
                                if (strArray3[k] == "")
                                {
                                    flag = false;
                                    break;
                                }
                                if (WinNumber.IndexOf(strArray3[k]) >= 0)
                                {
                                    num7++;
                                }
                            }
                            if (flag)
                            {
                                switch (num7)
                                {
                                    case 5:
                                        num++;
                                        num3 += WinMoney1;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                        break;

                                    case 4:
                                        num2++;
                                        num3 += WinMoney2;
                                        WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                        break;
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
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num3;
        }

        private string[] FilterRepeated(string[] NumberPart)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= 0x16)) && !base.isExistBall(al, ball))
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
            return new PlayType[] { new PlayType(0x8fd, "单式"), new PlayType(0x8fe, "复式"), new PlayType(0x8ff, "好运一单式"), new PlayType(0x900, "好运一复式"), new PlayType(0x901, "好运二单式"), new PlayType(0x902, "好运二复式"), new PlayType(0x903, "好运三单式"), new PlayType(0x904, "好运三复式"), new PlayType(0x905, "好运四单式"), new PlayType(0x906, "好运四复式") };
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
                if (((str = LotteryMachine) != null) && (str == "SN-2000"))
                {
                    if (((PlayTypeID == 0x8fd) || (PlayTypeID == 0x8ff)) || (((PlayTypeID == 0x901) || (PlayTypeID == 0x903)) || (PlayTypeID == 0x905)))
                    {
                        return this.GetPrintKeyList_SN_2000_D(numbers);
                    }
                    if (((PlayTypeID == 0x8fe) || (PlayTypeID == 0x900)) || (((PlayTypeID == 0x902) || (PlayTypeID == 0x904)) || (PlayTypeID == 0x906)))
                    {
                        return this.GetPrintKeyList_SN_2000_F(numbers);
                    }
                }
            }
            return "";
        }

        private string GetPrintKeyList_SN_2000_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_SN_2000_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return (str + "[↑][E]");
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if ((PlayType == 0x8fd) || (PlayType == 0x8fe))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x8ff) || (PlayType == 0x900))
            {
                return this.ToSingle_HY1(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x901) || (PlayType == 0x902))
            {
                return this.ToSingle_HY2(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x903) || (PlayType == 0x904))
            {
                return this.ToSingle_HY3(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x905) && (PlayType != 0x906))
            {
                return null;
            }
            return this.ToSingle_HY4(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_HY1(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_HY2(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_HY3(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_HY4(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
            CanonicalNumber = "";
            if (strArray.Length < 4)
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
            for (int j = 0; j < (length - 3); j++)
            {
                for (int m = j + 1; m < (length - 2); m++)
                {
                    for (int n = m + 1; n < (length - 1); n++)
                    {
                        for (int num6 = n + 1; num6 < length; num6++)
                        {
                            list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6]);
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

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
            CanonicalNumber = "";
            if (strArray.Length < 5)
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
            for (int j = 0; j < (length - 4); j++)
            {
                for (int m = j + 1; m < (length - 3); m++)
                {
                    for (int n = m + 1; n < (length - 2); n++)
                    {
                        for (int num6 = n + 1; num6 < (length - 1); num6++)
                        {
                            for (int num7 = num6 + 1; num7 < length; num7++)
                            {
                                list.Add(strArray[j] + " " + strArray[m] + " " + strArray[n] + " " + strArray[num6] + " " + strArray[num7]);
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
