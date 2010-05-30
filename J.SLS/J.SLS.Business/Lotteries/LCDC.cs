using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class LCDC : LotteryBase
    {
        public const string Code = "LCDC";
        public const int ID = 0x13;
        public const double MaxMoney = 20000.0;
        public const string Name = "篮彩";
        public const int PlayType_D = 0x76d;
        public const int PlayType_F = 0x76e;
        public const string sID = "19";

        public LCDC()
        {
            base.id = 0x13;
            base.name = "篮彩";
            base.code = "LCDC";
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
            if (PlayType == 0x76d)
            {
                str2 = @"([\d]){4}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){4}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x76d) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x76d);
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
                    str = str + random.Next(0, 10).ToString();
                }
                builder.Append(str.Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x76d) && (play_type <= 0x76e));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
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
            if ((WinMoneyList == null) || (WinMoneyList.Length < 2))
            {
                return -3.0;
            }
            int num = 0;
            double num2 = 0.0;
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
                        if ((strArray2[j].Length >= 4) && (strArray2[j] == WinNumber))
                        {
                            num++;
                            num2 += WinMoneyList[0];
                            WinMoneyNoWithTax += WinMoneyList[1];
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
            return new PlayType[] { new PlayType(0x76d, "单式"), new PlayType(0x76e, "复式") };
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
                    if (!(str == "CR_YTCII2"))
                    {
                        if (str == "TGAMPOS4000")
                        {
                            if (PlayTypeID == 0x76d)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_D(numbers);
                            }
                            if (PlayTypeID == 0x76e)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_F(numbers);
                            }
                        }
                        else if (str == "CP86")
                        {
                            if (PlayTypeID == 0x76d)
                            {
                                return this.GetPrintKeyList_CP86_D(numbers);
                            }
                            if (PlayTypeID == 0x76e)
                            {
                                return this.GetPrintKeyList_CP86_F(numbers);
                            }
                        }
                        else if (str == "MODEL_4000")
                        {
                            if (PlayTypeID == 0x76d)
                            {
                                return this.GetPrintKeyList_MODEL_4000_D(numbers);
                            }
                            if (PlayTypeID == 0x76e)
                            {
                                return this.GetPrintKeyList_MODEL_4000_F(numbers);
                            }
                        }
                    }
                    else
                    {
                        if (PlayTypeID == 0x76d)
                        {
                            return this.GetPrintKeyList_CR_YTCII2_D(numbers);
                        }
                        if (PlayTypeID == 0x76e)
                        {
                            return this.GetPrintKeyList_CR_YTCII2_F(numbers);
                        }
                    }
                }
            }
            return "";
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
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 4; i++)
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
                    if (i < 3)
                    {
                        str = str + "[→]";
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
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 4; i++)
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
                    if (i < 3)
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
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 4; i++)
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
                    if (i < 3)
                    {
                        str = str + "[↓]";
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
                Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str2);
                for (int i = 0; i < 4; i++)
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
                    if (i < 3)
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
                if (str.Length < 4)
                {
                    str = str.PadRight(4, ' ');
                }
                while ((startIndex < str.Length) && (listArray[i].Count < 4))
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
            string[,] strArray2 = new string[listArray.Length, 4];
            for (int j = 0; j < listArray.Length; j++)
            {
                for (int k = 0; (k < listArray[j].Count) && (k < 4); k++)
                {
                    strArray2[j, k] = listArray[j][k].ToString();
                }
            }
            return strArray2;
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
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
    }
}
