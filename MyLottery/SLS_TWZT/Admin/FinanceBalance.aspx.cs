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

public partial class Admin_FinanceBalance : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlYear.Items.Count != 0)
        {
            int returnValue = -1;
            string returnDescription = "";
            DataSet ds = null;
            if (Procedures.P_GetAccount(ref ds, base._Site.ID, int.Parse(this.ddlYear.SelectedValue), int.Parse(this.ddlMonth.SelectedValue), ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceAddMoney");
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, "Admin_FinanceAddMoney");
            }
            else
            {
                PF.DataGridBindData(this.g, ds.Tables[0], this.gPager);
            }
        }
    }

    private void BindDataForYearMonth()
    {
        this.ddlYear.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year >= 0x7d8)
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear.SelectedIndex = this.ddlYear.Items.Count - 1;
            this.ddlMonth.SelectedIndex = month - 1;
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            for (int i = 3; i <= 9; i++)
            {
                double num2 = _Convert.StrToDouble(e.Item.Cells[i].Text, 0.0);
                e.Item.Cells[i].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
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
            this.BindDataForYearMonth();
            this.BindData();
        }
    }


}

