using ASP;
using SMS.Eucp.Gateway;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ISPAccount : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        string name = base._Site.SiteOptions["Opt_ISP_UserID"].Value.ToString();
        string password = base._Site.SiteOptions["Opt_ISP_UserPassword"].Value.ToString();
        if ((name == "") || (password == ""))
        {
            PF.GoError(1, "查询短信服务器失败，可能是参数设置错误。", base.GetType().BaseType.FullName);
        }
        else
        {
            SMS.Eucp.Gateway.Gateway gateway = new SMS.Eucp.Gateway.Gateway(name, password);
            CallResult balance = gateway.GetBalance();
            CallResult price = gateway.GetPrice();
            if (balance.Code < 0)
            {
                PF.GoError(1, "查询短信服务器失败，查询余额时：" + balance.Description, base.GetType().BaseType.FullName);
            }
            else if (price.Code < 0)
            {
                PF.GoError(1, "查询短信服务器失败，查询单价时：" + price.Description, base.GetType().BaseType.FullName);
            }
            else
            {
                this.Label1.Text = balance.Value.ToString() + " 元";
                this.Label2.Text = price.Value.ToString() + " 元/条";
                this.Label3.Text = "服务商不提供此数据";
                this.Label4.Text = "服务商不提供此数据";
                this.Label5.Text = "服务商不提供此数据";
                this.Label6.Text = "服务商不提供此数据";
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
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

