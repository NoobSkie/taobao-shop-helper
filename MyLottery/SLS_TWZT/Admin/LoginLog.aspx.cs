using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_LoginLog : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        string str = "select * from V_SystemLog where SiteID = " + base._Site.ID.ToString();
        int num = _Convert.StrToInt(this.ddlTime.SelectedValue, -1);
        if (num > 0)
        {
            str = str + " and Datediff(day, [DateTime], GetDate()) <= " + num.ToString();
        }
        if (this.tbUserName.Text.Trim() != "")
        {
            str = str + " and [Name] = '" + Utility.FilteSqlInfusion(this.tbUserName.Text.Trim()) + "'";
        }
        DataTable dt = MSSQL.Select(str + " order by [DateTime]", new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_LoginLog");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.btnClear.Enabled = dt.Rows.Count > 0;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        string commandText = "delete from T_SystemLog where SiteID = " + base._Site.ID.ToString();
        int num = _Convert.StrToInt(this.ddlTime.SelectedValue, -1);
        if (num > 0)
        {
            commandText = commandText + " and Datediff(day, DateTime, GetDate()) <= " + num.ToString();
        }
        if (this.tbUserName.Text.Trim() != "")
        {
            string str2 = commandText;
            commandText = str2 + " and dbo.F_GetUserIDByName(" + base._Site.ID.ToString() + ", Name) = '" + Utility.FilteSqlInfusion(this.tbUserName.Text.Trim()) + "'";
        }
        if (MSSQL.ExecuteNonQuery(commandText, new MSSQL.Parameter[0]) < 0)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_LoginLog");
        }
        else
        {
            this.BindData();
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            if (e.Item.Cells[7].Text == "0")
            {
                e.Item.Cells[7].Text = "正常登录";
            }
            else if (e.Item.Cells[7].Text == "1")
            {
                e.Item.Cells[7].Text = "<font color='red'>密码错误</font>";
            }
            else if (e.Item.Cells[7].Text == "2")
            {
                e.Item.Cells[7].Text = "<font color='blue'>冻结登录</font>";
            }
            else if (e.Item.Cells[7].Text == "3")
            {
                e.Item.Cells[7].Text = "取回密码";
            }
            else if (e.Item.Cells[7].Text == "4")
            {
                e.Item.Cells[7].Text = "清除日志";
            }
            else
            {
                e.Item.Cells[7].Text = "其它";
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Log", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnClear.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Log" }));
        }
    }


}

