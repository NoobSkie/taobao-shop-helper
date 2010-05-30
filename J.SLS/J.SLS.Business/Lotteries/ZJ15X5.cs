using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class ZJ15X5 : LotteryBase
    {
        public const string Code = "ZJ15X5";
        public const int ID = 0x15;
        public const double MaxMoney = 48202.0;
        public const string Name = "浙江15选5";
        public const int PlayType_D = 0x835;
        public const int PlayType_F = 0x836;
        public const string sID = "21";

        public ZJ15X5()
        {
            base.id = 0x15;
            base.name = "浙江15选5";
            base.code = "ZJ15X5";
        }

        public override string AnalyseScheme(string Content, int PlayType)
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
            if (PlayType == 0x835)
            {
                str2 = @"(\d\d\s){4}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){4,14}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x835) ? 1 : 2))) && (strArray2.Length <= 24101.0))
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
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x835);
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
                        ball = random.Next(1, 0x10);
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
            return ((play_type >= 0x835) && (play_type <= 0x836));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
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
            if ((WinMoneyList == null) || (WinMoneyList.Length < 6))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            double num4 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle(strArray[i], ref canonicalNumber, PlayType);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 14)
                        {
                            string[] strArray3 = new string[5];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num8 = 0;
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
                                    num8++;
                                }
                            }
                            if (flag)
                            {
                                switch (num8)
                                {
                                    case 5:
                                        if (this.isThreeContinuum(WinNumber))
                                        {
                                            num++;
                                            num4 += WinMoneyList[0];
                                            WinMoneyNoWithTax += WinMoneyList[1];
                                        }
                                        else
                                        {
                                            num2++;
                                            num4 += WinMoneyList[2];
                                            WinMoneyNoWithTax += WinMoneyList[3];
                                        }
                                        break;

                                    case 4:
                                        num3++;
                                        num4 += WinMoneyList[4];
                                        WinMoneyNoWithTax += WinMoneyList[5];
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "特等奖" + num.ToString() + "注";
            }
            if (num2 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "一等奖" + num2.ToString() + "注";
            }
            if (num3 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "二等奖" + num3.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num4;
        }

        private string[] FilterRepeated(string[] NumberPart)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= 15)) && !base.isExistBall(al, ball))
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
            return new PlayType[] { new PlayType(0x835, "单式"), new PlayType(0x836, "复式") };
        }

        public override string GetPrintKeyList(string Number, int PlayTypeID, string LotteryMachine)
        {
            string str;
            Number = Number.Trim();
            if (Number == "")
            {
                return "";
            }
            string[] numbers = Number.Split(new char[] { '\n' });
            if ((numbers == null) || (numbers.Length < 1))
            {
                return "";
            }
            if ((((str = LotteryMachine) == null) || !(str == "FCR8000")) || ((PlayTypeID != 0x835) && (PlayTypeID != 0x836)))
            {
                return "";
            }
            return this.GetPrintKeyList_FCR8000(numbers);
        }

        private string GetPrintKeyList_FCR8000(string[] Numbers)
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

        private bool isThreeContinuum(string Number)
        {
            string[] strArray = this.FilterRepeated(Number.Split(new char[] { ' ' }));
            if (strArray.Length >= 5)
            {
                int[] numArray = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    numArray[i] = int.Parse(strArray[i]);
                }
                for (int j = 0; j < 2; j++)
                {
                    if ((((numArray[j] + 1) == numArray[j + 1]) && ((numArray[j] + 2) == numArray[j + 2])) && ((numArray[j] + 3) == numArray[j + 3]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
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
