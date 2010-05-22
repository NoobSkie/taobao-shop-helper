using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_SelectDefaultFirstPage : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        this.labName.Text = base._Site.Name;
        this.labLevel.Text = SiteLevels.GetSiteLevelName(base._Site.Level);
        this.imgON.ImageUrl = base._Site.ON ? "../Images/Admin/Run.gif" : "../Images/Admin/Stop.gif";
        this.imgON.ToolTip = base._Site.ON ? "正在运行" : "已停止";
        short num = base._Site.SiteOptions["Opt_DefaultFirstPageType"].ToShort(2);
        if (base._Site.Level == 4)
        {
            this.rb1.Enabled = false;
            num = 2;
        }
        this.rb1.Checked = num == 1;
        this.rb2.Checked = num == 2;
        this.rb3.Checked = num == 3;
        this.rb4.Checked = num == 4;
        this.rb5.Checked = num == 5;
        this.rb6.Checked = num == 6;
        this.rb7.Checked = num == 7;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.rb1.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)1);
        }
        else if (this.rb2.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)2);
        }
        else if (this.rb3.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)3);
        }
        else if (this.rb4.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)4);
        }
        else if (this.rb5.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)5);
        }
        else if (this.rb6.Checked)
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)6);
        }
        else
        {
            base._Site.SiteOptions["Opt_DefaultFirstPageType"] = new OptionValue((short)7);
        }
        JavaScript.Alert(this.Page, "站点默认的首页已经保存成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        if (options["SystemVersionType"].ToInt(3) >= 3)
        {
            PF.GoError(3, "对不起，您没有足够的权限访问此页面", base.GetType().BaseType.FullName);
        }
        else if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
    }


}

