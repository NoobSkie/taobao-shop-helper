using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SZPL3 : LotteryBase
    {
        public const string Code = "SZPL3";
        public const int ID = 0x3f;
        public const double MaxMoney = 20000.0;
        public const string Name = "数字排列3";
        public const int PlayType_3_ZhiD = 0x189d;
        public const int PlayType_3_ZhiF = 0x189e;
        public const int PlayType_3_ZhiH = 0x18a2;
        public const int PlayType_3_Zu3F = 0x18a1;
        public const int PlayType_3_Zu6F = 0x18a0;
        public const int PlayType_3_ZuD = 0x189f;
        public const int PlayType_3_ZuH = 0x18a3;
        public const string sID = "63";

        public SZPL3()
        {
            base.id = 0x3f;
            base.name = "数字排列3";
            base.code = "SZPL3";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x189d) || (PlayType == 0x189e))
            {
                return this.AnalyseScheme_3(Content, PlayType);
            }
            if ((PlayType == 0x189f) || (PlayType == 0x18a0))
            {
                return this.AnalyseScheme_Zu3D_Zu6(Content, PlayType);
            }
            if (PlayType == 0x18a1)
            {
                return this.AnalyseScheme_Zu3F(Content, PlayType);
            }
            if (PlayType == 0x18a2)
            {
                return this.AnalyseScheme_ZhiH(Content, PlayType);
            }
            if (PlayType == 0x18a3)
            {
                return this.AnalyseScheme_ZuH(Content, PlayType);
            }
            return "";
        }

        private string AnalyseScheme_3(string Content, int PlayType)
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
            if (PlayType == 0x189d)
            {
                str2 = @"([\d]){3}";
            }
            else
            {
                str2 = @"(([\d])|([(][\d]{1,10}[)])){3}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_3(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x189d) ? 1 : 2)))
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

        private string AnalyseScheme_ZhiH(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZhiH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
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

        private string AnalyseScheme_Zu3D_Zu6(string Content, int PlayType)
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
            if (PlayType == 0x189f)
            {
                str2 = @"([\d]){3}";
            }
            else
            {
                str2 = @"([\d]){3,10}";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu3D_Zu6(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x189f) ? 1 : 2)))
                    {
                        if (this.FilterRepeated(base.Sort(match.Value)).Length == 2)
                        {
                            if (PlayType != 0x18a0)
                            {
                                str = str + match.Value + "|1\n";
                            }
                        }
                        else
                        {
                            string str4 = str;
                            string[] strArray3 = new string[] { str4, canonicalNumber, "|", strArray2.Length.ToString(), "\n" };
                            str = string.Concat(strArray3);
                        }
                    }
                }
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private string AnalyseScheme_Zu3F(string Content, int PlayType)
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
                    string[] strArray2 = this.ToSingle_Zu3F(match.Value, ref canonicalNumber);
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

        private string AnalyseScheme_ZuH(string Content, int PlayType)
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
            Regex regex = new Regex(@"([\d]){1,2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_ZuH(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
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
            string[] strArray = this.ToSingle_3(Number, ref canonicalNumber);
            return ((strArray != null) && (strArray.Length == 1));
        }

        public override string BuildNumber(int Num)
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < 3; j++)
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
            return ((play_type >= 0x189d) && (play_type <= 0x18a3));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((PlayType == 0x189d) || (PlayType == 0x189e))
            {
                return this.ComputeWin_3(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if ((PlayType == 0x189f) || (PlayType == 0x18a0))
            {
                return this.ComputeWin_Zu3D_Zu6(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            if (PlayType == 0x18a1)
            {
                return this.ComputeWin_Zu3F(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3]);
            }
            if (PlayType == 0x18a2)
            {
                return this.ComputeWin_ZhiH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x18a3)
            {
                return this.ComputeWin_ZuH(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5]);
            }
            return -4.0;
        }

        private double ComputeWin_3(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
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
                string[] strArray2 = this.ToSingle_3(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
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

        private double ComputeWin_ZhiH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
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
                string[] strArray2 = this.ToSingle_ZhiH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (strArray2[j] == WinNumber))
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

        private double ComputeWin_Zu3D_Zu6(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
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
                if (strArray[i].Length >= 3)
                {
                    if (this.FilterRepeated(base.Sort(strArray[i])).Length == 2)
                    {
                        if (base.Sort(strArray[i]) == base.Sort(WinNumber))
                        {
                            num++;
                            num3 += WinMoney1;
                            WinMoneyNoWithTax += WinMoneyNoWithTax1;
                        }
                    }
                    else
                    {
                        string[] strArray2 = this.ToSingle_Zu3D_Zu6(strArray[i], ref canonicalNumber);
                        if ((strArray2 != null) && (strArray2.Length >= 1))
                        {
                            for (int j = 0; j < strArray2.Length; j++)
                            {
                                if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                                {
                                    num2++;
                                    num3 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选3奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            return num3;
        }

        private double ComputeWin_Zu3F(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
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
                string[] strArray2 = this.ToSingle_Zu3F(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
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
                Description = "组选3奖" + num.ToString() + "注。";
            }
            return num2;
        }

        private double ComputeWin_ZuH(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 3)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 3);
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
                string[] strArray2 = this.ToSingle_ZuH(strArray[i], ref canonicalNumber);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        if ((strArray2[j].Length >= 3) && (base.Sort(strArray2[j]) == base.Sort(WinNumber)))
                        {
                            if (this.FilterRepeated(strArray2[j]).Length == 2)
                            {
                                num++;
                                num3 += WinMoney1;
                                WinMoneyNoWithTax += WinMoneyNoWithTax1;
                            }
                            else
                            {
                                num2++;
                                num3 += WinMoney2;
                                WinMoneyNoWithTax += WinMoneyNoWithTax2;
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选3奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            return num3;
        }

        private string ConvertFormatToElectronTicket_DYJ(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string canonicalNumber = "";
            string str2 = "";
            if (((PlayTypeID == 0x189d) || (PlayTypeID == 0x189f)) || ((PlayTypeID == 0x189e) || (PlayTypeID == 0x18a2)))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (PlayTypeID == 0x189d)
                    {
                        str2 = str2 + "1|";
                    }
                    else if (PlayTypeID == 0x189f)
                    {
                        str2 = str2 + "6|";
                    }
                    else if (PlayTypeID == 0x189e)
                    {
                        str2 = str2 + "1|";
                    }
                    else if (PlayTypeID == 0x18a2)
                    {
                        str2 = str2 + "s1|";
                    }
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        if (PlayTypeID == 0x189f)
                        {
                            strArray[i] = base.Sort(strArray[i]);
                        }
                        str2 = str2 + strArray[i].Substring(j, 1) + ",";
                    }
                    if (str2.EndsWith(","))
                    {
                        str2 = str2.Substring(0, str2.Length - 1);
                    }
                    str2 = str2 + ";\n";
                }
                if (str2.EndsWith("\n"))
                {
                    str2 = str2.Substring(0, str2.Length - 1);
                }
            }
            if (PlayTypeID == 0x18a0)
            {
                string[] singleNumber = this.ToSingle_Zu3D_Zu6(Number, ref canonicalNumber);
                str2 = "F6|" + this.GetFormateOfElectronTicket(singleNumber) + ";";
            }
            if (PlayTypeID == 0x18a1)
            {
                string[] strArray3 = this.ToSingle_Zu3F(Number, ref canonicalNumber);
                str2 = "F3|" + this.GetFormateOfElectronTicket(strArray3) + ";";
            }
            if (PlayTypeID == 0x18a3)
            {
                string[] strArray4 = this.ToSingle_ZuH(Number, ref canonicalNumber);
                str2 = "6|" + this.GetFormateOfElectronTicket(strArray4) + ";";
            }
            return str2;
        }

        private string ConvertFormatToElectronTicket_HPSD(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string canonicalNumber = "";
            string formateOfElectronTicket = "";
            if (((PlayTypeID == 0x189d) || (PlayTypeID == 0x189f)) || ((PlayTypeID == 0x189e) || (PlayTypeID == 0x18a2)))
            {
                string[] strArray = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < strArray[i].Length; j++)
                    {
                        if (PlayTypeID == 0x189f)
                        {
                            strArray[i] = base.Sort(strArray[i]);
                        }
                        formateOfElectronTicket = formateOfElectronTicket + strArray[i].Substring(j, 1) + ",";
                    }
                    if (formateOfElectronTicket.EndsWith(","))
                    {
                        formateOfElectronTicket = formateOfElectronTicket.Substring(0, formateOfElectronTicket.Length - 1);
                    }
                    formateOfElectronTicket = formateOfElectronTicket + "\n";
                }
                if (formateOfElectronTicket.EndsWith("\n"))
                {
                    formateOfElectronTicket = formateOfElectronTicket.Substring(0, formateOfElectronTicket.Length - 1);
                }
            }
            if (PlayTypeID == 0x18a0)
            {
                string[] singleNumber = this.ToSingle_Zu3D_Zu6(Number, ref canonicalNumber);
                formateOfElectronTicket = this.GetFormateOfElectronTicket(singleNumber);
            }
            if (PlayTypeID == 0x18a1)
            {
                string[] strArray3 = this.ToSingle_Zu3F(Number, ref canonicalNumber);
                formateOfElectronTicket = this.GetFormateOfElectronTicket(strArray3);
            }
            if (PlayTypeID == 0x18a3)
            {
                string[] strArray4 = this.ToSingle_ZuH(Number, ref canonicalNumber);
                formateOfElectronTicket = this.GetFormateOfElectronTicket(strArray4);
            }
            return formateOfElectronTicket;
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

        private string GetFormateOfElectronTicket(string[] SingleNumber)
        {
            string str = "";
            string[] strArray = new string[SingleNumber.Length];
            for (int i = 0; i < SingleNumber.Length; i++)
            {
                for (int j = 0; j < SingleNumber[i].Length; j++)
                {
                    string[] strArray2;
                    IntPtr ptr;
                    (strArray2 = strArray)[(int)(ptr = (IntPtr)i)] = strArray2[(int)ptr] + SingleNumber[i].Substring(j, 1) + ",";
                }
                str = str + strArray[i].Substring(0, strArray[i].Length - 1) + "\n";
            }
            if (str.EndsWith("\n"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x189d, "排列3直选单式"), new PlayType(0x189e, "排列3直选复式"), new PlayType(0x189f, "排列3组选单式"), new PlayType(0x18a0, "排列3组选6复式"), new PlayType(0x18a1, "排列3组选3复式"), new PlayType(0x18a2, "排列3直选和值"), new PlayType(0x18a3, "排列3组选和值") };
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
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CR_YTCII2_H(numbers);
                        }
                        return this.GetPrintKeyList_CR_YTCII2_ZhiD(numbers);

                    case "TCBJYTD":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_TCBJYTD_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TCBJYTD_H(numbers);
                        }
                        return this.GetPrintKeyList_TCBJYTD_ZhiD(numbers);

                    case "TGAMPOS4000":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_TGAMPOS4000_H(numbers);
                        }
                        return this.GetPrintKeyList_TGAMPOS4000_ZhiD(numbers);

                    case "CP86":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_CP86_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_CP86_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CP86_H(numbers);
                        }
                        return this.GetPrintKeyList_CP86_ZhiD(numbers);

                    case "MODEL_4000":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_MODEL_4000_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_MODEL_4000_H(numbers);
                        }
                        return this.GetPrintKeyList_MODEL_4000_ZhiD(numbers);

                    case "CORONISTPT":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_CORONISTPT_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_CORONISTPT_H(numbers);
                        }
                        return this.GetPrintKeyList_CORONISTPT_ZhiD(numbers);

                    case "RS6500":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_RS6500_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_RS6500_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_RS6500_H(numbers);
                        }
                        return this.GetPrintKeyList_RS6500_ZhiD(numbers);

                    case "ks230":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_ks230_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_ks230_ZhiD(numbers);
                            }
                            if ((PlayTypeID != 0x18a2) && (PlayTypeID != 0x18a3))
                            {
                                break;
                            }
                            return this.GetPrintKeyList_ks230_H(numbers);
                        }
                        return this.GetPrintKeyList_ks230_ZhiD(numbers);

                    case "LA-600A":
                        if (PlayTypeID != 0x189d)
                        {
                            if (PlayTypeID == 0x189e)
                            {
                                return this.GetPrintKeyList_LA_600A_3_ZhiF(numbers);
                            }
                            if (PlayTypeID == 0x189f)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a1)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if (PlayTypeID == 0x18a0)
                            {
                                return this.GetPrintKeyList_LA_600A_ZhiD(numbers);
                            }
                            if ((PlayTypeID == 0x18a2) || (PlayTypeID == 0x18a3))
                            {
                                return this.GetPrintKeyList_LA_600A_H(numbers);
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

        public override JTicket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x189d)
            {
                return this.ToElectronicTicket_DYJ_Zhi_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0x189e) || (PlayTypeID == 0x18a2))
            {
                return this.ToElectronicTicket_DYJ_Zhi_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x189f)
            {
                return this.ToElectronicTicket_DYJ_Zu_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (((PlayTypeID != 0x18a1) && (PlayTypeID != 0x18a0)) && (PlayTypeID != 0x18a3))
            {
                return null;
            }
            return this.ToElectronicTicket_DYJ_Zu_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
        }

        private JTicket[] ToElectronicTicket_DYJ_Zhi_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zhi_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
            string canonicalNumber = "";
            ArrayList list = new ArrayList();
            if (PlayTypeID == 0x189e)
            {
                for (int k = 0; k < strArray.Length; k++)
                {
                    string[] strArray2 = this.ToSingle_3(strArray[k].Split(new char[] { '|' })[0], ref canonicalNumber);
                    for (int m = 0; m < strArray2.Length; m++)
                    {
                        list.Add(strArray2[m]);
                    }
                }
            }
            if (PlayTypeID == 0x18a2)
            {
                for (int n = 0; n < strArray.Length; n++)
                {
                    string[] strArray3 = this.ToSingle_ZhiH(strArray[n].Split(new char[] { '|' })[0], ref canonicalNumber);
                    for (int num4 = 0; num4 < strArray3.Length; num4++)
                    {
                        list.Add(strArray3[num4]);
                    }
                }
            }
            ArrayList list2 = new ArrayList();
            Money = 0.0;
            int num5 = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num5 = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num5 = Multiple / MaxMultiple;
            }
            int multiple = 1;
            double num7 = 0.0;
            for (int i = 1; i < (num5 + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                for (int num9 = 0; num9 < list.Count; num9 += 5)
                {
                    string number = "";
                    num7 = 0.0;
                    for (int num10 = 0; num10 < 5; num10++)
                    {
                        if (((num9 + num10) < list.Count) && (list[num9 + num10].ToString().Length >= 2))
                        {
                            number = number + list[num9 + num10].ToString() + "\n";
                            num7 = 2 * (num10 + 1);
                        }
                    }
                    Money += num7 * multiple;
                    list2.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num7 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list2.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list2[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zu_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_DYJ_Zu_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_DYJ(PlayTypeID, number), multiple, num3 * multiple));
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
            if (PlayTypeID == 0x189d)
            {
                return this.ToElectronicTicket_HPSD_Zhi_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if ((PlayTypeID == 0x189e) || (PlayTypeID == 0x18a2))
            {
                return this.ToElectronicTicket_HPSD_Zhi_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x189f)
            {
                return this.ToElectronicTicket_HPSD_Zu_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (((PlayTypeID != 0x18a1) && (PlayTypeID != 0x18a0)) && (PlayTypeID != 0x18a3))
            {
                return null;
            }
            return this.ToElectronicTicket_HPSD_Zu_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
        }

        private JTicket[] ToElectronicTicket_HPSD_Zhi_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_Zhi_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
            string canonicalNumber = "";
            ArrayList list = new ArrayList();
            if (PlayTypeID == 0x189e)
            {
                for (int k = 0; k < strArray.Length; k++)
                {
                    string[] strArray2 = this.ToSingle_3(strArray[k].Split(new char[] { '|' })[0], ref canonicalNumber);
                    for (int m = 0; m < strArray2.Length; m++)
                    {
                        list.Add(strArray2[m]);
                    }
                }
            }
            if (PlayTypeID == 0x18a2)
            {
                for (int n = 0; n < strArray.Length; n++)
                {
                    string[] strArray3 = this.ToSingle_ZhiH(strArray[n].Split(new char[] { '|' })[0], ref canonicalNumber);
                    for (int num4 = 0; num4 < strArray3.Length; num4++)
                    {
                        list.Add(strArray3[num4]);
                    }
                }
            }
            ArrayList list2 = new ArrayList();
            Money = 0.0;
            int num5 = 0;
            if ((Multiple % MaxMultiple) != 0)
            {
                num5 = ((Multiple - (Multiple % MaxMultiple)) / MaxMultiple) + 1;
            }
            else
            {
                num5 = Multiple / MaxMultiple;
            }
            int multiple = 1;
            double num7 = 0.0;
            for (int i = 1; i < (num5 + 1); i++)
            {
                if ((i * MaxMultiple) < Multiple)
                {
                    multiple = MaxMultiple;
                }
                else
                {
                    multiple = Multiple - ((i - 1) * MaxMultiple);
                }
                for (int num9 = 0; num9 < list.Count; num9 += 5)
                {
                    string number = "";
                    num7 = 0.0;
                    for (int num10 = 0; num10 < 5; num10++)
                    {
                        if (((num9 + num10) < list.Count) && (list[num9 + num10].ToString().Length >= 2))
                        {
                            number = number + list[num9 + num10].ToString() + "\n";
                            num7 = 2 * (num10 + 1);
                        }
                    }
                    Money += num7 * multiple;
                    list2.Add(new JTicket(0xc9, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num7 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list2.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list2[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_Zu_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSD_Zu_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0xca, this.ConvertFormatToElectronTicket_HPSD(PlayTypeID, number), multiple, num3 * multiple));
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
            if ((PlayType == 0x189d) || (PlayType == 0x189e))
            {
                return this.ToSingle_3(Number, ref CanonicalNumber);
            }
            if ((PlayType == 0x189f) || (PlayType == 0x18a0))
            {
                return this.ToSingle_Zu3D_Zu6(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x18a1)
            {
                return this.ToSingle_Zu3F(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x18a2)
            {
                return this.ToSingle_ZhiH(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x18a3)
            {
                return this.ToSingle_ZuH(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_3(string Number, ref string CanonicalNumber)
        {
            string[] strArray = new string[3];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 3; i++)
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
                        list.Add(str3);
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

        private string[] ToSingle_ZhiH(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            if ((num < 0) || (num > 0x1b))
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = num.ToString();
            ArrayList list = new ArrayList();
            for (int i = 0; i <= 9; i++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    for (int m = 0; m <= 9; m++)
                    {
                        if (((i + k) + m) == num)
                        {
                            list.Add(i.ToString() + k.ToString() + m.ToString());
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu3D_Zu6(string Number, ref string CanonicalNumber)
        {
            CanonicalNumber = this.FilterRepeated(Number.Trim());
            if (CanonicalNumber.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = Number;
            char[] chArray = CanonicalNumber.ToCharArray();
            ArrayList list = new ArrayList();
            int length = chArray.Length;
            if (length == 2)
            {
                for (int j = 0; j < (length - 1); j++)
                {
                    for (int k = j + 1; k < length; k++)
                    {
                        list.Add(chArray[j].ToString() + chArray[j].ToString() + chArray[k].ToString());
                        list.Add(chArray[j].ToString() + chArray[k].ToString() + chArray[k].ToString());
                    }
                }
            }
            else
            {
                for (int m = 0; m < (length - 2); m++)
                {
                    for (int n = m + 1; n < (length - 1); n++)
                    {
                        for (int num6 = n + 1; num6 < length; num6++)
                        {
                            list.Add(chArray[m].ToString() + chArray[n].ToString() + chArray[num6].ToString());
                        }
                    }
                }
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_Zu3F(string Number, ref string CanonicalNumber)
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
                    list.Add(chArray[i].ToString() + chArray[i].ToString() + chArray[k].ToString());
                    list.Add(chArray[i].ToString() + chArray[k].ToString() + chArray[k].ToString());
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] ToSingle_ZuH(string sBill, ref string CanonicalNumber)
        {
            int num = _Convert.StrToInt(sBill, -1);
            CanonicalNumber = "";
            ArrayList list = new ArrayList();
            if ((num < 1) || (num > 0x1a))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i <= 9; i++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    if ((i != k) && (((i + i) + k) == num))
                    {
                        list.Add(i.ToString() + i.ToString() + k.ToString());
                    }
                }
            }
            if ((num >= 3) && (num <= 0x18))
            {
                for (int m = 0; m <= 7; m++)
                {
                    for (int n = m + 1; n <= 8; n++)
                    {
                        for (int num6 = n + 1; num6 <= 9; num6++)
                        {
                            if (((m + n) + num6) == num)
                            {
                                list.Add(m.ToString() + n.ToString() + num6.ToString());
                            }
                        }
                    }
                }
            }
            CanonicalNumber = num.ToString();
            if (list.Count == 0)
            {
                return null;
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
