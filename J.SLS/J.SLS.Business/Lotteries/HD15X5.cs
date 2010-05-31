using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class HD15X5 : LotteryBase
    {
        public const string Code = "HD15X5";
        public const int ID = 0x3b;
        public const double MaxMoney = 6006.0;
        public const string Name = "华东15选5";
        public const int PlayType_D = 0x170d;
        public const int PlayType_DT = 0x170f;
        public const int PlayType_F = 0x170e;
        public const string sID = "59";

        public HD15X5()
        {
            base.id = 0x3b;
            base.name = "华东15选5";
            base.code = "HD15X5";
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
            if (PlayType == 0x170d)
            {
                str2 = @"(\d\d\s){4}\d\d";
            }
            else if (PlayType == 0x170e)
            {
                str2 = @"(\d\d\s){4,14}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){1,4}(,)(\s)(\d\d\s){1,13}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x170d) ? 1 : 2))) && (strArray2.Length <= 3003.0))
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

        private string AnalyseSchemeToElectronicTicket_F(string Content, int PlayType)
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
            if (PlayType == 0x170d)
            {
                str2 = @"(\d\d\s){4}\d\d";
            }
            else if (PlayType == 0x170e)
            {
                str2 = @"(\d\d\s){4,14}\d\d";
            }
            else
            {
                str2 = @"(\d\d\s){1,4}(,)(\s)(\d\d\s){1,13}\d\d";
            }
            Regex regex = new Regex(str2, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
                    if (((strArray2 != null) && (strArray2.Length >= ((PlayType == 0x170d) ? 1 : 2))) && (strArray2.Length <= 3003.0))
                    {
                        if ((PlayType == 0x170e) && (strArray2.Length > 0x507))
                        {
                            if (strArray2.Length >= 1)
                            {
                                for (int j = 0; j < strArray2.Length; j++)
                                {
                                    str = str + strArray2[j] + "|1\n";
                                }
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

        public override bool AnalyseWinNumber(string Number)
        {
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Number, ref canonicalNumber, 0x170d);
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
            return ((play_type >= 0x170d) && (play_type <= 0x170f));
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
                                        num2++;
                                        num4 += WinMoneyList[2];
                                        WinMoneyNoWithTax += WinMoneyList[3];
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

        private string ConvertFormatToElectronTicket_HPJX(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID == 0x170d) || (PlayTypeID == 0x170e))
            {
                str = Number.Replace(" ", ",");
            }
            if (PlayTypeID == 0x170f)
            {
                str = Number.Replace(" ", ",").Replace(",,,", "#00#");
            }
            return str;
        }

        private string ConvertFormatToElectronTicket_HPSH(int PlayTypeID, string Number)
        {
            Number = Number.Trim();
            string str = "";
            if ((PlayTypeID == 0x170d) || (PlayTypeID == 0x170e))
            {
                str = Number.Replace(" ", ",");
            }
            if (PlayTypeID == 0x170f)
            {
                str = Number.Replace(" ", ",").Replace(",,,", "#00#");
            }
            return str;
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

        private string[] FilterRepeated(string[] NumberPart1, string[] NumberPart2)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart2.Length; i++)
            {
                al.Add(NumberPart2[i]);
            }
            ArrayList list2 = new ArrayList();
            for (int j = 0; j < NumberPart1.Length; j++)
            {
                int ball = _Convert.StrToInt(NumberPart1[j], -1);
                if (!base.isExistBall(al, ball))
                {
                    list2.Add(NumberPart1[j]);
                }
            }
            LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
            list2.Sort(comparer);
            string[] strArray = new string[list2.Count];
            for (int k = 0; k < list2.Count; k++)
            {
                strArray[k] = list2[k].ToString().PadLeft(2, '0');
            }
            return strArray;
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x170d, "单式"), new PlayType(0x170e, "复式"), new PlayType(0x170f, "胆拖") };
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
            if ((((str = LotteryMachine) == null) || !(str == "FCR8000")) || ((PlayTypeID != 0x170d) && (PlayTypeID != 0x170e)))
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

        public override string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            TicketNumber = "";
            Number = Number.Trim();
            foreach (string str2 in Number.Replace(",", " ").Split(new char[] { '\n' }))
            {
                TicketNumber = TicketNumber + str2 + "\n";
            }
            NewPlayTypeID = PlayTypeID;
            return "";
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

        public override JTicket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x170d)
            {
                return this.ToElectronicTicket_HPJX_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x170e)
            {
                return this.ToElectronicTicket_HPJX_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x170f)
            {
                return this.ToElectronicTicket_HPJX_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
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

        private JTicket[] ToElectronicTicket_HPJX_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                if (strArray.Length > 0x27)
                {
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
                else
                {
                    for (int n = 0; n < strArray.Length; n++)
                    {
                        string str2 = "";
                        num3 = 0.0;
                        str2 = strArray[n].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[n].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x67, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, str2), multiple, num3 * multiple));
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

        private JTicket[] ToElectronicTicket_HPJX_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                if (strArray.Length > 0x27)
                {
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
                else
                {
                    for (int n = 0; n < strArray.Length; n++)
                    {
                        string str2 = "";
                        num3 = 0.0;
                        str2 = strArray[n].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[n].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPJX(PlayTypeID, str2), multiple, num3 * multiple));
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

        public override JTicket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            if (PlayTypeID == 0x170d)
            {
                return this.ToElectronicTicket_HPSH_D(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x170e)
            {
                return this.ToElectronicTicket_HPSH_F(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
            }
            if (PlayTypeID == 0x170f)
            {
                return this.ToElectronicTicket_HPSH_DT(PlayTypeID, Number, Multiple, MaxMultiple, ref Money);
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

        private JTicket[] ToElectronicTicket_HPSH_DT(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                if (strArray.Length > 0x27)
                {
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
                else
                {
                    for (int n = 0; n < strArray.Length; n++)
                    {
                        string str2 = "";
                        num3 = 0.0;
                        str2 = strArray[n].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[n].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x67, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, str2), multiple, num3 * multiple));
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

        private JTicket[] ToElectronicTicket_HPSH_F(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            string[] strArray = this.AnalyseSchemeToElectronicTicket_F(Number, PlayTypeID).Split(new char[] { '\n' });
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
                if (strArray.Length > 0x27)
                {
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
                else
                {
                    for (int n = 0; n < strArray.Length; n++)
                    {
                        string str2 = "";
                        num3 = 0.0;
                        str2 = strArray[n].ToString().Split(new char[] { '|' })[0];
                        num3 += 2.0 * double.Parse(strArray[n].ToString().Split(new char[] { '|' })[1]);
                        Money += num3 * multiple;
                        list.Add(new JTicket(0x66, this.ConvertFormatToElectronTicket_HPSH(PlayTypeID, str2), multiple, num3 * multiple));
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
            if (PlayType == 0x170d)
            {
                return this.ToSingle_DF(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x170e)
            {
                return this.ToSingle_DF(Number, ref CanonicalNumber);
            }
            if (PlayType == 0x170f)
            {
                return this.ToSingle_DT(Number, ref CanonicalNumber);
            }
            return null;
        }

        private string[] ToSingle_DF(string Number, ref string CanonicalNumber)
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

        private string[] ToSingle_DT(string Number, ref string CanonicalNumber)
        {
            string[] strArray = Number.Split(new char[] { ',' });
            CanonicalNumber = "";
            if (strArray.Length != 2)
            {
                CanonicalNumber = "";
                return null;
            }
            string[] strArray2 = this.FilterRepeated(strArray[0].Trim().Split(new char[] { ' ' }));
            string[] strArray3 = this.FilterRepeated(strArray[1].Trim().Split(new char[] { ' ' }));
            string[] strArray4 = this.FilterRepeated(strArray2, strArray3);
            if ((((strArray4.Length + strArray3.Length) < 5) || (strArray4.Length < 1)) || (((strArray4.Length > 4) || (strArray3.Length < 2)) || (strArray3.Length > 14)))
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; i < strArray4.Length; i++)
            {
                CanonicalNumber = CanonicalNumber + strArray4[i] + " ";
            }
            CanonicalNumber = CanonicalNumber + ", ";
            for (int j = 0; j < strArray3.Length; j++)
            {
                CanonicalNumber = CanonicalNumber + strArray3[j] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            ArrayList list = new ArrayList();
            int length = strArray4.Length;
            int num4 = strArray3.Length;
            switch (length)
            {
                case 1:
                    for (int m = 0; m < (num4 - 3); m++)
                    {
                        for (int n = m + 1; n < (num4 - 2); n++)
                        {
                            for (int num7 = n + 1; num7 < (num4 - 1); num7++)
                            {
                                for (int num8 = num7 + 1; num8 < num4; num8++)
                                {
                                    list.Add(strArray4[0].ToString() + " " + strArray3[m].ToString() + " " + strArray3[n].ToString() + " " + strArray3[num7].ToString() + " " + strArray3[num8].ToString());
                                }
                            }
                        }
                    }
                    break;

                case 2:
                    for (int num9 = 0; num9 < (num4 - 2); num9++)
                    {
                        for (int num10 = num9 + 1; num10 < (num4 - 1); num10++)
                        {
                            for (int num11 = num10 + 1; num11 < num4; num11++)
                            {
                                list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray3[num9].ToString() + " " + strArray3[num10].ToString() + " " + strArray3[num11].ToString());
                            }
                        }
                    }
                    break;

                case 3:
                    for (int num12 = 0; num12 < (num4 - 1); num12++)
                    {
                        for (int num13 = num12 + 1; num13 < num4; num13++)
                        {
                            list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray3[num12].ToString() + " " + strArray3[num13].ToString());
                        }
                    }
                    break;

                case 4:
                    for (int num14 = 0; num14 < num4; num14++)
                    {
                        list.Add(strArray4[0].ToString() + " " + strArray4[1].ToString() + " " + strArray4[2].ToString() + " " + strArray4[3].ToString() + " " + strArray3[num14].ToString());
                    }
                    break;
            }
            if (list.Count == 0)
            {
                return null;
            }
            string[] strArray5 = new string[list.Count];
            for (int k = 0; k < list.Count; k++)
            {
                strArray5[k] = list[k].ToString();
            }
            return strArray5;
        }
    }
}
