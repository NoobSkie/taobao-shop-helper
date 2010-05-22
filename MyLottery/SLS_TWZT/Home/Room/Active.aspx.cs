using ASP;
using Shove.Database;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Active : SitePageBase, IRequiresSessionState
{

    protected void btnAgree_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if (!MSSQL.ExecuteSQLScript("update T_Users set IsCrossLogin = 1 where [ID] = " + base._User.ID.ToString()))
            {
                new Log("Users").Write("修改用户的IsCrossLogin字段失败");
            }
        }
        else
        {
            new Log("Users").Write("用户点击隐私页面的同意按钮时，用户信息为空");
        }
        base.Response.Redirect("../../Default.aspx", true);
    }

    protected void btnDisagree_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string returnDescription = "";
            base._User.Logout(ref returnDescription);
        }
        base.Response.Redirect("../../Default.aspx", true);
    }

    protected void btnIntroduce_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("BottomNavigationPages/index.html", true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if ((base._User != null) && !base._User.IsCrossLogin)
            {
                this.lbFrom.Text = base._User.Name;
            }
            else
            {
                base.Response.Redirect("../../Default.aspx", true);
            }
        }
    }
}

