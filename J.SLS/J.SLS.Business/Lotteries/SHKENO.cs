using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Shove;

namespace J.SLS.Business
{
    internal class SHKENO : LotteryBase
    {
        public const string Code = "SHKENO";
        public const int ID = 0x22;
        public const double MaxMoney = 2.0;
        public const string Name = "上海Keno游戏";
        public const int PlayType_D = 0xd49;
        public const string sID = "34";

        public SHKENO()
        {
            base.id = 0x22;
            base.name = "上海Keno游戏";
            base.code = "SHKENO";
        }

        public override string AnalyseScheme(string Content, int PlayType)
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
            Regex regex = new Regex(@"(\d\d\s){0,9}\d\d", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (int i = 0; i < strArray.Length; i++)
            {
                Match match = regex.Match(strArray[i]);
                if (match.Success)
                {
                    string canonicalNumber = "";
                    string[] strArray2 = this.ToSingle(match.Value, ref canonicalNumber, PlayType);
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
            string[] strArray = this.FilterRepeated(Number.Split(new char[] { ' ' }));
            return ((strArray != null) && (strArray.Length == 20));
        }

        public override string BuildNumber(int Num, int Type)
        {
            if (((((Type != 10) && (Type != 9)) && ((Type != 8) && (Type != 7))) && (((Type != 6) && (Type != 5)) && ((Type != 4) && (Type != 3)))) && ((Type != 2) && (Type != 1)))
            {
                Type = 10;
            }
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            ArrayList al = new ArrayList();
            for (int i = 0; i < Num; i++)
            {
                string str = "";
                for (int j = 0; j < Type; j++)
                {
                    int ball = 0;
                    while ((ball == 0) || base.isExistBall(al, ball))
                    {
                        ball = random.Next(1, 0x51);
                    }
                    al.Add(ball.ToString().PadLeft(2, '0'));
                }
                LotteryBase.CompareToAscii comparer = new LotteryBase.CompareToAscii();
                al.Sort(comparer);
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
            return (play_type == 0xd49);
        }

        public override double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            WinNumber = WinNumber.Trim();
            if (WinNumber.Length < 0x3b)
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
            if ((WinMoneyList == null) || (WinMoneyList.Length < 0x4a))
            {
                return -3.0;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            int num13 = 0;
            int num14 = 0;
            int num15 = 0;
            int num16 = 0;
            int num17 = 0;
            int num18 = 0;
            int num19 = 0;
            int num20 = 0;
            int num21 = 0;
            int num22 = 0;
            int num23 = 0;
            int num24 = 0;
            int num25 = 0;
            int num26 = 0;
            int num27 = 0;
            int num28 = 0;
            int num29 = 0;
            int num30 = 0;
            int num31 = 0;
            int num32 = 0;
            int num33 = 0;
            int num34 = 0;
            int num35 = 0;
            int num36 = 0;
            int num37 = 0;
            double num38 = 0.0;
            WinMoneyNoWithTax = 0.0;
            for (int i = 0; i < strArray.Length; i++)
            {
                string canonicalNumber = "";
                string[] strArray2 = this.ToSingle(strArray[i], ref canonicalNumber, 0xd49);
                if ((strArray2 != null) && (strArray2.Length >= 1))
                {
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        int num41 = 0;
                        int num42 = 0;
                        int num43 = 0;
                        int num44 = 0;
                        int num45 = 0;
                        int num46 = 0;
                        int num47 = 0;
                        int num48 = 0;
                        int num49 = 0;
                        int num50 = 0;
                        int num51 = 0;
                        int num52 = 0;
                        int num53 = 0;
                        int num54 = 0;
                        int num55 = 0;
                        int num56 = 0;
                        int num57 = 0;
                        int num58 = 0;
                        int num59 = 0;
                        int num60 = 0;
                        int num61 = 0;
                        int num62 = 0;
                        int num63 = 0;
                        int num64 = 0;
                        int num65 = 0;
                        int num66 = 0;
                        int num67 = 0;
                        int num68 = 0;
                        int num69 = 0;
                        int num70 = 0;
                        int num71 = 0;
                        int num72 = 0;
                        int num73 = 0;
                        int num74 = 0;
                        int num75 = 0;
                        int num76 = 0;
                        int num77 = 0;
                        double num78 = 0.0;
                        double winMoneyNoWithTax = 0.0;
                        switch ((_String.StringAt(strArray2[j], ' ') + 1))
                        {
                            case 1:
                                num78 = this.ComputeWin_1(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x48], WinMoneyList[0x49], ref num77);
                                break;

                            case 2:
                                num78 = this.ComputeWin_2(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[70], WinMoneyList[0x47], ref num76);
                                break;

                            case 3:
                                num78 = this.ComputeWin_3(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x42], WinMoneyList[0x43], WinMoneyList[0x44], WinMoneyList[0x45], ref num74, ref num75);
                                break;

                            case 4:
                                num78 = this.ComputeWin_4(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[60], WinMoneyList[0x3d], WinMoneyList[0x3e], WinMoneyList[0x3f], WinMoneyList[0x40], WinMoneyList[0x41], ref num71, ref num72, ref num73);
                                break;

                            case 5:
                                num78 = this.ComputeWin_5(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x36], WinMoneyList[0x37], WinMoneyList[0x38], WinMoneyList[0x39], WinMoneyList[0x3a], WinMoneyList[0x3b], ref num68, ref num69, ref num70);
                                break;

                            case 6:
                                num78 = this.ComputeWin_6(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x2e], WinMoneyList[0x2f], WinMoneyList[0x30], WinMoneyList[0x31], WinMoneyList[50], WinMoneyList[0x33], WinMoneyList[0x34], WinMoneyList[0x35], ref num64, ref num65, ref num66, ref num67);
                                break;

                            case 7:
                                num78 = this.ComputeWin_7(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x26], WinMoneyList[0x27], WinMoneyList[40], WinMoneyList[0x29], WinMoneyList[0x2a], WinMoneyList[0x2b], WinMoneyList[0x2c], WinMoneyList[0x2d], ref num60, ref num61, ref num62, ref num63);
                                break;

                            case 8:
                                num78 = this.ComputeWin_8(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0x1a], WinMoneyList[0x1b], WinMoneyList[0x1c], WinMoneyList[0x1d], WinMoneyList[30], WinMoneyList[0x1f], WinMoneyList[0x20], WinMoneyList[0x21], WinMoneyList[0x22], WinMoneyList[0x23], WinMoneyList[0x24], WinMoneyList[0x25], ref num54, ref num55, ref num56, ref num57, ref num58, ref num59);
                                break;

                            case 9:
                                num78 = this.ComputeWin_9(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[14], WinMoneyList[15], WinMoneyList[0x10], WinMoneyList[0x11], WinMoneyList[0x12], WinMoneyList[0x13], WinMoneyList[20], WinMoneyList[0x15], WinMoneyList[0x16], WinMoneyList[0x17], WinMoneyList[0x18], WinMoneyList[0x19], ref num48, ref num49, ref num50, ref num51, ref num52, ref num53);
                                break;

                            case 10:
                                num78 = this.ComputeWin_10(strArray2[j], WinNumber, ref winMoneyNoWithTax, WinMoneyList[0], WinMoneyList[1], WinMoneyList[2], WinMoneyList[3], WinMoneyList[4], WinMoneyList[5], WinMoneyList[6], WinMoneyList[7], WinMoneyList[8], WinMoneyList[9], WinMoneyList[10], WinMoneyList[11], WinMoneyList[12], WinMoneyList[13], ref num41, ref num42, ref num43, ref num44, ref num45, ref num46, ref num47);
                                break;

                            default:
                                goto Label_0563;
                        }
                        num += num41;
                        num2 += num42;
                        num3 += num43;
                        num4 += num44;
                        num5 += num45;
                        num6 += num46;
                        num7 += num47;
                        num8 += num48;
                        num9 += num49;
                        num10 += num50;
                        num11 += num51;
                        num12 += num52;
                        num13 += num53;
                        num14 += num54;
                        num15 += num55;
                        num16 += num56;
                        num17 += num57;
                        num18 += num58;
                        num19 += num59;
                        num20 += num60;
                        num21 += num61;
                        num22 += num62;
                        num23 += num63;
                        num24 += num64;
                        num25 += num65;
                        num26 += num66;
                        num27 += num67;
                        num28 += num68;
                        num29 += num69;
                        num30 += num70;
                        num31 += num71;
                        num32 += num72;
                        num33 += num73;
                        num34 += num74;
                        num35 += num75;
                        num36 += num76;
                        num37 += num77;
                        num38 += num78;
                        WinMoneyNoWithTax += winMoneyNoWithTax;
                    Label_0563: ;
                    }
                }
            }
            Description = "";
            if (num > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中10奖" + num.ToString() + "注";
            }
            if (num2 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中9奖" + num2.ToString() + "注";
            }
            if (num3 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中8奖" + num3.ToString() + "注";
            }
            if (num4 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中7奖" + num4.ToString() + "注";
            }
            if (num5 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中6奖" + num5.ToString() + "注";
            }
            if (num6 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中5奖" + num6.ToString() + "注";
            }
            if (num7 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选10中0奖" + num7.ToString() + "注";
            }
            if (num8 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中9奖" + num8.ToString() + "注";
            }
            if (num9 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中8奖" + num9.ToString() + "注";
            }
            if (num10 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中7奖" + num10.ToString() + "注";
            }
            if (num11 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中6奖" + num11.ToString() + "注";
            }
            if (num12 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中5奖" + num12.ToString() + "注";
            }
            if (num13 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选9中0奖" + num13.ToString() + "注";
            }
            if (num14 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中8奖" + num14.ToString() + "注";
            }
            if (num15 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中7奖" + num15.ToString() + "注";
            }
            if (num16 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中6奖" + num16.ToString() + "注";
            }
            if (num17 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中5奖" + num17.ToString() + "注";
            }
            if (num18 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中4奖" + num18.ToString() + "注";
            }
            if (num19 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选8中0奖" + num19.ToString() + "注";
            }
            if (num20 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选7中7奖" + num20.ToString() + "注";
            }
            if (num21 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选7中6奖" + num21.ToString() + "注";
            }
            if (num22 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选7中5奖" + num22.ToString() + "注";
            }
            if (num23 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选7中4奖" + num23.ToString() + "注";
            }
            if (num24 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选6中6奖" + num24.ToString() + "注";
            }
            if (num25 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选6中5奖" + num25.ToString() + "注";
            }
            if (num26 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选6中4奖" + num26.ToString() + "注";
            }
            if (num27 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选6中3奖" + num27.ToString() + "注";
            }
            if (num28 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选5中5奖" + num28.ToString() + "注";
            }
            if (num29 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选5中4奖" + num29.ToString() + "注";
            }
            if (num30 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选5中3奖" + num30.ToString() + "注";
            }
            if (num31 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选4中4奖" + num31.ToString() + "注";
            }
            if (num32 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选4中3奖" + num32.ToString() + "注";
            }
            if (num33 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选4中2奖" + num33.ToString() + "注";
            }
            if (num34 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选3中3奖" + num34.ToString() + "注";
            }
            if (num35 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选3中2奖" + num35.ToString() + "注";
            }
            if (num36 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选2中2奖" + num36.ToString() + "注";
            }
            if (num37 > 0)
            {
                if (Description != "")
                {
                    Description = Description + "，";
                }
                Description = Description + "选2中2奖" + num37.ToString() + "注";
            }
            if (Description != "")
            {
                Description = Description + "。";
            }
            return num38;
        }

        private double ComputeWin_1(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int Description1)
        {
            Description1 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            if (WinNumber.IndexOf(Number) >= 0)
            {
                Description1++;
                num += WinMoney1;
                WinMoneyNoWithTax += WinMoneyNoWithTax1;
            }
            return num;
        }

        private double ComputeWin_10(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, double WinMoney7, double WinMoneyNoWithTax7, ref int Description1, ref int Description2, ref int Description3, ref int Description4, ref int Description5, ref int Description6, ref int Description7)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            Description4 = 0;
            Description5 = 0;
            Description6 = 0;
            Description7 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[10];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d\s)(?<R7>\d\d\s)(?<R8>\d\d\s)(?<R9>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 10; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 10:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 9:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 8:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;

                case 7:
                    Description4++;
                    num += WinMoney4;
                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                    return num;

                case 6:
                    Description5++;
                    num += WinMoney5;
                    WinMoneyNoWithTax += WinMoneyNoWithTax5;
                    return num;

                case 5:
                    Description6++;
                    num += WinMoney6;
                    WinMoneyNoWithTax += WinMoneyNoWithTax6;
                    return num;

                case 0:
                    Description7++;
                    num += WinMoney7;
                    WinMoneyNoWithTax += WinMoneyNoWithTax7;
                    return num;
            }
            return num;
        }

        private double ComputeWin_2(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, ref int Description1)
        {
            Description1 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[2];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 2; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            if (num2 == 2)
            {
                Description1++;
                num += WinMoney1;
                WinMoneyNoWithTax += WinMoneyNoWithTax1;
            }
            return num;
        }

        private double ComputeWin_3(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, ref int Description1, ref int Description2)
        {
            Description1 = 0;
            Description2 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[3];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 3; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 3:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 2:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;
            }
            return num;
        }

        private double ComputeWin_4(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, ref int Description1, ref int Description2, ref int Description3)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[4];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 4; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 4:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 3:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 2:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;
            }
            return num;
        }

        private double ComputeWin_5(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, ref int Description1, ref int Description2, ref int Description3)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[5];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 5; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 5:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 4:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 3:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;
            }
            return num;
        }

        private double ComputeWin_6(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, ref int Description1, ref int Description2, ref int Description3, ref int Description4)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            Description4 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[6];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 6; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 6:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 5:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 4:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;

                case 3:
                    Description4++;
                    num += WinMoney4;
                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                    return num;
            }
            return num;
        }

        private double ComputeWin_7(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, ref int Description1, ref int Description2, ref int Description3, ref int Description4)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            Description4 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[7];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 7; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 7:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 6:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 5:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;

                case 4:
                    Description4++;
                    num += WinMoney4;
                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                    return num;
            }
            return num;
        }

        private double ComputeWin_8(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, ref int Description1, ref int Description2, ref int Description3, ref int Description4, ref int Description5, ref int Description6)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            Description4 = 0;
            Description5 = 0;
            Description6 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[8];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d\s)(?<R7>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 8; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 8:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 7:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 6:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;

                case 5:
                    Description4++;
                    num += WinMoney4;
                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                    return num;

                case 4:
                    Description5++;
                    num += WinMoney5;
                    WinMoneyNoWithTax += WinMoneyNoWithTax5;
                    return num;

                case 0:
                    Description6++;
                    num += WinMoney6;
                    WinMoneyNoWithTax += WinMoneyNoWithTax6;
                    return num;
            }
            return num;
        }

        private double ComputeWin_9(string Number, string WinNumber, ref double WinMoneyNoWithTax, double WinMoney1, double WinMoneyNoWithTax1, double WinMoney2, double WinMoneyNoWithTax2, double WinMoney3, double WinMoneyNoWithTax3, double WinMoney4, double WinMoneyNoWithTax4, double WinMoney5, double WinMoneyNoWithTax5, double WinMoney6, double WinMoneyNoWithTax6, ref int Description1, ref int Description2, ref int Description3, ref int Description4, ref int Description5, ref int Description6)
        {
            Description1 = 0;
            Description2 = 0;
            Description3 = 0;
            Description4 = 0;
            Description5 = 0;
            Description6 = 0;
            double num = 0.0;
            WinMoneyNoWithTax = 0.0;
            string[] strArray = new string[9];
            Match match = new Regex(@"(?<R0>\d\d\s)(?<R1>\d\d\s)(?<R2>\d\d\s)(?<R3>\d\d\s)(?<R4>\d\d\s)(?<R5>\d\d\s)(?<R6>\d\d\s)(?<R7>\d\d\s)(?<R8>\d\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Match(Number);
            int num2 = 0;
            for (int i = 0; i < 9; i++)
            {
                strArray[i] = match.Groups["R" + i.ToString()].ToString().Trim();
                if (WinNumber.IndexOf(strArray[i]) >= 0)
                {
                    num2++;
                }
            }
            switch (num2)
            {
                case 9:
                    Description1++;
                    num += WinMoney1;
                    WinMoneyNoWithTax += WinMoneyNoWithTax1;
                    return num;

                case 8:
                    Description2++;
                    num += WinMoney2;
                    WinMoneyNoWithTax += WinMoneyNoWithTax2;
                    return num;

                case 7:
                    Description3++;
                    num += WinMoney3;
                    WinMoneyNoWithTax += WinMoneyNoWithTax3;
                    return num;

                case 6:
                    Description4++;
                    num += WinMoney4;
                    WinMoneyNoWithTax += WinMoneyNoWithTax4;
                    return num;

                case 5:
                    Description5++;
                    num += WinMoney5;
                    WinMoneyNoWithTax += WinMoneyNoWithTax5;
                    return num;

                case 0:
                    Description6++;
                    num += WinMoney6;
                    WinMoneyNoWithTax += WinMoneyNoWithTax6;
                    return num;
            }
            return num;
        }

        private string[] FilterRepeated(string[] NumberPart)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < NumberPart.Length; i++)
            {
                int ball = _Convert.StrToInt(NumberPart[i], -1);
                if (((ball >= 1) && (ball <= 80)) && !base.isExistBall(al, ball))
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

        public override PlayType[] GetPlayTypeList()
        {
            return new PlayType[] { new PlayType(0xd49, "代购") };
        }

        public override string ShowNumber(string Number)
        {
            return base.ShowNumber(Number, "");
        }

        public override string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            string[] strArray = this.FilterRepeated(Number.Trim().Split(new char[] { ' ' }));
            CanonicalNumber = "";
            if (strArray.Length < 1)
            {
                CanonicalNumber = "";
                return null;
            }
            for (int i = 0; (i < strArray.Length) && (i < 10); i++)
            {
                CanonicalNumber = CanonicalNumber + strArray[i] + " ";
            }
            CanonicalNumber = CanonicalNumber.Trim();
            return new string[] { CanonicalNumber };
        }
    }
}
