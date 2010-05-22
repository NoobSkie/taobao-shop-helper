using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ViewAccount : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.labUserType.Text = (base._User.UserType == 1) ? "普通用户" : ((base._User.UserType == 3) ? "VIP" : "高级用户");
        this.labBalance.Text = (base._User.Balance + base._User.Freeze).ToString("N");
        this.labFreeze.Text = base._User.Freeze.ToString("N");
        this.labBalanceDo.Text = base._User.Balance.ToString("N");
        this.labScoring.Text = base._User.Scoring.ToString();
        if (base._User.Freeze > 0.0)
        {
            this.lbFreezDetail.Visible = true;
        }
        else
        {
            this.lbFreezDetail.Visible = false;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }
}

