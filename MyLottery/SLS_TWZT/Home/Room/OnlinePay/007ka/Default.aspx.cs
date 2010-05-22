using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_007ka_Default : RoomPageBase, IRequiresSessionState
{
    public string Balance;

    private SystemOptions so = new SystemOptions();
    public string UserName;

    private void GetBlankURL()
    {
        string selectedValue = "0";
        string str2 = "007KA";
        selectedValue = this.rblist.SelectedValue;
        this.imgbtn_OK.NavigateUrl = Utility.GetUrl() + "/Home/Room/OnlinePay/007ka/send.aspx?ordermoney=" + selectedValue + "&cardno=" + str2 + "&BuyId=" + Utility.GetRequest("BuyID");
    }

    protected string getReallityMoney(int OrialMoney)
    {
        double num = 0.0;
        double num2 = this.so["OnlinePay_007Ka_FormalitiesFees"].ToDouble(0.0) / 100.0;
        num = OrialMoney - (OrialMoney * num2);
        return num.ToString();
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
            this.labFeesScale.Text = this.so["OnlinePay_007Ka_FormalitiesFees"].ToString("") + "%";
            this.GetBlankURL();
        }
    }

    protected void rblist_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetBlankURL();
    }


}

