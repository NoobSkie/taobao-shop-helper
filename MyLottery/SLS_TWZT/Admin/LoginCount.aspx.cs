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

public partial class Admin_LoginCount : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataSet ds = null;
        if (Procedures.P_GetLoginCount(ref ds, _Convert.StrToInt(this.ddlYear.SelectedValue, 0), _Convert.StrToInt(this.ddlMonth.SelectedValue, 0)) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else if ((ds == null) || (ds.Tables.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_LoginCount");
        }
        else
        {
            PF.DataGridBindData(this.g, ds.Tables[0], this.gPager);
        }
    }

    private void BindDataForYearMonth()
    {
        this.ddlYear.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year < 0x7d8)
        {
            this.btnGO.Enabled = false;
        }
        else
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear.SelectedIndex = this.ddlYear.Items.Count - 1;
            this.ddlMonth.SelectedIndex = month - 1;
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            for (int i = 4; i <= 0x24; i++)
            {
                if (_Convert.StrToInt(e.Item.Cells[i].Text, 0) == 0)
                {
                    e.Item.Cells[i].Text = "";
                }
            }
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Log" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForYearMonth();
            this.BindData();
        }
    }

}

