using ASP;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Error : SitePageBase, IRequiresSessionState
{
    protected string script = "";

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        short num = _Convert.StrToShort(Utility.GetRequest("ErrorNumber"), 1);
        string request = Utility.GetRequest("Tip");
        string str2 = Encrypt.UnEncryptString(PF.GetCallCert(), Utility.GetRequest("ClassName"));
        this.labTip.Text = request;
        this.labTipForNoIsuse.Text = request;
        this.labClassName1.Text = str2;
        this.labClassName2.Text = str2;
        switch (num)
        {
            case 6:
            case 7:
                this.tabError.Visible = false;
                this.tabErrorForNoIsuse.Visible = true;
                break;

            default:
                this.tabError.Visible = true;
                this.tabErrorForNoIsuse.Visible = false;
                break;
        }
        base.Request.Url.AbsoluteUri.ToLower();
        this.script = "window.setTimeout(function(){top.location.href='" + Utility.GetUrl() + "';},5000);";
    }
}

