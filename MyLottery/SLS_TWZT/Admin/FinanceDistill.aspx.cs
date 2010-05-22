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

public partial class Admin_FinanceDistill : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlYear.Items.Count != 0)
        {
            DataTable table;
            long num = _Convert.StrToLong(this.tbID.Text, -1L);
            if (this.tbID.Text == "-1")
            {
                table = new Views.V_UserDistills().Open("", "SiteID = " + base._Site.ID.ToString() + " and year([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlYear.SelectedValue) + " and month([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlMonth.SelectedValue), "[DateTime] desc");
            }
            else
            {
                table = new Views.V_UserDistills().Open("", "SiteID = " + base._Site.ID.ToString() + " and UserID = " + num.ToString() + " and year([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlYear.SelectedValue) + " and month([DateTime]) = " + Utility.FilteSqlInfusion(this.ddlMonth.SelectedValue), "[DateTime] desc");
            }
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceDistill");
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
            switch (_Convert.StrToShort(e.Item.Cells[6].Text, -100))
            {
                case 0:
                    e.Item.Cells[6].Text = "<font color='Blue'>申请中</font>";
                    break;

                case -1:
                    e.Item.Cells[6].Text = "<font color='Blue'>已拒绝</font>";
                    break;

                case -2:
                    e.Item.Cells[6].Text = "<font color='Blue'>用户撤销提款</font>";
                    break;

                case 1:
                    e.Item.Cells[6].Text = "<font color='Blue'>付款成功</font>";
                    break;

                case 10:
                    e.Item.Cells[6].Text = "<font color='Blue'>已接受提款</font>";
                    break;

                case 11:
                    e.Item.Cells[6].Text = "<font color='Blue'>支付宝处理中</font>";
                    break;

                case 12:
                    e.Item.Cells[6].Text = "<font color='Blue'>支付宝付款失败</font>";
                    break;
            }
            e.Item.Cells[1].Text = "<a href='UserDetail.aspx?SiteID=1&ID=" + e.Item.Cells[11].Text + "'>" + e.Item.Cells[1].Text + "</a>";
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/FinanceDistill.aspx";
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

