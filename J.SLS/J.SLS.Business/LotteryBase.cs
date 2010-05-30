using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace J.SLS.Business
{
    public class LotteryBase
    {
        public string code;
        public int id;
        public string name;

        public virtual string AnalyseScheme(string Content, int PlayType)
        {
            return "";
        }

        public virtual bool AnalyseWinNumber(string Number)
        {
            return true;
        }

        public virtual bool AnalyseWinNumber(string Number, int CompetitionCount)
        {
            return true;
        }

        public virtual string BuildNumber(int Num)
        {
            return "";
        }

        public virtual string BuildNumber(int Num, int Type)
        {
            return "";
        }

        public virtual string BuildNumber(int Red, int Blue, int Num)
        {
            return "";
        }

        public virtual bool CheckPlayType(int play_type)
        {
            return false;
        }

        public virtual double ComputeWin(string Number, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, params double[] WinMoneyList)
        {
            return 0.0;
        }

        public virtual double ComputeWin(string Scheme, string WinNumber, ref string Description, ref double WinMoneyNoWithTax, int PlayType, int CompetitionCount, string NoSignificance)
        {
            return 0.0;
        }

        protected string FilterPreFix(string Number)
        {
            if (!Number.StartsWith("[") && (Number.IndexOf("]") < 0))
            {
                return Number;
            }
            return Number.Split(new char[] { ']' })[1];
        }

        protected string GetLotteryNumberPreFix(string Number)
        {
            if (((Number == null) || (Number == "")) || !Number.StartsWith("["))
            {
                return "";
            }
            return (Number.Split(new char[] { ']' })[0] + "]");
        }

        public virtual PlayType[] GetPlayTypeList()
        {
            return null;
        }

        public virtual string GetPrintKeyList(string Number, int PlayType_id, string LotteryMachine)
        {
            return "";
        }

        public virtual bool GetSchemeSplit(string Scheme, ref string BuyContent, ref string CnLocateWaysAndMultiples)
        {
            return true;
        }

        public virtual string HPJX_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            return "";
        }

        public virtual string HPSH_ToElectronicTicket(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID)
        {
            return "";
        }

        protected bool isExistBall(ArrayList al, int Ball)
        {
            if (al.Count != 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    if (int.Parse(al[i].ToString()) == Ball)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected string[] MergeLotteryNumberPreFix(string[] Numbers, string PreFix)
        {
            if ((Numbers != null) && (Numbers.Length != 0))
            {
                for (int i = 0; i < Numbers.Length; i++)
                {
                    Numbers[i] = PreFix + Numbers[i];
                }
            }
            return Numbers;
        }

        protected void MergeWinDescription(ref string WinDescription, string AddDescription)
        {
            if (WinDescription != "")
            {
                WinDescription = WinDescription + "，";
            }
            WinDescription = WinDescription + AddDescription;
        }

        public virtual string ShowNumber(string Number)
        {
            return "";
        }

        public string ShowNumber(string Number, string SpaceMark)
        {
            if (SpaceMark == "")
            {
                return Number;
            }
            Number = Number.Replace(" ", "");
            string str = "";
            for (int i = 0; i < Number.Length; i++)
            {
                str = str + Number[i].ToString() + SpaceMark;
            }
            return str.Trim();
        }

        protected string Sort(string str)
        {
            char[] array = str.ToCharArray();
            Array.Sort(array, new CompareToAscii());
            return new string(array);
        }

        protected string[] SplitLotteryNumber(string Number)
        {
            string[] strArray = Number.Split(new char[] { '\n' });
            if (strArray.Length == 0)
            {
                return null;
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = strArray[i].Trim();
            }
            return strArray;
        }

        public virtual string ToElectronicTicket_BJDC(int PlayTypeID, string Number, ref string TicketNumber, ref int NewPlayTypeID, ref string Rule, ref int Multiple, ref double Money, ref string GameNoList, ref string PassMode, ref int TicketCount)
        {
            return "";
        }

        public virtual Ticket[] ToElectronicTicket_DYJ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_HPCQ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_HPJX(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_HPSD(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_HPSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_XGCQ(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual Ticket[] ToElectronicTicket_XGSH(int PlayTypeID, string Number, int Multiple, int MaxMultiple, ref double Money)
        {
            return null;
        }

        public virtual string[] ToSingle(string Number, ref string CanonicalNumber, int PlayType)
        {
            return null;
        }

        protected class CompareToAscii : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return new CaseInsensitiveComparer().Compare(x, y);
            }
        }
    }
}
