using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_FocusNews : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataTable dt = new Tables.T_FocusNews().Open("", "", "");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_FocusNews");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("FocusNewsAdd.aspx", true);
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("FocusNewsAdd.aspx?id=" + e.Item.Cells[4].Text, true);
        }
        else if (e.CommandName == "Del")
        {
            new Tables.T_FocusNews().Delete("ID=" + e.Item.Cells[4].Text.Trim());
            Shove._Web.Cache.ClearCache("Default_GetFocusNews");
            this.BindData();
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.FindControl("cbIsMaster");
            box.Checked = _Convert.StrToBool(e.Item.Cells[5].Text, true);
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
            this.g.Columns[3].Visible = this.btnAdd.Visible;
        }
    }


}

