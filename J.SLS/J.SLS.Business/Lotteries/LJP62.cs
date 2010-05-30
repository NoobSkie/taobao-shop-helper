using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class LJP62 : LotteryBase
    {
        public const string Code = "LJP62";
        public const int ID = 8;
        public const double MaxMoney = 20000.0;
        public const string Name = "龙江P62";
        public const int PlayType_D = 0x321;
        public const int PlayType_F = 0x322;
        public const string sID = "8";

        public LJP62()
        {
            base.id = 8;
            base.name = "龙江P62";
            base.code = "LJP62";
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
            if (PlayType == 0x321)
            {
                str2 = @"(\d){6}[+][01]";
            }
            else
            {
                str2 = @"((\d)|([(]\d{1,10}[)])){6}[+](([01])|([(]([01]){1,2}[)]))";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x321) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            Regex regex = new Regex("([0123456789]){6}[+][01]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x321);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 6; j++)
                {
                    str = str + random.Next(0, 10).ToString();
                }
                builder.Append((str + "+" + random.Next(0, 2).ToString()).Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x321) && (play_type <= 0x322));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 8)
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
            if ((WinMoneyList == null) || (WinMoneyList.Length < 12))
            {
                return -3.0;
            }
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
                string[] strArray2 = this.ToSingle(strArray[i], ref canonicalNumber, PlayType);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 8)
                        {
                            if (strArray2[j] == WinNumber)
                            {
                                num++;
                                num7 += WinMoneyList[0];
                                WinMoneyNoWithTax += WinMoneyList[1];
                            }
                            else if (strArray2[j].Substring(0, 6) == WinNumber.Substring(0, 6))
                            {
                                num2++;
                                num7 += WinMoneyList[2];
                                WinMoneyNoWithTax += WinMoneyList[3];
                            }
                            else
                            {
                                bool flag = false;
                                int startIndex = 0;
                                while (startIndex <= 1)
                                {
                                    if (strArray2[j].Substring(startIndex, 5) == WinNumber.Substring(startIndex, 5))
                                    {
                                        num3++;
                                        num7 += WinMoneyList[4];
                                        WinMoneyNoWithTax += WinMoneyList[5];
                                        flag = true;
                                        break;
                                    }
                                    startIndex++;
                                }
                                if (!flag)
                                {
                                    startIndex = 0;
                                    while (startIndex <= 2)
                                    {
                                        if (strArray2[j].Substring(startIndex, 4) == WinNumber.Substring(startIndex, 4))
                                        {
                                            num4++;
                                            num7 += WinMoneyList[6];
                                            WinMoneyNoWithTax += WinMoneyList[7];
                                            flag = true;
                                            break;
                                        }
                                        startIndex++;
                                    }
                                    if (!flag)
                                    {
                                        startIndex = 0;
                                        while (startIndex <= 3)
                                        {
                                            if (strArray2[j].Substring(startIndex, 3) == WinNumber.Substring(startIndex, 3))
                                            {
                                                num5++;
                                                num7 += WinMoneyList[8];
                                                WinMoneyNoWithTax += WinMoneyList[9];
                                                flag = true;
                                                break;
                                            }
                                            startIndex++;
                                        }
                                        if (!flag)
                                        {
                                            int num11 = 0;
                                            for (startIndex = 0; startIndex < 6; startIndex++)
                                            {
                                                if (strArray2[j][startIndex] == WinNumber[startIndex])
                                                {
                                                    num11++;
                                                }
                                            }
                                            if (num11 >= 2)
                                            {
                                                num6++;
                                                num7 += WinMoneyList[10];
                                                WinMoneyNoWithTax += WinMoneyList[11];
                                            }
                                        }
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
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num7;
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
            return new PlayType[] { new PlayType(0x321, "单式"), new PlayType(0x322, "复式") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            string[] strArray = Number.Split(new char[] { '+' });
            CanonicalNumber = "";
            if (strArray.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray2 = new string[6];
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray[0].Trim());
            for (int i = 0; i < 6; i++)
            {
                strArray2[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (strArray2[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (strArray2[i].Length > 1)
                {
                    strArray2[i] = strArray2[i].Substring(1, strArray2[i].Length - 2);
                    if (strArray2[i].Length > 1)
                    {
                        strArray2[i] = this.FilterRepeated(strArray2[i]);
                    }
                    if (strArray2[i] == "")
                    {
                        CanonicalNumber = "";
                        return null;
                    }
                }
                if (strArray2[i].Length > 1)
                {
                    CanonicalNumber = CanonicalNumber + "(" + strArray2[i] + ")";
                }
                else
                {
                    CanonicalNumber = CanonicalNumber + strArray2[i];
                }
            }
            CanonicalNumber = CanonicalNumber + "+";
            string numberPart = strArray[1].Trim();
            if (numberPart.Length > 1)
            {
                numberPart = numberPart.Substring(1, numberPart.Length - 2);
                if (numberPart.Length > 1)
                {
                    numberPart = this.FilterRepeated(numberPart);
                }
                if (numberPart == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (numberPart.Length > 2)
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            for (int j = 0; j < numberPart.Length; j++)
            {
                if ((numberPart[j] != '0') && (numberPart[j] != '1'))
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            if (numberPart.Length > 1)
            {
                CanonicalNumber = CanonicalNumber + "(" + numberPart + ")";
            }
            else
            {
                CanonicalNumber = CanonicalNumber + numberPart;
            }
            ArrayList list = new ArrayList();
            for (int k = 0; k < strArray2[0].Length; k++)
            {
                string str2 = strArray2[0][k].ToString();
                for (int n = 0; n < strArray2[1].Length; n++)
                {
                    string str3 = str2 + strArray2[1][n].ToString();
                    for (int num5 = 0; num5 < strArray2[2].Length; num5++)
                    {
                        string str4 = str3 + strArray2[2][num5].ToString();
                        for (int num6 = 0; num6 < strArray2[3].Length; num6++)
                        {
                            string str5 = str4 + strArray2[3][num6].ToString();
                            for (int num7 = 0; num7 < strArray2[4].Length; num7++)
                            {
                                string str6 = str5 + strArray2[4][num7].ToString();
                                for (int num8 = 0; num8 < strArray2[5].Length; num8++)
                                {
                                    string str7 = str6 + strArray2[5][num8].ToString();
                                    for (int num9 = 0; num9 < numberPart.Length; num9++)
                                    {
                                        list.Add(str7 + "+" + numberPart[num9].ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string[] strArray3 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray3[m] = list[m].ToString();
            }
            return strArray3;
        }
    }
}
