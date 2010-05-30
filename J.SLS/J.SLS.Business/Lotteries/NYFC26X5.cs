using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class NYFC26X5 : LotteryBase
    {
        public const string Code = "NYFC26X5";
        public const int ID = 0x11;
        public const double MaxMoney = 65780.0;
        public const string Name = "南粤风采26选5";
        public const int PlayType_D = 0x6a5;
        public const int PlayType_F = 0x6a6;
        public const int PlayType_HC2_D = 0x6a7;
        public const int PlayType_HC2_F = 0x6a8;
        public const int PlayType_HC3_D = 0x6a9;
        public const int PlayType_HC3_F = 0x6aa;
        public const string sID = "17";

        public NYFC26X5()
        {
            base.id = 0x11;
            base.name = "南粤风采26选5";
            base.code = "NYFC26X5";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x6a5) || (PlayType == 0x6a6))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if ((PlayType == 0x6a7) || (PlayType == 0x6a8))
            {
                return this.AnalyseScheme_HC2(Content, PlayType);
            }
            if ((PlayType != 0x6a9) && (PlayType != 0x6aa))
            {
                return "";
            }
            return this.AnalyseScheme_HC3(Content, PlayType);
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
            if (PlayType == 0x6a7)
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
                    string[] strArray2 = this.ToSingle_HC2(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x6a7) ? 1 : 2))) && (strArray2.Length <= 32890.0))
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
            if (PlayType == 0x6a9)
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
                    string[] strArray2 = this.ToSingle_HC3(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x6a9) ? 1 : 2))) && (strArray2.Length <= 32890.0))
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
            if (PlayType == 0x6a5)
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
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x6a5) ? 1 : 2))) && (strArray2.Length <= 32890.0))
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
                        ball = random.Next(1, 0x1b);
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
            return ((play_type >= 0x6a5) && (play_type <= 0x6aa));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 8))
            {
                return -3.0;
            }
            if ((PlayType == 0x6a5) || (PlayType == 0x6a6))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3]);
            }
            if ((PlayType == 0x6a7) || (PlayType == 0x6a8))
            {
                return this.ComputeWin_HC2(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
            }
            if ((PlayType != 0x6a9) && (PlayType != 0x6aa))
            {
                return -4.0;
            }
            return this.ComputeWin_HC3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[6], WinMoneyList[7]);
        }

        private double ComputeWin_HC2(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                Description = "好彩三奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
                if (((ball >= 1) && (ball <= 0x1a)) && !base.isExistBall(al, ball))
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
            return new PlayType[] { new PlayType(0x6a5, "单式"), new PlayType(0x6a6, "复式"), new PlayType(0x6a7, "好彩二单式"), new PlayType(0x6a8, "好彩二复式"), new PlayType(0x6a9, "好彩三单式"), new PlayType(0x6aa, "好彩三复式") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            if ((PlayType == 0x6a5) || (PlayType == 0x6a6))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x6a7) || (PlayType == 0x6a8))
            {
                return this.ToSingle_HC2(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x6a9) && (PlayType != 0x6aa))
            {
                return null;
            }
            return this.ToSingle_HC3(Number, ref CanonicalNumber);
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
