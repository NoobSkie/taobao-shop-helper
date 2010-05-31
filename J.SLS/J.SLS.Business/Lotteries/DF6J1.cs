using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class DF6J1 : LotteryBase
    {
        public const string Code = "DF6J1";
        public const int ID = 0x3a;
        public const double MaxMoney = 20000.0;
        public const string Name = "东方6+1";
        public const int PlayType_D = 0x16a9;
        public const int PlayType_F = 0x16aa;
        public const string sID = "58";

        public DF6J1()
        {
            base.id = 0x3a;
            base.name = "东方6+1";
            base.code = "DF6J1";
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
            if (PlayType == 0x16a9)
            {
                str2 = @"(\d){6}[+][鼠牛虎兔龙蛇马羊猴鸡狗猪]";
            }
            else
            {
                str2 = @"((\d)|([(]\d{1,10}[)])){6}[+]([鼠牛虎兔龙蛇马羊猴鸡狗猪]{1,12})";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x16a9) ? 1 : 2))) && (strArray2.Length <= 10000.0))
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
            Regex regex = new Regex(@"([\d]){6}[+][鼠牛虎兔龙蛇马羊猴鸡狗猪]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x16a9);
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
                builder.Append((str + "+" + "鼠牛虎兔龙蛇马羊猴鸡狗猪"[random.Next(0, 12)].ToString()).Trim() + "\n");
            }
            string str2 = builder.ToString();
            return str2.Substring(0, str2.Length - 1);
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x16a9) && (play_type <= 0x16aa));
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
                                        for (startIndex = 0; startIndex <= 3; startIndex++)
                                        {
                                            if (strArray2[j].Substring(startIndex, 3) == WinNumber.Substring(startIndex, 3))
                                            {
                                                num5++;
                                                num7 += WinMoneyList[8];
                                                WinMoneyNoWithTax += WinMoneyList[9];
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag && (strArray2[j].Substring(7, 1) == WinNumber.Substring(7, 1)))
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
            if (num > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
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
                Description = "六等奖" + num6.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num7;
        }

        private string ConvertFormatToElectronTicket_HPJX(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[7];
            string str = "";
            if ((PlayTypeID == 0x16a9) || (PlayTypeID == 0x16aa))
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray2.Length; i++)
                {
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))[+](?<L6>([鼠牛虎兔龙蛇马羊猴鸡狗猪]+))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[i]);
                    for (int j = 0; j < 6; j++)
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
                    strArray[6] = match.Groups["L6"].ToString().Trim();
                    if (strArray[6] == "")
                    {
                        return "";
                    }
                    if (strArray[6].Length > 0)
                    {
                        strArray[6] = this.FilterRepeated_SX(strArray[6]);
                        if (strArray[6] == "")
                        {
                            return "";
                        }
                        str = str + "#";
                        for (int k = 0; k < strArray[6].Length; k++)
                        {
                            str = str + strArray[6].Substring(k, 1).Replace("鼠", "01").Replace("牛", "02").Replace("虎", "03").Replace("兔", "04").Replace("龙", "05").Replace("蛇", "06").Replace("马", "07").Replace("羊", "08").Replace("猴", "09").Replace("鸡", "10").Replace("狗", "11").Replace("猪", "12") + ",";
                        }
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

        private string ConvertFormatToElectronTicket_HPSH(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string[] strArray = new string[7];
            string str = "";
            if ((PlayTypeID == 0x16a9) || (PlayTypeID == 0x16aa))
            {
                string[] strArray2 = Number.Split(new char[] { '\n' });
                for (int i = 0; i < strArray2.Length; i++)
                {
                    Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))[+](?<L6>([鼠牛虎兔龙蛇马羊猴鸡狗猪]+))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(strArray2[i]);
                    for (int j = 0; j < 6; j++)
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
                    strArray[6] = match.Groups["L6"].ToString().Trim();
                    if (strArray[6] == "")
                    {
                        return "";
                    }
                    if (strArray[6].Length > 0)
                    {
                        strArray[6] = this.FilterRepeated_SX(strArray[6]);
                        if (strArray[6] == "")
                        {
                            return "";
                        }
                        str = str + "#";
                        for (int k = 0; k < strArray[6].Length; k++)
                        {
                            str = str + strArray[6].Substring(k, 1).Replace("鼠", "01").Replace("牛", "02").Replace("虎", "03").Replace("兔", "04").Replace("龙", "05").Replace("蛇", "06").Replace("马", "07").Replace("羊", "08").Replace("猴", "09").Replace("鸡", "10").Replace("狗", "11").Replace("猪", "12") + ",";
                        }
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

        private string FilterRepeated_SX(string NumberPart)
        {
            string str = "";
            for (int i = 0; i < NumberPart.Length; i++)
            {
                if ((str.IndexOf(NumberPart.Substring(i, 1)) == -1) && ("鼠牛虎兔龙蛇马羊猴鸡狗猪".IndexOf(NumberPart.Substring(i, 1)) >= 0))
                {
                    str = str + NumberPart.Substring(i, 1);
                }
            }
            return str;
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x16a9, "单式"), new PlayType(0x16aa, "复式") };
        }

        private string HPSH_ConvertFormatToElectronTicket(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            return Number.Replace(",", "").Replace("#01", "+鼠").Replace("#02", "+牛").Replace("#03", "+虎").Replace("#04", "+兔").Replace("#05", "+龙").Replace("#06", "+蛇").Replace("#07", "+马").Replace("#08", "+羊").Replace("#09", "+猴").Replace("#10", "+鸡").Replace("#11", "+狗").Replace("#12", "+猪");
        }

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            foreach (string str2 in this.HPSH_ConvertFormatToElectronTicket(PlayTypeID, Number).Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, " ");
        }

        public override JTicket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x16a9)
            {
                return this.ToElectronicTicket_HPJX_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x16aa)
            {
                return this.ToElectronicTicket_HPJX_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPJX_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPJX_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        public override JTicket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x16a9)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x16aa)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            return null;
        }

        private JTicket[] ToElectronicTicket_HPSH_D(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x65, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
                }
            }
            JTicket[] ticketArray = new JTicket[list.Count];
            for (int j = 0; j < ticketArray.Length; j++)
            {
                ticketArray[j] = (JTicket)list[j];
            }
            return ticketArray;
        }

        private JTicket[] ToElectronicTicket_HPSH_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
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
                    list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, number), multiple, num3 * multiple));
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
            string[] strArray = new string[7];
            CanonicalNumber = "";
            Match match = new Regex(@"(?<L0>(\d)|([(][\d]+?[)]))(?<L1>(\d)|([(][\d]+?[)]))(?<L2>(\d)|([(][\d]+?[)]))(?<L3>(\d)|([(][\d]+?[)]))(?<L4>(\d)|([(][\d]+?[)]))(?<L5>(\d)|([(][\d]+?[)]))[+](?<L6>([鼠牛虎兔龙蛇马羊猴鸡狗猪]+))", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            for (int i = 0; i < 6; i++)
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
            strArray[6] = match.Groups["L6"].ToString().Trim();
            if (strArray[6] == "")
            {
                CanonicalNumber = "";
                return null;
            }
            if (strArray[6].Length > 1)
            {
                strArray[6] = this.FilterRepeated_SX(strArray[6]);
                if (strArray[6] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
            }
            CanonicalNumber = CanonicalNumber + "+" + strArray[6];
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
                                        string str7 = str6 + "+" + strArray[6][num8].ToString();
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
