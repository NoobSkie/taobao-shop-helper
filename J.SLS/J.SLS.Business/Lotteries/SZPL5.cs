using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SZPL5 : LotteryBase
    {
        public const string Code = "SZPL5";
        public const int ID = 0x40;
        public const double MaxMoney = 20000.0;
        public const string Name = "体彩排列5";
        public const int PlayType_5_D = 0x1901;
        public const int PlayType_5_F = 0x1902;
        public const string sID = "64";

        public SZPL5()
        {
            base.id = 0x40;
            base.name = "体彩排列5";
            base.code = "SZPL5";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType != 0x1901) && (PlayType != 0x1902))
            {
                return "";
            }
            return this.AnalyseScheme_5(Content, PlayType);
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
            if (PlayType == 0x1901)
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
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1901) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            string[] strArray = this.ToSingle_5(Number, ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 5; j++)
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
            return ((play_type >= 0x1901) && (play_type <= 0x1902));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((PlayType != 0x1901) && (PlayType != 0x1902))
            {
                return -4.0;
            }
            return this.ComputeWin_5(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
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

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (PlayTypeID == 0x1901)
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
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
                str = str + ";";
            }
            if (PlayTypeID == 0x1902)
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[5];
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 5; m++)
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
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string ConvertFormatToElectronTicket_HPSD(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if (PlayTypeID == 0x1901)
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
                if (str.EndsWith("\n"))
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            if (PlayTypeID == 0x1902)
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int k = 0; k < strArray2.Length; k++)
                {
                    string[] strArray3 = new string[5];
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[k]);
                    for (int m = 0; m < 5; m++)
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
            if (str.EndsWith("\n"))
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
            return new PlayType[] { new PlayType(0x1901, "排列5单式"), new PlayType(0x1902, "排列5复式") };
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
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);

                    case "TCBJYTD":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TCBJYTD_5_F(numbers);
                        }
                        return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);

                    case "TGAMPOS4000":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_5_F(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);

                    case "CP86":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CP86_ZhiD(numbers);

                    case "MODEL_4000":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_5_F(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);

                    case "CORONISTPT":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_5_F(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_5_F(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_ZhiD(numbers);

                    case "ks230":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID != 0x1902)
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_5_F(numbers);
                        }
                        return this.GetPrintKeyList_ks230_ZhiD(numbers);

                    case "LA-600A":
                        if (PlayTypeID != 0x1901)
                        {
                            if (PlayTypeID == 0x1902)
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

        public override Ticket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1901)
            {
                return this.ToElectronicTicket_DYJ_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1902)
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                    }
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
            if (PlayTypeID == 0x1901)
            {
                return this.ToElectronicTicket_HPSD_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1902)
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
                        if (((k + m) < strArray.Length) && (strArray[k + m].ToString().Split(new char[] { '|' }).Length >= 2))
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
                    if (strArray[k].ToString().Split(new char[] { '|' }).Length >= 2)
                    {
                        string number = "";
                        num3 = 0.0;
                        number = strArray[k].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[k].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new Ticket(0x66, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                    }
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
            if ((PlayType != 0x1901) && (PlayType != 0x1902))
            {
                return null;
            }
            return this.ToSingle_5(Number, ref CanonicalNumber);
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
    }
}
