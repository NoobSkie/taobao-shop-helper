using ASP;
using DAL;
using Shove;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_BuyProtocol : SitePageBase, IRequiresSessionState
{

    private void bindData(int lotteryID)
    {
        DataTable table = new Tables.T_Lotteries().Open("Agreement", "ID = " + lotteryID, "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            string str = table.Rows[0]["Agreement"].ToString();
            this.lbAgreement.Text = str.Replace("[SiteName]", base._Site.Name).Replace("[SiteUrl]", base._Site.Url);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int lotteryID = _Convert.StrToInt(base.Request["LotteryID"], 5);
            this.bindData(lotteryID);
        }
    }
}

