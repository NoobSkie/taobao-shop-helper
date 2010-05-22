using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Users : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        DataTable dt = null;
        string commandText = "";
        if (Shove._Web.Cache.GetCache("FirstQuery_" + base._User.ID) != null)
        {
            if (Shove._Web.Cache.GetCache("FirstQuery_" + base._User.ID).ToString() == "1")
            {
                commandText = "select * from V_Users where (CONVERT(datetime,RegisterTime) between DATEADD(DD,-(DatePart(D,GETDATE())),GETDATE()) and GETDATE()) AND SiteID = @SiteID order by RegisterTime desc";
                dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
            }
            else if (Shove._Web.Cache.GetCache("FirstQuery_" + base._User.ID).ToString() == "2")
            {
                if ((this.tbBeginTime.Text.Trim() == "") && (this.tbEndTime.Text.Trim() == ""))
                {
                    commandText = "select * from V_Users where SiteID = @SiteID order by RegisterTime desc";
                    dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
                }
                else
                {
                    commandText = "select * from V_Users where (CONVERT(datetime,RegisterTime) between @StartDate and @EndDate or CONVERT(datetime,RegisterTime) = @EndDate) and SiteID = @SiteID order by RegisterTime desc";
                    DateTime time2 = _Convert.StrToDateTime(Utility.FilteSqlInfusion(this.tbBeginTime.Text), DateTime.Now.ToString("yyyy-MM-dd"));
                    DateTime time5 = _Convert.StrToDateTime(Utility.FilteSqlInfusion(this.tbEndTime.Text), DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1.0);
                    dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("StartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, time2), new MSSQL.Parameter("EndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, time5), new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
                }
            }
            else if (Shove._Web.Cache.GetCache("FirstQuery_" + base._User.ID).ToString() == "3")
            {
                if ((this.tbBeginTime.Text.Trim() == "") || (this.tbEndTime.Text.Trim() == ""))
                {
                    commandText = "select * from V_Users Users where not exists ( select UserID from T_UserPayDetails PayDetails where Users.ID=PayDetails.UserID and Result = 1 ) and SiteID = @SiteID order by RegisterTime desc";
                    dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
                }
                else
                {
                    commandText = "select * from V_Users Users where not exists ( select UserID from T_UserPayDetails PayDetails where Users.ID=PayDetails.UserID and Result = 1 ) and SiteID = @SiteID and (CONVERT(datetime,RegisterTime) between @StartDate and @EndDate) order by RegisterTime desc";
                    DateTime time7 = _Convert.StrToDateTime(Utility.FilteSqlInfusion(this.tbBeginTime.Text), DateTime.Now.ToString("yyyy-MM-dd"));
                    DateTime time10 = _Convert.StrToDateTime(Utility.FilteSqlInfusion(this.tbEndTime.Text), DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1.0);
                    dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID), new MSSQL.Parameter("StartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, time7), new MSSQL.Parameter("EndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, time10) });
                }
            }
            else
            {
                commandText = "select * from V_Users where SiteID = @SiteID order by RegisterTime desc";
                dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
            }
        }
        else
        {
            commandText = "select * from V_Users where SiteID = @SiteID order by RegisterTime desc";
            dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
        }
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_Users");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.btnSearch.Enabled = dt.Rows.Count > 0;
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DataTable table = new Tables.T_Users().Open("", "", "[ID]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            string str = "T_Users.xls";
            HttpResponse response = this.Page.Response;
            response.AppendHeader("Content-Disposition", "attachment;filename=" + str);
            base.Response.ContentType = "application/ms-excel";
            response.ContentEncoding = Encoding.GetEncoding("gb2312");
            foreach (DataColumn column in table.Columns)
            {
                response.Write(column.ColumnName + "\t");
            }
            response.Write("\n");
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    response.Write(row[i].ToString() + "\t");
                }
                response.Write("\n");
            }
            response.End();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.tbUserName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入用户名称");
        }
        else
        {
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户不存在");
            }
            else
            {
                base.Response.Redirect("UserDetail.aspx?SiteID=" + base._Site.ID.ToString() + "&ID=" + users.ID.ToString(), true);
            }
        }
    }

    protected void btnSearchByRegDate_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.SetCache("FirstQuery_" + base._User.ID, "2");
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (!DateTime.TryParse(this.tbBeginTime.Text, out now) && !DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
                return;
            }
        }
        this.BindData();
    }

    protected void btnSearchNoPay_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.SetCache("FirstQuery_" + base._User.ID, "3");
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (!DateTime.TryParse(this.tbBeginTime.Text, out now) && !DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
                return;
            }
        }
        this.BindData();
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.ClearCache("FirstQuery_" + base._User.ID);
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = "<a href='UserDetail.aspx?SiteID=" + e.Item.Cells[0x1a].Text + "&ID=" + e.Item.Cells[0x18].Text + "'>" + e.Item.Cells[0].Text + "</a>";
            CheckBox box = (CheckBox)e.Item.Cells[0x11].FindControl("cbisCanLogin");
            box.Checked = _Convert.StrToBool(e.Item.Cells[0x19].Text, true);
            CheckBox box2 = (CheckBox)e.Item.Cells[4].FindControl("cbisEmailValided");
            if (box2 != null)
            {
                box2.Checked = _Convert.StrToBool(e.Item.Cells[0x1b].Text, false);
            }
            CheckBox box3 = (CheckBox)e.Item.Cells[6].FindControl("cbisMobileValided");
            if (box3 != null)
            {
                box3.Checked = _Convert.StrToBool(e.Item.Cells[0x1c].Text, false);
            }
            e.Item.Cells[0x15].Text = (e.Item.Cells[0x15].Text.Trim() == "2") ? "<font color='red'>高级</font>" : ((e.Item.Cells[0x15].Text.Trim() == "3") ? "<font color='blue'>VIP</font>" : "普通");
            double num = _Convert.StrToDouble(e.Item.Cells[10].Text, 0.0);
            e.Item.Cells[10].Text = num.ToString("N");
            e.Item.Cells[11].Text = _Convert.StrToDouble(e.Item.Cells[11].Text, 0.0).ToString("N");
        }
    }

    private void GetCompetence()
    {
        DataTable table = MSSQL.Select("select * from T_UserInGroups  where GroupID =1 and UserID=" + base._User.ID + " ", new MSSQL.Parameter[0]);
        if ((table != null) && (table.Rows.Count > 0))
        {
            this.btnDownload.Visible = true;
            this.btnSelect.Visible = true;
        }
        else
        {
            this.btnDownload.Visible = false;
            this.btnSelect.Visible = false;
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
            Shove._Web.Cache.SetCache("FirstQuery_" + base._User.ID, "1");
            DateTime now = DateTime.Now;
            this.tbBeginTime.Text = now.AddDays((double)-(now.Day - 1)).ToString("yyyy-MM-dd");
            this.tbEndTime.Text = now.ToString("yyyy-MM-dd");
            this.BindData();
            this.GetCompetence();
        }
    }
}

