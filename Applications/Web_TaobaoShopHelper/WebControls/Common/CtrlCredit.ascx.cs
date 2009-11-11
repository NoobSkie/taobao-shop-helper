using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Common
{
    public partial class CtrlCredit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CreditNum == 0)
                {
                    lblNum.Visible = true;
                    imgCredit.Visible = false;
                }
                else
                {
                    lblNum.Visible = false;
                    imgCredit.Visible = true;
                    string name = GetImageName();
                    imgCredit.ImageUrl = string.Format("~/Images/System/CreditIcos/{0}.gif", name);
                }
            }
        }

        private string GetImageName()
        {
            string name = "";
            if (UserType == UserType.Buyer)
            {
                name += "b_";
            }
            else
            {
                name += "s_";
            }
            if (CreditNum <= 250)
            {
                name += "red_";
                if (CreditNum <= 10) { name += "1"; }
                else if (CreditNum <= 40) { name += "2"; }
                else if (CreditNum <= 90) { name += "3"; }
                else if (CreditNum <= 150) { name += "4"; }
                else { name += "5"; }
            }
            else if (CreditNum <= 10000)
            {
                name += "blue_";
                if (CreditNum <= 500) { name += "1"; }
                else if (CreditNum <= 1000) { name += "2"; }
                else if (CreditNum <= 2000) { name += "3"; }
                else if (CreditNum <= 5000) { name += "4"; }
                else { name += "5"; }
            }
            else if (CreditNum <= 500000)
            {
                name += "cap_";
                if (CreditNum <= 20000) { name += "1"; }
                else if (CreditNum <= 50000) { name += "2"; }
                else if (CreditNum <= 100000) { name += "3"; }
                else if (CreditNum <= 200000) { name += "4"; }
                else { name += "5"; }
            }
            else
            {
                name += "king_";
                if (CreditNum <= 1000000) { name += "1"; }
                else if (CreditNum <= 2000000) { name += "2"; }
                else if (CreditNum <= 5000000) { name += "3"; }
                else if (CreditNum <= 10000000) { name += "4"; }
                else { name += "5"; }
            }
            return name;
        }

        public int CreditNum { get; set; }

        public UserType UserType { get; set; }
    }
}