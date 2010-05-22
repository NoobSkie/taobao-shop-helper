using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ChaseLogin : RoomPageBase, IRequiresSessionState
{

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if (new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription) < 0)
        {
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            base.Response.Write("<script>window.top.location.href='../../LotteryPackage.aspx'</script>");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
        }
    }
}

