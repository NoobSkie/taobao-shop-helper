using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_Alipay02_Send_Default : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    public string DefaultSendPage = "";
    private SystemOptions so = new SystemOptions();
    public string UserName;

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
        }
        if (WebConfig.GetAppSettingsInt("OnlinePayType", 2) == 1)
        {
            base.Response.Redirect("../Alipay01/Default.aspx", true);
        }
        else
        {
            bool flag = this.so["OnlinePay_Alipay_Status_ON"].ToBoolean(false);
            bool flag2 = this.so["OnlinePay_99Bill_Status_ON"].ToBoolean(false);
            bool flag3 = this.so["OnlinePay_Tenpay_Status_ON"].ToBoolean(false);
            bool flag4 = this.so["OnlinePay_007Ka_Status_ON"].ToBoolean(false);
            bool flag5 = this.so["OnlinePay_YeePay_Status_ON"].ToBoolean(false);
            if (!flag)
            {
                this.td_Alipay.Visible = false;
                this.td_Alipay1.Visible = false;
            }
            else if (this.DefaultSendPage == "")
            {
                this.DefaultSendPage = "Send_Alipay.aspx";
            }
            if (!flag2)
            {
                this.td_99Bill.Visible = false;
                this.td_99Bill1.Visible = false;
            }
            else if (this.DefaultSendPage == "")
            {
                this.DefaultSendPage = "Send_99Bill.aspx";
            }
            if (!flag3)
            {
                this.td_CFT.Visible = false;
            }
            else if (this.DefaultSendPage == "")
            {
                this.DefaultSendPage = "Send_CFT.aspx";
            }
            if (!flag5)
            {
                this.td_Yeepay.Visible = false;
                this.td_Yeepay1.Visible = false;
            }
            else if (this.DefaultSendPage == "")
            {
                this.DefaultSendPage = "Send_YeePay.aspx";
            }
            if (!flag4)
            {
                this.td_SZX.Visible = false;
                this.td_SZX1.Visible = false;
            }
            else if (this.DefaultSendPage == "")
            {
                this.DefaultSendPage = "../007ka/Default.aspx";
            }
        }
    }

   
}

