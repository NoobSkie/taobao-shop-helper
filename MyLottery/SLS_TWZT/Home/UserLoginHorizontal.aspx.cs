using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_UserLoginHorizontal : SitePageBase, IRequiresSessionState
{
    public string labCheckCode = "验证码：";

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        base.Response.Write(" <script   language=javascript> parent.location.href= '../Admin/Default.aspx'; </script> ");
        base.Response.End();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if (new Login().LoginSubmit(this.Page, base._Site, this.tbUserName.Text, this.tbUserPassword.Text, this.tbCheckCode.Text, this.ShoveCheckCode1, ref returnDescription) < 0)
        {
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            base.Response.Redirect(base.Request.Url.AbsoluteUri, true);
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string returnDescription = "";
            base._User.Logout(ref returnDescription);
        }
        else
        {
            base.Response.Redirect(base.Request.Url.AbsoluteUri, true);
        }
        base.Response.Redirect(base.Request.Url.AbsoluteUri, true);
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // This item is obfuscated and can not be translated.
        if (!base.IsPostBack)
        {
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            if (!flag)
            {
                this.labCheckCode = "";
                this.tbCheckCode.Visible = false;
                this.ShoveCheckCode1.Visible = false;
            }
        }
        base._User = Users.GetCurrentUser(base._Site.ID);
        if (base._User == null)
        {
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            goto Label_01F4;
        }
        this.Panel1.Visible = false;
        this.Panel2.Visible = true;
        if (base._User.Name == null)
        {
            goto Label_01F4;
        }
        string name = base._User.Name;
        this.lbUserName.Text = "";
        if (base._User.Competences.CompetencesList != "")
        {
            this.lbUserType.Text = "级别:管理员";
        }
        else if (base._User.OwnerSites != "")
        {
            this.lbUserType.Text = "级别:代理商";
        }
        else
        {
            switch (base._User.UserType)
            {
                case 1:
                    this.lbUserType.Text = "级别:普通";
                    goto Label_0183;

                case 2:
                    this.lbUserType.Text = "级别:高级";
                    goto Label_0183;

                case 3:
                    this.lbUserType.Text = "级别:VIP";
                    goto Label_0183;
            }
        }
    Label_0183:
        this.lbBalance.Text = "余额：<font color=\"red\">" + base._User.Balance.ToString("N") + "</font> 元";
        this.btnAdmin.Visible = base._User.Competences.CompetencesList != "";
    Label_01F4:
        this.tbUserPassword.Attributes.Add("value", this.tbUserPassword.Text);
    }
}

