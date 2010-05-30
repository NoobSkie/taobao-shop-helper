using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class TTCX4 : LotteryBase
    {
        public const string Code = "TTCX4";
        public const int ID = 60;
        public const double MaxMoney = 10000.0;
        public const string Name = "天天彩选4";
        public const int PlayType_ZhiD = 0x1771;
        public const int PlayType_ZhiF = 0x1772;
        public const int PlayType_ZuD = 0x1773;
        public const string sID = "60";

        public TTCX4()
        {
            base.id = 60;
            base.name = "天天彩选4";
            base.code = "TTCX4";
        }

        public override string AnalyseScheme(string Content, int PlayType)
        {
            if ((PlayType == 0x1771) || (PlayType == 0x1772))
            {
                return this.AnalyseScheme_Zhi(Content, PlayType);
            }
            if (PlayType == 0x1773)
            {
                return this.AnalyseScheme_Zu(Content, PlayType);
            }
            return "";
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
            if (PlayType == 0x1771)
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
                    string[] strArray2 = this.ToSingle_Zhi(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1771) ? 1 : 2)))
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

        private string AnalyseScheme_Zu(string Content, int PlayType)
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
            string pattern = @"(([\d])|([(][\d]{2,10}[)])){4}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x1773) ? 1 : 2)))
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

        private string AnalyseSchemeToElectronicTicket_Zu(string Content, int PlayType)
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
            string pattern = @"(([\d])|([(][\d]{1,10}[)])){4}";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle_Zu(match.Value, ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            str = str + strArray2[j] + "|1\n";
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
            return ((play_type >= 0x1771) && (play_type <= 0x1773));
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            if ((WinMoneyList == null) || (WinMoneyList.Length < 10))
            {
                return -3.0;
            }
            if ((PlayType == 0x1771) || (PlayType == 0x1772))
            {
                return this.ComputeWin_Zhi(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1]);
            }
            if (PlayType == 0x1773)
            {
                return this.ComputeWin_Zu(Number, WinNumber, ref Description, ref WinMoneyNoWithTax, WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9]);
            }
            return -4.0;
        }

        private double ComputeWin_Zhi(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1)
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
            int num = 0;
            double num2 = 0.0;
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
                        if ((strArray2[j].Length >= 4) && (strArray2[j] == WinNumber))
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

        private double ComputeWin_Zu(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 4)
            {
                return -1.0;
            }
            WinNumber = WinNumber.Substring(0, 4);
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
            int num3 = 0;
            int num4 = 0;
            double num5 = 0.0;
            WinMoneyNoWithTax = 0.0;
            Description = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                if (strArray[i].Length >= 4)
                {
                    string[] strArray2 = this.ToSingle_Zu(strArray[i], ref canonicalNumber);
                    if ((strArray2 != null) && (strArray2.Length >= 1))
                    {
                        for (int j = 0; j < strArray2.Length; j++)
                        {
                            if ((strArray2[j].Length >= 4) && ((base.Sort(strArray2[j]) == base.Sort(WinNumber)) || base.Sort(strArray2[j]).Equals(base.Sort(WinNumber))))
                            {
                                if ((this.FilterRepeated(base.Sort(strArray2[j])).Length == 2) && (base.Sort(strArray2[j]).Substring(1, 1) == base.Sort(strArray2[j]).Substring(2, 1)))
                                {
                                    num++;
                                    num5 += WinMoney1;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                                }
                                if ((this.FilterRepeated(base.Sort(strArray2[j])).Length == 2) && (base.Sort(strArray2[j]).Substring(1, 1) != base.Sort(strArray2[j]).Substring(2, 1)))
                                {
                                    num2++;
                                    num5 += WinMoney2;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                                }
                                if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 3)
                                {
                                    num3++;
                                    num5 += WinMoney3;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                                }
                                if (this.FilterRepeated(base.Sort(strArray2[j])).Length == 4)
                                {
                                    num4++;
                                    num5 += WinMoney4;
                                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                                }
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Description = "组选4奖" + num.ToString() + "注。";
            }
            if (num2 > 0)
            {
                Description = "组选6奖" + num2.ToString() + "注。";
            }
            if (num3 > 0)
            {
                Description = "组选12奖" + num3.ToString() + "注。";
            }
            if (num4 > 0)
            {
                Description = "组选24奖" + num4.ToString() + "注。";
            }
            return num5;
        }

        private string ConvertFormatToElectronTicket_HPSH(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[4];
            string str = "";
            if (((PlayTypeID == 0x1771) || (PlayTypeID == 0x1773)) || (PlayTypeID == 0x1772))
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray2.Length; i++)
                {
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[i]);
                    for (int j = 0; j < 4; j++)
                    {
                        strArray[j] = match.Groups["L" + j.ToString()].ToString().Trim();
                        if (strArray[j] == "")
                        {
                            return "";
                        }
                        if (strArray[j].Length > 1)
                        {
                            strArray[j] = strArray[j].Substring(1, strArray[j].Length - 2);
                            if (strArray[j].Length > 1)
                            {
                                strArray[j] = this.FilterRepeated(strArray[j]);
                            }
                            if (strArray[j] == "")
                            {
                                return "";
                            }
                        }
                        str = str + strArray[j] + ",";
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
            return new PlayType[] { new PlayType(0x1771, "直选单式"), new PlayType(0x1772, "直选复式"), new PlayType(0x1773, "组选单复式") };
        }

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            if (((PlayTypeID != 0x1771) && (PlayTypeID != 0x1772)) && (PlayTypeID != 0x1773))
            {
                return "";
            }
            return this.HPSH_ToElectronicTicket(PlayTypeID, Number, ref TicketNumber, ref NewPlayTypeID);
        }

        private string HPSH_ToElectronicTicket_D(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            Number = Number.Trim();
            string str = "";
            foreach (string str2 in Number.Split(new char[] { ',' }))
            {
                if (str2.Length > 1)
                {
                    str = str + "(" + str2 + ")";
                }
                else
                {
                    str = str + str2;
                }
            }
            NewPlayTypeID = PlayTypeID;
            return str;
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override Ticket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x1771)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1772)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x1773)
            {
                return this.ToElectronicTicket_HPSH_Zu(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private Ticket[] ToElectronicTicket_HPSH_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xc9, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new Ticket(0xd0, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            Ticket[] ticketArray = new Ticket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (Ticket)list[j];
            }
            return ticketArray;
        }

        private Ticket[] ToElectronicTicket_HPSH_Zu(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_Zu(Number, PlayTypeID).Split(new char[] { '\n' });
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
                    list.Add(new Ticket(0xca, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
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
            if ((PlayType == 0x1771) || (PlayType == 0x1772))
            {
                return this.ToSingle_Zhi(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x1773)
            {
                return this.ToSingle_Zu(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_Zhi(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_Zu(string Number, ref string CanonicalNumber)
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
            ArrayList list2 = new ArrayList();
            for (int j = 0; j < strArray[0].Length; j++)
            {
                string str = strArray[0][j].ToString();
                for (int num3 = 0; num3 < strArray[1].Length; num3++)
                {
                    string str2 = str + strArray[1][num3].ToString();
                    for (int num4 = 0; num4 < strArray[2].Length; num4++)
                    {
                        string str3 = str2 + strArray[2][num4].ToString();
                        for (int num5 = 0; num5 < strArray[3].Length; num5++)
                        {
                            string str4 = str3 + strArray[3][num5].ToString();
                            list.Add(str4);
                        }
                    }
                }
            }
            for (int k = 0; k < list.Count; k++)
            {
                if (this.FilterRepeated(base.Sort(list[k].ToString())).Length == 1)
                {
                    list.Remove(list[k]);
                }
            }
            for (int m = 0; m < list.Count; m++)
            {
                list[m] = base.Sort(list[m].ToString());
            }
            for (int n = 0; n < list.Count; n++)
            {
                if (list2.IndexOf(list[n]) == -1)
                {
                    list2.Add(list[n]);
                }
            }
            string[] strArray2 = new string[list2.Count];
            for (int num9 = 0; num9 < list2.Count; num9++)
            {
                strArray2[num9] = list2[num9].ToString();
            }
            return strArray2;
        }
    }
}
