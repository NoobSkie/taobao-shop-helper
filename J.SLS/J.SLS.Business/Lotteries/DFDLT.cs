using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class DFDLT : LotteryBase
    {
        public const string Code = "DFDLT";
        public const int ID = 0x18;
        public const double MaxMoney = 22880.0;
        public const string Name = "东方大乐透";
        public const int PlayType_D = 0x961;
        public const int PlayType_F = 0x962;
        public const string sID = "24";

        public DFDLT()
        {
            base.id = 0x18;
            base.name = "东方大乐透";
            base.code = "DFDLT";
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
            if (PlayType == 0x961)
            {
                str2 = @"(\d\d\s){6}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){6,36}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x961) ? 1 : 2))) && (strArray2.Length <= 11440.0))
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
            Regex regex = new Regex(@"(\d\d\s){7}[+]\s\d\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number.Substring(0, 20), ref canonicalNumber, 0x961);
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
                        ball = random.Next(1, 0x26);
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
            return ((play_type >= 0x961) && (play_type <= 0x962));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x19)
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
            if ((WinMoneyList == null) || (WinMoneyList.Length < 14))
            {
                return -3.0;
            }
            string str = WinNumber.Substring(0x17, 2);
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
                string[] strArray2 = this.ToSingle(strArray[i], ref canonicalNumber, PlayType);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 20)
                        {
                            string[] strArray3 = new string[7];
                            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[j]);
                            int num11 = 0;
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
                                    num11++;
                                }
                                if (str == strArray3[k])
                                {
                                    flag = true;
                                }
                            }
                            if (flag2)
                            {
                                if (num11 == 7)
                                {
                                    num++;
                                    num8 += WinMoneyList[0];
                                    WinMoneyNoWithTax += WinMoneyList[1];
                                }
                                else if ((num11 == 6) && flag)
                                {
                                    num2++;
                                    num8 += WinMoneyList[2];
                                    WinMoneyNoWithTax += WinMoneyList[3];
                                }
                                else if (num11 == 6)
                                {
                                    num3++;
                                    num8 += WinMoneyList[4];
                                    WinMoneyNoWithTax += WinMoneyList[5];
                                }
                                else if ((num11 == 5) && flag)
                                {
                                    num4++;
                                    num8 += WinMoneyList[6];
                                    WinMoneyNoWithTax += WinMoneyList[7];
                                }
                                else if (num11 == 5)
                                {
                                    num5++;
                                    num8 += WinMoneyList[8];
                                    WinMoneyNoWithTax += WinMoneyList[9];
                                }
                                else if ((num11 == 4) && flag)
                                {
                                    num6++;
                                    num8 += WinMoneyList[10];
                                    WinMoneyNoWithTax += WinMoneyList[11];
                                }
                                else if ((num11 == 4) || ((num11 == 3) && flag))
                                {
                                    num7++;
                                    num8 += WinMoneyList[12];
                                    WinMoneyNoWithTax += WinMoneyList[13];
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
                Description = Description + "七等奖" + num7.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num8;
        }

        private string[] FilterRepeated(string[] NumberPart)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= 0x25)) && !base.isExistBall(al, ball))
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
            return new PlayType[] { new PlayType(0x961, "单式"), new PlayType(0x962, "复式") };
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
                string str = LotteryMachine;
                if (str != null)
                {
                    if (!(str == "FCR8000"))
                    {
                        if (str == "SN_3000CG")
                        {
                            if (PlayTypeID == 0x961)
                            {
                                return this.GetPrintKeyList_SN_3000CG_D(numbers);
                            }
                            if (PlayTypeID == 0x962)
                            {
                                return this.GetPrintKeyList_SN_3000CG_F(numbers);
                            }
                        }
                    }
                    else if ((PlayTypeID == 0x961) || (PlayTypeID == 0x962))
                    {
                        return this.GetPrintKeyList_FCR8000(numbers);
                    }
                }
            }
            return "";
        }

        private string GetPrintKeyList_FCR8000(string[] Numbers)
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

        private string GetPrintKeyList_SN_3000CG_D(string[] Numbers)
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

        private string GetPrintKeyList_SN_3000CG_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace("+", "").Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return (str + "[ENTER]");
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
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
