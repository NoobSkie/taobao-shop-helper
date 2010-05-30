using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class QXC : LotteryBase
    {
        public const string Code = "QXC";
        public const int ID = 3;
        public const double MaxMoney = 20000.0;
        public const string Name = "七星彩";
        public const int PlayType_D = 0x12d;
        public const int PlayType_F = 0x12e;
        public const string sID = "3";

        public QXC()
        {
            base.id = 3;
            base.name = "七星彩";
            base.code = "QXC";
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
            if (PlayType == 0x12d)
            {
                str2 = @"([\d]){7}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){7}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x12d) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x12d);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 7; j++)
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
            return ((play_type >= 0x12d) && (play_type <= 0x12e));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 7)
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
                        if (strArray2[j].Length >= 7)
                        {
                            if (strArray2[j] == WinNumber)
                            {
                                num++;
                                num7 += WinMoneyList[0];
                                WinMoneyNoWithTax += WinMoneyList[1];
                            }
                            else
                            {
                                bool flag = false;
                                int startIndex = 0;
                                while (startIndex <= 1)
                                {
                                    if (strArray2[j].Substring(startIndex, 6) == WinNumber.Substring(startIndex, 6))
                                    {
                                        num2++;
                                        num7 += WinMoneyList[2];
                                        WinMoneyNoWithTax += WinMoneyList[3];
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
                                        while (startIndex <= 3)
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
                                            while (startIndex <= 4)
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
                                                for (startIndex = 0; startIndex <= 5; startIndex++)
                                                {
                                                    if (strArray2[j].Substring(startIndex, 2) == WinNumber.Substring(startIndex, 2))
                                                    {
                                                        num6++;
                                                        num7 += WinMoneyList[10];
                                                        WinMoneyNoWithTax += WinMoneyList[11];
                                                        flag = true;
                                                        break;
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

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (PlayTypeID == 0x12d)
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
            if (PlayTypeID == 0x12e)
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[7];
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 7; m++)
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
            if (PlayTypeID == 0x12d)
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
            if (PlayTypeID == 0x12e)
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[7];
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 7; m++)
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
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("0123456789".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return base.Sort(str);
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x12d, "单式"), new PlayType(0x12e, "复式") };
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
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_F(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_D(numbers);

                    case "TCBJYTD":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TCBJYTD_F(numbers);
                        }
                        return this.GetPrintKeyList_TCBJYTD_D(numbers);

                    case "TGAMPOS4000":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_F(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_D(numbers);

                    case "CP86":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_F(numbers);
                        }
                        return this.GetPrintKeyList_CP86_D(numbers);

                    case "MODEL_4000":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_F(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_D(numbers);

                    case "CORONISTPT":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_F(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_D(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_F(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_D(numbers);

                    case "ks230":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID != 0x12e)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_F(numbers);
                        }
                        return this.GetPrintKeyList_ks230_D(numbers);

                    case "LA-600A":
                        if (PlayTypeID != 0x12d)
                        {
                            if (PlayTypeID == 0x12e)
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_CORONISTPT_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_CP86_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_CR_YTCII2_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_ks230_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_LA_600A_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_MODEL_4000_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_RS6500_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_TCBJYTD_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[→]";
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
                    str = str + "[" + ch.ToString() + "]";
                }
            }
            return str;
        }

        private string GetPrintKeyList_TGAMPOS4000_F(string[] Numbers)
        {
            string str = "";
            foreach (string str2 in Numbers)
            {
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 7; i++)
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
                    if (i < 6)
                    {
                        str = str + "[↓]";
                    }
                }
            }
            return str;
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override Ticket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x12d)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x12e)
            {
                return this.ToElectronicTicket_DYJ_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
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
                        if ((k + m) < strArray.Length)
                        {
                            number = number + strArray[k + m].ToString().Split(new char[] { '|' })[0] + "\n";
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
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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
            if (PlayTypeID == 0x12d)
            {
                return this.ToElectronicTicket_HPSD_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x12e)
            {
                return this.ToElectronicTicket_HPSD_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
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
                        if ((k + m) < strArray.Length)
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
                    number = strArray[k].ToString().Split(new char[] { '|' })[0];
                    num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                    Money += num3 * multiple;
                    list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
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
            string[] strArray = new string[7];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))(?<L6>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 7; i++)
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
                                        list.Add(str7);
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
