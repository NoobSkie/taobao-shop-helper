using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Help_Help_Index : SitePageBase, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.hdLotteryID.Value = base.Request.QueryString["Type"];
    }


}

