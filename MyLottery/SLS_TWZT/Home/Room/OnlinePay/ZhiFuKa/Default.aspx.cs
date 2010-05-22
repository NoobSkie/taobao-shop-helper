using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_ZhiFuKa_Default : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    private SystemOptions so = new SystemOptions();
    public string UserName;

    protected void btnNext_Click(object sender, ImageClickEventArgs e)
    {
        string selectedValue = "0";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        if (this.radSZX.Checked)
        {
            selectedValue = this.rblist_szx.SelectedValue;
            str2 = "szx";
            str3 = str2 + selectedValue.ToString().PadLeft(3, '0');
            str4 = this.txtCardNum_szx.Text.Trim();
            str5 = this.txtCardPass_szx.Text.Trim();
        }
        else
        {
            selectedValue = this.rblist_zfk.SelectedValue;
            str2 = "zfk";
            str3 = str2 + selectedValue.ToString().PadLeft(3, '0');
            str4 = this.txtCardNum_zfk.Text.Trim();
            str5 = this.txtCardPass_zfk.Text.Trim();
            if (selectedValue == "1")
            {
                selectedValue = "0.01";
            }
        }
        base.Response.Redirect("send.aspx?ordermoney=" + selectedValue + "&cardno=" + str2 + "&faceno=" + str3 + "&cardnum=" + str4 + "&cardpass=" + str5 + "&BuyId=" + Utility.GetRequest("BuyID"));
    }

    protected string getReallityMoney(int OrialMoney)
    {
        double num = 0.0;
        double num2 = this.so["OnlinePay_ZhiFuKa_PayFormalitiesFeesScale"].ToDouble(0.0) / 100.0;
        num = OrialMoney - (OrialMoney * num2);
        return num.ToString();
    }

    protected void lbReturn_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("../default.aspx?BuyId=" + Utility.GetRequest("BuyID"));
    }

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
        if (!base.IsPostBack)
        {
            if (Utility.GetRequest("cardno") != "zfk")
            {
                this.radSZX.Checked = true;
                this.imgCardType.ImageUrl = "../Alipay02/images/bank_logo/logo_szx.gif";
                this.tb_szx.Visible = true;
                this.tb_51zfk.Visible = false;
            }
            else
            {
                this.rad51ZFK.Checked = true;
                this.imgCardType.ImageUrl = "../Alipay02/images/bank_logo/logo_51zfk.gif";
                this.tb_szx.Visible = false;
                this.tb_51zfk.Visible = true;
            }
            this.labFeesScale_zfk.Text = this.labFeesScale_szx.Text = this.so["OnlinePay_ZhiFuKa_PayFormalitiesFeesScale"].Value.ToString() + " %";
        }
    }
}

