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

public partial class Admin_StationSMSList : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable dt = new Views.V_StationSMS().Open("", "SiteID = " + base._Site.ID.ToString(), "[DateTime] desc");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_StationSMSList");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    protected void g_ItemCheckedChanged(object sender, EventArgs e)
    {
        CheckBox box = (CheckBox)sender;
        DataGridItem parent = (DataGridItem)box.Parent.Parent;
        long num = _Convert.StrToLong(parent.Cells[6].Text, 0L);
        if (new Tables.T_StationSMS { isShow = { Value = box.Checked } }.Update("ID = " + num.ToString()) < 0L)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_StationSMSList");
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            long num = _Convert.StrToLong(e.Item.Cells[6].Text, 0L);
            if (new Tables.T_StationSMS().Delete("ID = " + num.ToString()) < 0L)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_StationSMSList");
            }
            else
            {
                this.BindData();
            }
        }
    }

    protected void g_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[5].FindControl("cbisShow");
            box.CheckedChanged += new EventHandler(this.g_ItemCheckedChanged);
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[5].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[7].Text, true);
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "SendMessage", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.g.Columns[4].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "SendMessage" }));
        }
    }


}

