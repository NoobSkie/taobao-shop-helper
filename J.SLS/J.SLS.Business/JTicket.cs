using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Business
{
    public class JTicket
    {
        public double Money;
        public int Multiple;
        public string Number;
        public int PlayTypeID;

        public JTicket(int playtype_id, string number, int multiple, double money)
        {
            this.PlayTypeID = playtype_id;
            this.Multiple = multiple;
            this.Number = number;
            this.Money = money;
        }

        public override string ToString()
        {
            return (this.PlayTypeID.ToString() + "," + this.Multiple.ToString() + "," + this.Money.ToString() + "," + this.Number.Replace("\r\n", "\t").Replace("\n", "\t") + ";");
        }
    }
}
