using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_CardPassword_Login : SitePageBase, IRequiresSessionState
{
  

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if (this.LoginSubmit(this.Page, base._Site, this.tbID.Text, this.tbPassword.Text, this.tbCheckCode.Text, this.CheckCode, ref returnDescription) < 0)
        {
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            new Login().GoToRequestLoginPage("Default.aspx");
        }
    }

    public int LoginSubmit(Page page, Sites site, string ID, string Password, string InputCheckCode, ShoveCheckCode sccCheckCode, ref string ReturnDescription)
    {
        ReturnDescription = "";
        bool flag = site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
        ID = ID.Trim();
        Password = Password.Trim();
        if ((ID == "") || (Password == ""))
        {
            ReturnDescription = "用户名和密码都不能为空";
            return -1;
        }
        if (flag && !sccCheckCode.Valid(InputCheckCode))
        {
            ReturnDescription = "验证码输入错误";
            return -2;
        }
        Thread.Sleep(500);
        return new CardPasswordAgentUsers { ID = _Convert.StrToInt(ID, 0), Password = Password }.Login(ref ReturnDescription);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        new Login().SetCheckCode(base._Site, this.CheckCode);
    }


}

