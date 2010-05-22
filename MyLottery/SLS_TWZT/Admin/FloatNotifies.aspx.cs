using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_FloatNotifies : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string key = "FloatNotifyContent";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_FloatNotify().Open("", "", "[Order] asc,[DateTime] desc");
            if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xea60);
            }
        }
        this.g.DataSource = cacheAsDataTable;
        this.g.DataBind();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            base.Response.Redirect("FloatNotifiesEdit.aspx?ID=" + e.Item.Cells[6].Text, true);
        }
        if (e.CommandName == "Deletes")
        {
            new Tables.T_FloatNotify().Delete("ID=" + e.Item.Cells[6].Text);
            Shove._Web.Cache.ClearCache("FloatNotifyContent");
            this.BindData();
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbisShow");
            box.Checked = _Convert.StrToBool(e.Item.Cells[7].Text, true);
            e.Item.Cells[0].Text = e.Item.Cells[0].Text.Split(new string[] { "Color" }, StringSplitOptions.None)[0];
        }
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
            this.rblTime.SelectedValue = base._Site.SiteOptions["Opt_FloatNotifiesTime"].Value.ToString();
            this.lbAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
            this.rblTime.Visible = this.lbAdd.Visible;
            this.g.Columns[5].Visible = this.lbAdd.Visible;
        }
    }

    protected void rblTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        base._Site.SiteOptions["Opt_FloatNotifiesTime"] = new OptionValue(this.rblTime.SelectedValue);
    }


}

