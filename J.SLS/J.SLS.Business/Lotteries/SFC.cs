using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SFC : LotteryBase
    {
        public const string Code = "SFC";
        public const int ID = 1;
        public const double MaxMoney = 20000.0;
        public const string Name = "胜负彩";
        public const int PlayType_9_D = 0x67;
        public const int PlayType_9_F = 0x68;
        public const int PlayType_D = 0x65;
        public const int PlayType_F = 0x66;
        public const string sID = "1";

        public SFC()
        {
            base.id = 1;
            base.name = "胜负彩";
            base.code = "SFC";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x65) || (PlayType == 0x66))
            {
                return this.AnalyseScheme_14(Content, PlayType);
            }
            if ((PlayType != 0x67) && (PlayType != 0x68))
            {
                return "";
            }
            return this.AnalyseScheme_9(Content, PlayType);
        }

        private string AnalyseScheme_14(string Content, int PlayType)
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
            if (PlayType == 0x65)
            {
                str2 = "([013]){14}";
            }
            else
            {
                str2 = "(([013])|([(][013]{1,3}[)])){14}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_14(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x65) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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

        private string AnalyseScheme_9(string Content, int PlayType)
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
            if (PlayType == 0x67)
            {
                str2 = "([013-]){14}";
            }
            else
            {
                str2 = "(([013-])|([(][013]{1,3}[)])){14}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_9(match.Value, ref canonicalNumber);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x67) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            Number = Number.Replace("*", "0");
            string canonicalNumber = "";
            string[] strArray = this.ToSingle_14(Number, ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num, int Type)
        {
            if ((Type != 14) && (Type != 9))
            {
                Type = 14;
            }
            if (Type == 14)
            {
                return this.BuildNumber_14(Num);
            }
            if (Type == 9)
            {
                return this.BuildNumber_9(Num);
            }
            return "";
        }

        private string BuildNumber_14(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 14; j++)
                {
                    str = str + "310"[random.Next(0, 3)].ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        private string BuildNumber_9(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = this.BuildNumber_14(1);
                for (int j = 0; j < 5; j++)
                {
                    int startIndex = 0;
                    do
                    {
                        startIndex = random.Next(0, 14);
                    }
                    while (str[startIndex] == '-');
                    str = str.Remove(startIndex, 1).Insert(startIndex, "-");
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x65) && (play_type <= 0x68));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 6))
            {
                return -3.0;
            }
            if (((PlayType == 0x65) || (PlayType == 0x65)) || ((PlayType == 0x66) || (PlayType == 0x66)))
            {
                return this.ComputeWin_14(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3]);
            }
            if (((PlayType != 0x67) && (PlayType != 0x67)) && ((PlayType != 0x68) && (PlayType != 0x68)))
            {
                return -4.0;
            }
            return this.ComputeWin_9(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[4], WinMoneyList[5]);
        }

        private double ComputeWin_14(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
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
                string[] strArray2 = this.ToSingle_14(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 14)
                        {
                            int num6 = 0;
                            for (int k = 0; k < 14; k++)
                            {
                                if ((WinNumber[k] == '*') || (strArray2[j][k] == WinNumber[k]))
                                {
                                    num6++;
                                }
                            }
                            switch (num6)
                            {
                                case 14:
                                    num++;
                                    num3 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                    break;

                                case 13:
                                    num2++;
                                    num3 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                    break;
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

        private double ComputeWin_9(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
                string[] strArray2 = this.ToSingle_9(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if (strArray2[j].Length >= 14)
                        {
                            int num5 = 0;
                            for (int k = 0; k < 14; k++)
                            {
                                if (((WinNumber[k] == '*') || (strArray2[j][k] == WinNumber[k])) || (strArray2[j][k] == '-'))
                                {
                                    num5++;
                                }
                            }
                            if (num5 == 14)
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
                Description = "一等奖" + num.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num2;
        }

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID == 0x65) || (PlayTypeID == 0x67))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + ";\n";
                }
            }
            if ((PlayTypeID == 0x66) || (PlayTypeID == 0x68))
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[14];
                    Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 14; m++)
                    {
                        strArray3[m] = match.Groups["L" + m.ToString()].ToString().Trim();
                        if (strArray3[m] == "")
                        {
                            return "";
                        }
                        if (strArray3[m].Length > 1)
                        {
                            strArray3[m] = strArray3[m].Substring(1, strArray3[m].Length - 2);
                            if (strArray3[m].Length > 1)
                            {
                                strArray3[m] = this.FilterRepeated(strArray3[m]);
                            }
                            if (strArray3[m] == "")
                            {
                                return "";
                            }
                        }
                        str = str + strArray3[m] + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + ";\n";
                }
            }
            str = str.Replace("-", "#");
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string ConvertFormatToElectronTicket_HPSD(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID == 0x65) || (PlayTypeID == 0x67))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        str = str + strArray[i].Substring(j, 1) + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            if ((PlayTypeID == 0x66) || (PlayTypeID == 0x68))
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[14];
                    Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 14; m++)
                    {
                        strArray3[m] = match.Groups["L" + m.ToString()].ToString().Trim();
                        if (strArray3[m] == "")
                        {
                            return "";
                        }
                        if (strArray3[m].Length > 1)
                        {
                            strArray3[m] = strArray3[m].Substring(1, strArray3[m].Length - 2);
                            if (strArray3[m].Length > 1)
                            {
                                strArray3[m] = this.FilterRepeated(strArray3[m]);
                            }
                            if (strArray3[m] == "")
                            {
                                return "";
                            }
                        }
                        str = str + strArray3[m] + ",";
                    }
                    if (str.EndsWith(","))
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    str = str + "\n";
                }
            }
            str = str.Replace("-", "#");
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string FilterRepeated(string NumberPart)
        {
            string str = "";
            for (int i = 0; i < NumberPart.Length; i++)
            {
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("013-".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return base.Sort(str);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x65, "单式"), new PlayType(0x66, "复式"), new PlayType(0x67, "任九场单式"), new PlayType(0x68, "任九场复式") };
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
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_F(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_D(numbers);

                    case "TCBJYTD":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TCBJYTD_F(numbers);
                        }
                        return this.GetPrintKeyList_TCBJYTD_D(numbers);

                    case "TGAMPOS4000":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_F(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_D(numbers);

                    case "CP86":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_F(numbers);
                        }
                        return this.GetPrintKeyList_CP86_D(numbers);

                    case "MODEL_4000":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_F(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_D(numbers);

                    case "CORONISTPT":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_F(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_D(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0x65)
                        {
                            if (PlayTypeID == 0x66)
                            {
                                return this.GetPrintKeyList_RS6500_F(numbers);
                            }
                            if (PlayTypeID == 0x67)
                            {
                                return this.GetPrintKeyList_RS6500_R9_D(numbers);
                            }
                            if (PlayTypeID != 0x68)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_R9_F(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_D(numbers);

                    case "ks230":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID != 0x66) && (PlayTypeID != 0x68))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_F(numbers);
                        }
                        return this.GetPrintKeyList_ks230_D(numbers);

                    case "LA-600A":
                        if ((PlayTypeID != 0x65) && (PlayTypeID != 0x67))
                        {
                            if ((PlayTypeID == 0x66) || (PlayTypeID == 0x68))
                            {
                                return this.GetPrintKeyList_LA_600A_F(numbers);
                            }
                            break;
                        }
                        return this.GetPrintKeyList_LA_600A_D(numbers);
                }
            }
            return "";
        }

        private string GetPrintKeyList_CORONISTPT_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[→]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[→]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[→]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[←]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[→]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[→]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_R9_D(string[] Numbers)
        {
            string str = "";
            for (int i = 0; i < Numbers.Length; i++)
            {
                bool flag = true;
                for (int j = 13; j >= 0; j--)
                {
                    if (flag)
                    {
                        if (Numbers[i].Substring(j, 1) != "-")
                        {
                            flag = false;
                        }
                        else
                        {
                            Numbers[i] = Numbers[i].Substring(0, j);
                        }
                    }
                }
            }
            foreach (string str3 in Numbers)
            {
                foreach (char ch in str3.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_R9_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TCBJYTD_D(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                foreach (char ch in str2.Replace(" ", "").Replace("\r", "").Replace("\n", ""))
                {
                    if (ch == '-')
                    {
                        str = str + "[→]";
                    }
                    else
                    {
                        str = str + "[" + ch.ToString() + "]";
                    }
                }
            }
            return str;
        }

        private string GetPrintKeyList_TCBJYTD_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[→]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[→]";
                        }
                    }
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
                    if (ch == '-')
                    {
                        str = str + "[↓]";
                    }
                    else
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
                Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 14; i++)
                {
                    string str3 = match.Groups["L" + i.ToString()].ToString().Trim();
                    if (str3 == "-")
                    {
                        str = str + "[↓]";
                    }
                    else
                    {
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
                        if (i < 13)
                        {
                            str = str + "[↓]";
                        }
                    }
                }
            }
            return str;
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public string[,] SplitLotteryNumberForGrid(string Number)
        {
            string[] strArray = Number.Split(new char[] { '\n' });
            if (strArray.Length == 0)
            {
                return null;
            }
            ArrayList[] listArray = new ArrayList[strArray.Length];
            for (int i = 0; i < listArray.Length; i++)
            {
                listArray[i] = new ArrayList();
                int startIndex = 0;
                string str = strArray[i];
                if (str.Length < 14)
                {
                    str = str.PadRight(14, ' ');
                }
                while ((startIndex < str.Length) && (listArray[i].Count < 14))
                {
                    if (str.Substring(startIndex, 1) != "(")
                    {
                        listArray[i].Add(str.Substring(startIndex, 1));
                        startIndex++;
                    }
                    else
                    {
                        int num3 = startIndex + 1;
                        while (str.Substring(num3, 1) != ")")
                        {
                            num3++;
                        }
                        string str2 = str.Substring(startIndex, num3 - startIndex);
                        listArray[i].Add(str2.Substring(1, str2.Length - 1));
                        startIndex = num3 + 1;
                    }
                }
            }
            string[,] strArray2 = new string[listArray.Length, 14];
            for (int j = 0; j < listArray.Length; j++)
            {
                for (int k = 0; (k < listArray[j].Count) && (k < 14); k++)
                {
                    strArray2[j, k] = listArray[j][k].ToString();
                }
            }
            return strArray2;
        }

        public override JTicket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x65)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x66)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x67)
            {
                return this.ToElectronicTicket_DYJ_9_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x68)
            {
                return this.ToElectronicTicket_DYJ_9_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_DYJ_9_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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

        private JTicket[] ToElectronicTicket_DYJ_9_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x68, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                    }
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x67, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                    }
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override JTicket[] ToElectronicTicket_HPSD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x65)
            {
                return this.ToElectronicTicket_HPSD_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x66)
            {
                return this.ToElectronicTicket_HPSD_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x67)
            {
                return this.ToElectronicTicket_HPSD_9_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x68)
            {
                return this.ToElectronicTicket_HPSD_9_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPSD_9_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_9_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x68, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                    }
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x67, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                    }
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
            if ((PlayType == 0x65) || (PlayType == 0x66))
            {
                return this.ToSingle_14(Number, ref CanonicalNumber);
            }
            if ((PlayType != 0x67) && (PlayType != 0x68))
            {
                return null;
            }
            return this.ToSingle_9(Number, ref CanonicalNumber);
        }

        private string[] ToSingle_14(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[14];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>([\d])|([(][\d]+?[)]))(?<L1>([\d])|([(][\d]+?[)]))(?<L2>([\d])|([(][\d]+?[)]))(?<L3>([\d])|([(][\d]+?[)]))(?<L4>([\d])|([(][\d]+?[)]))(?<L5>([\d])|([(][\d]+?[)]))(?<L6>([\d])|([(][\d]+?[)]))(?<L7>([\d])|([(][\d]+?[)]))(?<L8>([\d])|([(][\d]+?[)]))(?<L9>([\d])|([(][\d]+?[)]))(?<L10>([\d])|([(][\d]+?[)]))(?<L11>([\d])|([(][\d]+?[)]))(?<L12>([\d])|([(][\d]+?[)]))(?<L13>([\d])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 14; i++)
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
                                for (int num7 = 0; num7 < strArray[5].Length; num7++)
                                {
                                    string str6 = str5 + strArray[5][num7].ToString();
                                    for (int num8 = 0; num8 < strArray[6].Length; num8++)
                                    {
                                        string str7 = str6 + strArray[6][num8].ToString();
                                        for (int num9 = 0; num9 < strArray[7].Length; num9++)
                                        {
                                            string str8 = str7 + strArray[7][num9].ToString();
                                            for (int num10 = 0; num10 < strArray[8].Length; num10++)
                                            {
                                                string str9 = str8 + strArray[8][num10].ToString();
                                                for (int num11 = 0; num11 < strArray[9].Length; num11++)
                                                {
                                                    string str10 = str9 + strArray[9][num11].ToString();
                                                    for (int num12 = 0; num12 < strArray[10].Length; num12++)
                                                    {
                                                        string str11 = str10 + strArray[10][num12].ToString();
                                                        for (int num13 = 0; num13 < strArray[11].Length; num13++)
                                                        {
                                                            string str12 = str11 + strArray[11][num13].ToString();
                                                            for (int num14 = 0; num14 < strArray[12].Length; num14++)
                                                            {
                                                                string str13 = str12 + strArray[12][num14].ToString();
                                                                for (int num15 = 0; num15 < strArray[13].Length; num15++)
                                                                {
                                                                    string str14 = str13 + strArray[13][num15].ToString();
                                                                    list.Add(str14);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
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

        private string[] ToSingle_9(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[14];
            CanonicalNumber = "";
            if (_String.StringAt(Number, '-') != 5)
            {
                CanonicalNumber = "";
                return null;
            }
            Match match = new Regex(@"(?<L0>([\d-])|([(][\d]+?[)]))(?<L1>([\d-])|([(][\d]+?[)]))(?<L2>([\d-])|([(][\d]+?[)]))(?<L3>([\d-])|([(][\d]+?[)]))(?<L4>([\d-])|([(][\d]+?[)]))(?<L5>([\d-])|([(][\d]+?[)]))(?<L6>([\d-])|([(][\d]+?[)]))(?<L7>([\d-])|([(][\d]+?[)]))(?<L8>([\d-])|([(][\d]+?[)]))(?<L9>([\d-])|([(][\d]+?[)]))(?<L10>([\d-])|([(][\d]+?[)]))(?<L11>([\d-])|([(][\d]+?[)]))(?<L12>([\d-])|([(][\d]+?[)]))(?<L13>([\d-])|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 14; i++)
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
                                for (int num7 = 0; num7 < strArray[5].Length; num7++)
                                {
                                    string str6 = str5 + strArray[5][num7].ToString();
                                    for (int num8 = 0; num8 < strArray[6].Length; num8++)
                                    {
                                        string str7 = str6 + strArray[6][num8].ToString();
                                        for (int num9 = 0; num9 < strArray[7].Length; num9++)
                                        {
                                            string str8 = str7 + strArray[7][num9].ToString();
                                            for (int num10 = 0; num10 < strArray[8].Length; num10++)
                                            {
                                                string str9 = str8 + strArray[8][num10].ToString();
                                                for (int num11 = 0; num11 < strArray[9].Length; num11++)
                                                {
                                                    string str10 = str9 + strArray[9][num11].ToString();
                                                    for (int num12 = 0; num12 < strArray[10].Length; num12++)
                                                    {
                                                        string str11 = str10 + strArray[10][num12].ToString();
                                                        for (int num13 = 0; num13 < strArray[11].Length; num13++)
                                                        {
                                                            string str12 = str11 + strArray[11][num13].ToString();
                                                            for (int num14 = 0; num14 < strArray[12].Length; num14++)
                                                            {
                                                                string str13 = str12 + strArray[12][num14].ToString();
                                                                for (int num15 = 0; num15 < strArray[13].Length; num15++)
                                                                {
                                                                    string str14 = str13 + strArray[13][num15].ToString();
                                                                    list.Add(str14);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
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
