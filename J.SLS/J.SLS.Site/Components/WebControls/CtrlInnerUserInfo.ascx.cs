using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Components_WebControls_CtrlInnerUserInfo : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CurrentUser != null)
            {
                lblName.Text = CurrentUser.RealName;
                lblMoney.Text = "￥" + CurrentUser.EnableMoney.ToString("0.00");
            }
        }
    }
}
