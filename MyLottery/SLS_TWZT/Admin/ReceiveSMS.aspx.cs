using ASP;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ReceiveSMS : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        string str;
        int num = int.Parse(this.ddlDateTime.SelectedValue);
        if (num == -1)
        {
            str = "select * from T_SMS where SiteID = " + base._Site.ID.ToString() + " and SMSID <> -1 order by [DateTime] desc";
        }
        else
        {
            str = "select * from T_SMS where SiteID = " + base._Site.ID.ToString() + " and Datediff(day, [DateTime], GetDate()) <= " + num.ToString() + " and SMSID <> -1 order by [DateTime] desc";
        }
        DataTable dt = MSSQL.Select(str, new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Questions");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    protected void ddlDateTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "SendMessage" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

    private void ReceiveMessage()
    {
    }

 
}

