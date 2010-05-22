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

public partial class Admin_UserAccountDetail : AdminPageBase, IRequiresSessionState
{

    private DataSet ds;
    private void BinDataForDay()
    {
        this.ddlDay.Items.Clear();
        int[] numArray = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        DateTime now = DateTime.Now;
        int year = now.Year;
        int day = now.Day;
        int num3 = int.Parse(this.ddlMonth.SelectedValue);
        int num4 = 0;
        foreach (int num6 in numArray)
        {
            if (num3 == num6)
            {
                num4 = 0x1f;
                break;
            }
            if (num3 == 2)
            {
                if ((((year % 4) == 0) && ((year % 100) != 0)) && ((year % 400) == 0))
                {
                    num4 = 0x1d;
                }
                else
                {
                    num4 = 0x1c;
                }
                break;
            }
            num4 = 30;
        }
        for (int i = 1; i <= num4; i++)
        {
            this.ddlDay.Items.Add(new ListItem(i.ToString() + "日", i.ToString()));
        }
        if (day > num4)
        {
            day = num4;
        }
        this.ddlDay.SelectedIndex = day - 1;
    }

    private void BindData()
    {
        if (this.ddlYear.Items.Count != 0)
        {
            if (this.tbID.Text == "")
            {
                this.tbID.Text = Utility.GetRequest("id");
                if (this.tbID.Text == "")
                {
                    return;
                }
            }
            long userID = _Convert.StrToLong(this.tbID.Text, -1L);
            if (userID < 0L)
            {
                PF.GoError(1, "参数错误", "Admin_UserAccountDetail");
            }
            else
            {
                if (this.tbUserName.Text.Trim() == "")
                {
                    Users users = new Users(base._Site.ID)[base._Site.ID, userID];
                    if (users == null)
                    {
                        JavaScript.Alert(this.Page, "用户名不存在。");
                        return;
                    }
                    this.tbUserName.Text = users.Name;
                }
                int returnValue = -1;
                string returnDescription = "";
                if (Procedures.P_GetUserAccountDetail(ref this.ds, base._Site.ID, userID, int.Parse(this.ddlYear.SelectedValue), int.Parse(this.ddlMonth.SelectedValue), int.Parse(this.ddlDay.SelectedValue), ref returnValue, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                }
                else if ((this.ds == null) || (this.ds.Tables.Count < 1))
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_UserAccountDetail");
                }
                else
                {
                    PF.DataGridBindData(this.g, this.ds.Tables[0], this.gPager);
                }
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
        if (this.tbUserName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入用户名。");
        }
        else
        {
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户名不存在。");
            }
            else
            {
                this.tbID.Text = users.ID.ToString();
                this.BindData();
            }
        }
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BinDataForDay();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble((e.Item.Cells[2].FindControl("lblIn") as Label).Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble((e.Item.Cells[3].FindControl("Label2") as Label).Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble((e.Item.Cells[4].FindControl("Label3") as Label).Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble((e.Item.Cells[5].FindControl("Label4") as Label).Text, 0.0);
            e.Item.Cells[5].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble((e.Item.Cells[6].FindControl("Label5") as Label).Text, 0.0);
            e.Item.Cells[6].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble((e.Item.Cells[7].FindControl("Label6") as Label).Text, 0.0);
            e.Item.Cells[7].Text = (num == 0.0) ? "" : num.ToString("N");
            long num2 = _Convert.StrToLong((e.Item.Cells[8].FindControl("Label7") as Label).Text, -1L);
            if (num2 >= 0L)
            {
                (e.Item.Cells[1].FindControl("lblMemo") as Label).Text = "<a href='../Home/Room/Scheme.aspx?id=" + num2.ToString() + "' target='_blank'><font color=\"#330099\">" + (e.Item.Cells[1].FindControl("lblMemo") as Label).Text + "</Font></a>";
            }
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            e.Item.Cells[0].ColumnSpan = 2;
            e.Item.Cells.RemoveAt(8);
            e.Item.Cells[0].Text = "合计";
            e.Item.Cells[1].Text = PF.GetSumByColumn(this.ds.Tables[0], 3, false, 30, this.gPager.PageIndex).ToString("N");
            e.Item.Cells[2].Text = PF.GetSumByColumn(this.ds.Tables[0], 4, false, 30, this.gPager.PageIndex).ToString("N");
            e.Item.Cells[3].Text = PF.GetSumByColumn(this.ds.Tables[0], 5, false, 30, this.gPager.PageIndex).ToString("N");
            e.Item.Cells[5].Text = PF.GetSumByColumn(this.ds.Tables[0], 7, false, 30, this.gPager.PageIndex).ToString("N");
            e.Item.Cells[7].Visible = false;
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
            this.BinDataForDay();
            this.BindData();
        }
    }

 
}

