using ASP;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_User : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string commandText = "select a.ID,Name,RealityName,IDCardNumber,Email,QQ,Telephone,Mobile,RegisterTime,BankName,BankCardNumber from  T_Users a \r\n  where   RegisterTime between '2009-10-01 00:00:00' and '2009-10-08 23:59:59' and ID in(select UserID from T_UserPayDetails where Money >= 60 and DateTime  between '2009-10-01 00:00:00' and '2009-10-08 23:59:59' and Result = 1)";
        DataTable dt = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
        PF.DataGridBindData(this.g, dt, this.gPager);
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = "<a href='UserDetail.aspx?SiteID=1&ID=" + e.Item.Cells[10].Text + "'>" + e.Item.Cells[0].Text + "</a>";
        }
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberManagement", "QueryData" });
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

