using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class ZCDC : LotteryBase
    {
        public const string Code = "ZCDC";
        public const int ID = 0x2d;
        public const double MaxMoney = 200000.0;
        public const string Name = "足彩单场";
        public const int PlayType_BQCSPF = 0x1199;
        public const int PlayType_SPF = 0x1195;
        public const int PlayType_SXDS = 0x1197;
        public const int PlayType_ZJQ = 0x1196;
        public const int PlayType_ZQBF = 0x1198;
        public const string sID = "45";

        public ZCDC()
        {
            base.id = 0x2d;
            base.name = "足彩单场";
            base.code = "ZCDC";
        }

        public override string AnalyseScheme(string Scheme, int CompetitionCount)
        {
            int num = 0;
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Scheme, ref canonicalNumber, CompetitionCount);
            if ((strArray == null) || (strArray.Length == 0))
            {
                return "";
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                int num3 = _Convert.StrToInt(strArray[i].Split(new char[] { ';' })[1], 0);
                num = (num3 > num) ? num3 : num;
            }
            string[] strArray2 = new string[] { strArray.Length.ToString(), "|", num.ToString(), "|", ((strArray.Length * num) * 2).ToString("N") };
            return string.Concat(strArray2);
        }

        public override bool AnalyseWinNumber(string Number, int CompetitionCount)
        {
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            for (int i = 0; i < CompetitionCount; i++)
            {
                str2 = str2 + "(?<L" + i.ToString() + @">[\d]{1,2}[(][310*][,][\d]{1,}([.][\d]{1,}){0,1}[)])[|]";
            }
            str2 = str2.Substring(0, str2.Length - 3);
            for (int j = 0; j < CompetitionCount; j++)
            {
                str3 = str3 + "(?<L" + ((CompetitionCount + j)).ToString() + @">[\d]{1,2}[(][01234567*][,][\d]{1,}([.][\d]{1,}){0,1}[)])[|]";
            }
            str3 = str3.Substring(0, str3.Length - 3);
            for (int k = 0; k < CompetitionCount; k++)
            {
                str4 = str4 + "(?<L" + (((CompetitionCount * 2) + k)).ToString() + @">[\d]{1,2}[(][1234*][,][\d]{1,}([.][\d]{1,}){0,1}[)])[|]";
            }
            str4 = str4.Substring(0, str4.Length - 3);
            for (int m = 0; m < CompetitionCount; m++)
            {
                str5 = str5 + "(?<L" + (((CompetitionCount * 3) + m)).ToString() + @">[\d]{1,2}[(]([\d]{1,2}|[*])[,][\d]{1,}([.][\d]{1,}){0,1}[)])[|]";
            }
            str5 = str5.Substring(0, str5.Length - 3);
            for (int n = 0; n < CompetitionCount; n++)
            {
                str6 = str6 + "(?<L" + (((CompetitionCount * 4) + n)).ToString() + @">[\d]{1,2}[(][123456789*][,][\d]{1,}([.][\d]{1,}){0,1}[)])[|]";
            }
            str6 = str6.Substring(0, str6.Length - 3);
            Regex regex = new Regex(str2 + ";" + str3 + ";" + str4 + ";" + str5 + ";" + str6, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.IsMatch(Number))
            {
                return false;
            }
            return true;
        }

        public override bool CheckPlayType(int play_type)
        {
            return ((play_type >= 0x1195) && (play_type <= 0x1199));
        }

        private bool ComparedWithResult(int BuyNumberOfShowings, string BuyLotteryTicketResult, string WinNumber, int PlayType, int ResultLength, ref double SpIndex)
        {
            bool flag = false;
            string[] strArray = WinNumber.Split(new char[] { ';' });
            string str = "";
            if (PlayType == 0x1195)
            {
                str = strArray[0];
            }
            else if (PlayType == 0x1196)
            {
                str = strArray[1];
            }
            else if (PlayType == 0x1197)
            {
                str = strArray[2];
            }
            else if (PlayType == 0x1198)
            {
                str = strArray[3];
            }
            else if (PlayType == 0x1199)
            {
                str = strArray[4];
            }
            else
            {
                return flag;
            }
            string[] strArray2 = str.Split(new char[] { '|' });
            if ((BuyNumberOfShowings - 1) > strArray2.Length)
            {
                SpIndex = 0.0;
                return false;
            }
            int num = int.Parse(strArray2[BuyNumberOfShowings - 1].Substring(0, strArray2[BuyNumberOfShowings - 1].IndexOf('(')).ToString());
            string str2 = strArray2[BuyNumberOfShowings - 1].Substring(strArray2[BuyNumberOfShowings - 1].IndexOf('(') + 1, (strArray2[BuyNumberOfShowings - 1].IndexOf(',') - strArray2[BuyNumberOfShowings - 1].IndexOf('(')) - 1).ToString();
            if ((BuyNumberOfShowings != num) || (!(BuyLotteryTicketResult == str2) && !(str2 == "*")))
            {
                return flag;
            }
            if ((ResultLength <= 1) && (str2 == "*"))
            {
                SpIndex = -1.0;
                return true;
            }
            if ((ResultLength > 1) && (str2 == "*"))
            {
                SpIndex = 1.0;
                return true;
            }
            SpIndex = double.Parse(strArray2[BuyNumberOfShowings - 1].Substring(strArray2[BuyNumberOfShowings - 1].IndexOf(',') + 1, (strArray2[BuyNumberOfShowings - 1].IndexOf(')') - strArray2[BuyNumberOfShowings - 1].IndexOf(',')) - 1).ToString());
            return true;
        }

        public override double ComputeWin(string Scheme, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, int CompetitionCount, string NoSignificance)
        {
            if (Scheme.Length < 0x10)
            {
                return -3.0;
            }
            if ((PlayType < 0x1195) || (PlayType > 0x1199))
            {
                return -2.0;
            }
            if (((PlayType != 0x1195) && (PlayType != 0x1196)) && (((PlayType != 0x1197) && (PlayType != 0x1198)) && (PlayType != 0x1199)))
            {
                return -4.0;
            }
            return this.ComputeWinMethods(Scheme, WinNumber, ref Description, ref WinMoneyNoWithTax, PlayType, CompetitionCount);
        }

        private double ComputeWinMethods(string Scheme, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, int CompetitionCount)
        {
            string canonicalNumber = "";
            string[] strArray = this.ToSingle(Scheme, ref canonicalNumber, CompetitionCount);
            if ((strArray == null) || (strArray.Length < 1))
            {
                return -2.0;
            }
            int num = 0;
            int resultLength = 0;
            double num3 = 0.0;
            double spIndex = 1.0;
            double num5 = 1.0;
            string str2 = "";
            bool flag = false;
            Description = "";
            int num6 = 0;
            int num7 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                flag = false;
                str2 = strArray[i].Split(new char[] { ';' })[0];
                try
                {
                    num = int.Parse(strArray[i].Split(new char[] { ';' })[1].ToString());
                }
                catch
                {
                    num = 0;
                }
                num5 = 1.0;
                string[] strArray2 = str2.Split(new char[] { '|' });
                resultLength = strArray2.Length;
                for (int j = 0; j < resultLength; j++)
                {
                    if (strArray2[j].Length >= 4)
                    {
                        int buyNumberOfShowings = 0;
                        try
                        {
                            buyNumberOfShowings = int.Parse(strArray2[j].Substring(0, strArray2[j].IndexOf('(')).ToString());
                        }
                        catch
                        {
                            buyNumberOfShowings = 0;
                        }
                        string buyLotteryTicketResult = strArray2[j].Substring(strArray2[j].IndexOf('(') + 1, (strArray2[j].IndexOf(')') - strArray2[j].IndexOf('(')) - 1).ToString();
                        spIndex = 1.0;
                        flag = this.ComparedWithResult(buyNumberOfShowings, buyLotteryTicketResult, WinNumber, PlayType, resultLength, ref spIndex);
                        if (!flag)
                        {
                            break;
                        }
                        if (((strArray2.Length == 1) && (spIndex < 1.538)) && (spIndex > 0.0))
                        {
                            spIndex = 1.538;
                        }
                        num5 *= Math.Round(spIndex, 4);
                    }
                }
                if (flag)
                {
                    if ((strArray2.Length == 1) && (num5 == -1.0))
                    {
                        num3 += 2 * num;
                        num7++;
                    }
                    else
                    {
                        num6++;
                        num3 += (Math.Round((double)(num5 * 0.65), 4) * 2.0) * num;
                        if ((Math.Round((double)(num5 * 0.65), 4) * 2.0) >= 10000.0)
                        {
                            WinMoneyNoWithTax += ((Math.Round((double)(num5 * 0.65), 4) * 2.0) * num) * 0.8;
                        }
                        else
                        {
                            WinMoneyNoWithTax += (Math.Round((double)(num5 * 0.65), 4) * 2.0) * num;
                        }
                    }
                }
            }
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = "退票" + num7.ToString() + "注（场）";
            }
            if (num6 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = "中奖" + num6.ToString() + "注";
            }
            WinMoneyNoWithTax = Math.Round(WinMoneyNoWithTax, 2);
            return Math.Round(num3, 2);
        }

        private string FilterRepeated(string NumberPart, string strPlayType)
        {
            string[] strArray = NumberPart.Split(new char[] { ',' });
            if (strArray.Length == 1)
            {
                return NumberPart;
            }
            string str = "";
            string str2 = "";
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int k = 1; k < (strArray.Length - i); k++)
                {
                    try
                    {
                        num = int.Parse(strArray[k]);
                    }
                    catch
                    {
                        num = -1;
                    }
                    try
                    {
                        num2 = int.Parse(strArray[k - 1]);
                    }
                    catch
                    {
                        num2 = -1;
                    }
                    if (num < num2)
                    {
                        str = strArray[k - 1];
                        strArray[k - 1] = strArray[k];
                        strArray[k] = str;
                    }
                }
            }
            for (int j = 0; j < strArray.Length; j++)
            {
                if (("013".IndexOf(strArray[j]) >= 0) && (strPlayType == "4501"))
                {
                    str2 = str2 + strArray[j] + ",";
                }
                else if (("01234567".IndexOf(strArray[j]) >= 0) && (strPlayType == "4502"))
                {
                    str2 = str2 + strArray[j] + ",";
                }
                else if (("1234".IndexOf(strArray[j]) >= 0) && (strPlayType == "4503"))
                {
                    str2 = str2 + strArray[j] + ",";
                }
                else if (strPlayType == "4504")
                {
                    int num6 = 0;
                    try
                    {
                        num6 = int.Parse(strArray[j]);
                    }
                    catch
                    {
                        num6 = 0;
                    }
                    if ((num6 > 0) && (num6 < 0x1a))
                    {
                        str2 = str2 + strArray[j] + ",";
                    }
                }
                else if (("123456789".IndexOf(strArray[j]) >= 0) && (strPlayType == "4505"))
                {
                    str2 = str2 + strArray[j] + ",";
                }
            }
            return str2.Substring(0, str2.Length - 1);
        }

        private string FilterRepeatedScheme(string Scheme)
        {
            string[] strArray = Scheme.Split(new char[] { '|' });
            if (strArray.Length == 1)
            {
                return Scheme;
            }
            string str = "";
            string str2 = "";
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int k = 1; k < (strArray.Length - i); k++)
                {
                    try
                    {
                        num = int.Parse(strArray[k].Substring(0, strArray[k].IndexOf('(')));
                    }
                    catch
                    {
                        num = 0;
                    }
                    try
                    {
                        num2 = int.Parse(strArray[k - 1].Substring(0, strArray[k - 1].IndexOf('(')));
                    }
                    catch
                    {
                        num2 = 0;
                    }
                    if (num < num2)
                    {
                        str = strArray[k - 1];
                        strArray[k - 1] = strArray[k];
                        strArray[k] = str;
                    }
                }
            }
            for (int j = 0; j < strArray.Length; j++)
            {
                str2 = str2 + strArray[j] + "|";
            }
            return str2.Substring(0, str2.Length - 1);
        }

        private string FilterRepeatedWaysResult(string WaysResult)
        {
            string[] strArray = WaysResult.Split(new char[] { ',' });
            if (strArray.Length == 1)
            {
                return WaysResult;
            }
            string str = "";
            string str2 = "";
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                for (int k = 1; k < (strArray.Length - i); k++)
                {
                    try
                    {
                        num = int.Parse(_Convert.Asc(char.Parse(strArray[k].Substring(0, 1).ToString())).ToString());
                    }
                    catch
                    {
                        num = 0;
                    }
                    try
                    {
                        num2 = int.Parse(_Convert.Asc(char.Parse(strArray[k - 1].Substring(0, 1).ToString())).ToString());
                    }
                    catch
                    {
                        num2 = 0;
                    }
                    if (num < num2)
                    {
                        str = strArray[k - 1];
                        strArray[k - 1] = strArray[k];
                        strArray[k] = str;
                    }
                }
            }
            for (int j = 0; j < strArray.Length; j++)
            {
                str2 = str2 + strArray[j] + ",";
            }
            return str2.Substring(0, str2.Length - 1);
        }

        private string[] getAll1G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int index = 0;
                goto Label_0073;
            Label_0011: ;
                list.Add(string.Concat(new object[] { Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ");", TempWaysMultiples }));
                index++;
            Label_0073: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0011;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAll2G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int num3;
                int index = 0;
                goto Label_00F8;
            Label_0014:
                num3 = i + 1;
                while (num3 < GamesNumber)
                {
                    int num4 = 0;
                    goto Label_00C8;
                Label_0025: ;
                    list.Add(string.Concat(new object[] { Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ")|", Screenings[num3], "(", LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString(), ");", TempWaysMultiples }));
                    num4++;
                Label_00C8: ;
                    if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
                    {
                        goto Label_0025;
                    }
                    num3++;
                }
                index++;
            Label_00F8: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0014;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAll3G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int num3;
                int index = 0;
                goto Label_0184;
            Label_0014:
                num3 = i + 1;
                while (num3 < GamesNumber)
                {
                    int num5;
                    int num4 = 0;
                    goto Label_0154;
                Label_0025:
                    num5 = num3 + 1;
                    while (num5 < GamesNumber)
                    {
                        int num6 = 0;
                        goto Label_011E;
                    Label_0037: ;
                        list.Add(string.Concat(new object[] { Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ")|", Screenings[num3], "(", LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString(), ")|", Screenings[num5], "(", LocateBuyResult[num5].Split(new char[] { ',' })[num6].ToString(), ");", TempWaysMultiples }));
                        num6++;
                    Label_011E: ;
                        if (num6 < LocateBuyResult[num5].Split(new char[] { ',' }).Length)
                        {
                            goto Label_0037;
                        }
                        num5++;
                    }
                    num4++;
                Label_0154: ;
                    if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
                    {
                        goto Label_0025;
                    }
                    num3++;
                }
                index++;
            Label_0184: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0014;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAll4G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int num3;
                int index = 0;
                goto Label_0211;
            Label_0014:
                num3 = i + 1;
                while (num3 < GamesNumber)
                {
                    int num5;
                    int num4 = 0;
                    goto Label_01E1;
                Label_0025:
                    num5 = num3 + 1;
                    while (num5 < GamesNumber)
                    {
                        int num7;
                        int num6 = 0;
                        goto Label_01AB;
                    Label_0037:
                        num7 = num5 + 1;
                        while (num7 < GamesNumber)
                        {
                            int num8 = 0;
                            goto Label_0175;
                        Label_004A: ;
                            list.Add(string.Concat(new object[] { 
                                    Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ")|", Screenings[num3], "(", LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString(), ")|", Screenings[num5], "(", LocateBuyResult[num5].Split(new char[] { ',' })[num6].ToString(), ")|", Screenings[num7], "(", LocateBuyResult[num7].Split(new char[] { ',' })[num8].ToString(), ");", 
                                    TempWaysMultiples
                                 }));
                            num8++;
                        Label_0175: ;
                            if (num8 < LocateBuyResult[num7].Split(new char[] { ',' }).Length)
                            {
                                goto Label_004A;
                            }
                            num7++;
                        }
                        num6++;
                    Label_01AB: ;
                        if (num6 < LocateBuyResult[num5].Split(new char[] { ',' }).Length)
                        {
                            goto Label_0037;
                        }
                        num5++;
                    }
                    num4++;
                Label_01E1: ;
                    if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
                    {
                        goto Label_0025;
                    }
                    num3++;
                }
                index++;
            Label_0211: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0014;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAll5G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int num3;
                int index = 0;
                goto Label_029E;
            Label_0014:
                num3 = i + 1;
                while (num3 < GamesNumber)
                {
                    int num5;
                    int num4 = 0;
                    goto Label_026E;
                Label_0025:
                    num5 = num3 + 1;
                    while (num5 < GamesNumber)
                    {
                        int num7;
                        int num6 = 0;
                        goto Label_0238;
                    Label_0037:
                        num7 = num5 + 1;
                        while (num7 < GamesNumber)
                        {
                            int num9;
                            int num8 = 0;
                            goto Label_0202;
                        Label_004A:
                            num9 = num7 + 1;
                            while (num9 < GamesNumber)
                            {
                                int num10 = 0;
                                goto Label_01CC;
                            Label_005D: ;
                                list.Add(string.Concat(new object[] { 
                                        Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ")|", Screenings[num3], "(", LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString(), ")|", Screenings[num5], "(", LocateBuyResult[num5].Split(new char[] { ',' })[num6].ToString(), ")|", Screenings[num7], "(", LocateBuyResult[num7].Split(new char[] { ',' })[num8].ToString(), ")|", 
                                        Screenings[num9], "(", LocateBuyResult[num9].Split(new char[] { ',' })[num10].ToString(), ");", TempWaysMultiples
                                     }));
                                num10++;
                            Label_01CC: ;
                                if (num10 < LocateBuyResult[num9].Split(new char[] { ',' }).Length)
                                {
                                    goto Label_005D;
                                }
                                num9++;
                            }
                            num8++;
                        Label_0202: ;
                            if (num8 < LocateBuyResult[num7].Split(new char[] { ',' }).Length)
                            {
                                goto Label_004A;
                            }
                            num7++;
                        }
                        num6++;
                    Label_0238: ;
                        if (num6 < LocateBuyResult[num5].Split(new char[] { ',' }).Length)
                        {
                            goto Label_0037;
                        }
                        num5++;
                    }
                    num4++;
                Label_026E: ;
                    if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
                    {
                        goto Label_0025;
                    }
                    num3++;
                }
                index++;
            Label_029E: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0014;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAll6G(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < GamesNumber; i++)
            {
                int num3;
                int index = 0;
                goto Label_032B;
            Label_0014:
                num3 = i + 1;
                while (num3 < GamesNumber)
                {
                    int num5;
                    int num4 = 0;
                    goto Label_02FB;
                Label_0025:
                    num5 = num3 + 1;
                    while (num5 < GamesNumber)
                    {
                        int num7;
                        int num6 = 0;
                        goto Label_02C5;
                    Label_0037:
                        num7 = num5 + 1;
                        while (num7 < GamesNumber)
                        {
                            int num9;
                            int num8 = 0;
                            goto Label_028F;
                        Label_004A:
                            num9 = num7 + 1;
                            while (num9 < GamesNumber)
                            {
                                int num11;
                                int num10 = 0;
                                goto Label_0259;
                            Label_005D:
                                num11 = num9 + 1;
                                while (num11 < GamesNumber)
                                {
                                    int num12 = 0;
                                    goto Label_0223;
                                Label_0070: ;
                                    list.Add(string.Concat(new object[] { 
                                            Screenings[i], "(", LocateBuyResult[i].Split(new char[] { ',' })[index].ToString(), ")|", Screenings[num3], "(", LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString(), ")|", Screenings[num5], "(", LocateBuyResult[num5].Split(new char[] { ',' })[num6].ToString(), ")|", Screenings[num7], "(", LocateBuyResult[num7].Split(new char[] { ',' })[num8].ToString(), ")|", 
                                            Screenings[num9], "(", LocateBuyResult[num9].Split(new char[] { ',' })[num10].ToString(), ")|", Screenings[num11], "(", LocateBuyResult[num11].Split(new char[] { ',' })[num12].ToString(), ");", TempWaysMultiples
                                         }));
                                    num12++;
                                Label_0223: ;
                                    if (num12 < LocateBuyResult[num11].Split(new char[] { ',' }).Length)
                                    {
                                        goto Label_0070;
                                    }
                                    num11++;
                                }
                                num10++;
                            Label_0259: ;
                                if (num10 < LocateBuyResult[num9].Split(new char[] { ',' }).Length)
                                {
                                    goto Label_005D;
                                }
                                num9++;
                            }
                            num8++;
                        Label_028F: ;
                            if (num8 < LocateBuyResult[num7].Split(new char[] { ',' }).Length)
                            {
                                goto Label_004A;
                            }
                            num7++;
                        }
                        num6++;
                    Label_02C5: ;
                        if (num6 < LocateBuyResult[num5].Split(new char[] { ',' }).Length)
                        {
                            goto Label_0037;
                        }
                        num5++;
                    }
                    num4++;
                Label_02FB: ;
                    if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
                    {
                        goto Label_0025;
                    }
                    num3++;
                }
                index++;
            Label_032B: ;
                if (index < LocateBuyResult[i].Split(new char[] { ',' }).Length)
                {
                    goto Label_0014;
                }
            }
            string[] strArray = new string[list.Count];
            for (int j = 0; j < list.Count; j++)
            {
                strArray[j] = list[j].ToString();
            }
            return strArray;
        }

        private string[] getAllMC1(int GamesNumber, string[] Locate, string[] LocateBuyResult, string[] Screenings, int TempWaysMultiples)
        {
            string str;
            int num3;
            int num4;
            string str2;
            int num5;
            int num6;
            string str3;
            int num7;
            int num8;
            string str4;
            int num9;
            int num10;
            string str5;
            int num11;
            int num12;
            string str6;
            int num13;
            int num14;
            string str7;
            int num15;
            int num16;
            string str8;
            int num17;
            int num18;
            string str9;
            int num19;
            int num20;
            string str10;
            int num21;
            int num22;
            string str11;
            int num23;
            int num24;
            string str12;
            int num25;
            int num26;
            string str13;
            int num27;
            int num28;
            ArrayList list = new ArrayList();
            int index = 0;
            int num2 = 0;
            goto Label_0AEB;
        Label_06B2:
            num28++;
        Label_06B8: ;
            if (num28 < LocateBuyResult[num27].Split(new char[] { ',' }).Length)
            {
                string str14 = str13 + Screenings[num27] + "(" + LocateBuyResult[num27].Split(new char[] { ',' })[num28].ToString() + ")|";
                int num29 = num27 + 1;
                if (num29 >= GamesNumber)
                {
                    list.Add(str14.Substring(0, str14.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_06B2;
                }
                int num30 = 0;
            Label_0665: ;
                if (num30 < LocateBuyResult[num29].Split(new char[] { ',' }).Length)
                {
                    string str15 = str14 + Screenings[num29] + "(" + LocateBuyResult[num29].Split(new char[] { ',' })[num30].ToString() + ")|";
                    list.Add(str15.Substring(0, str15.Length - 1) + ";" + TempWaysMultiples);
                    num30++;
                    goto Label_0665;
                }
                goto Label_06B2;
            }
        Label_0705:
            num26++;
        Label_070B: ;
            if (num26 < LocateBuyResult[num25].Split(new char[] { ',' }).Length)
            {
                str13 = str12 + Screenings[num25] + "(" + LocateBuyResult[num25].Split(new char[] { ',' })[num26].ToString() + ")|";
                num27 = num25 + 1;
                if (num27 >= GamesNumber)
                {
                    list.Add(str13.Substring(0, str13.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0705;
                }
                num28 = 0;
                goto Label_06B8;
            }
        Label_0758:
            num24++;
        Label_075E: ;
            if (num24 < LocateBuyResult[num23].Split(new char[] { ',' }).Length)
            {
                str12 = str11 + Screenings[num23] + "(" + LocateBuyResult[num23].Split(new char[] { ',' })[num24].ToString() + ")|";
                num25 = num23 + 1;
                if (num25 >= GamesNumber)
                {
                    list.Add(str12.Substring(0, str12.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0758;
                }
                num26 = 0;
                goto Label_070B;
            }
        Label_07AB:
            num22++;
        Label_07B1: ;
            if (num22 < LocateBuyResult[num21].Split(new char[] { ',' }).Length)
            {
                str11 = str10 + Screenings[num21] + "(" + LocateBuyResult[num21].Split(new char[] { ',' })[num22].ToString() + ")|";
                num23 = num21 + 1;
                if (num23 >= GamesNumber)
                {
                    list.Add(str11.Substring(0, str11.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_07AB;
                }
                num24 = 0;
                goto Label_075E;
            }
        Label_07FE:
            num20++;
        Label_0804: ;
            if (num20 < LocateBuyResult[num19].Split(new char[] { ',' }).Length)
            {
                str10 = str9 + Screenings[num19] + "(" + LocateBuyResult[num19].Split(new char[] { ',' })[num20].ToString() + ")|";
                num21 = num19 + 1;
                if (num21 >= GamesNumber)
                {
                    list.Add(str10.Substring(0, str10.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_07FE;
                }
                num22 = 0;
                goto Label_07B1;
            }
        Label_0851:
            num18++;
        Label_0857: ;
            if (num18 < LocateBuyResult[num17].Split(new char[] { ',' }).Length)
            {
                str9 = str8 + Screenings[num17] + "(" + LocateBuyResult[num17].Split(new char[] { ',' })[num18].ToString() + ")|";
                num19 = num17 + 1;
                if (num19 >= GamesNumber)
                {
                    list.Add(str9.Substring(0, str9.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0851;
                }
                num20 = 0;
                goto Label_0804;
            }
        Label_08A4:
            num16++;
        Label_08AA: ;
            if (num16 < LocateBuyResult[num15].Split(new char[] { ',' }).Length)
            {
                str8 = str7 + Screenings[num15] + "(" + LocateBuyResult[num15].Split(new char[] { ',' })[num16].ToString() + ")|";
                num17 = num15 + 1;
                if (num17 >= GamesNumber)
                {
                    list.Add(str8.Substring(0, str8.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_08A4;
                }
                num18 = 0;
                goto Label_0857;
            }
        Label_08F7:
            num14++;
        Label_08FD: ;
            if (num14 < LocateBuyResult[num13].Split(new char[] { ',' }).Length)
            {
                str7 = str6 + Screenings[num13] + "(" + LocateBuyResult[num13].Split(new char[] { ',' })[num14].ToString() + ")|";
                num15 = num13 + 1;
                if (num15 >= GamesNumber)
                {
                    list.Add(str7.Substring(0, str7.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_08F7;
                }
                num16 = 0;
                goto Label_08AA;
            }
        Label_094A:
            num12++;
        Label_0950: ;
            if (num12 < LocateBuyResult[num11].Split(new char[] { ',' }).Length)
            {
                str6 = str5 + Screenings[num11] + "(" + LocateBuyResult[num11].Split(new char[] { ',' })[num12].ToString() + ")|";
                num13 = num11 + 1;
                if (num13 >= GamesNumber)
                {
                    list.Add(str6.Substring(0, str6.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_094A;
                }
                num14 = 0;
                goto Label_08FD;
            }
        Label_099D:
            num10++;
        Label_09A3: ;
            if (num10 < LocateBuyResult[num9].Split(new char[] { ',' }).Length)
            {
                str5 = str4 + Screenings[num9] + "(" + LocateBuyResult[num9].Split(new char[] { ',' })[num10].ToString() + ")|";
                num11 = num9 + 1;
                if (num11 >= GamesNumber)
                {
                    list.Add(str5.Substring(0, str5.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_099D;
                }
                num12 = 0;
                goto Label_0950;
            }
        Label_09F0:
            num8++;
        Label_09F6: ;
            if (num8 < LocateBuyResult[num7].Split(new char[] { ',' }).Length)
            {
                str4 = str3 + Screenings[num7] + "(" + LocateBuyResult[num7].Split(new char[] { ',' })[num8].ToString() + ")|";
                num9 = num7 + 1;
                if (num9 >= GamesNumber)
                {
                    list.Add(str4.Substring(0, str4.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_09F0;
                }
                num10 = 0;
                goto Label_09A3;
            }
        Label_0A43:
            num6++;
        Label_0A49: ;
            if (num6 < LocateBuyResult[num5].Split(new char[] { ',' }).Length)
            {
                str3 = str2 + Screenings[num5] + "(" + LocateBuyResult[num5].Split(new char[] { ',' })[num6].ToString() + ")|";
                num7 = num5 + 1;
                if (num7 >= GamesNumber)
                {
                    list.Add(str3.Substring(0, str3.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0A43;
                }
                num8 = 0;
                goto Label_09F6;
            }
        Label_0A96:
            num4++;
        Label_0A9C: ;
            if (num4 < LocateBuyResult[num3].Split(new char[] { ',' }).Length)
            {
                str2 = str + Screenings[num3] + "(" + LocateBuyResult[num3].Split(new char[] { ',' })[num4].ToString() + ")|";
                num5 = num3 + 1;
                if (num5 >= GamesNumber)
                {
                    list.Add(str2.Substring(0, str2.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0A96;
                }
                num6 = 0;
                goto Label_0A49;
            }
        Label_0AE7:
            num2++;
        Label_0AEB: ;
            if (num2 < LocateBuyResult[index].Split(new char[] { ',' }).Length)
            {
                str = Screenings[index] + "(" + LocateBuyResult[index].Split(new char[] { ',' })[num2].ToString() + ")|";
                num3 = index + 1;
                if (num3 >= GamesNumber)
                {
                    list.Add(str.Substring(0, str.Length - 1) + ";" + TempWaysMultiples);
                    goto Label_0AE7;
                }
                num4 = 0;
                goto Label_0A9C;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        public int GetBettingNumber(string Scheme, ref string CanonicalNumber, int CompetitionCount)
        {
            string[] strArray = this.ToSingle(Scheme, ref CanonicalNumber, CompetitionCount);
            if ((strArray != null) && (strArray.Length >= 1))
            {
                return strArray.Length;
            }
            return -2;
        }

        private void GetNewPlayTypeID(int PlayTypeID, ref int NewPlayTypeID, ref string Rule)
        {
            switch (PlayTypeID)
            {
                case 0x1195:
                    NewPlayTypeID = 0x2c;
                    Rule = "单场胜平负";
                    return;

                case 0x1196:
                    NewPlayTypeID = 0x2d;
                    Rule = "单场进球数";
                    return;

                case 0x1197:
                    NewPlayTypeID = 0x2e;
                    Rule = "单场上下单双";
                    return;

                case 0x1198:
                    NewPlayTypeID = 0x2f;
                    Rule = "单场比分";
                    return;

                case 0x1199:
                    NewPlayTypeID = 0x30;
                    Rule = "单场半全场胜平负";
                    return;
            }
            NewPlayTypeID = 0;
            Rule = "";
        }

        private string GetPassMode(string passmode)
        {
            return passmode.Replace("1", "单关").Replace("2", "双关").Replace("3", "三关").Replace("4", "2串1").Replace("5", "2串3").Replace("6", "3串1").Replace("7", "3串4").Replace("8", "3串7").Replace("9", "4串1").Replace("A", "4串4").Replace("B", "4串4").Replace("C", "4串11").Replace("D", "4串15").Replace("E", "5串1").Replace("F", "5串6").Replace("G", "5串16").Replace("H", "5串31").Replace("I", "6串1").Replace("J", "6串7").Replace("K", "6串22").Replace("L", "6串42").Replace("M", "6串57").Replace("N", "6串63");
        }

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0x1195, "胜平负"), new PlayType(0x1196, "总进球"), new PlayType(0x1197, "上下单双"), new PlayType(0x1198, "正确比分"), new PlayType(0x1199, "半全场胜平负") };
        }

        public override bool GetSchemeSplit(string Scheme, ref string BuyContent, ref string CnLocateWaysAndMultiples)
        {
            if (Scheme.Split(new char[] { ';' }).Length != 3)
            {
                BuyContent = "";
                CnLocateWaysAndMultiples = "";
                return false;
            }
            Scheme.Trim().Split(new char[] { ';' })[0].ToString();
            string str = Scheme.Trim().Split(new char[] { ';' })[1].ToString();
            BuyContent = str.Substring(1, str.Length - 1).Substring(0, str.Length - 2).ToString().Trim();
            if (BuyContent == "")
            {
                BuyContent = "";
                CnLocateWaysAndMultiples = "";
                return false;
            }
            string str2 = Scheme.Trim().Split(new char[] { ';' })[2].ToString().Substring(1, Scheme.Trim().Split(new char[] { ';' })[2].ToString().Length - 1).Substring(0, Scheme.Trim().Split(new char[] { ';' })[2].ToString().Length - 2).ToString().Trim();
            if (str2 == "")
            {
                BuyContent = "";
                CnLocateWaysAndMultiples = "";
                return false;
            }
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                switch (strArray[i].ToString().Substring(0, 1))
                {
                    case "1":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "单关  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "2":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "双关  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "3":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "三关  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "4":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "2串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "5":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "2串3  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "6":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "3串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "7":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "3串4  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "8":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "3串7  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "9":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "4串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "A":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "4串5  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "B":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "4串11  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "C":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "4串15  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "D":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "5串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "E":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "5串6  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "F":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "5串16  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "G":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "5串26  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "H":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "5串31  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "I":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "J":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串7  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "K":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串22  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "L":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串42  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "M":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串57  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "N":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "6串63  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "O":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "7串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "P":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "8串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "Q":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "9串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "R":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "10串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "S":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "11串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "T":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "12串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "U":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "13串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "V":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "14串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    case "W":
                        if (CnLocateWaysAndMultiples != "")
                        {
                            CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "，";
                        }
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + "15串1  " + strArray[i].Substring(1, strArray[i].Length - 1) + " 倍";
                        break;

                    default:
                        CnLocateWaysAndMultiples = CnLocateWaysAndMultiples + " <font color='red'>读取错误！</font>";
                        break;
                }
            }
            return true;
        }

        private string PrizeInfo(int PlayTypeID, string PrizeInfo)
        {
            switch (PlayTypeID)
            {
                case 0x1195:
                    return PrizeInfo.Replace("3", "胜").Replace("1", "平").Replace("0", "负");

                case 0x1196:
                    return PrizeInfo;

                case 0x1197:
                    return PrizeInfo.Replace("1", "上单").Replace("2", "上双").Replace("3", "下单").Replace("4", "下双");

                case 0x1198:
                    return PrizeInfo.Replace("1", "1:0").Replace("2", "2:0").Replace("3", "2:1").Replace("4", "3:0").Replace("5", "3:1").Replace("6", "3:2").Replace("7", "4:0").Replace("8", "4:1").Replace("9", "4:2").Replace("10", "胜其他").Replace("11", "0:0").Replace("12", "1:1").Replace("13", "2:2").Replace("14", "3:3").Replace("15", "平其他").Replace("16", "0:1").Replace("17", "0:2").Replace("18", "1:2").Replace("19", "0:3").Replace("20", "1:3").Replace("21", "2:3").Replace("22", "0:4").Replace("23", "1:4").Replace("24", "2:4").Replace("25", "负其他");

                case 0x1199:
                    return PrizeInfo.Replace("1", "胜-胜").Replace("2", "胜-平").Replace("3", "胜-负").Replace("4", "平-胜").Replace("5", "平-平").Replace("6", "平-负").Replace("7", "负-胜").Replace("8", "负-平").Replace("9", "负-负");
            }
            return PrizeInfo;
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string ToElectronicTicket_BJDC(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID, ref string Rule, ref int Multiple, ref double Money, ref string GameNoList, ref string PassMode, ref int TicketCount)
        {
            this.GetNewPlayTypeID(PlayTypeID, ref NewPlayTypeID, ref Rule);
            if (Number.Split(new char[] { ';' }).Length == 3)
            {
                string str = Number.Trim().Split(new char[] { ';' })[1].ToString();
                string str2 = Number.Trim().Split(new char[] { ';' })[2].ToString();
                PassMode = this.GetPassMode(str2.Substring(0, 1));
                Multiple = _Convert.StrToInt(str2.Substring(1), 0);
                string str3 = str.Substring(1, str.Length - 1).Substring(0, str.Length - 2).ToString().Trim();
                if (str3 == "")
                {
                    return "";
                }
                string[] strArray = str3.Split(new char[] { '|' });
                if (strArray.Length < 1)
                {
                    return "";
                }
                TicketNumber = "";
                GameNoList = "";
                string str4 = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    str4 = strArray[i].Substring(strArray[i].IndexOf('(') + 1, (strArray[i].IndexOf(')') - strArray[i].IndexOf('(')) - 1);
                    GameNoList = GameNoList + str4 + ",";
                    TicketNumber = TicketNumber + str4;
                    TicketNumber = TicketNumber + "[";
                    TicketNumber = TicketNumber + this.PrizeInfo(PlayTypeID, strArray[i].Substring(0, strArray[i].IndexOf('(')));
                    TicketNumber = TicketNumber + "]";
                }
                GameNoList = GameNoList.Substring(GameNoList.Length - 1);
            }
            return "";
        }

        public override string[] ToSingle(string Scheme, ref string CanonicalNumber, int CompetitionCount)
        {
            CanonicalNumber = "";
            if (Scheme.Split(new char[] { ';' }).Length != 3)
            {
                CanonicalNumber = "";
                return null;
            }
            string strPlayType = Scheme.Trim().Split(new char[] { ';' })[0].ToString();
            string str2 = Scheme.Trim().Split(new char[] { ';' })[1].ToString();
            string input = str2.Substring(1, str2.Length - 1).Substring(0, str2.Length - 2).ToString().Trim();
            if (input == "")
            {
                CanonicalNumber = "";
                return null;
            }
            string str4 = Scheme.Trim().Split(new char[] { ';' })[2].ToString().Substring(1, Scheme.Trim().Split(new char[] { ';' })[2].ToString().Length - 1).Substring(0, Scheme.Trim().Split(new char[] { ';' })[2].ToString().Length - 2).ToString().Trim();
            if (str4 == "")
            {
                CanonicalNumber = "";
                return null;
            }
            int length = input.Split(new char[] { '|' }).Length;
            int num3 = str4.Split(new char[] { ',' }).Length;
            string[] locate = new string[length];
            string[] strArray2 = new string[num3];
            string pattern = "";
            string numberPart = "";
            string str7 = "";
            string str8 = "";
            int tempWaysMultiples = 0;
            switch (strPlayType)
            {
                case "4501":
                    for (int n = 0; n < length; n++)
                    {
                        pattern = pattern + "(?<L" + n.ToString() + @">[\d]{1,2}[(][310]([,][310]){0,2}[)])[|]";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 3);
                    break;

                case "4502":
                    for (int num6 = 0; num6 < length; num6++)
                    {
                        pattern = pattern + "(?<L" + num6.ToString() + @">[\d]{1,2}[(][01234567]([,][01234567]){0,7}[)])[|]";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 3);
                    break;

                case "4503":
                    for (int num7 = 0; num7 < length; num7++)
                    {
                        pattern = pattern + "(?<L" + num7.ToString() + @">[\d]{1,2}[(][1234]([,][1234]){0,3}[)])[|]";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 3);
                    break;

                case "4504":
                    for (int num8 = 0; num8 < length; num8++)
                    {
                        pattern = pattern + "(?<L" + num8.ToString() + @">[\d]{1,2}[(][\d]{1,2}([,][\d]{1,2}){0,24}[)])[|]";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 3);
                    break;

                case "4505":
                    for (int num9 = 0; num9 < length; num9++)
                    {
                        pattern = pattern + "(?<L" + num9.ToString() + @">[\d]{1,2}[(][\d]([,][\d]){0,8}[)])[|]";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 3);
                    break;
            }
            Match match = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(input);
            for (int i = 0; i < length; i++)
            {
                locate[i] = match.Groups["L" + i.ToString()].ToString().Trim();
                if (locate[i] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (CompetitionCount < int.Parse(locate[i].Substring(0, locate[i].IndexOf('(')).ToString()))
                {
                    CanonicalNumber = "";
                    return null;
                }
                numberPart = locate[i].Substring(locate[i].IndexOf('(') + 1, (locate[i].IndexOf(')') - locate[i].IndexOf('(')) - 1);
                if (numberPart.Length > 0)
                {
                    numberPart = this.FilterRepeated(numberPart, strPlayType);
                    if (numberPart == "")
                    {
                        CanonicalNumber = "";
                        return null;
                    }
                }
                if (numberPart.Length > 0)
                {
                    string str10 = CanonicalNumber;
                    CanonicalNumber = str10 + locate[i].Substring(0, locate[i].IndexOf('(')) + "(" + numberPart + ")|";
                }
            }
            if (CanonicalNumber.Length < 4)
            {
                CanonicalNumber = "";
                return null;
            }
            CanonicalNumber = this.FilterRepeatedScheme(CanonicalNumber.Substring(0, CanonicalNumber.Length - 1));
            length = 0;
            numberPart = "";
            pattern = "";
            for (int j = 0; j < num3; j++)
            {
                pattern = pattern + "(?<L" + j.ToString() + @">[123456789ABCDEFGHIJKLMNOPQRSTUVW]{1}[\d]{1,4})[,]";
            }
            Match match2 = new Regex(pattern.Substring(0, pattern.Length - 3), RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(str4);
            for (int k = 0; k < num3; k++)
            {
                strArray2[k] = match2.Groups["L" + k.ToString()].ToString().Trim();
                if (strArray2[k] == "")
                {
                    CanonicalNumber = "";
                    return null;
                }
                numberPart = strArray2[k].Substring(1, strArray2[k].Length - 1);
                if (numberPart.Length > 0)
                {
                    try
                    {
                        tempWaysMultiples = Convert.ToInt32(numberPart);
                    }
                    catch
                    {
                        tempWaysMultiples = 0;
                    }
                    if (tempWaysMultiples > 0)
                    {
                        str8 = numberPart;
                    }
                    else
                    {
                        str8 = "";
                    }
                }
                if (str8.Length > 0)
                {
                    str7 = str7 + strArray2[k].Substring(0, 1).ToUpper() + str8.ToString() + ",";
                }
            }
            if (str7.Length < 2)
            {
                CanonicalNumber = "";
                return null;
            }
            str7 = this.FilterRepeatedWaysResult(str7.Substring(0, str7.Length - 1));
            num3 = 0;
            ArrayList list = new ArrayList();
            length = CanonicalNumber.Split(new char[] { '|' }).Length;
            num3 = str7.Split(new char[] { ',' }).Length;
            if (length == 1)
            {
                string[] locateBuyResult = new string[length];
                string[] screenings = new string[length];
                for (int num13 = 0; num13 < length; num13++)
                {
                    locate[num13] = CanonicalNumber.Split(new char[] { '|' })[num13].ToString();
                    locateBuyResult[num13] = locate[num13].Substring(locate[num13].IndexOf('(') + 1, (locate[num13].IndexOf(')') - locate[num13].IndexOf('(')) - 1);
                    screenings[num13] = locate[num13].Substring(0, locate[num13].IndexOf('('));
                }
                string str9 = str7.Substring(0, 1);
                if (num3 > 1)
                {
                    CanonicalNumber = "";
                    return null;
                }
                if (str9 != "1")
                {
                    CanonicalNumber = "";
                    return null;
                }
                tempWaysMultiples = 0;
                try
                {
                    tempWaysMultiples = Convert.ToInt32(str7.Substring(1, str7.Length - 1));
                }
                catch
                {
                    tempWaysMultiples = 0;
                }
                if (tempWaysMultiples <= 0)
                {
                    CanonicalNumber = "";
                    return null;
                }
                string[] strArray5 = this.getAll1G(length, locate, locateBuyResult, screenings, tempWaysMultiples);
                for (int num14 = 0; num14 < strArray5.Length; num14++)
                {
                    list.Add(strArray5[num14].ToString());
                }
            }
            else if (length > 1)
            {
                string[] strArray6 = new string[length];
                string[] strArray7 = new string[length];
                for (int num15 = 0; num15 < length; num15++)
                {
                    locate[num15] = CanonicalNumber.Split(new char[] { '|' })[num15].ToString();
                    strArray6[num15] = locate[num15].Substring(locate[num15].IndexOf('(') + 1, (locate[num15].IndexOf(')') - locate[num15].IndexOf('(')) - 1);
                    strArray7[num15] = locate[num15].Substring(0, locate[num15].IndexOf('('));
                }
                if ((((strPlayType == "4502") || (strPlayType == "4503")) || (strPlayType == "4505")) && (length > 6))
                {
                    CanonicalNumber = "";
                    return null;
                }
                if ((strPlayType == "4504") && (length > 3))
                {
                    CanonicalNumber = "";
                    return null;
                }
                string[] strArray8 = new string[num3];
                string[] strArray9 = new string[num3];
                string[] strArray10 = new string[num3];
                for (int num16 = 0; num16 < num3; num16++)
                {
                    string[] strArray11;
                    int num17;
                    string[] strArray12;
                    int num18;
                    string[] strArray13;
                    int num19;
                    string[] strArray14;
                    int num20;
                    string[] strArray15;
                    int num21;
                    string[] strArray17;
                    int num23;
                    string[] strArray18;
                    int num24;
                    string[] strArray20;
                    int num26;
                    string[] strArray23;
                    int num29;
                    string[] strArray24;
                    int num30;
                    string[] strArray26;
                    int num32;
                    string[] strArray29;
                    int num35;
                    string[] strArray33;
                    int num39;
                    string[] strArray34;
                    int num40;
                    string[] strArray36;
                    int num42;
                    string[] strArray39;
                    int num45;
                    string[] strArray43;
                    int num49;
                    string[] strArray48;
                    int num54;
                    string[] strArray49;
                    int num55;
                    string[] strArray51;
                    int num57;
                    string[] strArray54;
                    int num60;
                    string[] strArray58;
                    int num64;
                    string[] strArray63;
                    int num69;
                    string[] strArray69;
                    strArray8[num16] = str7.Split(new char[] { ',' })[num16].ToString();
                    strArray9[num16] = strArray8[num16].Substring(0, 1);
                    strArray10[num16] = strArray8[num16].Substring(1, strArray8[num16].Length - 1);
                    switch (strArray9[num16])
                    {
                        case "1":
                            strArray11 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num17 = 0;
                            goto Label_0B19;

                        case "2":
                            strArray12 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num18 = 0;
                            goto Label_0B62;

                        case "3":
                            strArray13 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num19 = 0;
                            goto Label_0BAB;

                        case "4":
                            strArray14 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num20 = 0;
                            goto Label_0BF4;

                        case "5":
                            strArray15 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num21 = 0;
                            goto Label_0C3D;

                        case "6":
                            strArray17 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num23 = 0;
                            goto Label_0CCA;

                        case "7":
                            strArray18 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num24 = 0;
                            goto Label_0D13;

                        case "8":
                            strArray20 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num26 = 0;
                            goto Label_0DA0;

                        case "9":
                            strArray23 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num29 = 0;
                            goto Label_0E71;

                        case "A":
                            strArray24 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num30 = 0;
                            goto Label_0EBA;

                        case "B":
                            strArray26 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num32 = 0;
                            goto Label_0F47;

                        case "C":
                            strArray29 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num35 = 0;
                            goto Label_1018;

                        case "D":
                            strArray33 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num39 = 0;
                            goto Label_112D;

                        case "E":
                            strArray34 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num40 = 0;
                            goto Label_1176;

                        case "F":
                            strArray36 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num42 = 0;
                            goto Label_1203;

                        case "G":
                            strArray39 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num45 = 0;
                            goto Label_12D4;

                        case "H":
                            strArray43 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num49 = 0;
                            goto Label_13E9;

                        case "I":
                            strArray48 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num54 = 0;
                            goto Label_1542;

                        case "J":
                            strArray49 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num55 = 0;
                            goto Label_158B;

                        case "K":
                            strArray51 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num57 = 0;
                            goto Label_1618;

                        case "L":
                            strArray54 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num60 = 0;
                            goto Label_16E9;

                        case "M":
                            strArray58 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num64 = 0;
                            goto Label_17FE;

                        case "N":
                            strArray63 = this.getAll1G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                            num69 = 0;
                            goto Label_1957;

                        default:
                            goto Label_1AB5;
                    }
                Label_0B01:
                    list.Add(strArray11[num17].ToString());
                    num17++;
                Label_0B19:
                    if (num17 < strArray11.Length)
                    {
                        goto Label_0B01;
                    }
                    goto Label_1AF9;
                Label_0B4A:
                    list.Add(strArray12[num18].ToString());
                    num18++;
                Label_0B62:
                    if (num18 < strArray12.Length)
                    {
                        goto Label_0B4A;
                    }
                    goto Label_1AF9;
                Label_0B93:
                    list.Add(strArray13[num19].ToString());
                    num19++;
                Label_0BAB:
                    if (num19 < strArray13.Length)
                    {
                        goto Label_0B93;
                    }
                    goto Label_1AF9;
                Label_0BDC:
                    list.Add(strArray14[num20].ToString());
                    num20++;
                Label_0BF4:
                    if (num20 < strArray14.Length)
                    {
                        goto Label_0BDC;
                    }
                    goto Label_1AF9;
                Label_0C25:
                    list.Add(strArray15[num21].ToString());
                    num21++;
                Label_0C3D:
                    if (num21 < strArray15.Length)
                    {
                        goto Label_0C25;
                    }
                    string[] strArray16 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num22 = 0; num22 < strArray16.Length; num22++)
                    {
                        list.Add(strArray16[num22].ToString());
                    }
                    goto Label_1AF9;
                Label_0CB2:
                    list.Add(strArray17[num23].ToString());
                    num23++;
                Label_0CCA:
                    if (num23 < strArray17.Length)
                    {
                        goto Label_0CB2;
                    }
                    goto Label_1AF9;
                Label_0CFB:
                    list.Add(strArray18[num24].ToString());
                    num24++;
                Label_0D13:
                    if (num24 < strArray18.Length)
                    {
                        goto Label_0CFB;
                    }
                    string[] strArray19 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num25 = 0; num25 < strArray19.Length; num25++)
                    {
                        list.Add(strArray19[num25].ToString());
                    }
                    goto Label_1AF9;
                Label_0D88:
                    list.Add(strArray20[num26].ToString());
                    num26++;
                Label_0DA0:
                    if (num26 < strArray20.Length)
                    {
                        goto Label_0D88;
                    }
                    string[] strArray21 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num27 = 0; num27 < strArray21.Length; num27++)
                    {
                        list.Add(strArray21[num27].ToString());
                    }
                    string[] strArray22 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num28 = 0; num28 < strArray22.Length; num28++)
                    {
                        list.Add(strArray22[num28].ToString());
                    }
                    goto Label_1AF9;
                Label_0E59:
                    list.Add(strArray23[num29].ToString());
                    num29++;
                Label_0E71:
                    if (num29 < strArray23.Length)
                    {
                        goto Label_0E59;
                    }
                    goto Label_1AF9;
                Label_0EA2:
                    list.Add(strArray24[num30].ToString());
                    num30++;
                Label_0EBA:
                    if (num30 < strArray24.Length)
                    {
                        goto Label_0EA2;
                    }
                    string[] strArray25 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num31 = 0; num31 < strArray25.Length; num31++)
                    {
                        list.Add(strArray25[num31].ToString());
                    }
                    goto Label_1AF9;
                Label_0F2F:
                    list.Add(strArray26[num32].ToString());
                    num32++;
                Label_0F47:
                    if (num32 < strArray26.Length)
                    {
                        goto Label_0F2F;
                    }
                    string[] strArray27 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num33 = 0; num33 < strArray27.Length; num33++)
                    {
                        list.Add(strArray27[num33].ToString());
                    }
                    string[] strArray28 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num34 = 0; num34 < strArray28.Length; num34++)
                    {
                        list.Add(strArray28[num34].ToString());
                    }
                    goto Label_1AF9;
                Label_1000:
                    list.Add(strArray29[num35].ToString());
                    num35++;
                Label_1018:
                    if (num35 < strArray29.Length)
                    {
                        goto Label_1000;
                    }
                    string[] strArray30 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num36 = 0; num36 < strArray30.Length; num36++)
                    {
                        list.Add(strArray30[num36].ToString());
                    }
                    string[] strArray31 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num37 = 0; num37 < strArray31.Length; num37++)
                    {
                        list.Add(strArray31[num37].ToString());
                    }
                    string[] strArray32 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num38 = 0; num38 < strArray32.Length; num38++)
                    {
                        list.Add(strArray32[num38].ToString());
                    }
                    goto Label_1AF9;
                Label_1115:
                    list.Add(strArray33[num39].ToString());
                    num39++;
                Label_112D:
                    if (num39 < strArray33.Length)
                    {
                        goto Label_1115;
                    }
                    goto Label_1AF9;
                Label_115E:
                    list.Add(strArray34[num40].ToString());
                    num40++;
                Label_1176:
                    if (num40 < strArray34.Length)
                    {
                        goto Label_115E;
                    }
                    string[] strArray35 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num41 = 0; num41 < strArray35.Length; num41++)
                    {
                        list.Add(strArray35[num41].ToString());
                    }
                    goto Label_1AF9;
                Label_11EB:
                    list.Add(strArray36[num42].ToString());
                    num42++;
                Label_1203:
                    if (num42 < strArray36.Length)
                    {
                        goto Label_11EB;
                    }
                    string[] strArray37 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num43 = 0; num43 < strArray37.Length; num43++)
                    {
                        list.Add(strArray37[num43].ToString());
                    }
                    string[] strArray38 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num44 = 0; num44 < strArray38.Length; num44++)
                    {
                        list.Add(strArray38[num44].ToString());
                    }
                    goto Label_1AF9;
                Label_12BC:
                    list.Add(strArray39[num45].ToString());
                    num45++;
                Label_12D4:
                    if (num45 < strArray39.Length)
                    {
                        goto Label_12BC;
                    }
                    string[] strArray40 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num46 = 0; num46 < strArray40.Length; num46++)
                    {
                        list.Add(strArray40[num46].ToString());
                    }
                    string[] strArray41 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num47 = 0; num47 < strArray41.Length; num47++)
                    {
                        list.Add(strArray41[num47].ToString());
                    }
                    string[] strArray42 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num48 = 0; num48 < strArray42.Length; num48++)
                    {
                        list.Add(strArray42[num48].ToString());
                    }
                    goto Label_1AF9;
                Label_13D1:
                    list.Add(strArray43[num49].ToString());
                    num49++;
                Label_13E9:
                    if (num49 < strArray43.Length)
                    {
                        goto Label_13D1;
                    }
                    string[] strArray44 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num50 = 0; num50 < strArray44.Length; num50++)
                    {
                        list.Add(strArray44[num50].ToString());
                    }
                    string[] strArray45 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num51 = 0; num51 < strArray45.Length; num51++)
                    {
                        list.Add(strArray45[num51].ToString());
                    }
                    string[] strArray46 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num52 = 0; num52 < strArray46.Length; num52++)
                    {
                        list.Add(strArray46[num52].ToString());
                    }
                    string[] strArray47 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num53 = 0; num53 < strArray47.Length; num53++)
                    {
                        list.Add(strArray47[num53].ToString());
                    }
                    goto Label_1AF9;
                Label_152A:
                    list.Add(strArray48[num54].ToString());
                    num54++;
                Label_1542:
                    if (num54 < strArray48.Length)
                    {
                        goto Label_152A;
                    }
                    goto Label_1AF9;
                Label_1573:
                    list.Add(strArray49[num55].ToString());
                    num55++;
                Label_158B:
                    if (num55 < strArray49.Length)
                    {
                        goto Label_1573;
                    }
                    string[] strArray50 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num56 = 0; num56 < strArray50.Length; num56++)
                    {
                        list.Add(strArray50[num56].ToString());
                    }
                    goto Label_1AF9;
                Label_1600:
                    list.Add(strArray51[num57].ToString());
                    num57++;
                Label_1618:
                    if (num57 < strArray51.Length)
                    {
                        goto Label_1600;
                    }
                    string[] strArray52 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num58 = 0; num58 < strArray52.Length; num58++)
                    {
                        list.Add(strArray52[num58].ToString());
                    }
                    string[] strArray53 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num59 = 0; num59 < strArray53.Length; num59++)
                    {
                        list.Add(strArray53[num59].ToString());
                    }
                    goto Label_1AF9;
                Label_16D1:
                    list.Add(strArray54[num60].ToString());
                    num60++;
                Label_16E9:
                    if (num60 < strArray54.Length)
                    {
                        goto Label_16D1;
                    }
                    string[] strArray55 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num61 = 0; num61 < strArray55.Length; num61++)
                    {
                        list.Add(strArray55[num61].ToString());
                    }
                    string[] strArray56 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num62 = 0; num62 < strArray56.Length; num62++)
                    {
                        list.Add(strArray56[num62].ToString());
                    }
                    string[] strArray57 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num63 = 0; num63 < strArray57.Length; num63++)
                    {
                        list.Add(strArray57[num63].ToString());
                    }
                    goto Label_1AF9;
                Label_17E6:
                    list.Add(strArray58[num64].ToString());
                    num64++;
                Label_17FE:
                    if (num64 < strArray58.Length)
                    {
                        goto Label_17E6;
                    }
                    string[] strArray59 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num65 = 0; num65 < strArray59.Length; num65++)
                    {
                        list.Add(strArray59[num65].ToString());
                    }
                    string[] strArray60 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num66 = 0; num66 < strArray60.Length; num66++)
                    {
                        list.Add(strArray60[num66].ToString());
                    }
                    string[] strArray61 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num67 = 0; num67 < strArray61.Length; num67++)
                    {
                        list.Add(strArray61[num67].ToString());
                    }
                    string[] strArray62 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num68 = 0; num68 < strArray62.Length; num68++)
                    {
                        list.Add(strArray62[num68].ToString());
                    }
                    goto Label_1AF9;
                Label_193F:
                    list.Add(strArray63[num69].ToString());
                    num69++;
                Label_1957:
                    if (num69 < strArray63.Length)
                    {
                        goto Label_193F;
                    }
                    string[] strArray64 = this.getAll2G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num70 = 0; num70 < strArray64.Length; num70++)
                    {
                        list.Add(strArray64[num70].ToString());
                    }
                    string[] strArray65 = this.getAll3G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num71 = 0; num71 < strArray65.Length; num71++)
                    {
                        list.Add(strArray65[num71].ToString());
                    }
                    string[] strArray66 = this.getAll4G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num72 = 0; num72 < strArray66.Length; num72++)
                    {
                        list.Add(strArray66[num72].ToString());
                    }
                    string[] strArray67 = this.getAll5G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num73 = 0; num73 < strArray67.Length; num73++)
                    {
                        list.Add(strArray67[num73].ToString());
                    }
                    string[] strArray68 = this.getAll6G(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num74 = 0; num74 < strArray68.Length; num74++)
                    {
                        list.Add(strArray68[num74].ToString());
                    }
                    goto Label_1AF9;
                Label_1AB5:
                    strArray69 = this.getAllMC1(length, locate, strArray6, strArray7, int.Parse(strArray10[num16].ToString()));
                    for (int num75 = 0; num75 < strArray69.Length; num75++)
                    {
                        list.Add(strArray69[num75].ToString());
                    }
                Label_1AF9: ;
                }
            }
            string[] strArray70 = new string[list.Count];
            for (int m = 0; m < list.Count; m++)
            {
                strArray70[m] = list[m].ToString();
            }
            return strArray70;
        }
    }
}
