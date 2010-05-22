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

public partial class Admin_FinanceWin : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlYear.Items.Count != 0)
        {
            DataTable table;
            long num = _Convert.StrToLong(this.tbID.Text, -1L);
            if (this.tbID.Text == "-1")
            {
                table = new Views.V_UserDetails().Open("", "SiteID = " + base._Site.ID.ToString() + " and OperatorType = dbo.F_GetDetailsOperatorType('中奖') and year([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlYear.SelectedValue) + " and month([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlMonth.SelectedValue), "[DateTime] desc");
            }
            else
            {
                table = new Views.V_UserDetails().Open("", "SiteID = " + base._Site.ID.ToString() + " and UserID = " + num.ToString() + " and OperatorType = dbo.F_GetDetailsOperatorType('中奖') and year([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlYear.SelectedValue) + " and month([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlMonth.SelectedValue), "[DateTime] desc");
            }
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceWin");
            }
            else
            {
                PF.DataGridBindData(this.g, table, this.gPager);
            }
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
            this.btnRead.Enabled = false;
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

    protected void btnRead_Click(object sender, EventArgs e)
    {
        if (this.tbUserName.Text.Trim() != "")
        {
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户名不存在。");
                return;
            }
            this.tbID.Text = users.ID.ToString();
        }
        else
        {
            this.tbID.Text = "-1";
        }
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.Cells[0].Text = "<a href='UserDetail.aspx?SiteID=" + e.Item.Cells[5].Text + "&ID=" + e.Item.Cells[4].Text + "'>" + e.Item.Cells[0].Text + "</a>";
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
            this.tbID.Text = Utility.GetRequest("id");
            if (this.tbID.Text == "")
            {
                this.tbID.Text = "-1";
            }
            this.BindDataForYearMonth();
            this.BindData();
        }
    }
}

