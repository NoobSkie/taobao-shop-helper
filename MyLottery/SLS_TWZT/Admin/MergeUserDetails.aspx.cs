using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_MergeUserDetails : AdminPageBase, IRequiresSessionState
{


    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.tbPassword.Text != (base._User.Name + base._User.Balance.ToString()))
        {
            JavaScript.Alert(this.Page, "系统密码错误，请向开发商咨询此密码！");
        }
        else
        {
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_MergeUserDetails("7ien.88856856", ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_MergeUserDetails");
            }
            else if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                base._User.Logout(ref returnDescription);
                JavaScript.Alert(this.Page, "账户明细结转成功！");
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Administrator" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

 
}

