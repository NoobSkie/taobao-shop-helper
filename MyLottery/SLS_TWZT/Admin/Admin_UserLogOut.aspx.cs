using ASP;
using DAL;
using Shove;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Admin_UserLogOut : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataTable table = new Tables.T_Users().Open("ID,SiteID ,Name ,RealityName, IDCardNumber ,Email ,QQ,Telephone , Mobile ,isCanLogin ,Reason", "SiteID = " + base._Site.ID.ToString() + "and isCanLogin= 0", "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Admin_UserLogOut");
        }
        else
        {
            DataRow[] rowArray;
            DataTable dt = table.Clone();
            if (this.rbUser.Checked)
            {
                rowArray = table.Select("Reason is not null");
            }
            else
            {
                rowArray = table.Select("Reason is null");
            }
            foreach (DataRow row in rowArray)
            {
                dt.Rows.Add(row.ItemArray);
            }
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[7].FindControl("cbisCanLogin");
            box.Checked = _Convert.StrToBool(e.Item.Cells[10].Text, true);
            string text = e.Item.Cells[8].Text;
            if (text.Length > 20)
            {
                e.Item.Cells[8].Text = text.Substring(0, 20) + "……";
            }
            e.Item.Cells[8].Attributes.Add("title", text);
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

    protected void rbAdmin_CheckedChanged(object sender, EventArgs e)
    {
        this.tdDscrition.InnerHtml = "管理员限制详情";
        this.BindData();
    }

    protected void rbUser_CheckedChanged(object sender, EventArgs e)
    {
        this.tdDscrition.InnerHtml = "用户注销详情";
        this.BindData();
    }


}

